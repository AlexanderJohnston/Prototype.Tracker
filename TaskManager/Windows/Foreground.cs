using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Windows
{
    internal class Foreground
    {
        public uint ProcessIdentifier { get; set; }

        #region Windows API Call

        /// <summary>
        ///     Stores the reference to the active window.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        /// <summary>
        ///     Makes the call to retrieve text from a window passed by reference.
        /// </summary>
        /// <param name="hWnd">Reference to the active window.</param>
        /// <param name="text">String builder as buffer to receive text.</param>
        /// <param name="count">Max number of chars to copy into the buffer.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        /// <summary>
        ///     Prepares the buffer and makes the call.
        /// </summary>
        /// <returns>Name of the active window of focus.</returns>
        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var Buff = new StringBuilder(nChars);
            IntPtr refToWin = Foreground.GetForegroundWindow();

            return Foreground.GetWindowText(refToWin, Buff, nChars) > 0 ? Buff.ToString() : null;
        }

        /// <summary>
        ///     Makes the call to retrieve a process identifier as uint.
        /// </summary>
        /// <param name="hWnd">Reference to the active window.</param>
        /// <param name="processIdent">New uint to hold the output of this call.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processIdent);

        private uint GetProcessIdentifier()
        {
            var pid = new uint();
            IntPtr refToWin = Foreground.GetForegroundWindow();
            Foreground.GetWindowThreadProcessId(refToWin, out pid);

            //  Thread was destroyed and causes race condition.
            if (pid == 0)
                return this.ProcessIdentifier;

            return pid;
        }

        #endregion
    }
}
