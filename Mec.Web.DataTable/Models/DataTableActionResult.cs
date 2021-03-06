#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> DataTableActionResult.cs </Name>
//         <Created> 24/03/2018 2:10:36 PM </Created>
//         <Key> a9ff8188-eba0-43fd-b4c9-c3c460a44622 </Key>
//     </File>
//     <Summary>
//         DataTableActionResult.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Models.Request;
using Mec.Web.DataTable.Models.Response;
using Mec.Web.DataTable.Utils.DataTableActionResultUtils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mec.Web.DataTable.Models
{
    public abstract class DataTableActionResult : IActionResult
    {
        public abstract Task ExecuteResultAsync(ActionContext context);

        /// <typeparam name="T"></typeparam>
        /// <param name="request">  </param>
        /// <param name="response"> 
        ///     The properties of this can be marked up with [DataTablesAttribute] to control sorting/searchability/visibility
        /// </param>
        /// <param name="transform">
        ///     // a transform for custom column rendering e.g. to do a custom date row =&gt; new {
        ///     CreatedDate = row.CreatedDate.ToString("dd MM yy") }
        /// </param>
        /// <returns></returns>
        protected DataTableActionResult<T> Create<T>(DataTableRequestModel request, DataTableResponseModel<T> response,
            Func<T, object> transform) where T : class, new()
        {
            return DataTableActionResultHelper.Create(request, response, transform);
        }

        /// <typeparam name="T"></typeparam>
        /// <param name="request"> </param>
        /// <param name="response">
        ///     The properties of this can be marked up with [DataTablesAttribute] to control sorting/searchability/visibility
        /// </param>
        /// <returns></returns>
        protected DataTableActionResult<T> Create<T>(DataTableRequestModel request, DataTableResponseModel<T> response)
            where T : class, new()
        {
            return DataTableActionResultHelper.Create(request, response);
        }
    }
}