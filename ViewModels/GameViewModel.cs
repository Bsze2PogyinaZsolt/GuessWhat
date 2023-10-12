using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Windows.Input;
using GuessWhat.Models;
using ViewModels.BaseClass;

namespace GuessWhat.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        
        private GameModel game;
       

        public ICommand CheckGuessCommand { get; set; }
        public ICommand StartNewGameCommand { get; set; }

        public GameViewModel()
        {
            game = new GameModel();
            StartNewGame();
        }

        private int guess;
        public int Guess 
        { 
            get=>guess; 
            set 
            { 
                guess = value;
                OnPropertyChanged(nameof(Guess)); 
             }
        }

        private string feedback;
        public string Feedback 
        { get=>feedback; 
            set
            {
                feedback = value;
                OnPropertyChanged(nameof(Feedback));
            }


        private void CheckGuess()
        {

            string result = game.CheckGuess(Guess);
            Feedback = game.CheckGuess(Guess);
        }

        private void StartNewGame()
        {
            game.StartNewGame();
            Guess = 0;
            Feedback = "Guess the number!";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    
    }
}
