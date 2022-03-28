

namespace MagicKata
{
    public interface IWeapon
    {
        string Name { get; set; }
        string Attack { get; set; }
        double Speed { get; set; }
        string GetStats();
        void ClearEnchantment();
        bool SetEnchantment(Enchantment enchartment);
        bool IsEnchantmentActive();
        Enchantment? GetActiveEnchantment();
    }

    

    public class WeaponStatsManager 
    {
        IWeapon weapon;
        private string FullName = "{0} of the Nooblet";
        private string AttackDamage = "{0} attack damage";
        private string WeaponSpeed = "{0} attack speed";
        public List<Enchantment> enchantments = new List<Enchantment>();

        public WeaponStatsManager(IWeapon Weapon)
        {
            weapon = Weapon;
        }

        public  string GetBaseStats()
        {
           return $"{string.Format(FullName, weapon.Name)}\n{string.Format(AttackDamage, weapon.Attack)}\n{string.Format(WeaponSpeed, weapon.Speed.ToString())}";
        }

    }
}
