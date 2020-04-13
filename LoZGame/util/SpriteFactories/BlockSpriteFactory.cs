namespace LoZClone
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class BlockSpriteFactory
    {
        private static readonly int tileWidth = 55;
        private static readonly int tileHeight = 48;
        private static readonly int movableTileWidth = 54;
        private static readonly int movableTileHeight = 47;
        private static readonly int topOffset = LoZGame.Instance.InventoryOffset + 72;
        private static readonly int bottomOffset = LoZGame.Instance.ScreenHeight - 72;
        private static readonly int horizontalOffset = 79;
        private static readonly int doorOffset = 24;
        private static readonly int doorWidth = 90;
        private static readonly int doorHeight = 60;
        private static readonly int fireHeight = 18;
        private static readonly int fireWidth = 16;

        private static readonly int VerticalBlockWidth = 16;
        private static readonly int VerticalBlockHeight = 64;
        private static readonly int HorizontalBlockWidth = 64;
        private static readonly int HorizontalBlockHeight = 16;

        private static readonly int VerticalBombedWidth = 0;
        private static readonly int VerticalBombedHeight = 32;
        private static readonly int HorizontalBombedWidth = 32;
        private static readonly int HorizontalBombedHeight = 8;

        private Texture2D StairsTexture;
        private SpriteData stairsData;

        private Texture2D UnlockedDoorDownTexture;
        private SpriteData UnlockedDoorDownData;
        private Texture2D UnlockedDoorLeftTexture;
        private SpriteData UnlockedDoorLeftData;
        private Texture2D UnlockedDoorRightTexture;
        private SpriteData UnlockedDoorRightData;
        private Texture2D UnlockedDoorUpTexture;
        private SpriteData UnlockedDoorUpData;

        private Texture2D LockedDoorDownTexture;
        private SpriteData LockedDoorDownData;
        private Texture2D LockedDoorLeftTexture;
        private SpriteData LockedDoorLeftData;
        private Texture2D LockedDoorRightTexture;
        private SpriteData LockedDoorRightData;
        private Texture2D LockedDoorUpTexture;
        private SpriteData LockedDoorUpData;

        private Texture2D SpecialDoorDownTexture;
        private SpriteData SpecialDoorDownData;
        private Texture2D SpecialDoorLeftTexture;
        private SpriteData SpecialDoorLeftData;
        private Texture2D SpecialDoorRightTexture;
        private SpriteData SpecialDoorRightData;
        private Texture2D SpecialDoorUpTexture;
        private SpriteData SpecialDoorUpData;

        private Texture2D BombedOpeningDownTexture;
        private SpriteData bombedOpeningDownData;
        private Texture2D BombedOpeningUpTexture;
        private SpriteData bombedOpeningUpData;
        private Texture2D BombedOpeningRightTexture;
        private SpriteData bombedOpeningRightData;
        private Texture2D BombedOpeningLeftTexture;
        private SpriteData bombedOpeningLeftData;

        private Texture2D FireTexture;
        private SpriteData fireData;
        private Texture2D FloorTileTexture;
        private SpriteData floorTileData;
        private Texture2D GapTileTexture;
        private SpriteData gapTileData;
        private Texture2D MovableSquareTexture;
        private SpriteData movableSquareData;

        private Texture2D BlueStatueRightTexture;
        private SpriteData blueStatueRightData;
        private Texture2D BlueStatueLeftTexture;
        private SpriteData blueStatueLeftData;
        private Texture2D TurquoiseStatueLeftTexture;
        private SpriteData turquoiseStatueLeftData;
        private Texture2D TurquoiseStatueRightTexture;
        private SpriteData turquoiseStatueRightData;

        private Texture2D SpottedTileTexture;
        private SpriteData spottedTileData;
        private Texture2D WaterTileTexture;
        private SpriteData waterTileData;

        private Texture2D OrangeMovableSquareTexture;
        private SpriteData orangeMovableSquareData;
        private Texture2D BasementBrickTileTexture;
        private SpriteData basementBrickTileData;
        private Texture2D LadderTileTexture;
        private SpriteData ladderTileData;
        private Texture2D HorizontalBricksTexture;
        private SpriteData horizontalBricksData;
        private Texture2D VerticalBricksTexture;
        private SpriteData verticalBricksData;

        private Texture2D BlueStatueLeft2Texture;
        private SpriteData blueStatueLeft2Data;
        private Texture2D BlueStatueRight2Texture;
        private SpriteData blueStatueRight2Data;
        private Texture2D OrangeStatueRight2Texture;
        private SpriteData orangeStatueRight2Data;
        private Texture2D OrangeStatueLeft2Texture;
        private SpriteData orangeStatueLeft2Data;

        private Texture2D BombedOpeningDown2Texture;
        private SpriteData bombedOpeningDown2Data;
        private Texture2D BombedOpeningLeft2Texture;
        private SpriteData bombedOpeningLeft2Data;
        private Texture2D BombedOpeningRight2Texture;
        private SpriteData bombedOpeningRight2Data;
        private Texture2D BombedOpeningUp2Texture;
        private SpriteData bombedOpeningUp2Data;

        private Texture2D BossTile2Texture;
        private SpriteData bossTile2Data;
        private Texture2D FloorTile2Texture;
        private SpriteData floorTile2Data;
        private Texture2D Lava2Texture;
        private SpriteData lava2Data;
        private Texture2D MovableSquare2Texture;
        private SpriteData movableSquare2Data;
        private Texture2D SpottedTile2Texture;
        private SpriteData spottedTile2Data;

        private static readonly BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        
        public int TileWidth
        {
            get { return tileWidth; }
        }

        public int TileHeight
        {
            get { return tileHeight; }
        }

        public int MovableTileWidth
        {
            get { return movableTileWidth; }
        }

        public int MovableTileHeight
        {
            get { return movableTileHeight; }
        }

        public int TopOffset
        {
            get { return topOffset; }
        }

        public int BottomOffset
        {
            get { return bottomOffset; }
        }

        public int HorizontalOffset
        {
            get { return horizontalOffset; }
        }

        public int DoorOffset
        {
            get { return doorOffset; }
        }

        public int DoorWidth
        {
            get { return doorWidth; }
        }

        public int DoorHeight
        {
            get { return doorHeight; }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.LoadTextures(content);
            this.LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            this.FloorTileTexture = content.Load<Texture2D>("floor_tile");
            this.StairsTexture = content.Load<Texture2D>("stairs");
            this.MovableSquareTexture = content.Load<Texture2D>("movable_square");
            this.GapTileTexture = content.Load<Texture2D>("gap_tile");
            this.UnlockedDoorDownTexture = content.Load<Texture2D>("unlocked_door_down");
            this.UnlockedDoorLeftTexture = content.Load<Texture2D>("unlocked_door_left");
            this.UnlockedDoorRightTexture = content.Load<Texture2D>("unlocked_door_right");
            this.UnlockedDoorUpTexture = content.Load<Texture2D>("unlocked_door_up");
            this.LockedDoorDownTexture = content.Load<Texture2D>("locked_door_down");
            this.LockedDoorLeftTexture = content.Load<Texture2D>("locked_door_left");
            this.LockedDoorRightTexture = content.Load<Texture2D>("locked_door_right");
            this.LockedDoorUpTexture = content.Load<Texture2D>("locked_door_up");
            this.SpecialDoorDownTexture = content.Load<Texture2D>("special_door_down");
            this.SpecialDoorLeftTexture = content.Load<Texture2D>("special_door_left");
            this.SpecialDoorRightTexture = content.Load<Texture2D>("special_door_right");
            this.SpecialDoorUpTexture = content.Load<Texture2D>("special_door_up");
            this.FireTexture = content.Load<Texture2D>("fire");
            this.BombedOpeningDownTexture = content.Load<Texture2D>("bombed_opening_down");
            this.BombedOpeningUpTexture = content.Load<Texture2D>("bombed_opening_up");
            this.BombedOpeningRightTexture = content.Load<Texture2D>("bombed_opening_right");
            this.BombedOpeningLeftTexture = content.Load<Texture2D>("bombed_opening_left");
            this.BlueStatueRightTexture = content.Load<Texture2D>("blue_statue_right");
            this.BlueStatueLeftTexture = content.Load<Texture2D>("blue_statue_left");
            this.TurquoiseStatueRightTexture = content.Load<Texture2D>("turquoise_statue_right");
            this.TurquoiseStatueLeftTexture = content.Load<Texture2D>("turquoise_statue_left");
            this.SpottedTileTexture = content.Load<Texture2D>("spotted_tile");
            this.WaterTileTexture = content.Load<Texture2D>("water_tile");
            this.OrangeMovableSquareTexture = content.Load<Texture2D>("orange_movable_square");
            this.BasementBrickTileTexture = content.Load<Texture2D>("basement_brick_tile");
            this.LadderTileTexture = content.Load<Texture2D>("ladder_tile");
            this.HorizontalBricksTexture = content.Load<Texture2D>("horizontal_bricks");
            this.VerticalBricksTexture = content.Load<Texture2D>("vertical_bricks");

            this.BlueStatueLeft2Texture = content.Load<Texture2D>("blue_statue_left2");
            this.BlueStatueRight2Texture = content.Load<Texture2D>("blue_statue_right2");
            this.OrangeStatueRight2Texture = content.Load<Texture2D>("orange_statue_right2");
            this.OrangeStatueLeft2Texture = content.Load<Texture2D>("orange_statue_left2");
            this.BombedOpeningDown2Texture = content.Load<Texture2D>("bombed_opening_down2");
            this.BombedOpeningLeft2Texture = content.Load<Texture2D>("bombed_opening_left2");
            this.BombedOpeningRight2Texture = content.Load<Texture2D>("bombed_opening_right2");
            this.BombedOpeningUp2Texture = content.Load<Texture2D>("bombed_opening_up2");
            this.BossTile2Texture = content.Load<Texture2D>("boss_tile2");
            this.FloorTile2Texture = content.Load<Texture2D>("floor_tile2");
            this.Lava2Texture = content.Load<Texture2D>("lava2");
            this.MovableSquare2Texture = content.Load<Texture2D>("movable_square2");
            this.SpottedTile2Texture = content.Load<Texture2D>("spotted_tile2");
        }

        private void LoadData()
        {
            this.stairsData = new SpriteData(new Vector2(tileWidth, tileHeight), StairsTexture, 1, 1);
            this.UnlockedDoorDownData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorDownTexture, 1, 1);
            this.UnlockedDoorLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorLeftTexture, 1, 1);
            this.UnlockedDoorRightData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorRightTexture, 1, 1);
            this.UnlockedDoorUpData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorUpTexture, 1, 1);
            this.LockedDoorDownData = new SpriteData(new Vector2(doorWidth, doorHeight), LockedDoorDownTexture, 1, 1);
            this.LockedDoorLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), LockedDoorLeftTexture, 1, 1);
            this.LockedDoorRightData = new SpriteData(new Vector2(doorHeight, doorWidth), LockedDoorRightTexture, 1, 1);
            this.LockedDoorUpData = new SpriteData(new Vector2(doorWidth, doorHeight), LockedDoorUpTexture, 1, 1);
            this.SpecialDoorDownData = new SpriteData(new Vector2(doorWidth, doorHeight), SpecialDoorDownTexture, 1, 1);
            this.SpecialDoorLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), SpecialDoorLeftTexture, 1, 1);
            this.SpecialDoorRightData = new SpriteData(new Vector2(doorHeight, doorWidth), SpecialDoorRightTexture, 1, 1);
            this.SpecialDoorUpData = new SpriteData(new Vector2(doorWidth, doorHeight), SpecialDoorUpTexture, 1, 1);
            this.bombedOpeningDownData = new SpriteData(new Vector2(doorWidth, doorHeight), BombedOpeningDownTexture, 1, 1);
            this.bombedOpeningUpData = new SpriteData(new Vector2(doorWidth, doorHeight), BombedOpeningUpTexture, 1, 1);
            this.bombedOpeningRightData = new SpriteData(new Vector2(doorHeight, doorWidth), BombedOpeningRightTexture, 1, 1);
            this.bombedOpeningLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), BombedOpeningLeftTexture, 1, 1);
            this.fireData = new SpriteData(new Vector2(tileWidth, tileHeight), FireTexture, 1, 2);
            this.floorTileData = new SpriteData(new Vector2(tileWidth, tileHeight), FloorTileTexture, 1, 1);
            this.gapTileData = new SpriteData(new Vector2(tileWidth, tileHeight), GapTileTexture, 1, 1);
            this.movableSquareData = new SpriteData(new Vector2(tileWidth, tileHeight), MovableSquareTexture, 1, 1);
            this.blueStatueRightData = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueRightTexture, 1, 1);
            this.blueStatueLeftData = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueLeftTexture, 1, 1);
            this.turquoiseStatueLeftData = new SpriteData(new Vector2(tileWidth, tileHeight), TurquoiseStatueLeftTexture, 1, 1);
            this.turquoiseStatueRightData = new SpriteData(new Vector2(tileWidth, tileHeight), TurquoiseStatueRightTexture, 1, 1);
            this.spottedTileData = new SpriteData(new Vector2(tileWidth, tileHeight), SpottedTileTexture, 1, 1);
            this.waterTileData = new SpriteData(new Vector2(tileWidth, tileHeight), WaterTileTexture, 1, 1);
            this.orangeMovableSquareData = new SpriteData(new Vector2(tileWidth, tileHeight), OrangeMovableSquareTexture, 1, 1);
            this.basementBrickTileData = new SpriteData(new Vector2(tileWidth, tileHeight), BasementBrickTileTexture, 1, 1);
            this.ladderTileData = new SpriteData(new Vector2(tileWidth, tileHeight), LadderTileTexture, 1, 1);
            this.horizontalBricksData = new SpriteData(new Vector2(HorizontalBlockWidth, HorizontalBlockHeight), HorizontalBricksTexture, 1, 1);
            this.verticalBricksData = new SpriteData(new Vector2(VerticalBlockWidth, VerticalBlockHeight), VerticalBricksTexture, 1, 1);

            this.blueStatueLeft2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueLeft2Texture, 1, 1);
            this.blueStatueRight2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueRight2Texture, 1, 1);
            this.orangeStatueRight2Data = new SpriteData(new Vector2(tileWidth, tileHeight), OrangeStatueRight2Texture, 1, 1);
            this.orangeStatueLeft2Data = new SpriteData(new Vector2(tileWidth, tileHeight), OrangeStatueLeft2Texture, 1, 1);
            this.bombedOpeningDown2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BombedOpeningDownTexture, 1, 1);
            this.bombedOpeningLeft2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BombedOpeningLeftTexture, 1, 1);
            this.bombedOpeningRight2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BombedOpeningRightTexture, 1, 1);
            this.bombedOpeningUp2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BombedOpeningUpTexture, 1, 1);
            this.bossTile2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BossTile2Texture, 1, 1);
            this.floorTile2Data = new SpriteData(new Vector2(tileWidth, tileHeight), FloorTile2Texture, 1, 1);
            this.lava2Data = new SpriteData(new Vector2(tileWidth, tileHeight), Lava2Texture, 1, 1);
            this.movableSquare2Data = new SpriteData(new Vector2(tileWidth, tileHeight), MovableSquare2Texture, 1, 1);
            this.spottedTile2Data = new SpriteData(new Vector2(tileWidth, tileHeight), SpottedTile2Texture, 1, 1);
        }

        public ISprite Stairs()
        {
            return new ObjectSprite(this.StairsTexture, this.stairsData);
        }

        public ISprite UnlockedDoorDown()
        {
            return new ObjectSprite(this.UnlockedDoorDownTexture, this.UnlockedDoorDownData);
        }

        public ISprite UnlockedDoorLeft()
        {
            return new ObjectSprite(this.UnlockedDoorLeftTexture, this.UnlockedDoorLeftData);
        }

        public ISprite UnlockedDoorRight()
        {
            return new ObjectSprite(this.UnlockedDoorRightTexture, this.UnlockedDoorRightData);
        }

        public ISprite UnlockedDoorUp()
        {
            return new ObjectSprite(this.UnlockedDoorUpTexture, this.UnlockedDoorUpData);
        }

        public ISprite LockedDoorDown()
        {
            return new ObjectSprite(this.LockedDoorDownTexture, this.LockedDoorDownData);
        }

        public ISprite LockedDoorLeft()
        {
            return new ObjectSprite(this.LockedDoorLeftTexture, this.LockedDoorLeftData);
        }

        public ISprite LockedDoorRight()
        {
            return new ObjectSprite(this.LockedDoorRightTexture, this.LockedDoorRightData);
        }

        public ISprite LockedDoorUp()
        {
            return new ObjectSprite(this.LockedDoorUpTexture, this.LockedDoorUpData);
        }

        public ISprite SpecialDoorDown()
        {
            return new ObjectSprite(this.SpecialDoorDownTexture, this.SpecialDoorDownData);
        }

        public ISprite SpecialDoorLeft()
        {
            return new ObjectSprite(this.SpecialDoorLeftTexture, this.SpecialDoorLeftData);
        }

        public ISprite SpecialDoorRight()
        {
            return new ObjectSprite(this.SpecialDoorRightTexture, this.SpecialDoorRightData);
        }

        public ISprite SpecialDoorUp()
        {
            return new ObjectSprite(this.SpecialDoorUpTexture, this.SpecialDoorUpData);
        }

        public ISprite Fire()
        {
            return new ObjectSprite(this.FireTexture, this.fireData);
        }

        public ISprite FloorTile()
        {
            return new ObjectSprite(this.FloorTileTexture, this.floorTileData);
        }

        public ISprite GapTile()
        {
            return new ObjectSprite(this.GapTileTexture, this.gapTileData);
        }

        public ISprite MovableSquare()
        {
            return new ObjectSprite(this.MovableSquareTexture, this.movableSquareData);
        }

        public ISprite BombedOpeningDown()
        {
            return new ObjectSprite(this.BombedOpeningDownTexture, this.bombedOpeningDownData);
        }

        public ISprite BombedOpeningUp()
        {
            return new ObjectSprite(this.BombedOpeningUpTexture, this.bombedOpeningUpData);
        }

        public ISprite BombedOpeningLeft()
        {
            return new ObjectSprite(this.BombedOpeningLeftTexture, this.bombedOpeningLeftData);
        }

        public ISprite BombedOpeningRight()
        {
            return new ObjectSprite(this.BombedOpeningRightTexture, this.bombedOpeningRightData);
        }

        public ISprite BlueStatueRight()
        {
            return new ObjectSprite(this.BlueStatueRightTexture, this.blueStatueRightData);
        }

        public ISprite BlueStatueLeft()
        {
            return new ObjectSprite(this.BlueStatueLeftTexture, this.blueStatueLeftData);
        }

        public ISprite TurquoiseStatueLeft()
        {
            return new ObjectSprite(this.TurquoiseStatueLeftTexture, this.turquoiseStatueLeftData);
        }

        public ISprite TurquoiseStatueRight()
        {
            return new ObjectSprite(this.TurquoiseStatueRightTexture, this.turquoiseStatueRightData);
        }

        public ISprite SpottedTile()
        {
            return new ObjectSprite(this.SpottedTileTexture, this.spottedTileData);
        }

        public ISprite WaterTile()
        {
            return new ObjectSprite(this.WaterTileTexture, this.waterTileData);
        }

        public ISprite OrangeMovableSquare()
        {
            return new ObjectSprite(this.OrangeMovableSquareTexture, this.orangeMovableSquareData);
        }

        public ISprite BasementBrickTile()
        {
            return new ObjectSprite(this.BasementBrickTileTexture, this.basementBrickTileData);
        }

        public ISprite LadderTile()
        {
            return new ObjectSprite(this.LadderTileTexture, this.ladderTileData);
        }

        public ISprite HorizontalBricks()
        {
            return new ObjectSprite(this.HorizontalBricksTexture, this.horizontalBricksData);
        }

        public ISprite VerticalBricks()
        {
            return new ObjectSprite(this.VerticalBricksTexture, this.verticalBricksData);
        }

        public ISprite BlueStatueLeft2()
        {
            return new ObjectSprite(this.BlueStatueLeft2Texture, this.blueStatueLeft2Data);
        }

        public ISprite BlueStatueRight2()
        {
            return new ObjectSprite(this.BlueStatueRight2Texture, this.blueStatueRight2Data);
        }

        public ISprite OrangeStatueRight2()
        {
            return new ObjectSprite(this.OrangeStatueRight2Texture, this.orangeStatueRight2Data);
        }

        public ISprite OrangeStatueLeft2()
        {
            return new ObjectSprite(this.OrangeStatueLeft2Texture, this.orangeStatueLeft2Data);
        }

        public ISprite BombedOpeningDown2()
        {
            return new ObjectSprite(this.BombedOpeningDown2Texture, this.bombedOpeningDown2Data);
        }

        public ISprite BombedOpeningLeft2()
        {
            return new ObjectSprite(this.BombedOpeningLeft2Texture, this.bombedOpeningLeft2Data);
        }

        public ISprite BombedOpeningRight2()
        {
            return new ObjectSprite(this.BombedOpeningRight2Texture, this.bombedOpeningRight2Data);
        }

        public ISprite BombedOpeningUp2()
        {
            return new ObjectSprite(this.BombedOpeningUp2Texture, this.bombedOpeningUp2Data);
        }

        public ISprite BossTile2()
        {
            return new ObjectSprite(this.BossTile2Texture, this.bossTile2Data);
        }

        public ISprite FloorTile2()
        {
            return new ObjectSprite(this.FloorTile2Texture, this.floorTile2Data);
        }

        public ISprite LavaTile2()
        {
            return new ObjectSprite(this.Lava2Texture, this.lava2Data);
        }

        public ISprite MovableSquare2()
        {
            return new ObjectSprite(this.MovableSquare2Texture, this.movableSquare2Data);
        }

        public ISprite SpottedTile2()
        {
            return new ObjectSprite(this.SpottedTile2Texture, this.spottedTile2Data);
        }
    }
}