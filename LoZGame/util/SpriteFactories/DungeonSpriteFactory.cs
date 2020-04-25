namespace LoZClone
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class DungeonSpriteFactory
    {
        private static readonly int tileWidth = 54;
        private static readonly int tileHeight = 48;
        private static readonly int doorWidth = 90;
        private static readonly int doorHeight = 60;

        private static readonly int VerticalBlockWidth = 16;
        private static readonly int VerticalBlockHeight = 64;
        private static readonly int HorizontalBlockWidth = 64;
        private static readonly int HorizontalBlockHeight = 16;

        private Texture2D StairsTexture;

        private Texture2D UnlockedDoorDownFrameTexture;
        private Texture2D UnlockedDoorDownFloorTexture;
        private Texture2D UnlockedDoorLeftFrameTexture;
        private Texture2D UnlockedDoorLeftFloorTexture;
        private Texture2D UnlockedDoorRightFrameTexture;
        private Texture2D UnlockedDoorRightFloorTexture;
        private Texture2D UnlockedDoorUpFrameTexture;
        private Texture2D UnlockedDoorUpFloorTexture;

        private Texture2D LockedDoorDownTexture;
        private Texture2D LockedDoorLeftTexture;
        private Texture2D LockedDoorRightTexture;
        private Texture2D LockedDoorUpTexture;

        private Texture2D SpecialDoorDownTexture;
        private Texture2D SpecialDoorLeftTexture;
        private Texture2D SpecialDoorRightTexture;
        private Texture2D SpecialDoorUpTexture;

        private Texture2D BombedOpeningDownTexture;
        private Texture2D BombedOpeningUpTexture;
        private Texture2D BombedOpeningRightTexture;
        private Texture2D BombedOpeningLeftTexture;

        private Texture2D HorizontalBricksTexture;
        private Texture2D VerticalBricksTexture;

        private Texture2D SpottedTileTexture;
        private Texture2D FloorTileTexture;
        private Texture2D MoveableTileTexture;

        private Texture2D BricksTexture;
        private Texture2D DungeonHoleTexture;
        private Texture2D DungeonTexture;

        private Texture2D DoorOverhangTexture;

        private SpriteData DungeonData;

        private SpriteData TileData;
        private SpriteData HorizontalBrickData;
        private SpriteData VerticalBrickData;

        private SpriteData UpDoorData;
        private SpriteData DownDoorData;
        private SpriteData LeftDoorData;
        private SpriteData RightDoorData;

        private SpriteData VerticalOverhangData;
        private SpriteData HorizontalOverhangData;

        private static readonly DungeonSpriteFactory instance = new DungeonSpriteFactory();

        public static DungeonSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private DungeonSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            LoadTextures(content);
            LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            UnlockedDoorDownFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameDown");
            UnlockedDoorLeftFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameLeft");
            UnlockedDoorRightFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameRight");
            UnlockedDoorUpFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameUp");
            UnlockedDoorDownFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorDown");
            UnlockedDoorLeftFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorLeft");
            UnlockedDoorRightFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorRight");
            UnlockedDoorUpFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorUp");

            LockedDoorDownTexture = content.Load<Texture2D>("GrayLockedDoorDown");
            LockedDoorLeftTexture = content.Load<Texture2D>("GrayLockedDoorLeft");
            LockedDoorRightTexture = content.Load<Texture2D>("GrayLockedDoorRight");
            LockedDoorUpTexture = content.Load<Texture2D>("GrayLockedDoorUp");

            SpecialDoorDownTexture = content.Load<Texture2D>("GraySpecialDoorDown");
            SpecialDoorLeftTexture = content.Load<Texture2D>("GraySpecialDoorLeft");
            SpecialDoorRightTexture = content.Load<Texture2D>("GraySpecialDoorRight");
            SpecialDoorUpTexture = content.Load<Texture2D>("GraySpecialDoorUp");

            BombedOpeningDownTexture = content.Load<Texture2D>("GrayBombedDoorDown");
            BombedOpeningUpTexture = content.Load<Texture2D>("GrayBombedDoorUp");
            BombedOpeningRightTexture = content.Load<Texture2D>("GrayBombedDoorRight");
            BombedOpeningLeftTexture = content.Load<Texture2D>("GrayBombedDoorLeft");

            HorizontalBricksTexture = content.Load<Texture2D>("GrayHorizontalBricks");
            VerticalBricksTexture = content.Load<Texture2D>("GrayVerticalbricks");

            StairsTexture = content.Load<Texture2D>("GrayStairs");
            SpottedTileTexture = content.Load<Texture2D>("GraySpottedTile");
            FloorTileTexture = content.Load<Texture2D>("GrayFloorTile");
            MoveableTileTexture = content.Load<Texture2D>("GrayMoveableTile");

            BricksTexture = content.Load<Texture2D>("GrayBricks");
            DungeonHoleTexture = content.Load<Texture2D>("GrayDungeonHole");
            DungeonTexture = content.Load<Texture2D>("GrayDungeon");

            DoorOverhangTexture = content.Load<Texture2D>("SolidGray");
        }

        private void LoadData()
        {
            DungeonData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), DungeonTexture, 1, 1);

            TileData = new SpriteData(new Vector2(tileWidth, tileHeight), SpottedTileTexture, 1, 1);
            HorizontalBrickData = new SpriteData(new Vector2(HorizontalBlockWidth, HorizontalBlockHeight), HorizontalBricksTexture, 1, 1);
            VerticalBrickData = new SpriteData(new Vector2(VerticalBlockWidth, VerticalBlockHeight), VerticalBricksTexture, 1, 1);

            UpDoorData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorUpFrameTexture, 1, 1);
            DownDoorData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorDownFrameTexture, 1, 1);
            LeftDoorData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorLeftFrameTexture, 1, 1);
            RightDoorData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorRightFloorTexture, 1, 1);

            VerticalOverhangData = new SpriteData(new Vector2(doorWidth, BlockSpriteFactory.Instance.VerticalOffset - doorHeight), DoorOverhangTexture, 1, 1);
            HorizontalOverhangData = new SpriteData(new Vector2(BlockSpriteFactory.Instance.HorizontalOffset - doorHeight, doorWidth), DoorOverhangTexture, 1, 1);
        }

        public ISprite Stairs()
        {
            return new ObjectSprite(StairsTexture, TileData);
        }

        public ISprite SpottedTile()
        {
            return new ObjectSprite(SpottedTileTexture, TileData);
        }

        public ISprite MovableTile()
        {
            return new ObjectSprite(MoveableTileTexture, TileData);
        }

        public ISprite FloorTile()
        {
            return new ObjectSprite(FloorTileTexture, TileData);
        }

        public ISprite Dungeon()
        {
            return new ObjectSprite(DungeonTexture, DungeonData);
        }

        public ISprite DungeonHole()
        {
            return new ObjectSprite(DungeonHoleTexture, DungeonData);
        }

        public ISprite Bricks()
        {
            return new ObjectSprite(BricksTexture, DungeonData);
        }

        public ISprite HorizontalBricks()
        {
            return new ObjectSprite(HorizontalBricksTexture, HorizontalBrickData);
        }

        public ISprite Verticalbricks()
        {
            return new ObjectSprite(VerticalBricksTexture, VerticalBrickData);
        }

        public ISprite UnlockedUpDoorFrame()
        {
            return new ObjectSprite(UnlockedDoorUpFrameTexture, UpDoorData);
        }

        public ISprite UnlockedDownDoorFrame()
        {
            return new ObjectSprite(UnlockedDoorDownFrameTexture, DownDoorData);
        }

        public ISprite UnlockedLeftDoorFrame()
        {
            return new ObjectSprite(UnlockedDoorLeftFrameTexture, LeftDoorData);
        }

        public ISprite UnlockedRightDoorFrame()
        {
            return new ObjectSprite(UnlockedDoorRightFrameTexture, RightDoorData);
        }

        public ISprite UnlockedUpDoorFloor()
        {
            return new ObjectSprite(UnlockedDoorUpFloorTexture, UpDoorData);
        }

        public ISprite UnlockedDownDoorFloor()
        {
            return new ObjectSprite(UnlockedDoorDownFloorTexture, DownDoorData);
        }

        public ISprite UnlockedLeftDoorFloor()
        {
            return new ObjectSprite(UnlockedDoorLeftFloorTexture, LeftDoorData);
        }

        public ISprite UnlockedRightDoorFloor()
        {
            return new ObjectSprite(UnlockedDoorRightFloorTexture, RightDoorData);
        }

        public ISprite SpecialUpDoor()
        {
            return new ObjectSprite(SpecialDoorUpTexture, UpDoorData);
        }

        public ISprite SpecialDownDoor()
        {
            return new ObjectSprite(SpecialDoorDownTexture, DownDoorData);
        }

        public ISprite SpecialLeftDoor()
        {
            return new ObjectSprite(SpecialDoorLeftTexture, LeftDoorData);
        }

        public ISprite SpecialRightDoor()
        {
            return new ObjectSprite(SpecialDoorRightTexture, RightDoorData);
        }

        public ISprite LockedUpDoor()
        {
            return new ObjectSprite(LockedDoorUpTexture, UpDoorData);
        }

        public ISprite LockedDownDoor()
        {
            return new ObjectSprite(LockedDoorDownTexture, DownDoorData);
        }

        public ISprite LockedLeftDoor()
        {
            return new ObjectSprite(LockedDoorLeftTexture, LeftDoorData);
        }

        public ISprite LockedRightDoor()
        {
            return new ObjectSprite(LockedDoorRightTexture, RightDoorData);
        }

        public ISprite BombedUpDoor()
        {
            return new ObjectSprite(BombedOpeningUpTexture, UpDoorData);
        }

        public ISprite BombedDownDoor()
        {
            return new ObjectSprite(BombedOpeningDownTexture, DownDoorData);
        }

        public ISprite BombedLeftDoor()
        {
            return new ObjectSprite(BombedOpeningLeftTexture, LeftDoorData);
        }

        public ISprite BombedRightDoor()
        {
            return new ObjectSprite(BombedOpeningRightTexture, RightDoorData);
        }

        public ISprite VerticalOverhang()
        {
            return new ObjectSprite(DoorOverhangTexture, VerticalOverhangData);
        }

        public ISprite HorizontalOverhang()
        {
            return new ObjectSprite(DoorOverhangTexture, HorizontalOverhangData);
        }
    }
}