#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> IQueryableExtensions.cs </Name>
//         <Created> 23/03/2018 5:43:49 PM </Created>
//         <Key> 32a7cb87-f826-4ee8-9da0-28ee3e8fd319 </Key>
//     </File>
//     <Summary>
//         IQueryableExtensions.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Models;
using Mec.Web.DataTable.Models.Request;
using Mec.Web.DataTable.Models.Response;
using System.Linq;
using Mec.Web.DataTable.Utils.DataTableRequestModelUtils;

namespace Mec.Web.DataTable.Processing.Response
{
    public static class IQueryableExtensions
    {
        public static DataTableResponseModel<T> GetDataTableResponse<T>(this IQueryable<T> data,
            DataTableRequestModel dataTableRequestModel) where T : class, new()
        {
            // Count or LongCount is very annoying cause an extra evaluation.

            var totalRecords = data.Count();

            var filters = new DataTableRequestHelper();

            var outputProperties = new DataTableTypeInfoModel<T>().Properties;

            var filteredData = filters.ApplyFiltersAndSort(dataTableRequestModel, data, outputProperties);

            var totalDisplayRecords = filteredData.Count();

            var skipped = filteredData.Skip(dataTableRequestModel.DisplayStart);

            var page = (dataTableRequestModel.DisplayLength <= 0
                ? skipped
                : skipped.Take(dataTableRequestModel.DisplayLength)).ToArray();

            var result = new DataTableResponseModel<T>
            {
                TotalRecord = totalRecords,
                TotalDisplayRecord = totalDisplayRecords,
                Echo = dataTableRequestModel.Echo,
                Data = page.Cast<object>().ToArray()
            };

            return result;
        }
    }
}