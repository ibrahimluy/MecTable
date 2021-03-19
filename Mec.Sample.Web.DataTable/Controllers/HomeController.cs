using Mec.Sample.Web.DataTable.Models;
using Mec.Web.DataTable.Models;
using Mec.Web.DataTable.Models.Request;
using Mec.Web.DataTable.Models.Response;
using Mec.Web.DataTable.Processing.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mec.Sample.Web.DataTable.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<UserViewModel> DummyUsers = GetDummyUsers();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }


        public IActionResult Test()
        {
            return Ok("Test");
        }

        /// <summary>
        ///     Get Users DataTable 
        /// </summary>
        /// <returns></returns>
        [Route("datatable")]
        [HttpPost]
        public DataTableActionResult<UserViewModel> GetDataTable([FromForm] DataTableRequestModel model)
        {
            // 1. In Service Layer
            DataTableResponseModel<UserViewModel> response = GetDataTableResponse(model);

            // 2. In Controller
            var result = response.GetDataTableActionResult(model, x => new
            {
                IsActive = x.IsActive ? "Yes" : "No" // Transform Data before Response
            });

            return result;
        }

        private static DataTableResponseModel<UserViewModel> GetDataTableResponse(DataTableRequestModel model)
        {
            // Queryable Data
            var query = DummyUsers.AsQueryable();

            // Generate DataTable Response
            var result = query.GetDataTableResponse(model);

            return result;
        }

        private static List<UserViewModel> GetDummyUsers()
        {
            var users = new List<UserViewModel>();

            for (int i = 0; i < 1000; i++)
            {
                users.Add(new UserViewModel
                {
                    Id = i + 1,
                    FullName = $"User {i + 1}",
                    CreatedTime = DateTimeOffset.Now,
                    IsActive = i % 2 == 0
                });
            }

            return users;
        }
    }
}
