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
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.ArrowWidth;
            Heigth = ProjectileSpriteFactory.Instance.ArrowHeight;
            Offset = Heigth / 2;
            Physics.Mass = 10;
            Speed = GameData.Instance.ProjectileSpeedConstants.LinkArrowSpeed;
            Damage = GameData.Instance.ProjectileDamageConstants.LinkArrowDamage;
            Source = source;
            InitializeDirection();
            if (Physics.CurrentDirection == Physics.Direction.East || Physics.CurrentDirection == Physics.Direction.West)
            {
                CorrectProjectile();
            }
            Sprite = ProjectileSpriteFactory.Instance.Arrow();
            Physics.Mass = GameData.Instance.ProjectileMassConstants.ArrowMass;
        }
    }
}
