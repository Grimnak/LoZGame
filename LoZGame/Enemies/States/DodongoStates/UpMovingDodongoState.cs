﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IEnemySprite sprite;

        public UpMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createUpMovingDodongoSprite();
        }
        public void moveLeft()
        {
            dodongo.currentState = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            dodongo.currentState = new RightMovingDodongoState(dodongo);
        }
        public void moveUp()
        {
           // Blank b/c already moving up
        }
        public void moveDown()
        {
            dodongo.currentState = new DownMovingDodongoState(dodongo);
        }

        public void takeDamage()
        {
            this.dodongo.Health--;
            if (this.dodongo.Health-- == 0)
            {
                dodongo.currentState.die();
            }
        }
        public void die()
        {
             dodongo.currentState = new DeadDodongoState(dodongo);
        }

        public void update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X, dodongo.currentLocation.Y - 3);
            sprite.update();
        }
        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
