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

        /// <summary>
        /// Returns true or false if a line intersects a rectangle
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="rec"></param>
        /// <returns></returns>
        public bool LineIntersectsRectangle(Point one, Point two, Rectangle rec)
        {
            // quick checks for rectang
            if (one.X < rec.Left && two.X < rec.Left)
            {
                return false;
            }
            if (one.X > rec.Right && two.X > rec.Right)
            {
                return false;
            }
            if (one.Y < rec.Top && two.Y < rec.Top)
            {
                return false;
            }
            if (one.Y > rec.Bottom && two.Y > rec.Bottom)
            {
                return false;
            }
            int pointSum = 0;
            return true;
        }

        public Vector2 RotateVector(Vector2 oldVector, float rot)
        {
            float cosRot = (float)Math.Cos(rot);
            float sinRot = (float)Math.Sin(rot);
            float newX = (cosRot * oldVector.X) - (sinRot * oldVector.Y);
            float newY = (sinRot * oldVector.X) + (cosRot * oldVector.Y);
            return new Vector2(newX, newY);
        }

        public void HandleJump()
        {
            Enemy.Physics.HandleJump();
            if (!Enemy.Physics.IsJumping)
            {
                Enemy.Physics.MovementVelocity = Vector2.Zero;
            }
        }

        /// <summary>
        /// This provides the enemy with another state to enter within a certain time interval.
        /// </summary>
        public virtual void RandomStateChange()
        {
            DirectionChange = LoZGame.Instance.Random.Next(Enemy.MinMaxWander.X, Enemy.MinMaxWander.Y);
        }

        /// <summary>
        /// This allows an enemy to automatically face the player when it goes to attack, making the enemy a larger threat.
        /// </summary>
        public void FacePlayer()
        {
            Point playerLoc = LoZGame.Instance.Players[0].Physics.Bounds.Center - Enemy.Physics.Bounds.Center;
            if (Math.Abs(playerLoc.X) > Math.Abs(playerLoc.Y))
            {
                if (playerLoc.X < 0)
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.West;
                }
                else
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.East;
                }
            }
            else
            {
                if (playerLoc.Y < 0)
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.North;
                }
                else
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.South;
                }
            }
        }

        /// <summary>
        /// This makes an enemy prefer to move in the cardinal direction (north, south, east, or west) that is closest to the player's current location.
        /// </summary>
        /// <param name="weight">The affects how often the enemy will move toward the player.</param>
        public void FavorPlayerCardinal(int weight)
        {
            if (Math.Abs(weight) < 1)
            {
                weight = 1;
            }
            Enemy.States.Remove(StateType.MoveEast);
            Enemy.States.Remove(StateType.MoveNorth);
            Enemy.States.Remove(StateType.MoveWest);
            Enemy.States.Remove(StateType.MoveSouth);
            Vector2 toPlayer = UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());
            if (weight < 0)
            {
                toPlayer *= -1;
                weight *= -1;
            }
            if (toPlayer.X > 1 - MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.MoveEast, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveEast, 1);
            }
            if (toPlayer.X < -1 + MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.MoveWest, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveWest, 1);
            }
            if (toPlayer.Y > 1 - MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.MoveSouth, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveSouth, 1);
            }

            if (toPlayer.Y < -1 + MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.MoveNorth, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveNorth, 1);
            }
        }

        /// <summary>
        /// This makes an enemy prefer to move in the diagonal direction (north, south, east, or west) that is closest to the player's current location.
        /// </summary>
        /// <param name="weight">The affects how often the enemy will move toward the player.</param>
        public void FavorPlayerDiagonal(int weight)
        {
            if (Math.Abs(weight) < 1)
            {
                weight = 1;
            }
            Enemy.States.Remove(StateType.MoveNorthEast);
            Enemy.States.Remove(StateType.MoveNorthWest);
            Enemy.States.Remove(StateType.MoveSouthEast);
            Enemy.States.Remove(StateType.MoveSouthWest);
            Vector2 toPlayer = UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());
            if (weight < 0)
            {
                toPlayer *= -1;
                weight *= -1;
            }
            toPlayer.X *= -1;
            if (toPlayer.X > 0 && toPlayer.Y < 0)
            {
                Enemy.States.Add(StateType.MoveNorthEast, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveNorthEast, 1);
            }
            if (toPlayer.X < 0 && toPlayer.Y < 0)
            {
                Enemy.States.Add(StateType.MoveNorthWest, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveNorthWest, 1);
            }
            if (toPlayer.X > 0 && toPlayer.Y > 0)
            {
                Enemy.States.Add(StateType.MoveSouthEast, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveSouthEast, 1);
            }

            if (toPlayer.X < 0 && toPlayer.Y > 0)
            {
                Enemy.States.Add(StateType.MoveSouthWest, weight);
            }
            else
            {
                Enemy.States.Add(StateType.MoveSouthWest, 1);
            }
        }

        /// <summary>
        /// This makes an enemy prefer to jump in the cardinal direction (north, south, east, or west) that is closest to the player's current location.
        /// </summary>
        /// <param name="weight">The affects how often the enemy will move toward the player.</param>
        public void FavorPlayerJumpCardinal(int weight)
        {
            if (weight < 1)
            {
                weight = 1;
            }
            Enemy.States.Remove(StateType.JumpEast);
            Enemy.States.Remove(StateType.JumpNorth);
            Enemy.States.Remove(StateType.JumpWest);
            Enemy.States.Remove(StateType.JumpSouth);
            Vector2 toPlayer = UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());
            if (toPlayer.X > 1 - MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.JumpEast, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpEast, 1);
            }
            if (toPlayer.X < -1 + MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.JumpWest, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpWest, 1);
            }
            if (toPlayer.Y > 1 - MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.JumpSouth, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpSouth, 1);
            }

            if (toPlayer.Y < -1 + MathHelper.PiOver4)
            {
                Enemy.States.Add(StateType.JumpNorth, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpNorth, 1);
            }
        }

        /// <summary>
        /// This makes an enemy prefer to jump in the diagonal direction (north, south, east, or west) that is closest to the player's current location.
        /// </summary>
        /// <param name="weight">The affects how often the enemy will move toward the player.</param>
        public void FavorPlayerJumpDiagonal(int weight)
        {
            if (weight < 1)
            {
                weight = 1;
            }
            Enemy.States.Remove(StateType.JumpNorthEast);
            Enemy.States.Remove(StateType.JumpNorthWest);
            Enemy.States.Remove(StateType.JumpSouthEast);
            Enemy.States.Remove(StateType.JumpSouthWest);
            Vector2 toPlayer = UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());
            toPlayer.X *= -1;
            if (toPlayer.X > 0 && toPlayer.Y < 0)
            {
                Enemy.States.Add(StateType.JumpNorthEast, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpNorthEast, 1);
            }
            if (toPlayer.X < 0 && toPlayer.Y < 0)
            {
                Enemy.States.Add(StateType.JumpNorthWest, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpNorthWest, 1);
            }
            if (toPlayer.X > 0 && toPlayer.Y > 0)
            {
                Enemy.States.Add(StateType.JumpSouthEast, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpSouthEast, 1);
            }

            if (toPlayer.X < 0 && toPlayer.Y > 0)
            {
                Enemy.States.Add(StateType.JumpSouthWest, weight);
            }
            else
            {
                Enemy.States.Add(StateType.JumpSouthWest, 1);
            }
        }

        /// <summary>
        /// This allows the enemy to be aware of when it shares an X or Y coordinate with the player and change its state accordingly.
        /// </summary>
        public void CheckForLink()
        {
            int enemyX = (int)Enemy.Physics.Location.X;
            int enemyY = (int)Enemy.Physics.Location.Y;
            int linkX = (int)LoZGame.Instance.Players[0].Physics.Location.X;
            int linkY = (int)LoZGame.Instance.Players[0].Physics.Location.Y;

            if (Math.Abs(enemyX - linkX) <= GameData.Instance.EnemyMiscConstants.LinkPixelBuffer)
            {
                if ((linkY - enemyY) > 0)
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.South;
                }
                else
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.North;
                }
                Enemy.CurrentState.Attack();
            }
            else if (Math.Abs(enemyY - linkY) <= GameData.Instance.EnemyMiscConstants.LinkPixelBuffer)
            {
                if ((linkX - enemyX) > 0)
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.East;
                }
                else
                {
                    Enemy.Physics.CurrentDirection = Physics.Direction.West;
                }
                Enemy.CurrentState.Attack();
            }
        }
    }
}