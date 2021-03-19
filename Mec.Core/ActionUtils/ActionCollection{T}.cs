using System;
using System.Collections.Generic;
using System.Linq;
using Mec.Core.ActionUtils.Models;
using Mec.Core.LinqUtils;
using Mec.Core.ObjUtils;

namespace Mec.Core.ActionUtils
{
    public class ActionCollection<T> : MecDisposableModel
    {
        protected List<ActionModel<T>> Actions { get; set; } = new List<ActionModel<T>>();

        public virtual List<ActionModel<T>> Get()
        {
            return Actions;
        }

        public virtual string Add(Action<T> action)
        {
            var actionModel = new ActionModel<T>(action);

            Actions.Add(actionModel);

            return actionModel.Id;
        }

        public virtual void Remove(string actionId)
        {
            Actions = Actions.RemoveWhere(x => x.Id == actionId).ToList();
        }

        public virtual void Empty()
        {
            if (Actions?.Any() != true)
            {
                return;
            }

            Actions = Actions.RemoveWhere(x => x.Action != null).ToList();
        }
        
        protected override void DisposeUnmanagedResources()
        {
            if (Actions?.Any() != true)
            {
                return;
            }
            
            foreach (var actionModel in Actions)
            {
                actionModel.Dispose();
            }
        }
    }
}