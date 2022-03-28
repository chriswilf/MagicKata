

namespace MagicKata
{
    public interface IMagicBook
    {
        public bool RunSpell();
        public Enchantment SelectEnchantment();
    }


    public class MagicBook : IMagicBook
    {

        public List<Enchantment> enchantments = new List<Enchantment>();
        public int LoseAllNum = 5;
        private IRandomGenerator magicNumber;

        public MagicBook(IRandomGenerator randomNum)
        {
           magicNumber = randomNum;
           PopulateEnchantments();
        }

        public virtual bool RunSpell()
        {
            var roll = magicNumber.Generate(1, 11);

            return roll == LoseAllNum ? false : true;
        }

        public  Enchantment SelectEnchantment()
        {
            var enchartElm = magicNumber.Generate(0, enchantments.Count());
            return enchantments.ElementAt(enchartElm);
        }

        private void PopulateEnchantments()
        {
            enchantments = new List<Enchantment>
            {
                new Enchantment {Type = "ice",Prefix = "Icy",Attribute = "+5 ice damage"},
                new Enchantment {Type = "fire",Prefix = "Inferno",Attribute = "+5 fire damage"},
                new Enchantment {Type = "lifesteal",Prefix = "Vampire",Attribute = "+5 lifesteal"},
                new Enchantment {Type = "agility",Prefix = "Quick",Attribute = "+5 agilty"},
                new Enchantment {Type = "strength",Prefix = "Angry",Attribute = $"+5 strength" }
            };
        }
    }

    public class Enchantment
    {
        public string Type { get; set; }
        public string Prefix { get; set; }
        public string Attribute { get; set; }
    }
}
