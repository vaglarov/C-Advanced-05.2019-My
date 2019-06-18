using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {


        //        •	Name: string
        //•	Stat: Stat
        //•	Weapon: Weapon
        //•	GetTotalPower() : int – return the sum of the stat properties plus the sum of the weapon properties.
        //•	GetWeaponPower() : int - return the sum of the weapon properties.
        // •	GetStatPower(): int - return the sum of the stat properties.
        public Gladiator(string name, Stat stats, Weapon weapon)
        {
            
            Name = name;
            Stat = stats;
            Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetStatPower()
        {
            return this.Stat.Strength
                + this.Stat.Flexibility
             + this.Stat.Agility
            + this.Stat.Skills
            + this.Stat.Intelligence;
        }
        public int GetWeaponPower()
        {
            return this.Weapon.Size
             + this.Weapon.Solidity
             + this.Weapon.Sharpness;
        }
        public int GetTotalPower()
        {
            return GetStatPower() + GetWeaponPower();
        }
        public override string ToString()
        {
            return
            $"{Name} - {GetTotalPower()}" +
            $"{Environment.NewLine}  Weapon Power: {GetWeaponPower()}" +
            $"{Environment.NewLine}  Stat Power: {GetStatPower()}";

             
        }

    }
}
