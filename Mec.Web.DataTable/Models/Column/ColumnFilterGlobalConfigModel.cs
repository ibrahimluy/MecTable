#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> ColumnFilterGlobalConfigModel.cs </Name>
//         <Created> 23/03/2018 4:19:06 PM </Created>
//         <Key> 8d158cf2-cc12-4420-b7ee-1ead75c87b6d </Key>
//     </File>
//     <Summary>
//         ColumnFilterGlobalConfigModel.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Models.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq;

namespace Mec.Web.DataTable.Models.Column
{
    public class ColumnFilterGlobalConfigModel : Hashtable
    {
        private readonly DataTableModel _model;

        public JObject ColumnBuilders = new JObject();

        public ColumnFilterGlobalConfigModel(DataTableModel model)
        {
            _model = model;

            this[FilterConstants.PlaceHolder] = "head:after";
        }

        public override string ToString()
        {
            this[FilterConstants.UseColVis] = _model.IsEnableColVis;

            this[FilterConstants.Columns] = _model.Columns
                .Select(c => c.IsSearchable && c.ColumnFilter != null ? c.ColumnFilter : null).ToArray();

            return JsonConvert.SerializeObject(this);
        }
    }
}