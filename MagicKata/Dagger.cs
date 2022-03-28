using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicKata
{
    public class Dagger : IWeapon
    {
        public List<Enchantment> enchantments = new List<Enchantment>();
        private bool ActiveEnchantment { get; set; } = false;
        public string Name { get; set; } = "Dagger";
        public string Attack { get; set; } = "5 - 10";
        public double Speed { get; set; } = 1.2;
        

        
        public string GetStats()
        {
            var baseStats = new WeaponStatsManager(this).GetBaseStats();
            
            if (ActiveEnchantment)
            {
                var enc = enchantments.FirstOrDefault();

                if (enc != null)
                {
                    return $"{enc.Prefix} {baseStats}\n{enc.Attribute}";
                }
            }

            return baseStats;
        }

        public void ClearEnchantment()
        {
            enchantments.Clear();
            ActiveEnchantment = false;
        }

        public bool SetEnchantment(Enchantment enchartment)
        {
            if (IsEnchantmentActive())
            {
                ClearEnchantment();
            }
            else
            {
                enchantments.Add(enchartment);
            }

            return ActiveEnchantment = true;
        }

        public bool IsEnchantmentActive()
        {
            return enchantments.Count > 0;
        }

        public Enchantment? GetActiveEnchantment()
        {
            return enchantments.FirstOrDefault();
        }


    }
}
