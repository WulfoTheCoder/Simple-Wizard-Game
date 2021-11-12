# Wizard Game Docs

spell-new {Spell_Name} {Spell_Type(damage, healing or misc)} {Spell_Factor} - Creates a new spell

wizard-new {Wizard_Name} {Spells that the wizard can use separated by ',' (no space after a comma)} {Number of spell slots(Must be >= number of spells in the previous arguments)} - Creates a new wizard

wizard-cast {Wizard_Name} {Spell_Name} - Wizard will cast a spell on himself. If the type of the spell is "damage" the wizard will hurt himself, and if the type is set to "healing" wizard will heal himself

wizard-attack {Attacker_Wizard_Name} {Defender_Wizard_Name} {Spell_Name} - Attacker wizard will throw the spell at the defender wizard. Despite the name, Attacker can cast a healing spell onto the defender wizard, which is going to heal the defender wizard

wizard-meditate {Wizard_Name} - Wizard will meditate to regain spell slots after he's lost them by casting or attacking

wizard-gainslot {Wizard_Name} - Wizard will gain 1 more spell slot, which can be used as a "backpack" for potions. Every time he casts a spell/attacks another wizard he losses 1 spell slot

wizard-gainspell {Wizard_Name} {Spell_Name} - Wizard will gain the spell, but only if he has enough spell slots to fit the new spell