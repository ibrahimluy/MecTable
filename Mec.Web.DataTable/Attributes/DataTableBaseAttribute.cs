#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> DataTableBaseAttribute.cs </Name>
//         <Created> 23/03/2018 4:43:31 PM </Created>
//         <Key> 3ea70f2e-c72c-437e-ba23-86ffe7949cbe </Key>
//     </File>
//     <Summary>
//         DataTableBaseAttribute.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Models.Column;
using System;
using System.Reflection;

namespace Mec.Web.DataTable.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class DataTableBaseAttribute : Attribute
    {
        public abstract void ApplyTo(ColumnModel columnModel, PropertyInfo propertyInfo);
    }
}