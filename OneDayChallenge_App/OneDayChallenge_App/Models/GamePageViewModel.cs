using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;

namespace OneDayChallenge_App.Models
{
    public class GamePageViewModel : INotifyPropertyChanged
    {
        public GamePageViewModel()
        {
            StartGamePage = new Command(() =>
           {

           });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command StartGamePage { get; }
    }

}
