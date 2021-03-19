using System;
using Mec.Core.ObjUtils;

namespace Mec.Core.ActionUtils.Models
{
    public class ActionModel : MecDisposableModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        public Action Action { get; set; }

        public ActionModel(Action action)
        {
            Action = action;
        }
    }
}