using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIA
{
    public class MCTS
    {
        private GameState gameState;

        public MCTS(GameState state)
        {
            gameState = state;
        }

        public string SelectBestQuestion()
        {
            
            return gameState.AvailableQuestions.First(); 
        }
    }
}
