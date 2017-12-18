#region header

// UserInterface - ActiveWindow.cs
// 
// Copyright Untethered Labs, Inc.  All rights reserved.
// 
// Created: 2017-11-04 1:35 AM

#endregion

#region using

using System ;
using System.Runtime.InteropServices ;
using System.Text ;
using System.Threading ;

using PostSharp.Patterns.Model ;

#endregion

namespace UserInterface.Model
{
    /// <summary>
    ///     This model retrieves the window currently under active focus.
    ///     INotifyPropertyChanged is injected via PostSharp attribute.
    /// </summary>
    [NotifyPropertyChanged]
    public class ActiveWindow
    {
        internal ActiveWindow ()
        {
            //  0ms initial fire and each 100ms thereafter.
            this.stateTimer = new Timer (this.UpdateTimer, null, 0, 100) ;
        }

        /// <summary>
        ///     Used to initiate the Windows API call on a loop to check for new window names.
        /// </summary>
        private Timer stateTimer ;

        /// <summary>
        ///     Stores the active window name for retrieval by a viewmodel.
        /// </summary>
        public string Text { get ; set ; }

        /// <summary>
        ///     Stores the pid of the active window.
        /// </summary>
        public uint ProcessIdentifier { get ; set ; }

        /// <summary>
        ///     Initiates the call procedures.
        /// </summary>
        /// <param name="stateInfo"></param>
        private void UpdateTimer (object stateInfo)
        {
            //this.refToWin = ActiveWindow.GetForegroundWindow();
            this.Text = this.GetActiveWindowTitle () ;
            this.ProcessIdentifier = this.GetProcessIdentifier () ;
        }

        
    }
}
