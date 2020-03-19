using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace OneDayChallenge_App.Models
{


    class GamePageViewModel : INotifyPropertyChanged
    {
        public Boolean is_Visible;
        public Boolean is_Enabled = true;
        public int user_Guess;
        public string num_Guesses;
        public int intNum_Guesses = 0;
        public string computer_Guess;
        public int computerGuess;
        public int low;
        public int high;

        public GamePageViewModel (){
           

            StartGame = new Command(() =>
           {
         
               Is_Visible = true;
               Is_Enabled = false;
               computerGuess = computer_GenerateRandom(0, User_Guess);
               low = 0;
               high = User_Guess * 10;
         
           });

            LessThan = new Command(async() =>
            {
                intNum_Guesses++;
                Num_Guesses = intNum_Guesses.ToString();

                if (computerGuess != User_Guess)
                {
                    high = computerGuess;
                    computerGuess = computer_GenerateRandom(low, high);
                }else
                {
                    await Application.Current.MainPage.DisplayAlert("Congratulations", "The computer guessed in" + Num_Guesses + " rounds", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }

                Computer_Guess = computerGuess.ToString();
            });

            MoreThan = new Command(async() =>
            {
                intNum_Guesses++;
                Num_Guesses = intNum_Guesses.ToString();
              
                if (computerGuess != User_Guess)
                {
                    low = computerGuess + 1;
                    computerGuess = computer_GenerateRandom(low, high);
                }else
                {
                    await Application.Current.MainPage.DisplayAlert("Congratulations", "The computer guessed in" + Num_Guesses + " rounds", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }

                Computer_Guess = computerGuess.ToString();
            });



        }

        public int computer_GenerateRandom(int min, int max)
        {
            Random rnd = new Random();
            int test = rnd.Next(min, max);
            return test;
        }
        public bool Is_Visible
        {
            get => is_Visible;
            set
            {
                is_Visible = value;
                OnPropertyChanged(nameof(Is_Visible));
            }
        }

        public bool Is_Enabled
        {
            get => is_Enabled;
            set
            {
                is_Enabled = value;
                OnPropertyChanged(nameof(Is_Enabled));
            }
        }

        public int User_Guess
        {
            get => user_Guess;
            set
            { 
                user_Guess = value;
                OnPropertyChanged(nameof(User_Guess));
                
            }
        }

        public string Num_Guesses
        {
            get => num_Guesses;
            set
            {
                num_Guesses = value;
                OnPropertyChanged(nameof(Num_Guesses));
            }
        }

        public string Computer_Guess
        {
            get => computer_Guess;
            set
            {
                computer_Guess = value;
                OnPropertyChanged(nameof(Computer_Guess));
            }
        }
      
        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command StartGame { get; set; }
        public Command IncrementGuess { get; set; }
        public Command MoreThan { get; set; }
        public Command LessThan { get; set; }
    }

}
