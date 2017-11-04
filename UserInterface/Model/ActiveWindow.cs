#region header

// UserInterface - ActiveWindow.cs
// 
// Copyright Untethered Labs, Inc.  All rights reserved.
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
    [NotifyPropertyChanged]
    public class ActiveWindow
    {
        private Timer stateTimer ;

        internal ActiveWindow ()
        {
            //  0ms initial fire and each 100ms thereafter.
            stateTimer = new Timer (this.UpdateTimer, null, 0, 100) ;
        }

        private void UpdateTimer (Object stateInfo)
        {
            this.Text = this.GetActiveWindowTitle();
        }

        public string Text { get ; set ; }

        #region Windows API Call

        [DllImport ("user32.dll")]
        private static extern IntPtr GetForegroundWindow () ;


        [DllImport ("user32.dll")]
        private static extern int GetWindowText (IntPtr hWnd, StringBuilder text, int count) ;

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
