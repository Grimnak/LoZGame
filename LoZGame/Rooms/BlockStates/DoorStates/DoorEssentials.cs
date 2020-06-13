namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DoorEssentials : IDoorState
    {
        private Color spriteTint = LoZGame.Instance.DungeonTint;
        public IDoor Door;
        public ISprite FrameSprite;
        public ISprite FloorSprite;
        public ISprite OverhangSprite;

        public virtual void Close()
        {
            Door.State = new LockedDoorState(Door);
            Door.DoorType = LoZClone.Door.DoorTypes.Locked;
        }

        public virtual void Open()
        {
            Door.State = new UnlockedDoorState(Door);
            Door.DoorType = LoZClone.Door.DoorTypes.Unlocked;
        }

        public virtual void Bombed()
        {
            if (Door.State is LockedDoorState)
            {
                Door.State = new UnlockedDoorState(Door);
                Door.DoorType = LoZClone.Door.DoorTypes.Unlocked;
            }
            else
            {
                Door.State = new BombedDoorState(Door);
                Door.DoorType = LoZClone.Door.DoorTypes.Unlocked;
            }
        }

        public virtual void Update()
        {
            if (!(LoZGame.Instance.Dungeon is null))
            {
                spriteTint = LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint;
            }
        }

        public virtual void DrawFrame()
        {
            FrameSprite.Draw(Door.Physics.Location, spriteTint, Door.Physics.Depth);
            OverhangSprite.Draw(Door.Physics.Location + Door.OverhangOffset, spriteTint, Door.Physics.Depth);
        }

        public virtual void DrawFloor()
        {
            FloorSprite.Draw(Door.Physics.Location, spriteTint, 0);
        }
    }
}
