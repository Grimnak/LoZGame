namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static RandomStateGenerator;

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

        public void FavorPlayer(int weight)
        {
            this.Enemy.States.Remove(StateType.MoveEast);
            this.Enemy.States.Remove(StateType.MoveNorth);
            this.Enemy.States.Remove(StateType.MoveWest);
            this.Enemy.States.Remove(StateType.MoveSouth);
            Vector2 toPlayer = UnitVectorToPlayer(this.Enemy.Physics.Bounds.Center.ToVector2());
            if (toPlayer.X > 1 - MathHelper.PiOver4)
            {
                this.Enemy.States.Add(StateType.MoveEast, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveEast, 1);
            }
            if (toPlayer.X < -1 + MathHelper.PiOver4)
            {
                this.Enemy.States.Add(StateType.MoveWest, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveWest, 1);
            }
            if (toPlayer.Y > 1 - MathHelper.PiOver4)
            {
                this.Enemy.States.Add(StateType.MoveSouth, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveSouth, 1);
            }

            if (toPlayer.Y < -1 + MathHelper.PiOver4)
            {
                this.Enemy.States.Add(StateType.MoveNorth, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveNorth, 1);
            }
        }

        public virtual void Update()
        {
            this.Lifetime++;
            if (this.Lifetime > this.DirectionChange)
            {
                this.Enemy.UpdateState();
                this.Lifetime = 0;
            }
            this.Sprite.Update();
        }

        public virtual void Draw()
        {
            this.Sprite.Draw(this.Enemy.Physics.Location, this.Enemy.CurrentTint, this.Enemy.Physics.Depth);
        }
    }
}
