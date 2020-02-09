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
        //void usePrimaryItem();
        //void useSecondaryItem();
        void Update();
        void Draw();
    }
}