using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWhat.Models
{
    public class GameModel
    {
        private Random random = new Random();
        private int randomNumber;
        private int attempts;

        public void StartNewGame()
        {
            randomNumber = random.Next(1, 101);
            attempts = 0;
        }

        public string CheckGuess(int guess)
        {
            attempts++;
            if (guess < randomNumber)
                return "Higher";
            else if (guess > randomNumber)
                return "Lower";
            else return "correct";
        }

        public int GetAttempts()
        {
            return attempts;
        }
    }
}
