using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Tasks.Attributes
{
    [PSerializable]
    internal class SafelyInitializeRequestDelegates : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //  Get the base class and initialize the delegate for each request.
            var refClass = (Request)args.Instance;

            refClass.

            base.OnInvoke(args);
        }
    }
}
