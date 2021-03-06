#region	License
//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> LinkModel.cs </Name>
//         <Created> 02/04/2018 1:25:54 AM </Created>
//         <Key> 58efcc21-9e03-4a4b-be0d-8d7ff22c5ac2 </Key>
//     </File>
//     <Summary>
//         LinkModel.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------
#endregion License

using Mec.Core.ObjUtils;
using Mec.Web.Models;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mec.Web.Api.Models
{
    public class LinkModel : MecDisposableModel
    {
        public string Url { get; set; }

        /// <summary>
        ///     Http method, default is "GET". 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public HttpMethod Method { get; set; } = HttpMethod.GET;

        public RouteValueDictionary Data { get; set; } = new RouteValueDictionary();
    }
}