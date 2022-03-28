using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicKata
{
    public interface IRandomGenerator
    {
        int Generate(int min, int max);
    }

    public class MagicNumber : IRandomGenerator
    {
        public int Generate(int min, int max)
        {
            return (new Random()).Next(min, max);
        }
    }
}
