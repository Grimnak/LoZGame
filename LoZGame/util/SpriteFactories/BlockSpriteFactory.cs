namespace LoZClone
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class BlockSpriteFactory
    {
        private static readonly float tileOffset = 53.5f;
        private static readonly float tileWidth = 54;
        private static readonly int tileHeight = 48;
        private static readonly int movableTileWidth = 54;
        private static readonly int movableTileHeight = 47;
        private static readonly int topOffset = LoZGame.Instance.InventoryOffset + 72;
        private static readonly int bottomOffset = LoZGame.Instance.ScreenHeight - 72;
        private static readonly int verticalOffset = 72;
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

        private Texture2D UnlockedDoorDownFrameTexture;
        private Texture2D UnlockedDoorDownFloorTexture;
        private SpriteData UnlockedDoorDownData;
        private Texture2D UnlockedDoorLeftFrameTexture;
        private Texture2D UnlockedDoorLeftFloorTexture;
        private SpriteData UnlockedDoorLeftData;
        private Texture2D UnlockedDoorRightFrameTexture;
        private Texture2D UnlockedDoorRightFloorTexture;
        private SpriteData UnlockedDoorRightData;
        private Texture2D UnlockedDoorUpFrameTexture;
        private Texture2D UnlockedDoorUpFloorTexture;
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

        private Texture2D SpottedTile3Texture;
        private SpriteData spottedTile3Data;
        private Texture2D MovableSquare3Texture;
        private SpriteData movableSquare3Data;
        private Texture2D StairsTexture3;
        private SpriteData stairsData3;

        private Texture2D RedStatueLeft3Texture;
        private SpriteData redStatueLeft3Data;
        private Texture2D RedStatueRight3Texture;
        private SpriteData redStatueRight3Data;
        private Texture2D GreenStatueRight3Texture;
        private SpriteData greenStatueRight3Data;
        private Texture2D GreenStatueLeft3Texture;
        private SpriteData greenStatueLeft3Data;

        private Texture2D Lava5Texture;
        private SpriteData lava5Data;

        private Texture2D BlueStatueLeft4Texture;
        private SpriteData blueStatueLeft4Data;
        private Texture2D BlueStatueRight4Texture;
        private SpriteData blueStatueRight4Data;
        private Texture2D BrownStatueRight4Texture;
        private SpriteData brownStatueRight4Data;
        private Texture2D BrownStatueLeft4Texture;
        private SpriteData brownStatueLeft4Data;

        private Texture2D MovableTile4Texture;
        private SpriteData movableTile4Data;

        private Texture2D WaterTileLadderTexture;
        private SpriteData waterTileLadderData;
        private Texture2D LavaTileLadderTexture;
        private SpriteData lavaTileLadderData;

        private static readonly BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        
        public float TileWidth
        {
            get { return tileOffset; }
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

        public int VerticalOffset
        {
            get { return verticalOffset; }
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
            LoadTextures(content);
            LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            FloorTileTexture = content.Load<Texture2D>("floor_tile");
            StairsTexture = content.Load<Texture2D>("stairs");
            MovableSquareTexture = content.Load<Texture2D>("movable_square");
            GapTileTexture = content.Load<Texture2D>("gap_tile");
            UnlockedDoorDownFrameTexture = content.Load<Texture2D>("unlocked_door_down_frame");
            UnlockedDoorLeftFrameTexture = content.Load<Texture2D>("unlocked_door_left_frame");
            UnlockedDoorRightFrameTexture = content.Load<Texture2D>("unlocked_door_right_frame");
            UnlockedDoorUpFrameTexture = content.Load<Texture2D>("unlocked_door_up_frame");
            UnlockedDoorDownFloorTexture = content.Load<Texture2D>("unlocked_door_down_floor");
            UnlockedDoorLeftFloorTexture = content.Load<Texture2D>("unlocked_door_left_floor");
            UnlockedDoorRightFloorTexture = content.Load<Texture2D>("unlocked_door_right_floor");
            UnlockedDoorUpFloorTexture = content.Load<Texture2D>("unlocked_door_up_floor");
            LockedDoorDownTexture = content.Load<Texture2D>("locked_door_down");
            LockedDoorLeftTexture = content.Load<Texture2D>("locked_door_left");
            LockedDoorRightTexture = content.Load<Texture2D>("locked_door_right");
            LockedDoorUpTexture = content.Load<Texture2D>("locked_door_up");
            SpecialDoorDownTexture = content.Load<Texture2D>("special_door_down");
            SpecialDoorLeftTexture = content.Load<Texture2D>("special_door_left");
            SpecialDoorRightTexture = content.Load<Texture2D>("special_door_right");
            SpecialDoorUpTexture = content.Load<Texture2D>("special_door_up");
            FireTexture = content.Load<Texture2D>("fire");
            BombedOpeningDownTexture = content.Load<Texture2D>("bombed_opening_down");
            BombedOpeningUpTexture = content.Load<Texture2D>("bombed_opening_up");
            BombedOpeningRightTexture = content.Load<Texture2D>("bombed_opening_right");
            BombedOpeningLeftTexture = content.Load<Texture2D>("bombed_opening_left");
            BlueStatueRightTexture = content.Load<Texture2D>("blue_statue_right");
            BlueStatueLeftTexture = content.Load<Texture2D>("blue_statue_left");
            TurquoiseStatueRightTexture = content.Load<Texture2D>("turquoise_statue_right");
            TurquoiseStatueLeftTexture = content.Load<Texture2D>("turquoise_statue_left");
            SpottedTileTexture = content.Load<Texture2D>("spotted_tile");
            WaterTileTexture = content.Load<Texture2D>("water_tile");
            OrangeMovableSquareTexture = content.Load<Texture2D>("orange_movable_square");
            BasementBrickTileTexture = content.Load<Texture2D>("basement_brick_tile");
            LadderTileTexture = content.Load<Texture2D>("ladder_tile");
            HorizontalBricksTexture = content.Load<Texture2D>("horizontal_bricks");
            VerticalBricksTexture = content.Load<Texture2D>("vertical_bricks");

            BlueStatueLeft2Texture = content.Load<Texture2D>("blue_statue_left2");
            BlueStatueRight2Texture = content.Load<Texture2D>("blue_statue_right2");
            OrangeStatueRight2Texture = content.Load<Texture2D>("orange_statue_right2");
            OrangeStatueLeft2Texture = content.Load<Texture2D>("orange_statue_left2");
            BossTile2Texture = content.Load<Texture2D>("boss_tile2");
            FloorTile2Texture = content.Load<Texture2D>("floor_tile2");
            Lava2Texture = content.Load<Texture2D>("lava2");
            MovableSquare2Texture = content.Load<Texture2D>("movable_square2");
            SpottedTile2Texture = content.Load<Texture2D>("spotted_tile2");

            RedStatueLeft3Texture = content.Load<Texture2D>("red_statue_left3");
            RedStatueRight3Texture = content.Load<Texture2D>("red_statue_right3");
            GreenStatueRight3Texture = content.Load<Texture2D>("green_statue_right");
            GreenStatueLeft3Texture = content.Load<Texture2D>("green_statue_left3");
            MovableSquare3Texture = content.Load<Texture2D>("movable_square3");
            SpottedTile3Texture = content.Load<Texture2D>("spotted_tile3");
            StairsTexture3 = content.Load<Texture2D>("stairs3");

            BlueStatueLeft4Texture = content.Load<Texture2D>("blue_statue_left4");
            BlueStatueRight4Texture = content.Load<Texture2D>("blue_statue_right4");
            BrownStatueRight4Texture = content.Load<Texture2D>("brown_statue_right4");
            BrownStatueLeft4Texture = content.Load<Texture2D>("brown_statue_left4");
            MovableTile4Texture = content.Load<Texture2D>("movable_tile4");

            Lava5Texture = content.Load<Texture2D>("lava5");

            WaterTileLadderTexture = content.Load<Texture2D>("ladder_on_water");
            LavaTileLadderTexture = content.Load<Texture2D>("ladder_on_lava");
        }

        private void LoadData()
        {
            stairsData = new SpriteData(new Vector2(tileWidth + 1, tileHeight), StairsTexture, 1, 1);
            UnlockedDoorDownData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorDownFrameTexture, 1, 1);
            UnlockedDoorLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorLeftFrameTexture, 1, 1);
            UnlockedDoorRightData = new SpriteData(new Vector2(doorHeight, doorWidth), UnlockedDoorRightFrameTexture, 1, 1);
            UnlockedDoorUpData = new SpriteData(new Vector2(doorWidth, doorHeight), UnlockedDoorUpFrameTexture, 1, 1);
            LockedDoorDownData = new SpriteData(new Vector2(doorWidth, doorHeight), LockedDoorDownTexture, 1, 1);
            LockedDoorLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), LockedDoorLeftTexture, 1, 1);
            LockedDoorRightData = new SpriteData(new Vector2(doorHeight, doorWidth), LockedDoorRightTexture, 1, 1);
            LockedDoorUpData = new SpriteData(new Vector2(doorWidth, doorHeight), LockedDoorUpTexture, 1, 1);
            SpecialDoorDownData = new SpriteData(new Vector2(doorWidth, doorHeight), SpecialDoorDownTexture, 1, 1);
            SpecialDoorLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), SpecialDoorLeftTexture, 1, 1);
            SpecialDoorRightData = new SpriteData(new Vector2(doorHeight, doorWidth), SpecialDoorRightTexture, 1, 1);
            SpecialDoorUpData = new SpriteData(new Vector2(doorWidth, doorHeight), SpecialDoorUpTexture, 1, 1);
            bombedOpeningDownData = new SpriteData(new Vector2(doorWidth, doorHeight), BombedOpeningDownTexture, 1, 1);
            bombedOpeningUpData = new SpriteData(new Vector2(doorWidth, doorHeight), BombedOpeningUpTexture, 1, 1);
            bombedOpeningRightData = new SpriteData(new Vector2(doorHeight, doorWidth), BombedOpeningRightTexture, 1, 1);
            bombedOpeningLeftData = new SpriteData(new Vector2(doorHeight, doorWidth), BombedOpeningLeftTexture, 1, 1);
            fireData = new SpriteData(new Vector2(tileWidth, tileHeight), FireTexture, 1, 2);
            floorTileData = new SpriteData(new Vector2(tileWidth, tileHeight), FloorTileTexture, 1, 1);
            gapTileData = new SpriteData(new Vector2(tileWidth, tileHeight), GapTileTexture, 1, 1);
            movableSquareData = new SpriteData(new Vector2(tileWidth, tileHeight), MovableSquareTexture, 1, 1);
            blueStatueRightData = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueRightTexture, 1, 1);
            blueStatueLeftData = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueLeftTexture, 1, 1);
            turquoiseStatueLeftData = new SpriteData(new Vector2(tileWidth, tileHeight), TurquoiseStatueLeftTexture, 1, 1);
            turquoiseStatueRightData = new SpriteData(new Vector2(tileWidth, tileHeight), TurquoiseStatueRightTexture, 1, 1);
            spottedTileData = new SpriteData(new Vector2(tileWidth, tileHeight), SpottedTileTexture, 1, 1);
            waterTileData = new SpriteData(new Vector2(tileWidth, tileHeight), WaterTileTexture, 1, 1);
            orangeMovableSquareData = new SpriteData(new Vector2(tileWidth, tileHeight), OrangeMovableSquareTexture, 1, 1);
            basementBrickTileData = new SpriteData(new Vector2(tileWidth, tileHeight), BasementBrickTileTexture, 1, 1);
            ladderTileData = new SpriteData(new Vector2(tileWidth, tileHeight), LadderTileTexture, 1, 1);
            horizontalBricksData = new SpriteData(new Vector2(HorizontalBlockWidth, HorizontalBlockHeight), HorizontalBricksTexture, 1, 1);
            verticalBricksData = new SpriteData(new Vector2(VerticalBlockWidth, VerticalBlockHeight), VerticalBricksTexture, 1, 1);

            blueStatueLeft2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueLeft2Texture, 1, 1);
            blueStatueRight2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueRight2Texture, 1, 1);
            orangeStatueRight2Data = new SpriteData(new Vector2(tileWidth, tileHeight), OrangeStatueRight2Texture, 1, 1);
            orangeStatueLeft2Data = new SpriteData(new Vector2(tileWidth, tileHeight), OrangeStatueLeft2Texture, 1, 1);
            bossTile2Data = new SpriteData(new Vector2(tileWidth, tileHeight), BossTile2Texture, 1, 1);
            floorTile2Data = new SpriteData(new Vector2(tileWidth, tileHeight), FloorTile2Texture, 1, 1);
            lava2Data = new SpriteData(new Vector2(tileWidth, tileHeight), Lava2Texture, 1, 1);
            movableSquare2Data = new SpriteData(new Vector2(tileWidth, tileHeight), MovableSquare2Texture, 1, 1);
            spottedTile2Data = new SpriteData(new Vector2(tileWidth, tileHeight), SpottedTile2Texture, 1, 1);

            redStatueLeft3Data = new SpriteData(new Vector2(tileWidth, tileHeight), RedStatueLeft3Texture, 1, 1);
            redStatueRight3Data = new SpriteData(new Vector2(tileWidth, tileHeight), RedStatueRight3Texture, 1, 1);
            greenStatueRight3Data = new SpriteData(new Vector2(tileWidth, tileHeight), GreenStatueRight3Texture, 1, 1);
            greenStatueLeft3Data = new SpriteData(new Vector2(tileWidth, tileHeight), GreenStatueLeft3Texture, 1, 1);
            movableSquare3Data = new SpriteData(new Vector2(tileWidth, tileHeight), MovableSquare3Texture, 1, 1);
            spottedTile3Data = new SpriteData(new Vector2(tileWidth, tileHeight), SpottedTile3Texture, 1, 1);
            stairsData3 = new SpriteData(new Vector2(tileWidth, tileHeight), StairsTexture3, 1, 1);

            blueStatueLeft4Data = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueLeft4Texture, 1, 1);
            blueStatueRight4Data = new SpriteData(new Vector2(tileWidth, tileHeight), BlueStatueRight4Texture, 1, 1);
            brownStatueRight4Data = new SpriteData(new Vector2(tileWidth, tileHeight), BrownStatueRight4Texture, 1, 1);
            brownStatueLeft4Data = new SpriteData(new Vector2(tileWidth, tileHeight), BrownStatueLeft4Texture, 1, 1);
            movableTile4Data = new SpriteData(new Vector2(tileWidth, tileHeight), MovableTile4Texture, 1, 1);

            lava5Data = new SpriteData(new Vector2(tileWidth, tileHeight), Lava5Texture, 1, 1);

            waterTileLadderData = new SpriteData(new Vector2(tileWidth, tileHeight), WaterTileLadderTexture, 1, 1);
            lavaTileLadderData = new SpriteData(new Vector2(tileWidth, tileHeight), LavaTileLadderTexture, 1, 1);
        }

        public ISprite Stairs()
        {
            return new ObjectSprite(StairsTexture, stairsData);
        }

        public ISprite UnlockedDoorFrameDown()
        {
            return new ObjectSprite(UnlockedDoorDownFrameTexture, UnlockedDoorDownData);
        }

        public ISprite UnlockedDoorFloorDown()
        {
            return new ObjectSprite(UnlockedDoorDownFloorTexture, UnlockedDoorDownData);
        }

        public ISprite UnlockedDoorFrameLeft()
        {
            return new ObjectSprite(UnlockedDoorLeftFrameTexture, UnlockedDoorLeftData);
        }

        public ISprite UnlockedDoorFloorLeft()
        {
            return new ObjectSprite(UnlockedDoorLeftFloorTexture, UnlockedDoorLeftData);
        }

        public ISprite UnlockedDoorFrameRight()
        {
            return new ObjectSprite(UnlockedDoorRightFrameTexture, UnlockedDoorRightData);
        }

        public ISprite UnlockedDoorFloorRight()
        {
            return new ObjectSprite(UnlockedDoorRightFloorTexture, UnlockedDoorRightData);
        }

        public ISprite UnlockedDoorFrameUp()
        {
            return new ObjectSprite(UnlockedDoorUpFrameTexture, UnlockedDoorUpData);
        }

        public ISprite UnlockedDoorFloorUp()
        {
            return new ObjectSprite(UnlockedDoorUpFloorTexture, UnlockedDoorUpData);
        }

        public ISprite LockedDoorDown()
        {
            return new ObjectSprite(LockedDoorDownTexture, LockedDoorDownData);
        }

        public ISprite LockedDoorLeft()
        {
            return new ObjectSprite(LockedDoorLeftTexture, LockedDoorLeftData);
        }

        public ISprite LockedDoorRight()
        {
            return new ObjectSprite(LockedDoorRightTexture, LockedDoorRightData);
        }

        public ISprite LockedDoorUp()
        {
            return new ObjectSprite(LockedDoorUpTexture, LockedDoorUpData);
        }

        public ISprite SpecialDoorDown()
        {
            return new ObjectSprite(SpecialDoorDownTexture, SpecialDoorDownData);
        }

        public ISprite SpecialDoorLeft()
        {
            return new ObjectSprite(SpecialDoorLeftTexture, SpecialDoorLeftData);
        }

        public ISprite SpecialDoorRight()
        {
            return new ObjectSprite(SpecialDoorRightTexture, SpecialDoorRightData);
        }

        public ISprite SpecialDoorUp()
        {
            return new ObjectSprite(SpecialDoorUpTexture, SpecialDoorUpData);
        }

        public ISprite Fire()
        {
            return new ObjectSprite(FireTexture, fireData);
        }

        public ISprite FloorTile()
        {
            return new ObjectSprite(FloorTileTexture, floorTileData);
        }

        public ISprite GapTile()
        {
            return new ObjectSprite(GapTileTexture, gapTileData);
        }

        public ISprite MovableSquare()
        {
            return new ObjectSprite(MovableSquareTexture, movableSquareData);
        }

        public ISprite BombedOpeningDown()
        {
            return new ObjectSprite(BombedOpeningDownTexture, bombedOpeningDownData);
        }

        public ISprite BombedOpeningUp()
        {
            return new ObjectSprite(BombedOpeningUpTexture, bombedOpeningUpData);
        }

        public ISprite BombedOpeningLeft()
        {
            return new ObjectSprite(BombedOpeningLeftTexture, bombedOpeningLeftData);
        }

        public ISprite BombedOpeningRight()
        {
            return new ObjectSprite(BombedOpeningRightTexture, bombedOpeningRightData);
        }

        public ISprite BlueStatueRight()
        {
            return new ObjectSprite(BlueStatueRightTexture, blueStatueRightData);
        }

        public ISprite BlueStatueLeft()
        {
            return new ObjectSprite(BlueStatueLeftTexture, blueStatueLeftData);
        }

        public ISprite TurquoiseStatueLeft()
        {
            return new ObjectSprite(TurquoiseStatueLeftTexture, turquoiseStatueLeftData);
        }

        public ISprite TurquoiseStatueRight()
        {
            return new ObjectSprite(TurquoiseStatueRightTexture, turquoiseStatueRightData);
        }

        public ISprite SpottedTile()
        {
            return new ObjectSprite(SpottedTileTexture, spottedTileData);
        }

        public ISprite WaterTile()
        {
            return new ObjectSprite(WaterTileTexture, waterTileData);
        }

        public ISprite OrangeMovableSquare()
        {
            return new ObjectSprite(OrangeMovableSquareTexture, orangeMovableSquareData);
        }

        public ISprite BasementBrickTile()
        {
            return new ObjectSprite(BasementBrickTileTexture, basementBrickTileData);
        }

        public ISprite LadderTile()
        {
            return new ObjectSprite(LadderTileTexture, ladderTileData);
        }

        public ISprite BlueStatueLeft2()
        {
            return new ObjectSprite(BlueStatueLeft2Texture, blueStatueLeft2Data);
        }

        public ISprite BlueStatueRight2()
        {
            return new ObjectSprite(BlueStatueRight2Texture, blueStatueRight2Data);
        }

        public ISprite OrangeStatueRight2()
        {
            return new ObjectSprite(OrangeStatueRight2Texture, orangeStatueRight2Data);
        }

        public ISprite OrangeStatueLeft2()
        {
            return new ObjectSprite(OrangeStatueLeft2Texture, orangeStatueLeft2Data);
        }

        public ISprite BossTile2()
        {
            return new ObjectSprite(BossTile2Texture, bossTile2Data);
        }

        public ISprite LavaTile2()
        {
            return new ObjectSprite(Lava2Texture, lava2Data);
        }

        public ISprite RedStatueLeft3()
        {
            return new ObjectSprite(RedStatueLeft3Texture, redStatueLeft3Data);
        }

        public ISprite RedStatueRight3()
        {
            return new ObjectSprite(RedStatueRight3Texture, redStatueRight3Data);
        }

        public ISprite GreenStatueRight3()
        {
            return new ObjectSprite(GreenStatueRight3Texture, greenStatueRight3Data);
        }

        public ISprite GreenStatueLeft3()
        {
            return new ObjectSprite(GreenStatueLeft3Texture, greenStatueLeft3Data);
        }

        public ISprite BlueStatueLeft4()
        {
            return new ObjectSprite(BlueStatueLeft4Texture, blueStatueLeft4Data);
        }

        public ISprite BlueStatueRight4()
        {
            return new ObjectSprite(BlueStatueRight4Texture, blueStatueRight4Data);
        }

        public ISprite BrownStatueRight4()
        {
            return new ObjectSprite(BrownStatueRight4Texture, brownStatueRight4Data);
        }

        public ISprite BrownStatueLeft4()
        {
            return new ObjectSprite(BrownStatueLeft4Texture, brownStatueLeft4Data);
        }

        public ISprite MovableTile4()
        {
            return new ObjectSprite(MovableTile4Texture, movableTile4Data);
        }

        public ISprite Lava5()
        {
            return new ObjectSprite(Lava5Texture, lava5Data);
        }

        public ISprite WaterTileLadder()
        {
            return new ObjectSprite(WaterTileLadderTexture, waterTileLadderData);
        }

        public ISprite LavaTileLadder()
        {
            return new ObjectSprite(LavaTileLadderTexture, lavaTileLadderData);
        }
    }
}