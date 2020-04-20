namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static RandomStateGenerator;

    public partial class EnemyStateEssentials
    {
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

        /// <summary>
        /// This provides the enemy with another state to enter within a certain time interval.
        /// </summary>
        public virtual void RandomDirectionChange()
        {
            this.DirectionChange = LoZGame.Instance.Random.Next(this.Enemy.MinMaxWander.X, this.Enemy.MinMaxWander.Y);
        }

        /// <summary>
        /// This allows an enemy to automatically face the player when it goes to attack, making the enemy a larger threat.
        /// </summary>
        public void FacePlayer()
        {
            Point playerLoc = LoZGame.Instance.Players[0].Physics.Bounds.Center - this.Enemy.Physics.Bounds.Center;
            if (Math.Abs(playerLoc.X) > Math.Abs(playerLoc.Y))
            {
                if (playerLoc.X < 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
                }
            }
            else
            {
                if (playerLoc.Y < 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
                }
            }
        }

        /// <summary>
        /// This makes an enemy prefer to move in the cardinal direction (north, south, east, or west) that is closest to the player's current location.
        /// </summary>
        /// <param name="weight">The affects how often the enemy will move toward the player.</param>
        public void FavorPlayerCardinal(int weight)
        {
            if (weight < 1)
            {
                weight = 1;
            }
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

        /// <summary>
        /// This makes an enemy prefer to move in the diagonal direction (north, south, east, or west) that is closest to the player's current location.
        /// </summary>
        /// <param name="weight">The affects how often the enemy will move toward the player.</param>
        public void FavorPlayerDiagonal(int weight)
        {
            if (weight < 1)
            {
                weight = 1;
            }
            this.Enemy.States.Remove(StateType.MoveNorthEast);
            this.Enemy.States.Remove(StateType.MoveNorthWest);
            this.Enemy.States.Remove(StateType.MoveSouthEast);
            this.Enemy.States.Remove(StateType.MoveSouthWest);
            Vector2 toPlayer = UnitVectorToPlayer(this.Enemy.Physics.Bounds.Center.ToVector2());
            toPlayer.X *= -1;
            if (toPlayer.X > 0 && toPlayer.Y < 0)
            {
                this.Enemy.States.Add(StateType.MoveNorthEast, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveNorthEast, 1);
            }
            if (toPlayer.X < 0 && toPlayer.Y < 0)
            {
                this.Enemy.States.Add(StateType.MoveNorthWest, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveNorthWest, 1);
            }
            if (toPlayer.X > 0 && toPlayer.Y > 0)
            {
                this.Enemy.States.Add(StateType.MoveSouthEast, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveSouthEast, 1);
            }

            if (toPlayer.X < 0 && toPlayer.Y > 0)
            {
                this.Enemy.States.Add(StateType.MoveSouthWest, weight);
            }
            else
            {
                this.Enemy.States.Add(StateType.MoveSouthWest, 1);
            }
        }

        /// <summary>
        /// This allows the enemy to be aware of when it share's an X or Y coordinate with the player and change its state accordingly.
        /// </summary>
        public void CheckForLink()
        {
            int enemyX = (int)this.Enemy.Physics.Location.X;
            int enemyY = (int)this.Enemy.Physics.Location.Y;
            int linkX = (int)LoZGame.Instance.Players[0].Physics.Location.X;
            int linkY = (int)LoZGame.Instance.Players[0].Physics.Location.Y;

            if (Math.Abs(enemyX - linkX) <= GameData.Instance.EnemyMiscConstants.LinkPixelBuffer)
            {
                if ((linkY - enemyY) > 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
                }
                this.Enemy.CurrentState.Attack();
            }
            else if (Math.Abs(enemyY - linkY) <= GameData.Instance.EnemyMiscConstants.LinkPixelBuffer)
            {
                if ((linkX - enemyX) > 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
                }
                this.Enemy.CurrentState.Attack();
            }
        }
    }
}
