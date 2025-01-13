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
        public List<string> AskedQuestions { get; set; }

        public GameState(List<Character> characters, List<string> questions)
        {
            RemainingCharacters = new List<Character>(characters); 
            AvailableQuestions = new List<string>(questions);
        }

        public void RemoveQuestion(string question)
        {
            if (AvailableQuestions.Contains(question))
            {
                AvailableQuestions.Remove(question);
                AskedQuestions.Add(question);
            }
        }

        public void UpdateRemainingCharacters(Func<Character, bool> predicate)
        {
            RemainingCharacters = RemainingCharacters.Where(predicate).ToList();
        }

        public void Reset(List<Character> characters, List<string> questions)
        {
            RemainingCharacters = new List<Character>(characters);
            AvailableQuestions = new List<string>(questions);
            AskedQuestions.Clear();
        }

        public bool IsGameOver()
        {
            return RemainingCharacters.Count <= 1;
        }
    }

}
