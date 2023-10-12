using System;
using System.Collections.Generic;
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
        private GameModel _game;
        public int Guess { get; set; }
        public string Feedback { get; set; }

        public ICommand CheckGuessCommand { get; set; }
        public ICommand StartNewGameCommand { get; set; }

        public GameViewModel()
        {
            game = new GameModel();
            StartNewGame();
            CheckGuessCommand = new RelayCommand(CheckGuess);
            StartNewGameCommand = new RelayCommand(StartNewGame);


        }

        private void CheckGuess()
        {
            Feedback = game.CheckGuess(Guess);
        }

        private void StartNewGame()
        {
            game.StartNewGame();
            Guess = 0;
            Feedback = "Guess the number!";
        }
    
    }
}
