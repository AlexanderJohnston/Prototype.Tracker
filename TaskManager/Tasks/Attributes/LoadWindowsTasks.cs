using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Tasks.Attributes
{
    class LoadWindowsTasks : LocationInterceptionAspect
    {
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            var targetClass = (Request)args.Instance;
            if (targetClass.)
            base.OnGetValue(args);
        }
    }
}
