namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DoorEssentials : IDoorState
    {
        public readonly Color SpriteTint = LoZGame.Instance.DungeonTint;

        public IDoor Door;

        public ISprite FrameSprite;
        public ISprite FloorSprite;

        public virtual void Close()
        {
            this.Door.State = new LockedDoorState(this.Door);
        }

        public virtual void Open()
        {
            this.Door.State = new UnlockedDoorState(this.Door);
        }

        public virtual void Bombed()
        {
            if (this.Door.State is LockedDoorState)
            {
                this.Door.State = new UnlockedDoorState(this.Door);
            }
            else
            {
                this.Door.State = new BombedDoorState(this.Door);
            }
        }

        public virtual void Update()
        {
        }

        public virtual void DrawFrame()
        {
            this.FrameSprite.Draw(this.Door.Physics.Location, SpriteTint, this.Door.Physics.Depth);
        }

        public virtual void DrawFloor()
        {
            this.FloorSprite.Draw(this.Door.Physics.Location, SpriteTint, 0);
        }
    }
}
