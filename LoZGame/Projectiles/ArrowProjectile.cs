﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class ArrowProjectile : ProjectileEssentials, IProjectile
    {

        private ProjectileDamageData projectileDamageData;
        private ProjectileSpeedData projectileSpeedData;

        public ArrowProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.ArrowWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.ArrowHeight;
            this.Offset = this.Heigth / 2;
            this.Physics.Mass = 10;
            this.Speed = projectileSpeedData.LinkArrowSpeed;
            this.Damage = projectileDamageData.LinkArrowDamage;
            this.Source = source;
            this.InitializeDirection();
            if (this.Physics.CurrentDirection == Physics.Direction.East || this.Physics.CurrentDirection == Physics.Direction.West)
            {
                this.CorrectProjectile();
            }
            this.Sprite = ProjectileSpriteFactory.Instance.Arrow();
        }
    }
}
