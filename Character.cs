using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIA
{
    public class Character
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public bool HasGlasses { get; set; }
        public bool WearsHat { get; set; }
        public bool HasBeardOrMustache { get; set; }
        public string EstimatedAge { get; set; }
        public string ImagePath { get; set; }

        // Constructor
        public Character(string name, string gender, string hairColor, bool hasGlasses, bool wearsHat, bool hasBeardOrMustache, string estimatedAge, string imagePath)
        {
            Name = name;
            Gender = gender;
            HairColor = hairColor;
            HasGlasses = hasGlasses;
            WearsHat = wearsHat;
            HasBeardOrMustache = hasBeardOrMustache;
            EstimatedAge = estimatedAge;
            ImagePath = imagePath;
        }

        public bool CharacterMatchesQuestion(string question)
        {
            switch (question)
            {
                case "Personajul are par blond?":
                    return HairColor == "Blond";
                case "Personajul are par negru?":
                    return HairColor == "Negru";
                case "Personajul are par castaniu?":
                    return HairColor == "Castaniu";
                case "Personajul are barba sau mustata?":
                    return HasBeardOrMustache;
                case "Personajul este femeie?":
                    return Gender == "F";
                case "Personajul este barbat?":
                    return Gender == "M";
                case "Personajul are palarie?":
                    return WearsHat;
                case "Personajul este tanar?":
                    return EstimatedAge == "Tanar";
                case "Personajul este matur?":
                    return EstimatedAge == "Matur";
                case "Personajul este senior?":
                    return EstimatedAge == "Senior";
                case "Personajul poartă ochelari?":
                    return HasGlasses;
                default:
                    return false; // Intrebarea nu corespunde niciunei trasaturi
            }
        }
    }

}
