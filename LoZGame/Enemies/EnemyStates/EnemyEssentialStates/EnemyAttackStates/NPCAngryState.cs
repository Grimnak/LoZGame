﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class NPCAngryState : EnemyStateEssentials, IEnemyState
    {
        public NPCAngryState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.Physics.MovementVelocity = Vector2.Zero;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
        }
    }
}
