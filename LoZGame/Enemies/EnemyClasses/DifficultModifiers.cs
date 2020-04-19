namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class EnemyEssentials
    {
        public void ApplySmallSpeedMod()
        {
            this.MoveSpeed += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod;
            if (this.MoveSpeed < 1)
            {
                this.MoveSpeed = 1;
            }
        }

        public void ApplyLargeSpeedMod()
        {
            this.MoveSpeed += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeMoveMod;
            if (this.MoveSpeed < 1)
            {
                this.MoveSpeed = 1;
            }
        }

        public void ApplySmallWeightModPos()
        {
            this.Physics.Mass += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallWeightMod;
            if (this.Physics.Mass < 1)
            {
                this.Physics.Mass = 1;
            }
        }

        public void ApplyLargeWeightModPos()
        {
            this.Physics.Mass += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeWeightMod;
            if (this.Physics.Mass < 1)
            {
                this.Physics.Mass = 1;
            }
        }

        public void ApplySmallWeightModNeg()
        {
            this.Physics.Mass -= LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallWeightMod;
            if (this.Physics.Mass < 1)
            {
                this.Physics.Mass = 1;
            }
        }

        public void ApplyLargeWeightModNeg()
        {
            this.Physics.Mass -= LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeWeightMod;
            if (this.Physics.Mass < 1)
            {
                this.Physics.Mass = 1;
            }
        }

        public void ApplyDamageMod()
        {
            this.Damage += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.DamageMod;
            if (this.Damage < 1)
            {
                this.Damage = 1;
            }
        }

        public void ApplySmallHealthMod()
        {
            this.Health.MaxHealth += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallHealthMod;
            if (this.Health.MaxHealth < 2)
            {
                this.Health.MaxHealth = 2;
            }
            this.Health.CurrentHealth = this.Health.MaxHealth;
        }

        public void ApplyLargeHealthMod()
        {
            this.Health.MaxHealth += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeHealthMod;
            if (this.Health.MaxHealth < 4)
            {
                this.Health.MaxHealth = 4;
            }
            this.Health.CurrentHealth = this.Health.MaxHealth;
        }

    }
}
