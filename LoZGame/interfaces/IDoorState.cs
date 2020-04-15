namespace LoZClone
{
    public interface IDoorState
    {

        void Close(); // for entering a special room

        void Open(); // for locked doors and special doors 

        void Bombed(); // for hidden doors

        void Update();

        void DrawFrame();

        void DrawFloor();
    }
}
