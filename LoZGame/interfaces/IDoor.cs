namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface IDoor : ICollider
    {
        Vector2 UpScreenLoc { get; }

        Vector2 DownScreenLoc { get; }

        Vector2 LeftScreenLoc { get; }

        Vector2 RightScreenLoc { get; }

        IDoorState State { get; set; }

        void Close();

        void Open();

        void Bombed();

        void Update();

        void Draw();
    }
}
