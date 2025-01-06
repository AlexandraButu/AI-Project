using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIA
{
    public class GameState
    {
        public List<Character> RemainingCharacters { get; set; }
        public List<string> AvailableQuestions { get; set; }

        public GameState(List<Character> characters, List<string> questions)
        {
            RemainingCharacters = new List<Character>(characters); 
            AvailableQuestions = new List<string>(questions);
        }

    }

}
