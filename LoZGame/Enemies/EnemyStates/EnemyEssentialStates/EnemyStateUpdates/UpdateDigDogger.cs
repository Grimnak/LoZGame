namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateLargeDigDogger()
        {
            DefaultUpdate();
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DigDoggerFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.DigDoggerFavorDiagonalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }

        public void UpdateSmallDigDogger()
        {
            DefaultUpdate();
            Point playerDist = this.Enemy.Physics.Bounds.Center - LoZGame.Instance.Players[0].Physics.Bounds.Center;
            if (Math.Abs(playerDist.X) + Math.Abs(playerDist.Y) <= 4 * BlockSpriteFactory.Instance.TileWidth)
            {
                FavorPlayerCardinal(-(GameData.Instance.EnemyMiscConstants.DigDoggerFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                FavorPlayerDiagonal(-(GameData.Instance.EnemyMiscConstants.DigDoggerFavorDiagonalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                this.Enemy.UpdateState();
                this.Lifetime = 0;
                RandomStateChange(); 
                FavorPlayerCardinal(1);
                FavorPlayerDiagonal(1);
            }
        }
    }
}