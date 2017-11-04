#region header

// UserInterface - InterfaceViewModel.cs
// 
// Copyright Untethered Labs, Inc.  All rights reserved.
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
    [NotifyPropertyChanged]
    public class InterfaceViewModel
    {
        public InterfaceViewModel()
        {
            this.Test = "Hi";

            this.actWinModel = new ActiveWindow();

            Post.Cast<ActiveWindow, INotifyPropertyChanged>
                (this.actWinModel).PropertyChanged += this.RefreshActiveWindow;

            this.Looper();
        }

        private readonly ActiveWindow actWinModel ;

        public string Test { get ; set ; }

        private void RefreshActiveWindow (object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
                this.Test = this.actWinModel.Text ;
        }

        private async void Looper ()
        {
            await Task.Delay(3000);
            this.Looper();
        }
    }
}
