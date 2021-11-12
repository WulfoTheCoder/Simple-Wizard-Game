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

                    if(toks[0] == "wizard-cast") {
                        if(toks.Length != 3) throw new Exception("Invalid number of arguments! wizard-cast command requires 2 arguments after it!");
                        
                        Spell spell = null;
                        Wizard wizard = null;

                        foreach(Wizard wiz in wizards) {
                            if(wiz.name == toks[1].Replace('_', ' ')) {
                                wizard = wiz;
                                break;
                            }
                        }

                        foreach(Spell spl in spells) {
                            if(spl.name == toks[2].Replace('_', ' ')) {
                                spell = spl;
                            }
                        }

                        wizard.CastSpell(spell);
                    }

                    if(toks[0] == "wizard-meditate") {
                        if(toks.Length != 2) throw new Exception("Invalid number of arguments! wizard-meditate command requires 1 argument after it!");

                        Wizard wizard = null;

                        foreach(Wizard wiz in wizards) {
                            if(wiz.name == toks[1].Replace('_', ' ')) {
                                wizard = wiz;
                                break;
                            }
                        }

                        wizard.Meditate();
                    }

                    if(toks[0] == "wizard-attack") {
                        if(toks.Length != 4) throw new Exception("Invalid number of arguments! wizard-attack command requires 3 arguments after it!");

                        Wizard attacker = null;
                        Wizard defender = null;
                        Spell usedSpell = null;

                        foreach(Wizard wiz in wizards) {
                            if(wiz.name == toks[1].Replace('_', ' ')) {
                                attacker = wiz;
                            }
                            if(wiz.name == toks[2].Replace('_', ' ')) {
                                defender = wiz;
                            }
                        }

                        foreach(Spell spl in spells) {
                            if(spl.name == toks[3].Replace('_', ' ')) {
                                usedSpell = spl;
                            }
                        }

                        attacker.Attack(defender, usedSpell);

                    }

                    if(toks[0] == "wizard-gainslot") {
                        if(toks.Length != 2) throw new Exception("Invalid number of arguments! wizard-gainslot requires 1 argument after it!");

                        Wizard wizard = null;

                        foreach(Wizard wiz in wizards) {
                            if(wiz.name == toks[1].Replace('_', ' ')) {
                                wizard = wiz;
                                break;
                            }
                        }

                        wizard.GainSlot();
                    }

                    if(toks[0] == "wizard-gainspell") {
                        if(toks.Length != 3) throw new Exception("Invalid number of arguments! wizard-gainspell must have 2 arguments after it!");

                        Wizard wizard = null;
                        Spell spell = null;

                        foreach(Wizard wiz in wizards) {
                            if(wiz.name == toks[1].Replace('_', ' ')) {
                                wizard = wiz;
                                break;
                            }
                        }

                        foreach(Spell spl in spells) {
                            if(spl.name == toks[2].Replace('_', ' ')) {
                                spell = spl;
                            }
                        }

                        wizard.GainSpell(spell);
                    }
                }

                // GENERAL INPUT //
                /*
                spell-new Adava_Kedabra damage 100
                spell-new Expelliarmus damage 10
                spell-new Some_Healing_Spell healing 10
                wizard-new Parry_Jopper Adava_Kedabra,Expelliarmus 2
                wizard-new Merry_Poppins Adava_Kedabra,Expelliarmus 2
                wizard-attack Parry_Jopper Merry_Poppins Expelliarmus
                wizard-gainslot Parry_Jopper
                wizard-gainspell Parry_Jopper Some_Healing_Spell
                break
                */

            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}