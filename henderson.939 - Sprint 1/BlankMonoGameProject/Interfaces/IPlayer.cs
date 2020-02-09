namespace LoZClone
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
        //void usePrimaryItem();
        //void useSecondaryItem();
        void Update();
        void Draw();
    }
}
