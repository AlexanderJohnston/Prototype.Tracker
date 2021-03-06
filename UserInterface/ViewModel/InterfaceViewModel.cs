﻿#region header

// UserInterface - InterfaceViewModel.cs
// 
// Created: 2017-11-04 1:22 AM

#endregion

#region using

using System.ComponentModel ;
using System.Threading.Tasks ;

using PostSharp ;
using PostSharp.Patterns.Model ;

using UserInterface.Model ;

#endregion

namespace UserInterface.ViewModel
{
    /// <summary>
    ///     This contains logic for the user interface to communicate with the models.
    ///     May also contain viewmodels for interface components or sub-modules.
    ///     Data binding implementation of INotifyPropertyChanged is injected after compile time.
    /// </summary>
    [NotifyPropertyChanged]
    public class InterfaceViewModel
    {
        public InterfaceViewModel()
        {
            this.Test = "Hi";

            this.actWinModel = new ActiveWindow();

            //  Cast the type after compile-time when Postsharp injects the boilerplate.
            Post.Cast<ActiveWindow, INotifyPropertyChanged>
                (this.actWinModel).PropertyChanged += this.RefreshActiveWindow;

            this.Looper();
        }

        /// <summary>
        ///     This model retrieves the active window and stores it as Text based on a timer.
        /// </summary>
        private readonly ActiveWindow actWinModel ;

        public string Test { get ; set ; }

        public string ProcessIdentifier { get ; set ; }

        /// <summary>
        ///     The active window model uses a Windows API call on a timer loop,
        ///     so it is necessary to use an event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshActiveWindow (object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
                this.Test = this.actWinModel.Text ;
            if (e.PropertyName == "ProcessIdentifier")
                this.ProcessIdentifier = this.actWinModel.ProcessIdentifier.ToString() ;
        }

        /// <summary>
        ///     Looping for debug purposes.
        /// </summary>
        private async void Looper ()
        {
            await Task.Delay(3000);
            this.Looper();
        }
    }
}
