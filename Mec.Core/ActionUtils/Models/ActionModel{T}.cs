using System;
using Mec.Core.ObjUtils;

namespace Mec.Core.ActionUtils.Models
{
    public class ActionModel<T> : MecDisposableModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        
        public Action<T> Action { get; set; }

        public ActionModel(Action<T> action)
        {
            Action = action;
        }
    }
}