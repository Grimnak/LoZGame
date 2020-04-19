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
            this.LoadTextures(content);
            this.LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            this.UnlockedDoorDownFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameDown");
            this.UnlockedDoorLeftFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameLeft");
            this.UnlockedDoorRightFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameRight");
            this.UnlockedDoorUpFrameTexture = content.Load<Texture2D>("GrayUnlockedDoorFrameUp");
            this.UnlockedDoorDownFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorDown");
            this.UnlockedDoorLeftFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorLeft");
            this.UnlockedDoorRightFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorRight");
            this.UnlockedDoorUpFloorTexture = content.Load<Texture2D>("GrayUnlockedDoorFloorUp");

            this.LockedDoorDownTexture = content.Load<Texture2D>("GrayLockedDoorDown");
            this.LockedDoorLeftTexture = content.Load<Texture2D>("GrayLockedDoorLeft");
            this.LockedDoorRightTexture = content.Load<Texture2D>("GrayLockedDoorRight");
            this.LockedDoorUpTexture = content.Load<Texture2D>("GrayLockedDoorUp");

            this.SpecialDoorDownTexture = content.Load<Texture2D>("GraySpecialDoorDown");
            this.SpecialDoorLeftTexture = content.Load<Texture2D>("GraySpecialDoorLeft");
            this.SpecialDoorRightTexture = content.Load<Texture2D>("GraySpecialDoorRight");
            this.SpecialDoorUpTexture = content.Load<Texture2D>("GraySpecialDoorUp");

            this.BombedOpeningDownTexture = content.Load<Texture2D>("GrayBombedDoorDown");
            this.BombedOpeningUpTexture = content.Load<Texture2D>("GrayBombedDoorUp");
            this.BombedOpeningRightTexture = content.Load<Texture2D>("GrayBombedDoorRight");
            this.BombedOpeningLeftTexture = content.Load<Texture2D>("GrayBombedDoorLeft");

            this.HorizontalBricksTexture = content.Load<Texture2D>("GrayHorizontalBricks");
            this.VerticalBricksTexture = content.Load<Texture2D>("GrayVerticalbricks");

            this.StairsTexture = content.Load<Texture2D>("GrayStairs");
            this.SpottedTileTexture = content.Load<Texture2D>("GraySpottedTile");
            this.FloorTileTexture = content.Load<Texture2D>("GrayFloorTile");
            this.MoveableTileTexture = content.Load<Texture2D>("GrayMoveableTile");

            this.BricksTexture = content.Load<Texture2D>("GrayBricks");
            this.DungeonHoleTexture = content.Load<Texture2D>("GrayDungeonHole");
            this.DungeonTexture = content.Load<Texture2D>("GrayDungeon");

            this.DoorOverhangTexture = content.Load<Texture2D>("SolidGray");
        }

        private void LoadData()
        {
            this.DungeonData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), DungeonTexture, 1, 1);

            this.TileData = new SpriteData(new Vector2(tileWidth, tileHeight), SpottedTileTexture, 1, 1);
            this.HorizontalBrickData = new SpriteData(new Vector2(HorizontalBlockWidth, HorizontalBlockHeight), HorizontalBricksTexture, 1, 1);
            this.VerticalBrickData = new SpriteData(new Vector2(VerticalBlockWidth, VerticalBlockHeight), VerticalBricksTexture, 1, 1);

            this.UpDoorData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorUpFrameTexture, 1, 1);
            this.DownDoorData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorDownFrameTexture, 1, 1);
            this.LeftDoorData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorLeftFrameTexture, 1, 1);
            this.RightDoorData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorRightFloorTexture, 1, 1);

            this.VerticalOverhangData = new SpriteData(new Vector2(doorWidth, BlockSpriteFactory.Instance.VerticalOffset - doorHeight), DoorOverhangTexture, 1, 1);
            this.HorizontalOverhangData = new SpriteData(new Vector2(BlockSpriteFactory.Instance.HorizontalOffset - doorHeight, doorWidth), DoorOverhangTexture, 1, 1);
        }

        public ISprite Stairs()
        {
            return new ObjectSprite(this.StairsTexture, this.TileData);
        }

        public ISprite SpottedTile()
        {
            return new ObjectSprite(this.SpottedTileTexture, this.TileData);
        }

        public ISprite MoveabeTile()
        {
            return new ObjectSprite(this.MoveableTileTexture, this.TileData);
        }

        public ISprite FloorTile()
        {
            return new ObjectSprite(this.FloorTileTexture, this.TileData);
        }

        public ISprite Dungeon()
        {
            return new ObjectSprite(this.DungeonTexture, this.DungeonData);
        }

        public ISprite DungeonHole()
        {
            return new ObjectSprite(this.DungeonHoleTexture, this.DungeonData);
        }

        public ISprite Bricks()
        {
            return new ObjectSprite(this.BricksTexture, this.DungeonData);
        }

        public ISprite HorizontalBricks()
        {
            return new ObjectSprite(this.HorizontalBricksTexture, this.HorizontalBrickData);
        }

        public ISprite Verticalbricks()
        {
            return new ObjectSprite(this.VerticalBricksTexture, this.VerticalBrickData);
        }

        public ISprite UnlockedUpDoorFrame()
        {
            return new ObjectSprite(this.UnlockedDoorUpFrameTexture, this.UpDoorData);
        }

        public ISprite UnlockedDownDoorFrame()
        {
            return new ObjectSprite(this.UnlockedDoorDownFrameTexture, this.DownDoorData);
        }

        public ISprite UnlockedLeftDoorFrame()
        {
            return new ObjectSprite(this.UnlockedDoorLeftFrameTexture, this.LeftDoorData);
        }

        public ISprite UnlockedRightDoorFrame()
        {
            return new ObjectSprite(this.UnlockedDoorRightFrameTexture, this.RightDoorData);
        }

        public ISprite UnlockedUpDoorFloor()
        {
            return new ObjectSprite(this.UnlockedDoorUpFloorTexture, this.UpDoorData);
        }

        public ISprite UnlockedDownDoorFloor()
        {
            return new ObjectSprite(this.UnlockedDoorDownFloorTexture, this.DownDoorData);
        }

        public ISprite UnlockedLeftDoorFloor()
        {
            return new ObjectSprite(this.UnlockedDoorLeftFloorTexture, this.LeftDoorData);
        }

        public ISprite UnlockedRightDoorFloor()
        {
            return new ObjectSprite(this.UnlockedDoorRightFloorTexture, this.RightDoorData);
        }

        public ISprite SpecialUpDoor()
        {
            return new ObjectSprite(this.SpecialDoorUpTexture, this.UpDoorData);
        }

        public ISprite SpecialDownDoor()
        {
            return new ObjectSprite(this.SpecialDoorDownTexture, this.DownDoorData);
        }

        public ISprite SpecialLeftDoor()
        {
            return new ObjectSprite(this.SpecialDoorLeftTexture, this.LeftDoorData);
        }

        public ISprite SpecialRightDoor()
        {
            return new ObjectSprite(this.SpecialDoorRightTexture, this.RightDoorData);
        }

        public ISprite LockedUpDoor()
        {
            return new ObjectSprite(this.LockedDoorUpTexture, this.UpDoorData);
        }

        public ISprite LockedDownDoor()
        {
            return new ObjectSprite(this.LockedDoorDownTexture, this.DownDoorData);
        }

        public ISprite LockedLeftDoor()
        {
            return new ObjectSprite(this.LockedDoorLeftTexture, this.LeftDoorData);
        }

        public ISprite LockedRightDoor()
        {
            return new ObjectSprite(this.LockedDoorRightTexture, this.RightDoorData);
        }

        public ISprite BombedUpDoor()
        {
            return new ObjectSprite(this.BombedOpeningUpTexture, this.UpDoorData);
        }

        public ISprite BombedDownDoor()
        {
            return new ObjectSprite(this.BombedOpeningDownTexture, this.DownDoorData);
        }

        public ISprite BombedLeftDoor()
        {
            return new ObjectSprite(this.BombedOpeningLeftTexture, this.LeftDoorData);
        }

        public ISprite BombedRightDoor()
        {
            return new ObjectSprite(this.BombedOpeningRightTexture, this.RightDoorData);
        }

        public ISprite VerticalOverhang()
        {
            return new ObjectSprite(this.DoorOverhangTexture, this.VerticalOverhangData);
        }

        public ISprite HorizontalOverhang()
        {
            return new ObjectSprite(this.DoorOverhangTexture, this.HorizontalOverhangData);
        }
    }
}