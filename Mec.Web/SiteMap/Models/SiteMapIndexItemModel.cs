#region	License
//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> SiteMapIndexItemModel.cs </Name>
//         <Created> 21/03/2018 3:38:32 PM </Created>
//         <Key> ab4c6d57-c0ce-4974-b63c-90a739636b47 </Key>
//     </File>
//     <Summary>
//         SiteMapIndexItemModel.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------
#endregion License

using Mec.Core.CheckUtils;
using Mec.Web.SiteMap.Interfaces;
using System;
using Mec.Core.ObjUtils;

namespace Mec.Web.SiteMap.Models
{
    /// <summary>
    ///     Represents a site map index item. 
    /// </summary>
    public class SiteMapIndexItemModel : MecDisposableModel, ISiteMapItem
    {
        /// <summary>
        ///     Creates a new instance of <see cref="SiteMapIndexItemModel" /> 
        /// </summary>
        /// <param name="url">          URL of the page. Optional. </param>
        /// <param name="lastModified"> The date of last modification of the file. Optional. </param>
        /// <exception cref="System.ArgumentNullException">
        ///     If the <paramref name="url" /> is null or empty.
        /// </exception>
        public SiteMapIndexItemModel(string url, DateTime? lastModified = null)
        {
            CheckHelper.CheckNullOrWhiteSpace(url, nameof(url));

            Url = url;

            LastModified = lastModified;
        }

        /// <summary>
        ///     The date of last modification of the file. 
        /// </summary>
        public DateTime? LastModified { get; protected set; }

        /// <summary>
        ///     URL of the page. 
        /// </summary>
        public string Url { get; protected set; }
    }
}