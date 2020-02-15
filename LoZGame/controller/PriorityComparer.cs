﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    class PriorityComparer : IComparer<KeyValuePair<Keys, ICommand>>
    {
        public int Compare(KeyValuePair<Keys, ICommand> x, KeyValuePair<Keys, ICommand> y)
        {
            if (x.Value.Priority > y.Value.Priority)
            {
                return -1;
            }
            else if (x.Value.Priority < y.Value.Priority)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    
    }
}