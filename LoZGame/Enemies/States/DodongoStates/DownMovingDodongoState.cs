﻿using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IDodongoSprite sprite;

        public DownMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createDownMovingDodongoSprite();
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
            dodongo.currentState = new UpMovingDodongoState(dodongo);
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
                dodongo.currentState.die();
            }
        }
        public void die()
        {
            dodongo.currentState = new DeadDodongoState(dodongo);
        }

        public void update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X, dodongo.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
