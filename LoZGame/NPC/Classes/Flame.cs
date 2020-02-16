﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Flame : IEnemy
    {
        public Vector2 currentLocation;
        private IEnemyState currentState;

        public Flame()
        {
            currentLocation = new Vector2(400, 200);
        }

        public void moveLeft()
        {
            //
        }
        public void moveRight()
        {
           //
        }
        public void moveUp()
        {
           //
        }
        public void moveDown()
        {
            //
        }
        public void attack()
        {
            //
        }
        public void takeDamage()
        {
            //
        }
        public void die()
        {
           //
        }
        public void Update()
        {
            currentState.Update();
        }
        public void Draw(SpriteBatch sb)
        {
            currentState.Draw(sb);
        }
    }
}

