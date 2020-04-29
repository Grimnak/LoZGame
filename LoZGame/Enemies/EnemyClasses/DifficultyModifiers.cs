namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class EnemyEssentials
    {
        public void ApplySmallSpeedMod()
        {
            //MoveSpeed += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod;
            if (MoveSpeed < 1)
            {
                MoveSpeed = 1;
            }
        }

        public void ApplyLargeSpeedMod()
        {
            //MoveSpeed += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeMoveMod;
            if (MoveSpeed < 1)
            {
                MoveSpeed = 1;
            }
        }

        public void ApplySmallWeightModPos()
        {
            Physics.Mass += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallWeightMod;
            if (Physics.Mass < 1)
            {
                Physics.Mass = 1;
            }
        }

        public void ApplyLargeWeightModPos()
        {
            Physics.Mass += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeWeightMod;
            if (Physics.Mass < 1)
            {
                Physics.Mass = 1;
            }
        }

        public void ApplySmallWeightModNeg()
        {
            Physics.Mass -= LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallWeightMod;
            if (Physics.Mass < 1)
            {
                Physics.Mass = 1;
            }
        }

        public void ApplyLargeWeightModNeg()
        {
            Physics.Mass -= LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeWeightMod;
            if (Physics.Mass < 1)
            {
                Physics.Mass = 1;
            }
        }

        public void ApplyDamageMod()
        {
            //Damage += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.DamageMod;
            if (Damage < 1)
            {
                Damage = 1;
            }
        }

        public void ApplySmallHealthMod()
        {
            Health.MaxHealth += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallHealthMod;
            if (Health.MaxHealth < 2)
            {
                Health.MaxHealth = 2;
            }
            Health.CurrentHealth = Health.MaxHealth;
        }

        public void ApplyLargeHealthMod()
        {
            Health.MaxHealth += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeHealthMod;
            if (Health.MaxHealth < 4)
            {
                Health.MaxHealth = 4;
            }
            Health.CurrentHealth = Health.MaxHealth;
        }

    }
}
