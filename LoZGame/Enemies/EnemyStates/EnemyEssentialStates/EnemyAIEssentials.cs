﻿namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static RandomStateGenerator;

    public partial class EnemyStateEssentials
    {
        public void FavorPlayerCardinal(int weight)
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

        public void FavorPlayerDiagonal(int weight)
        {
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

        public void FavorDirection(RandomStateGenerator.StateType favorite)
        {
            // TODO: Get this to work. Should favor the favorite passed state over other states
            /*this.Enemy.States.Clear();
            foreach (KeyValuePair<RandomStateGenerator.StateType, int> state in GameData.Instance.DefaultEnemyStates.FireSnakeStatelist)
            {
                if (state.Key == favorite)
                {
                    this.Enemy.States.Add(state.Key, 1);
                } else
                {
                    this.Enemy.States.Add(state.Key, 1);
                }
            }*/
        }
    }
}