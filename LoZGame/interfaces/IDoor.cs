namespace LoZClone
{
    public interface IDoor : ICollider
    {
        void Close();

        void Open();

        void Bombed();

        void Update();

        void Draw();
    }
}
