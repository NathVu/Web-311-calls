#pragma checksum "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "721d3421bce00de474382a6841f92696de66a2d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\_ViewImports.cshtml"
using _311calls;

#line default
#line hidden
#line 2 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\_ViewImports.cshtml"
using _311calls.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"721d3421bce00de474382a6841f92696de66a2d2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"307fc3607bfcac15088ede57e22e6418f1618d29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(67, 35, true);
            WriteLiteral("<div id=\"CallsTableControls\">\r\n    ");
            EndContext();
            BeginContext(103, 4, false);
#line 6 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
Write(Html);

#line default
#line hidden
            EndContext();
            BeginContext(107, 3475, true);
            WriteLiteral(@"
</div>
<div id=""Data"">
    <table id=""311CallsTable"" class=""table-bordered"">
        <thead>
            <tr>
                <th class=""col-2"">
                    Unique Key
                </th>
                <th class=""col-2"">
                    Created Date
                </th>
                <th class=""col-2"">
                    Closed Date
                </th>
                <th class=""col-2"">
                    Agency Name
                </th>
                <th class=""col-2"">
                    Complaint Type
                </th>
                <th class=""col-6"">
                    Descriptor
                </th>
                <th class=""col-2"">
                    Location Type
                </th>
                <th class=""col-1"">
                    Incident Zip
                </th>
                <th class=""col-4"">
                    Incident Address
                </th>
                <th class=""col-2"">
                    Street Name
");
            WriteLiteral(@"                </th>
                <th class=""col-2"">
                    Cross St 1
                </th>
                <th class=""col-2"">
                    Cross St 2
                </th>
                <th class=""col-2"">
                    Intersection street 1
                </th>
                <th class=""col-2"">
                    Intersection street 2
                </th>
                <th class=""col-2"">
                    Address type
                </th>
                <th class=""col-2"">
                    City
                </th>
                <th class=""col-2"">
                    Landmark
                </th>
                <th class=""col-3"">
                    Facility type
                </th>
                <th class=""col-6"">
                    Status
                </th>
                <th class=""col-10"">
                    Resolution description
                </th>
                <th class=""col-2"">
                    Communi");
            WriteLiteral(@"ty board
                </th>
                <th class=""col-2"">
                    Borough
                </th>
                <th class=""col-2"">
                    Park facility name
                </th>
                <th class=""col-2"">
                    Park borough
                </th>
                <th class=""col-2"">
                    Vehicle type
                </th>
                <th class=""col-2"">
                    Taxi company borough
                </th>
                <th class=""col-2"">
                    Taxi pick up location
                </th>
                <th class=""col-2"">
                    Bridge highway name
                </th>
                <th class=""col-2"">
                    Bridge highway direction
                </th>
                <th class=""col-2"">
                    Road ramp
                </th>
                <th class=""col-2"">
                    Bridge highway segment
                </th>
                <");
            WriteLiteral(@"th class=""col-2"">
                    Latitude
                </th>
                <th class=""col-2"">
                    Longitude
                </th>
                <th class=""col-2"">
                    Location city
                </th>
                <th class=""col-2"">
                    Location zip
                </th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 120 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
             foreach (var option in Model.JsonData)
            {

#line default
#line hidden
            BeginContext(3650, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3724, 17, false);
#line 124 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Unique_key);

#line default
#line hidden
            EndContext();
            BeginContext(3742, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3823, 19, false);
#line 127 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Created_date);

#line default
#line hidden
            EndContext();
            BeginContext(3843, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3924, 18, false);
#line 130 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Closed_date);

#line default
#line hidden
            EndContext();
            BeginContext(3943, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4024, 18, false);
#line 133 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Agency_name);

#line default
#line hidden
            EndContext();
            BeginContext(4043, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4124, 21, false);
#line 136 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Complaint_type);

#line default
#line hidden
            EndContext();
            BeginContext(4146, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4227, 17, false);
#line 139 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Descriptor);

#line default
#line hidden
            EndContext();
            BeginContext(4245, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4326, 20, false);
#line 142 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Location_type);

#line default
#line hidden
            EndContext();
            BeginContext(4347, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4428, 19, false);
#line 145 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Incident_zip);

#line default
#line hidden
            EndContext();
            BeginContext(4448, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4529, 23, false);
#line 148 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Incident_address);

#line default
#line hidden
            EndContext();
            BeginContext(4553, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4634, 18, false);
#line 151 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Street_name);

#line default
#line hidden
            EndContext();
            BeginContext(4653, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4734, 21, false);
#line 154 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Cross_street_1);

#line default
#line hidden
            EndContext();
            BeginContext(4756, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4837, 21, false);
#line 157 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Cross_street_2);

#line default
#line hidden
            EndContext();
            BeginContext(4859, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4940, 28, false);
#line 160 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Intersection_street_1);

#line default
#line hidden
            EndContext();
            BeginContext(4969, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5050, 28, false);
#line 163 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Intersection_street_2);

#line default
#line hidden
            EndContext();
            BeginContext(5079, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5160, 19, false);
#line 166 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Address_type);

#line default
#line hidden
            EndContext();
            BeginContext(5180, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5261, 11, false);
#line 169 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.City);

#line default
#line hidden
            EndContext();
            BeginContext(5273, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5354, 15, false);
#line 172 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Landmark);

#line default
#line hidden
            EndContext();
            BeginContext(5370, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5451, 20, false);
#line 175 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Facility_type);

#line default
#line hidden
            EndContext();
            BeginContext(5472, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5553, 13, false);
#line 178 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Status);

#line default
#line hidden
            EndContext();
            BeginContext(5567, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5648, 29, false);
#line 181 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Resolution_description);

#line default
#line hidden
            EndContext();
            BeginContext(5678, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5759, 22, false);
#line 184 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Community_board);

#line default
#line hidden
            EndContext();
            BeginContext(5782, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5863, 14, false);
#line 187 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Borough);

#line default
#line hidden
            EndContext();
            BeginContext(5878, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5959, 25, false);
#line 190 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Park_facility_name);

#line default
#line hidden
            EndContext();
            BeginContext(5985, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6066, 19, false);
#line 193 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Park_borough);

#line default
#line hidden
            EndContext();
            BeginContext(6086, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6167, 19, false);
#line 196 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Vehicle_type);

#line default
#line hidden
            EndContext();
            BeginContext(6187, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6268, 27, false);
#line 199 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Taxi_company_borough);

#line default
#line hidden
            EndContext();
            BeginContext(6296, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6377, 28, false);
#line 202 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Taxi_pick_up_location);

#line default
#line hidden
            EndContext();
            BeginContext(6406, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6487, 26, false);
#line 205 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Bridge_highway_name);

#line default
#line hidden
            EndContext();
            BeginContext(6514, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6595, 31, false);
#line 208 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Bridge_highway_direction);

#line default
#line hidden
            EndContext();
            BeginContext(6627, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6708, 16, false);
#line 211 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Road_ramp);

#line default
#line hidden
            EndContext();
            BeginContext(6725, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6806, 29, false);
#line 214 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Bridge_highway_segment);

#line default
#line hidden
            EndContext();
            BeginContext(6836, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6917, 15, false);
#line 217 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Latitude);

#line default
#line hidden
            EndContext();
            BeginContext(6933, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(7014, 16, false);
#line 220 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Longitude);

#line default
#line hidden
            EndContext();
            BeginContext(7031, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(7112, 20, false);
#line 223 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Location_city);

#line default
#line hidden
            EndContext();
            BeginContext(7133, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(7214, 19, false);
#line 226 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
                    Write(option.Location_zip);

#line default
#line hidden
            EndContext();
            BeginContext(7234, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 229 "C:\Users\natha\OneDrive\Documents\GitHub\Web-311-calls\Calls\311calls\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(7301, 1115, true);
            WriteLiteral(@"        </tbody>
    </table>
</div>

<script>
    $(document).ready(function () {
        $('#311CallsTable').after('<div id=""Data""></div>');
        var rowsShown = 20;
        var rowsTotal = $('#311CallsTable tbody tr').length;
        var numPages = rowsTotal / rowsShown;
        for (i = 0; i < numPages; i++) {
            var pageNum = i + 1;
            $('#Data').append('<a href=""#"" rel=""' + i + '"">' + pageNum + '</a> ');
        }
        $('#311CallsTable tbody tr').hide();
        $('#311CallsTable tbody tr').slice(0, rowsShown).show();
        $('#Data a:first').addClass('active');
        $('#Data a').bind('click', function () {

            $('#Data a').removeClass('active');
            $(this).addClass('active');
            var currPage = $(this).attr('rel');
            var startItem = currPage * rowsShown;
            var endItem = startItem + rowsShown;
            $('#311CallsTable tbody tr').css('opacity', '0.0').hide().slice(startItem, endItem).
               ");
            WriteLiteral(" css(\'display\', \'table-row\').animate({ opacity: 1 }, 300);\r\n        });\r\n    });\r\n</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
