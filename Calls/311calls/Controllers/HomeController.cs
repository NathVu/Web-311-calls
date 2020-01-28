using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _311calls.Models;
using CallsData;
using Npgsql;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace _311calls.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(HomeViewModel model)
        {
            Json311 json = new Json311();
            ActionResult actionResult = null;
             if (model.StartDate.HasValue)
            {
                model.rowHandler = new RowHandler()
                {
                    Curr_min = model.CurrentFloor,
                    Curr_max = model.CurrentCeil,
                    total = model.CurrentMax
                };
                try
                {
                    DateTime? start, end;
                    start = model.StartDate;
                    if (model.EndDate.HasValue)
                    {
                        end = model.EndDate.Value;
                    }
                    else
                    {
                        end = DateTime.Now;
                    }
                    int offset = 0;
                    if (model.NextSet)
                    {
                        offset = model.CurrentCeil;
                    }
                    else if (model.PreviousSet)
                    {
                        if ((offset - 500) < 0)
                        {
                            offset = 0;
                        }
                        else
                        {
                            offset -= 500;
                        }
                    }
                    if (offset > model.CurrentMax)
                    {
                        offset = 0;
                    }

                    model.JsonData = json.GetDateFilteredList(500, offset, start.Value, end.Value);
                    model.CurrentFloor = offset;
                    model.StartDate = start;
                    model.EndDate = end;
                    model.CurrentCeil = model.CurrentFloor + model.JsonData.Count();
                    model.CurrentMax = json.GetCount(start.Value, end.Value);

                    actionResult = View(model);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                model.JsonData = json.GetFullDataset(0, 500);
                model.CurrentFloor = 0;
                model.CurrentCeil = model.JsonData.Count();
                model.CurrentMax = json.GetCount();
                model.ChangeUp = 500;
                model.ChangeDown = -500;
                model.ActiveSearch = false;
                actionResult = View(model);
            }

            return await Task.FromResult(actionResult);
        }

        public async Task<ActionResult> ChangeSetWithoutFilter(int floor, int ceil, int max, int change)
        {
            ActionResult actionResult = null;
            Json311 dataHandler = null;
            HomeViewModel model = new HomeViewModel()
            {
                rowHandler = new RowHandler()
                {
                    Curr_min = floor,
                    Curr_max = ceil,
                    total = max
                }
            };
            try
            {
                dataHandler = new Json311();
                if (change > 0)
                {
                    model.rowHandler.UpdateValuesUp();
                }
                else
                {
                    model.rowHandler.UpdateValuesDown();
                }
                model.JsonData = dataHandler.GetFullDataset(model.rowHandler.Curr_min, model.rowHandler.Curr_max);
                model.CurrentFloor = model.rowHandler.Curr_min;
                model.CurrentCeil = model.rowHandler.Curr_max;
                model.CurrentMax = max;
                model.ChangeDown = -500;
                model.ChangeUp = 500;
                model.ActiveSearch = false;
                actionResult = View("Index", model);
            }
            catch (Exception ex)
            {
                actionResult = Json(new { Reroute = false, error = $"Error retrieving new DataSet: {ex.GetType()}" });
            }
            return await Task.FromResult(actionResult);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeSet(int floor, int ceil, int max, bool isActiveSearch, string searchString, int requestedChange)
        {
            ActionResult actionResult = null;
            Json311 dataHandler = null;
            HomeViewModel model = new HomeViewModel()
            {
                rowHandler = new RowHandler()
                {
                    Curr_min = floor,
                    Curr_max = ceil,
                    total = max
                }
            };
            try
            {
                dataHandler = new Json311();
                if (isActiveSearch)
                {
                    string[] search;
                    DateTime? start, end;
                    string agency = null;
                    if (searchString.Contains("-"))
                    {
                        search = searchString.Split('-');
                        start = DateTime.Parse(search[0]);
                        if (search[1].Contains("|"))
                        {
                            search = search[1].Split('|');
                            end = DateTime.Parse(search[0]);
                            agency = search[1];
                            //Create date + agency search
                        }
                        else
                        {
                            if (requestedChange > 0)
                            {
                                model.rowHandler.UpdateValuesUp();
                            }
                            else
                            {
                                model.rowHandler.UpdateValuesDown();
                            }
                            end = DateTime.Parse(search[1]);
                            model.JsonData = dataHandler.GetDateFilteredList(model.rowHandler.Curr_min, model.rowHandler.Curr_max, start.Value, end.Value);
                        }

                    }
                }
                else
                {
                    return await ChangeSetWithoutFilter(floor, ceil, max, requestedChange);
                }
            }
            catch (Exception ex)
            {
                actionResult = Json(new { Reroute = false, error = $"Error retrieving new DataSet: {ex.GetType()}" });
            }
            return await Task.FromResult(actionResult);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
