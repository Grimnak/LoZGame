﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpMovingKeeseState : IKeeseState
    {
        private readonly Keese keese;
        private readonly IKeeseSprite sprite;

        public UpMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
        }

        public void moveLeft()
        {
            this.keese.CurrentState = new LeftMovingKeeseState(this.keese);
        }

        public void moveRight()
        {
            this.keese.CurrentState = new RightMovingKeeseState(this.keese);
        }

        public void moveUp()
        {
            // Blank b/c already moving up
        }

        public void moveDown()
        {
            this.keese.CurrentState = new DownMovingKeeseState(this.keese);
        }

        public void moveUpLeft()
        {
            this.keese.CurrentState = new UpLeftMovingKeeseState(this.keese);
        }

        public void moveUpRight()
        {
            this.keese.CurrentState = new UpRightMovingKeeseState(this.keese);
        }

        public void moveDownLeft()
        {
            this.keese.CurrentState = new DownLeftMovingKeeseState(this.keese);
        }

        public void moveDownRight()
        {
            this.keese.CurrentState = new DownRightMovingKeeseState(this.keese);
        }

        public void takeDamage()
        {
            this.keese.Health--;
            if (this.keese.Health == 0)
            {
                this.keese.CurrentState.die();
            }
        }

        public void die()
        {
            this.keese.CurrentState = new DeadKeeseState(this.keese);
        }

        public void Update()
        {
            this.keese.currentLocation = new Vector2(this.keese.currentLocation.X, this.keese.currentLocation.Y - 2);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.keese.currentLocation, Color.White);
        }
    }
}
