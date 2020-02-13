using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    interface IUsableItem : IItemSprite
    {
        bool IsExpired { get; }

        int Instance { get; }

    }
}
