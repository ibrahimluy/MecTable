#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> TransformTypeInfoHelper.cs </Name>
//         <Created> 24/03/2018 2:13:00 PM </Created>
//         <Key> 99460754-c57a-488d-a31d-4b43933baa2c </Key>
//     </File>
//     <Summary>
//         TransformTypeInfoHelper.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Web.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mec.Web.DataTable.Utils.TypeUtils
{
    internal class TransformTypeInfoHelper
    {
        internal static Dictionary<string, object> MergeTransformValuesIntoDictionary<T, TTransform>(
            Func<T, TTransform> transformInput, T input)
        {
            // Get the the properties from the input as a dictionary
            var dict = new DataTableTypeInfoModel<T>().ToDictionary(input);

            // Get the transform object
            var transform = transformInput(input);

            if (transform == null) return dict;

            foreach (var propertyInfo in transform.GetType().GetTypeInfo().GetProperties())
                dict[propertyInfo.Name] = propertyInfo.GetValue(transform, null);

            return dict;
        }
    }
}