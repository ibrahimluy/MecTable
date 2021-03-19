using Mec.Core.Interfaces;
using Mec.Web.DataTable.Models.Constants;
using Mec.Web.DataTable.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mec.Web.DataTable.Models.Options
{
    public class MecDataTableOptions : IMecOptions
    {
        private MecDataTableDefaultDisplayTextModel _defaultDisplayText = new MecDataTableDefaultDisplayTextModel();

        public static MecDataTableOptions Instance { get; set; }

        /// <summary>
        ///     Config use datetime with TimeZone. Default is "UTC", See more: https://msdn.microsoft.com/en-us/library/gg154758.aspx 
        /// </summary>
        public string DateTimeTimeZone { get; set; } = "UTC";

        /// <summary>
        ///     All response will apply the format by default. If
        ///     <see cref="RequestDateTimeFormatType" /> is
        ///     <see cref="DateTimeFormatType.Specific" />, every request will use the format to
        ///     parse string to DateTime. Else will try parse string to DateTime by any format.
        ///     <para> Format "dd/MM/yyyy" by default </para>
        /// </summary>
        public string DateFormat { get; set; } = "dd.MM.yyyy";

        /// <summary>
        ///     All response will apply the format by default. If
        ///     <see cref="RequestDateTimeFormatType" /> is
        ///     <see cref="DateTimeFormatType.Specific" />, every request will use the format to
        ///     parse string to DateTime. Else will try parse string to DateTime by any format.
        ///     <para> Format "dd/MM/yyyy hh:mm tt" by default </para>
        /// </summary>
        public string DateTimeFormat { get; set; } = "dd.MM.yyyy hh:mm:ss tt";

        /// <summary>
        ///     Set default display text for common text in DataTable.
        /// </summary>
        /// <remarks>Set null will use as default value.</remarks>
        /// <remarks>Support translate by <see cref="SharedResourceType"/> when get the value of each text. </remarks>
        public MecDataTableDefaultDisplayTextModel DefaultDisplayText
        {
            get => _defaultDisplayText;
            set => _defaultDisplayText = value ?? new MecDataTableDefaultDisplayTextModel();
        }

        /// <summary>
        ///     Control the way to parse string to DateTime every request. If value is
        ///     <see cref="DateTimeFormatType.Specific" />, every request will use the
        ///     <see cref="DateTimeFormatType" /> to parse string to DateTime. Else, will try parse
        ///     string to DateTime by any format.
        ///     <para> Value is "Auto" by default </para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DateTimeFormatType RequestDateTimeFormatType { get; set; } = DateTimeFormatType.Auto;

        /// <summary>
        ///     Shared resource type to localize all
        ///     <see cref="Attributes.DataTableAttribute.DisplayName" /> and will be override by
        ///     <see cref="Attributes.DataTableAttribute.DisplayNameResourceType" /> if set
        /// </summary>
        public Type SharedResourceType { get; set; }
    }

    public class MecDataTableDefaultDisplayTextModel
    {
        private string _yes = "Yes";
        private string _no = "No";
        private string _filter = "Filter";
        private string _filterBy = "Filter by";
        private string _all = "All";
        private string _loading = "Loading...";

        /// <summary>
        ///     Default is "Yes"
        /// </summary>
        /// <remarks>Support translate by <see cref="MecDataTableOptions.SharedResourceType"/> when get the value of each text. </remarks>
        public string Yes
        {
            get => MecDataTableTranslator.Get(_yes);
            set => _yes = value;
        }

        /// <summary>
        ///     Default is "No"
        /// </summary>
        /// <remarks>Support translate by <see cref="MecDataTableOptions.SharedResourceType"/> when get the value of each text. </remarks>
        public string No
        {
            get => MecDataTableTranslator.Get(_no);
            set => _no = value;
        }

        /// <summary>
        ///     Default is "Filter"
        /// </summary>
        /// <remarks>Support translate by <see cref="MecDataTableOptions.SharedResourceType"/> when get the value of each text. </remarks>
        public string Filter
        {
            get => MecDataTableTranslator.Get(_filter);
            set => _filter = value;
        }

        /// <summary>
        ///     Default is "Filter by"
        /// </summary>
        /// <remarks>Support translate by <see cref="MecDataTableOptions.SharedResourceType"/> when get the value of each text. </remarks>
        public string FilterBy
        {
            get => MecDataTableTranslator.Get(_filterBy);
            set => _filterBy = value;
        }

        /// <summary>
        ///     Default is "All"
        /// </summary>
        /// <remarks>Support translate by <see cref="MecDataTableOptions.SharedResourceType"/> when get the value of each text. </remarks>
        public string All
        {
            get => MecDataTableTranslator.Get(_all);
            set => _all = value;
        }

        /// <summary>
        ///     Default is "Loading..."
        /// </summary>
        /// <remarks>Support translate by <see cref="MecDataTableOptions.SharedResourceType"/> when get the value of each text. </remarks>
        public string Loading
        {
            get => MecDataTableTranslator.Get(_loading);
            set => _loading = value;
        }
    }
}