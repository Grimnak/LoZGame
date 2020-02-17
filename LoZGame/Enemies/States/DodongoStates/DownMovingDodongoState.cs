﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DownMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IDodongoSprite sprite;

        public DownMovingDodongoState(IEnemy dodongo)
        {
            this.dodongo = (Dodongo)dodongo;
            sprite = EnemySpriteFactory.Instance.createDownMovingDodongoSprite();
        }
        public void moveLeft()
        {
            dodongo.CurrentState = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            dodongo.CurrentState = new RightMovingDodongoState(dodongo);
        }
        public void moveUp()
        {
            dodongo.CurrentState = new UpMovingDodongoState(dodongo);
        }
        public void moveDown()
        {
            // Blank b/c already moving up
        }

        public void takeDamage()
        {
            this.dodongo.Health--;
            if (this.dodongo.Health-- == 0)
            {
                dodongo.CurrentState.die();
            }
        }
        public void die()
        {
            // dodongo.CurrentState = new DeadDodongoState(dodongo);
        }
        
        public void attack() 
        {
        }

        public void Update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X, dodongo.currentLocation.Y + 1);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
