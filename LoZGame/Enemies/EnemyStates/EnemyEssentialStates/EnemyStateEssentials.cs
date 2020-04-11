namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public ISprite Sprite { get; set; }

        public int DirectionChange { get; set; }

        public int Lifetime { get; set; }

        public IEnemy Enemy { get; set; }

        public Vector2 UnitVectorToPlayer(Vector2 origin)
        {
            Vector2 unitVector = LoZGame.Instance.Link.Physics.Bounds.Center.ToVector2() - origin;
            unitVector.Normalize();
            return unitVector;
        }

        public Vector2 RotateVector(Vector2 oldVector, float rot)
        {
            float cosRot = (float)Math.Cos(rot);
            float sinRot = (float)Math.Sin(rot);
            float newX = (cosRot * oldVector.X) - (sinRot * oldVector.Y);
            float newY = (sinRot * oldVector.X) + (cosRot * oldVector.Y);
            return new Vector2(newX, newY);
        }

        public virtual void RandomDirectionChange()
        {
            this.DirectionChange = LoZGame.Instance.Random.Next(GameData.Instance.EnemyMiscData.MinDirectionChange, GameData.Instance.EnemyMiscData.MaxDirectionChange);
        }

        public virtual void Update()
        {
            Console.WriteLine("EnemyStateEssentials: Attempted to  Update");
            this.Lifetime++;
            if (this.Lifetime > this.DirectionChange)
            {
                this.Enemy.UpdateState();
                this.Lifetime = 0;
            }
            this.Sprite.Update();
            Console.WriteLine("EnemyStateEssentials: Successfully Update");
        }

        public virtual void Draw()
        {
            this.Sprite.Draw(this.Enemy.Physics.Location, this.Enemy.CurrentTint, this.Enemy.Physics.Depth);
        }

    }
}
