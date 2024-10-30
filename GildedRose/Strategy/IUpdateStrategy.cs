using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Stratege
{
    public interface IUpdateStrategy
    {
        void Update(Item item);
    }
}
