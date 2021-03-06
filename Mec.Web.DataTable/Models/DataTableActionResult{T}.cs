#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> DataTableActionResult_T_.cs </Name>
//         <Created> 24/03/2018 2:10:51 PM </Created>
//         <Key> 0ddfacd1-381b-41bc-ba45-fbfbd858dd38 </Key>
//     </File>
//     <Summary>
//         DataTableActionResult_T_.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Models.Request;
using Mec.Web.DataTable.Models.Response;
using Mec.Web.DataTable.Processing.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mec.Web.DataTable.Models
{
    public class DataTableActionResult<T> : DataTableActionResult where T : class, new()
    {
        public DataTableActionResult(IQueryable<T> queryable, DataTableRequestModel requestModel)
        {
            Data = queryable.GetDataTableResponse(requestModel);
        }

        public DataTableActionResult(DataTableResponseModel<T> data)
        {
            Data = data;
        }

        public DataTableResponseModel<T> Data { get; set; }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var response = context.HttpContext.Response;

            return response.WriteAsync(JsonConvert.SerializeObject(Data));
        }
    }
}