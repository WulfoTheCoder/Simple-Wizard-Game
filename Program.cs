using System;

namespace WizardSimulator {
    class Program {
        static void Main(string[] args) {
            try {
                string command = "";

                List<Spell> spells = new List<Spell>();
                List<Wizard> wizards = new List<Wizard>();

                while(command != "break") {
                    command = Console.ReadLine();
                    string[] toks = command.Split(' ');
                    
                    if(toks[0] == "spell-new") {
                        if(toks.Length != 4) {
                            throw new Exception("Invalid number of arguments! spell-new command should have 3 arguments after it!");
                        }
                        Spell generatedSpell = new Spell(toks[1].Replace('_', ' '), toks[2], float.Parse(toks[3]));
                        spells.Add(generatedSpell);
                    }

                    if(toks[0] == "wizard-new") {
                        if(toks.Length != 4) throw new Exception("Invalid number of arguments! wizard-new command should have 3 arguments after it!");
                        string[] spellNames = toks[2].Split(',');
                        List<Spell> generatedSpells = new List<Spell>();

                        foreach(string spellName in spellNames) {
                            foreach(Spell spell in spells) {
                                if(spellName.Replace('_', ' ') == spell.name) {
                                    generatedSpells.Add(spell);
                                }
                            }
                        }

                        if(generatedSpells.Count <= 0) {
                            throw new Exception("No assigned spells to this wizard");
                        }

                        Wizard generatedWizard = new Wizard(toks[1].Replace('_', ' '), generatedSpells, int.Parse(toks[3]));
                        wizards.Add(generatedWizard);
                    }
                }

                Console.WriteLine("\nSpells generated:");
                foreach(Spell spell in spells) {
                    Console.WriteLine("\t" + spell.name);
                }
                
                Console.WriteLine("\nWizards generated:");
                foreach(Wizard wiz in wizards) {
                    Console.WriteLine("\t" + wiz.name);
                }
                
                // GENERAL INPUT
                // spell-new Adava_Kedabra damage 100
                // wizard-new Merry_Poppins Adava_Kedabra 1
                // break

            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}