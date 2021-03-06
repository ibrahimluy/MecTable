#region	License
//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> SiteMapImageItemModel.cs </Name>
//         <Created> 21/03/2018 3:28:27 PM </Created>
//         <Key> 2795b199-7883-4fed-85ac-febc36fd222b </Key>
//     </File>
//     <Summary>
//         SiteMapImageItemModel.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------
#endregion License

using Mec.Core.CheckUtils;
using Mec.Web.SiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Mec.Core.ObjUtils;

namespace Mec.Web.SiteMap.Models
{
    public class SiteMapImageItemModel : MecDisposableModel, ISiteMapItem
    {
        /// <summary>
        ///     Creates a new instance of <see cref="SiteMapImageItemDetailModel" /> 
        /// </summary>
        /// <param name="url">    URL of the page. </param>
        /// <param name="images"> List image </param>
        /// <exception cref="System.ArgumentNullException">
        ///     If the <paramref name="url" /> is null or empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     If the <paramref name="images" /> is null or empty.
        /// </exception>
        public SiteMapImageItemModel(string url, params SiteMapImageItemDetailModel[] images)
        {
            CheckHelper.CheckNullOrWhiteSpace(url, nameof(url));

            if (images?.Any() != true)
            {
                throw new ArgumentNullException($"{nameof(images)} is null");
            }

            Url = url;

            Images = images.ToList();
        }

        public List<SiteMapImageItemDetailModel> Images { get; protected set; }

        /// <summary>
        ///     URL of the page. 
        /// </summary>
        public string Url { get; protected set; }
    }
}