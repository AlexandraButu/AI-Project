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
    }

}
