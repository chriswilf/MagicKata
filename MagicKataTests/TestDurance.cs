using MagicKata;
using System.Text;
using Xunit;
using FakeItEasy;
using System.Linq;

namespace MagicKataTests
{
    public class TestDurance
    {
        IRandomGenerator fakeNumberGen = A.Fake<IRandomGenerator>();
        IWeapon weapon = A.Fake<IWeapon>();
        IMagicBook book = A.Fake<IMagicBook>();
        

        [Fact]
        public void MagicBook_ShouldRunSpell()
        {
            Durance d = new Durance(weapon, book);
            
            A.CallTo(() => book.RunSpell()).Returns(true);
            var selectedEnchantment = A.CallTo(() => book.SelectEnchantment()).Returns(new Enchantment() { Type="ice"});
            var activeEnchantment = A.CallTo(() => weapon.GetActiveEnchantment()).Returns(new Enchantment() { Type = "fire" });

            d.Enchant();

            A.CallTo(() => book.RunSpell()).MustHaveHappened();
            
        }

        [Fact]
        public void MagicBook_ShouldSetEnchartment_OnSuccesfulSpell()
        {
          
            Durance d = new Durance(weapon, book);
            var enc = A.Fake<Enchantment>();
           
            A.CallTo(() => book.RunSpell()).Returns(true);
            var selectedEnchantment = A.CallTo(() => book.SelectEnchantment()).Returns(new Enchantment() { Type = "lifesteal" });
            var activeEnchantment = A.CallTo(() => weapon.GetActiveEnchantment()).Returns(new Enchantment() { Type = "fire" });
            A.CallTo(() => weapon.SetEnchantment(enc)).Returns(false);

            d.Enchant();
            Assert.Contains(d.DescribeWeapon(), "lifesteal");
        }


        [Fact]
        public void MagicBook_ShouldNotSetEnchartment_OnSameEnchantmentRoll()
        {
            Durance d = new Durance(weapon, book);
            
            A.CallTo(() => book.RunSpell()).Returns(true);
            var selectedEnchantment = A.CallTo(() => book.SelectEnchantment()).Returns(new Enchantment() { Type = "lifesteal" });
            var activeEnchantment = A.CallTo(() => weapon.GetActiveEnchantment()).Returns(new Enchantment() { Type = "lifesteal" });
          

            d.Enchant();
          
            A.CallTo(() => weapon.SetEnchantment(A.Fake<Enchantment>())).MustNotHaveHappened();
          
        }

        [Fact]
        public void MagicBook_ShouldClearEnchartment_OnFailedSpell()
        {
            Durance d = new Durance(weapon, book);

            A.CallTo(() => book.RunSpell()).Returns(false);
            
            d.Enchant();

            A.CallTo(() => weapon.ClearEnchantment()).MustHaveHappened();

        }



    }
}