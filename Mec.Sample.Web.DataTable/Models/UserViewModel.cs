using Mec.Web.DataTable.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mec.Sample.Web.DataTable.Models
{
    public class UserViewModel
    {
        [DataTable(IsVisible = false, Order = 1)]
        public int Id { get; set; }

        [DataTable(DisplayName = "Full Name", Title = "Full Name", Required = "true", Order = 1)]
        public string FullName { get; set; }

        [DataTable(DisplayName = "Created At", Order = 2)]
        public DateTimeOffset CreatedTime { get; set; }

        [DataTable(DisplayName = "Actived", Order = 4)]
        public bool IsActive { get; set; }
    }


}
