#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> DataTablePropertyInfoModel.cs </Name>
//         <Created> 23/03/2018 4:41:32 PM </Created>
//         <Key> c900c821-dfe6-451c-93c6-07a489198ba2 </Key>
//     </File>
//     <Summary>
//         DataTablePropertyInfoModel.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Attributes;
using System;
using System.Reflection;
using Mec.Web.DataTable.Models.Constants;

namespace Mec.Web.DataTable.Models
{
    public class DataTablePropertyInfoModel
    {
        public DataTablePropertyInfoModel(PropertyInfo propertyInfo, DataTableBaseAttribute[] attributes)
        {
            PropertyInfo = propertyInfo;

            Attributes = attributes;
        }

        public PropertyInfo PropertyInfo { get; }

        public DataTableBaseAttribute[] Attributes { get; }

        public Type Type => PropertyInfo.PropertyType;

        public int Order { get; set; } = ConfigConstants.DefaultOrder;
    }
}