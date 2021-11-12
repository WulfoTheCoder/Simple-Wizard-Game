using System;

namespace WizardSimulator {
    class Spell {
        public static List<string> spellTypes = new List<string>();

        public string name;
        public string spellType;

        public float spellFactor;

        public Spell(string name_, string spellType_, float factor_) {
            name = name_;

            spellType = spellType_;
            if(spellType != "misc")
                spellFactor = factor_;
            else
                spellFactor = 0f;
            if(spellTypes.Count == 0) {
                Spell.spellTypes.Add("healing");
                Spell.spellTypes.Add("damage");
                Spell.spellTypes.Add("misc");
            }

            bool foundSplType = false;
            foreach(string spltype in spellTypes) {
                if(spltype == spellType) {
                    foundSplType = true;
                }
            }

            if(!foundSplType) {
                throw new Exception("Invalid Spell Type!");
            }
        }
    }
}
// v2.1
