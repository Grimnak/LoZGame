using Microsoft.Xna.Framework;
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
        void pickupItem(int itemTime);
        void useItem(int waitTime);
        void Update();
        void Draw();

        IPlayerState State { set; }
        string CurrentWeapon { get; set; }
        string CurrentColor { get; set; }
        string CurrentDirection { get; set; }
        Vector2 CurrentLocation { get; set; }
        Color CurrentTint { get; set; }
        int CurrentSpeed { get; set; }
        int DamageCounter { get; set; }
        int DamageTimer { get; set; }
        bool IsDead { get; set; }
    }
}