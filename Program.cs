using System;

namespace CS_Project {
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

    class Wizard {
        public static int Count;

        public int spellSlots;
        public int currentSpellSlots;
        public string name;
        public List<Spell> spells;
        public int health;
        public bool dead;

        public Wizard(string name_, List<Spell> spells_, int spellSlots_) {
            Count++;
            name = name_;
            spellSlots = spellSlots_;
            currentSpellSlots = spellSlots;
            spells = spells_;
            health = 100;
            if(spells_.Count > spellSlots) throw new Exception("Invalid amount of spells passed to the wizard!");
        }

        public void CastSpell(Spell spell_) {
            bool foundSpell = false;
            foreach (Spell spell in spells) {
                if(spell == spell_) {
                    foundSpell = true;
                    break;
                }
            }
            if(foundSpell) {
                if(currentSpellSlots > 0) {
                    Console.WriteLine(name + " casted " + spell_.name + " on himself");
                    currentSpellSlots--;
                } else {
                    Console.WriteLine(name + " doesn't have any spell slots! He needs to meditate to regain them!");
                }
            } else {
                Console.WriteLine(name + " doesn't have " + spell_.name);
            }

            if(spell_.spellType == "healing") {
                health += (int) spell_.spellFactor;
                if(health > 100) {
                    health = 100;
                }
            }

            if(spell_.spellType == "damage") {
                health -= (int) spell_.spellFactor;
                if(health <= 0) {
                    Die();
                }
            }
        }

        public void Meditate() {
            Console.WriteLine(name + " is meditating to regain spell slots!");
            currentSpellSlots = spellSlots;
            health = 100;
        }

        void GetCasted(Spell spell, Wizard attackee) {
            if(health > 0) {
                if (spell.spellType == "healing") {
                    health += (int) spell.spellFactor;
                    if(health > 100) health = 100;
                    Console.WriteLine(name + " got healed by " + attackee.name + " with " + spell.name);
                }
                else if (spell.spellType == "damage") {
                    health -= (int) spell.spellFactor;
                    Console.WriteLine(name + " got damaged by " + attackee.name + " with " + spell.name);
                }
                else if(spell.spellType == "misc") {
                    Console.WriteLine(attackee.name + " just threw " + spell.name + " at " + name);
                }
            }
        }

        public void Attack(Wizard defender, Spell spellAgainst) {
            if(currentSpellSlots > 0) {
                defender.GetCasted(spellAgainst, this);
                if(defender.health <= 0 && !defender.dead) {
                    defender.Die();
                }
                currentSpellSlots--;
            }
        }

        public void Die() {
            Console.WriteLine(name + " died!");
            dead = true;
        }
    }

    class Program {
        static void Main(string[] args) {
            try {
                // Addany spell you like
                Spell abrakadabra = new Spell("Avada Kedavra", "damage", 100f);
                Spell unexpectoPatronum = new Spell("Unexpecto Patronum", "damage", 10f);
                Spell reparo = new Spell("Reparo", "misc", 0f);
                Spell someHealingSpell = new Spell("Some Healing Spell", "healing", 10f);

                // Create custom wizards with the list of available spells for them
                Wizard wizard01 = new Wizard("Parry Hopper", new List<Spell>{abrakadabra, unexpectoPatronum, reparo, someHealingSpell}, 4);
                Wizard wizard02 = new Wizard("Marry Jopper", new List<Spell>{reparo}, 1);
                
                // Make them fight
                wizard01.Attack(wizard02, unexpectoPatronum);
                wizard01.Attack(wizard02, someHealingSpell);
                wizard01.Attack(wizard02, abrakadabra);

                // Make your wizard cast spells
                wizard01.CastSpell(abrakadabra);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}