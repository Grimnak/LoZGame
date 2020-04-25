using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public partial class EnemyStateEssentials
    {
        public void UpdateLikelike()
        {
            DefaultUpdate();
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.LikelikeFavorCardinalValue);
            }
        }
    }
}
