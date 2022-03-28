using MagicKata;
using System.Text;
using Xunit;
using FakeItEasy;
using System.Linq;

namespace MagicKataTests
{
    public class TestMagicBook
    {
        IRandomGenerator fakeNumberGen = A.Fake<IRandomGenerator>();
        IWeapon weapon = A.Fake<IWeapon>();

        [Fact]
        public void MagicBookCreated_ShouldPopulate_Enchantments()
        {
            MagicBook mb = new MagicBook(fakeNumberGen);
            Assert.True(mb.enchantments.Count == 5);
        }

        [Fact]
        public void MagicBookSpellRun_Success_whenNotLoseAllNum()
        {
            MagicBook mb = new MagicBook(fakeNumberGen);
            mb.LoseAllNum = 5;
            
            var num = A.CallTo(() => fakeNumberGen.Generate(1, 11)).Returns(3);

            Assert.True(mb.RunSpell());
        }

        [Fact]
        public void MagicBookSpellRun_Fail_OnLoseAllNum()
        {
            MagicBook mb = new MagicBook(fakeNumberGen);
            mb.LoseAllNum = 5;

            var num = A.CallTo(() => fakeNumberGen.Generate(1, 11)).Returns(5);

            Assert.False(mb.RunSpell());
        }

        [Fact]
        public void MagicBook_ShouldSelectFirst_EnchartmentIce()
        {
            MagicBook mb = new MagicBook(fakeNumberGen);

            var num = A.CallTo(() => fakeNumberGen.Generate(0, 5)).Returns(1);
           
            var ench = mb.SelectEnchantment();

            Assert.Equal("fire", ench.Type);
        }



        

    }
}