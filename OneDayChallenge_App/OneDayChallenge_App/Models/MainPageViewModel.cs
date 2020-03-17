using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;

namespace OneDayChallenge_App.Models
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            StartGame = new Command(async () =>
            {
                var gameVM = new GamePageViewModel();

                var gamePage = new GamePage();

                await Application.Current.MainPage.Navigation.PushAsync(gamePage);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command StartGame { get; }
    }

    
}
