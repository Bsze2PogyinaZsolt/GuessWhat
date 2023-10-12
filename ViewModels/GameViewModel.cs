using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using GuessWhat.Models;
using ViewModels.BaseClass;


namespace GuessWhat.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GameModel game;

        public GameViewModel()
        {
            game = new GameModel();
            StartNewGame();
            CheckGuessCommand = new RelayCommand(CheckGuess);
            StartNewGameCommand = new RelayCommand(StartNewGame);
        }

        public ICommand CheckGuessCommand { get; }
        public ICommand StartNewGameCommand { get; }

        private int guess;
        public int Guess
        {
            get => guess;
            set
            {
                guess = value;
                OnPropertyChanged(nameof(Guess));
            }
        }

        private string feedback;
        public string Feedback
        {
            get => feedback;
            set
            {
                feedback = value;
                OnPropertyChanged(nameof(Feedback));
            }
        }

        private int attempts;
        public int Attempts
        {
            get => attempts;
            set
            {
                attempts = value;
                OnPropertyChanged(nameof(Attempts));
            }
        }

        public void CheckGuess()
        {
            Feedback = game.CheckGuess(Guess);
            Attempts = game.GetAttempts();
        }

        public void StartNewGame()
        {
            game.StartNewGame();
            Guess = 0;
            Feedback = "Guess the number!";
            Attempts = 0;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}