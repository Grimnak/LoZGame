﻿namespace LoZClone
{
    public interface IPlayer
    {
        void idle();
        void moveUp();
        void moveDown();
        void moveLeft();
        void moveRight();
        void takeDamage();
        void attack();
        void pickupItem();
        void useItem();
        //void usePrimaryItem();
        //void useItemAnimation1();
        //void useItemAnimation2();
        //void useSecondaryItem();
        void Update();
        void Draw();
    }
}