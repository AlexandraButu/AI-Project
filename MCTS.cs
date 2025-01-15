private GameState gameState;

public MCTS(GameState state)
{
    gameState = state;
}

public string SelectBestQuestion()
{
    if (gameState.AvailableQuestions.Count == 0)
        return string.Empty;

    Dictionary<string, double> questionScores = new Dictionary<string, double>();

    foreach (var question in gameState.AvailableQuestions)
    {
        double score = 0;
        var remainingCharactersIfYes = SimulateRemainingCharacters(question, true);
        double probabilityYes = (double)remainingCharactersIfYes.Count / gameState.RemainingCharacters.Count;


        var remainingCharactersIfNo = SimulateRemainingCharacters(question, false);
        double probabilityNo = (double)remainingCharactersIfNo.Count / gameState.RemainingCharacters.Count;

        score = (1 - probabilityYes) * remainingCharactersIfYes.Count +
                (1 - probabilityNo) * remainingCharactersIfNo.Count;

        questionScores[question] = score;
    }


    return questionScores.OrderByDescending(q => q.Value).First().Key;
}

private List<Character> SimulateRemainingCharacters(string question, bool answer)
{
    var remainingCharacters = new List<Character>();

    foreach (var character in gameState.RemainingCharacters)
    {
        if (answer)
        {
            if (CharacterMatchesQuestion(character, question))
                remainingCharacters.Add(character);
        }
        else
        {
            if (!CharacterMatchesQuestion(character, question))
                remainingCharacters.Add(character);
        }
    }

    return remainingCharacters;
}


private bool CharacterMatchesQuestion(Character character, string question)
{
    switch (question)
    {
        case "Personajul are par blond?":
            return character.HairColor == "Blond";
        case "Personajul are par negru?":
            return character.HairColor == "Negru";
        case "Personajul are par castaniu?":
            return character.HairColor == "Castaniu";
        case "Personajul are barba sau mustata?":
            return character.HasBeardOrMustache;
        case "Personajul este femeie?":
            return character.Gender == "F";
        case "Personajul este barbat?":
            return character.Gender == "M";
        case "Personajul are palarie?":
            return character.WearsHat;
        case "Personajul este tanar?":
            return character.EstimatedAge == "Tanar";
        case "Personajul este matur?":
            return character.EstimatedAge == "Matur";
        case "Personajul este senior?":
            return character.EstimatedAge == "Senior";
        case "Personajul poartă ochelari?":
            return character.HasGlasses;
        default:
            return false;
    }
}
