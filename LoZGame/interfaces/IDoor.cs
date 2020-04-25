namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface IDoor : ICollider
    {
        Vector2 OverhangOffset { get; set; }

        bool IsSolved { get; set; }

        Door.DoorTypes DoorType { get; set; }

        int EntryWidth { get; set; }

        IDoorState State { get; set; }

        void Close();

        void Open();

        void Bombed();

        void Update();

        void Draw();

        void DrawFrame();

        void DrawFloor();
    }
}
