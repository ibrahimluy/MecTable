#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> DataTableIgnoreAttribute.cs </Name>
//         <Created> 23/03/2018 4:44:45 PM </Created>
//         <Key> 6fcd2d35-cf4e-4c60-b1b8-91da8f44e927 </Key>
//     </File>
//     <Summary>
//         DataTableIgnoreAttribute.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using System;

namespace Mec.Web.DataTable.Attributes
{
    /// <inheritdoc />
    /// <summary>
    ///     Prevent a public property from being included as a column in a DataTable row model 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTableIgnoreAttribute : Attribute
    {
    }
}