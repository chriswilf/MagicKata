using MagicKata;
using System.Text;
using Xunit;

namespace MagicKataTests
{
    public class TestDagger
    {
        private IWeapon dagger ;
        private WeaponStatsManager statsManager;

        private void SetupWeapon()
        {
            dagger = new Dagger();
            statsManager = new WeaponStatsManager(dagger);
        }

        [Fact]
        public void StatsManager_PrintsExpected_DaggerBaseStats()
        {
            SetupWeapon();

            string FullName = $"{dagger.Name} of the Nooblet";
            string AttackDamage = $"{dagger.Attack} attack damage";
            string WeaponSpeed = $"{dagger.Speed} attack speed";
            
            var stats = $"{FullName}\n{AttackDamage}\n{WeaponSpeed}";

            Assert.Equal(stats, statsManager.GetBaseStats());
        }


        [Fact]
        public void WhenEnchantmentInactive_Dagger_PrintsBaseStats()
        {
            SetupWeapon();

            string FullName = $"{dagger.Name} of the Nooblet";
            string AttackDamage = $"{dagger.Attack} attack damage";
            string WeaponSpeed = $"{dagger.Speed} attack speed";

            var stats = $"{FullName}\n{AttackDamage}\n{WeaponSpeed}";

            Assert.Equal(stats, statsManager.GetBaseStats());
        }

        [Fact]
        public void WhenEnchantmentSet_EnchartmentActive()
        {
            SetupWeapon();
            
            var ench = new Enchantment { Type = "ice", Prefix = "Icy", Attribute = "+5 ice damage" };
         
            dagger.SetEnchantment(ench);

            Assert.True(dagger.IsEnchantmentActive());
        }


        [Fact]
        public void WhenEnchantmentCleared_EnchartmentNotActive()
        {
            SetupWeapon();

            dagger.ClearEnchantment();

            Assert.False(dagger.IsEnchantmentActive());
        }

        [Fact]
        public void WhenEnchantmentSet_ActiveEnachartmentReturned()
        {
            SetupWeapon();

            var ench = new Enchantment { Type = "ice", Prefix = "Icy", Attribute = "+5 ice damage" };

            dagger.SetEnchantment(ench);

            Assert.Equal(ench, dagger.GetActiveEnchantment());
        }
        [Fact]
        public void WhenEnchantmentCleard_ActiveEnachartmentReturnsNull()
        {
            SetupWeapon();

            dagger.ClearEnchantment();

            Assert.Null(dagger.GetActiveEnchantment());
        }

    }
}