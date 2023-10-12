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
    public class GameViewModel
    {
        private GameModel game;

        public int Guess { get; set; }
        public string Feedback { get; set; }
        public int Attempts { get; set; }

        public ICommand CheckGuessCommand { get; set; }
        public ICommand StartNewGameCommand { get; set; }

        public GameViewModel()
        {
            game = new GameModel();
            StartNewGame();
            CheckGuessCommand = new RelayCommand(CheckGuess);
            StartNewGameCommand = new RelayCommand(StartNewGame);
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
    }
}