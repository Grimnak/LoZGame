namespace LoZClone
{
    public interface IPlayerState
    {
        void idle();
        void moveUp();
        void moveDown();
        void moveLeft();
        void moveRight();
        void attack();
        void die();
        void pickupItem(int itemTime);
        void useItem(int waitTime);
        //void usePrimaryItem();
        //void useSecondaryItem();
        void Update();
        void Draw();
    }
}