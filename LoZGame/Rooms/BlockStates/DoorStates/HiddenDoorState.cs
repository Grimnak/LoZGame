namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class HiddenDoorState : DoorEssentials, IDoorState
    {
        public HiddenDoorState(Door door)
        {
            Door = door;
        }

        public override void Close()
        {
        }

        public override void DrawFrame()
        {
        }

        public override void DrawFloor()
        {
        }

        public override void Open()
        {
        }
    }
}
