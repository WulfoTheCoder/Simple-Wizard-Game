using System;

namespace WizardSimulator {
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
            if (defender == this) throw new Exception("Wizards cannot attack themselves. If you want for wizards to cast spells on themselves use the CastSpell() method!");
            if(currentSpellSlots > 0) {
                defender.GetCasted(spellAgainst, this);
                if(defender.health <= 0 && !defender.dead) {
                    defender.Die();
                }
                currentSpellSlots--;
            }
        }

        public void GainSlot() {
            spellSlots++;
            currentSpellSlots++;
            Console.WriteLine(name + " just gained 1 more spell slot!");
        }

        public void GainSpell(Spell spell_) {
            spells.Add(spell_);
            Console.WriteLine(name + " just gained " + spell_.name);
        }

        public void Die() {
            Console.WriteLine(name + " died!");
            dead = true;
        }
    }
}