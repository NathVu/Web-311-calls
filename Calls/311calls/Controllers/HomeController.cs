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
        public async Task<ActionResult> Index()
        {
            var model = new HomeViewModel();
            Json311 json = new Json311();
            model.JsonData = json.GetFullDataset(0, 500);
            return await Task.FromResult(View(model));
        }

        [HttpPost]
        public async Task<ActionResult> ChangeSet(int floor, int ceil, int max, bool isActiveSearch, string searchString)
        {
            ActionResult actionResult = null;
            Json311 dataHandler = null;
            HomeViewModel model = new HomeViewModel()
            {
                CurrentCeil = ceil,
                CurrentFloor = floor,
                CurrentMax = max,
                ActiveSearch = isActiveSearch,
                CurrentSearch = searchString
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
                        }
                        else
                        {
                            end = DateTime.Parse(search[1]);

                        }
                    }
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
