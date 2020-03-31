using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class ArrowProjectile : ProjectileEssentials, IProjectile
    {
        public ArrowProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.ArrowWidth;
            this.Height = ProjectileSpriteFactory.Instance.ArrowHeight;
            this.Offset = (this.Height * 3) / 4;
            this.Speed = 5;
            this.Damage = 2;
            this.Source = source;
            this.InitializeDirection();
            this.Sprite = ProjectileSpriteFactory.Instance.Arrow();
        }
    }
}
