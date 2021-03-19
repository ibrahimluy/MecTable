#region	License
//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> SiteMapItemAttribute.cs </Name>
//         <Created> 21/03/2018 2:25:52 PM </Created>
//         <Key> 97bf8c46-9fc2-4159-a7dd-751bf976d2cb </Key>
//     </File>
//     <Summary>
//         SiteMapItemAttribute.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------
#endregion License

using Mec.Web.SiteMap.Models;
using System;

namespace Mec.Web.SiteMap.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class SiteMapItemAttribute : Attribute
    {
        public SiteMapItemAttribute(SiteMapItemFrequency frequency, double priority)
        {
            Frequency = frequency;
            Priority = priority;
        }

        public double Priority { get; set; }

        public SiteMapItemFrequency Frequency { get; set; }
    }
}