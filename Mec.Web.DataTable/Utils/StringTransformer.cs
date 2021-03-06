#region	License

//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.com/ </Url>
//     <Author> Top </Author>
//     <Project> Mec </Project>
//     <File>
//         <Name> StringTransformer.cs </Name>
//         <Created> 23/03/2018 5:01:38 PM </Created>
//         <Key> d9fe2ca9-7d89-459b-8ca9-9961a7a6b90e </Key>
//     </File>
//     <Summary>
//         StringTransformer.cs is a part of Mec
//     </Summary>
// <License>
//--------------------------------------------------

#endregion License

using Mec.Core.TypeUtils;
using Mec.Web.DataTable.Models.Options;
using Mec.Web.DataTable.Utils.EnumUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Mec.Web.DataTable.Utils
{
    internal class StringTransformer
    {
        private static readonly Dictionary<Type, Transformer> Transformers = new Dictionary<Type, Transformer>();

        static StringTransformer()
        {
            RegisterFilter<DateTimeOffset>(dateTimeOffset =>
                dateTimeOffset.ToString(MecDataTableOptions.Instance.DateTimeFormat));
            RegisterFilter<DateTime>(dateTime => dateTime.ToString(MecDataTableOptions.Instance.DateTimeFormat));
            RegisterFilter<IEnumerable<string>>(s => s.ToArray());
            RegisterFilter<IEnumerable<int>>(s => s.ToArray());
            RegisterFilter<IEnumerable<long>>(s => s.ToArray());
            RegisterFilter<IEnumerable<decimal>>(s => s.ToArray());
            RegisterFilter<IEnumerable<bool>>(s => s.ToArray());
            RegisterFilter<IEnumerable<double>>(s => s.ToArray());
            RegisterFilter<IEnumerable<object>>(s => s.Select(o => GetStringedValue(o.GetType(), o)).ToArray());
            RegisterFilter<bool>(s => s);
            RegisterFilter<object>(o => (o ?? string.Empty).ToString());
        }

        internal static object GetStringedValue(Type type, object value)
        {
            object stringedValue;

            if (Transformers.ContainsKey(type))
            {
                stringedValue = Transformers[type](type, value);
            }
            else
            {
                if (type.GetNotNullableType().IsEnum)
                {
                    var t = type.GetNotNullableType();
                    var enumObj = (Enum)TypeDescriptor.GetConverter(t).ConvertFrom(value.ToString());
                    stringedValue = enumObj.GetDisplayName() ?? enumObj.GetDescription() ?? enumObj.GetName();
                }
                else
                {
                    stringedValue = value?.ToString();
                }
            }

            stringedValue = stringedValue ?? string.Empty;
            return stringedValue;
        }

        internal static void RegisterFilter<TVal>(GuardedValueTransformer<TVal> filter)
        {
            if (Transformers.ContainsKey(typeof(TVal)))
                Transformers[typeof(TVal)] = Guard(filter);
            else
                Transformers.Add(typeof(TVal), Guard(filter));
        }

        private static Transformer Guard<TVal>(GuardedValueTransformer<TVal> transformer)
        {
            return (t, v) => !typeof(TVal).GetTypeInfo().IsAssignableFrom(t) ? null : transformer((TVal)v);
        }

        internal static Dictionary<string, object> StringifyValues(Dictionary<string, object> dict)
        {
            var output = new Dictionary<string, object>();

            foreach (var row in dict)
                output[row.Key] = row.Value == null ? string.Empty : GetStringedValue(row.Value.GetType(), row.Value);

            return output;
        }

        internal delegate object GuardedValueTransformer<in TVal>(TVal value);

        internal delegate object Transformer(Type type, object value);
    }
}