namespace LoZClone
{
    using Microsoft.Xna.Framework;
    public partial class Door
    {
        private string location;
        private int doorWidth;
        private bool solved;

        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Vector2 upScreenLoc = new Vector2(GameData.Instance.RoomConstants.UpDownDoorXLocation, GameData.Instance.RoomConstants.UpDoorYLocation);
        private readonly Vector2 downScreenLoc = new Vector2(GameData.Instance.RoomConstants.UpDownDoorXLocation, LoZGame.Instance.ScreenHeight - BlockSpriteFactory.Instance.DoorOffset - BlockSpriteFactory.Instance.TileHeight);
        private readonly Vector2 rightScreenLoc = new Vector2(GameData.Instance.RoomConstants.RightDoorXLocation, GameData.Instance.RoomConstants.RightLeftDoorYLocation);
        private readonly Vector2 leftScreenLoc = new Vector2(GameData.Instance.RoomConstants.LeftDoorXLocation, GameData.Instance.RoomConstants.RightLeftDoorYLocation);

        public enum DoorTypes
        {
            Cosmetic,
            Unlocked,
            Locked,
            Special,
            Bombed,
            Hidden,
            Puzzle
        }

        public DoorTypes DoorType { get; set; }

        public bool IsSolved
        {
            get { return solved; }
            set { solved = value; }
        }

        private IDoorState state;

        private string kind;

        public IDoorState State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public int EntryWidth
        {
            get { return this.doorWidth; }
            set { this.doorWidth = value; }
        }

        private DoorCollisionHandler doorCollisionHandler;

        public Physics Physics { get; set; }

        public Vector2 UpScreenLoc
        {
            get { return upScreenLoc; }
        }

        public Vector2 RightScreenLoc
        {
            get { return rightScreenLoc; }
        }

        public Vector2 DownScreenLoc
        {
            get { return downScreenLoc; }
        }

        public Vector2 LeftScreenLoc
        {
            get { return leftScreenLoc; }
        }

    }
}
