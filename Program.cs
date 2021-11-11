using System;

namespace WizardSimulator {
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
                Wizard wizard02 = new Wizard("Marry Jopper", new List<Spell>{someHealingSpell, unexpectoPatronum}, 2);
                
                // Make them fight
                wizard01.Attack(wizard02, unexpectoPatronum);
                wizard02.CastSpell(someHealingSpell);
                wizard02.Attack(wizard01, unexpectoPatronum);
                wizard02.Attack(wizard01, unexpectoPatronum);
                wizard02.Meditate();
                wizard02.GainSlot();
                wizard01.Attack(wizard02, unexpectoPatronum);
                wizard02.CastSpell(someHealingSpell);
                wizard01.Attack(wizard02, unexpectoPatronum);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}