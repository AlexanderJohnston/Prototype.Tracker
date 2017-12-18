using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Tasks
{
    /// <summary>
    ///     Encapsulates the API system to hide the details of calling C++ and the Windows API in general.
    /// </summary>
    public class Request
    {
        /// <summary>
        ///     Stores all available tasks for calls to the Windows API.
        /// </summary>
        private readonly WinAPI windows = new WinAPI();

        /// <summary>
        ///     Used to determine which tasks are available from the <see cref="WinAPI"/>.
        /// </summary>
        private MethodInfo[] windowsTaskInformation => GetWindowsTaskInformation();

        internal Dictionary<string, WinAPI> WindowsTasks;
        

        /// <summary>
        ///     Makes a call for an available task based on the selected API.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public dynamic Call(string task)
        {

        }
    }
}
