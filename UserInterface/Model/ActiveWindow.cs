#region header

// UserInterface - ActiveWindow.cs
//
// Created: 2017-11-04 1:35 AM

#endregion

#region using

using System ;
using System.Diagnostics ;
using System.Runtime.InteropServices ;
using System.Text ;
using System.Threading ;
using System.Threading.Tasks ;

using PostSharp.Patterns.Model ;

#endregion

namespace UserInterface.Model
{
    /// <summary>
    ///     This model retrieves the window currently under active focus.
    ///     Property changed notification implemented via PostSharp.
    /// </summary>
    [NotifyPropertyChanged]
    public class ActiveWindow
    {
        /// <summary>
        ///     Used to initiate the Windows API call on a loop to check for new window names.
        /// </summary>
        private Timer stateTimer ;

        internal ActiveWindow ()
        {
            //  0ms initial fire and each 100ms thereafter.
            stateTimer = new Timer (this.UpdateTimer, null, 0, 100) ;
        }

        /// <summary>
        ///     Initiates the call procedures.
        /// </summary>
        /// <param name="stateInfo"></param>
        private void UpdateTimer (Object stateInfo)
        {
            this.Text = this.GetActiveWindowTitle();
        }

        /// <summary>
        ///     Stores the active window name for retrieval by a viewmodel.
        /// </summary>
        public string Text { get ; set ; }

        #region Windows API Call

        /// <summary>
        ///     Stores the reference to the active window.
        /// </summary>
        /// <returns></returns>
        [DllImport ("user32.dll")]
        private static extern IntPtr GetForegroundWindow () ;

        /// <summary>
        ///     Makes the call to retrieve text from a window passed by reference.
        /// </summary>
        /// <param name="hWnd">Reference to the active window.</param>
        /// <param name="text">String builder as buffer to receive text.</param>
        /// <param name="count">Max number of chars to copy into the buffer.</param>
        /// <returns></returns>
        [DllImport ("user32.dll")]
        private static extern int GetWindowText (IntPtr hWnd, StringBuilder text, int count) ;

        /// <summary>
        ///     Prepares the buffer and makes the call.
        /// </summary>
        /// <returns></returns>
        private string GetActiveWindowTitle ()
        {
            const int nChars = 256 ;
            var Buff = new StringBuilder (nChars) ;
            IntPtr handle = ActiveWindow.GetForegroundWindow () ;

            return ActiveWindow.GetWindowText (handle, Buff, nChars) > 0 ? Buff.ToString () : null ;
        }

        #endregion
    }
}
