#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> PaginateModel.cs </Name>
//         <Created> 23/03/2018 4:34:17 PM </Created>
//         <Key> 0f4768c1-32c1-4a62-b213-9f74660fe342 </Key>
//     </File>
//     <Summary>
//         PaginateModel.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Models.Constants;
using Newtonsoft.Json;

namespace Mec.Web.DataTable.Models.Menu
{
    public class PaginateModel
    {
        [JsonProperty(PropertyName = PropertyConstants.First)]
        public string First { get; set; }

        [JsonProperty(PropertyName = PropertyConstants.Previous)]
        public string Previous { get; set; }

        [JsonProperty(PropertyName = PropertyConstants.Next)]
        public string Next { get; set; }

        [JsonProperty(PropertyName = PropertyConstants.Last)]
        public string Last { get; set; }
    }
}