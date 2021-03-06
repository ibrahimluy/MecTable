#region	License
//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> SiteMapImageItemDetailModel.cs </Name>
//         <Created> 21/03/2018 3:27:57 PM </Created>
//         <Key> e06672a6-3ae6-4f7c-ab85-0db03c574854 </Key>
//     </File>
//     <Summary>
//         SiteMapImageItemDetailModel.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------
#endregion License

using Mec.Core.ObjUtils;

namespace Mec.Web.SiteMap.Models
{
    public class SiteMapImageItemDetailModel: MecDisposableModel
    {
        /// <summary>
        ///     Caption/description of image. 
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        ///     Geo location of image. 
        /// </summary>
        public string GeoLocation { get; set; }

        /// <summary>
        ///     URL of image. 
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        ///     Url to License of image 
        /// </summary>
        public string License { get; set; }

        /// <summary>
        ///     Title of image. 
        /// </summary>
        public string Title { get; set; }
    }
}