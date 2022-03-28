using MagicKata;

public class Program
{
    static void Main()
    {
        Durance d = new Durance(new Dagger(), new MagicBook(new MagicNumber()));

        while (true)
        {
            d.Enchant();

            Console.WriteLine(d.DescribeWeapon());

            Console.WriteLine("Roll again? y/n");
            if(!Console.ReadLine().StartsWith("y")) break;
        }
    }
}

public class Durance
{
    IWeapon weapon;
    IMagicBook magicBook;
    IRandomGenerator magicNum;
    public Durance(IWeapon Weapon, IMagicBook book)
    {
        weapon = Weapon;
        magicBook = book;
    }

    public void Enchant()
    {
        if (magicBook.RunSpell())
        {
            var selectedEnchantment = magicBook.SelectEnchantment();
            var activeEnchantment = weapon.GetActiveEnchantment();
            
            if(selectedEnchantment.Type != activeEnchantment?.Type)
                weapon.SetEnchantment(selectedEnchantment);
        }
        else
        {
            weapon.ClearEnchantment();
        }
    }

    public string DescribeWeapon()
    {
        return weapon.GetStats();
    }
}





