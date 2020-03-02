namespace LoZClone
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class BlockSpriteFactory
    {
        private static readonly int tileWidth = 54;
        private static readonly int tileHeight = 48;
        private static readonly int verticalOffset = 72;
        private static readonly int horizontalOffset = 79;

        private static readonly int VerticalBlockWidth = 16;
        private static readonly int VerticalBlockHeight = 64;
        private static readonly int HorizontalBlockWidth = 64;
        private static readonly int HorizontalBlockHeight = 16;

        private Texture2D StairsTexture;
        private readonly SpriteSheetData stairsData = new SpriteSheetData("stairs", tileWidth, tileHeight, 1, 1);

        private Texture2D UnlockedDoorDownTexture;
        private readonly SpriteSheetData UnlockedDoorDownData = new SpriteSheetData("unlocked_door_down", tileWidth, tileHeight, 1, 1);
        private Texture2D UnlockedDoorLeftTexture;
        private readonly SpriteSheetData UnlockedDoorLeftData = new SpriteSheetData("unlocked_door_left", tileWidth, tileHeight, 1, 1);
        private Texture2D UnlockedDoorRightTexture;
        private readonly SpriteSheetData UnlockedDoorRightData = new SpriteSheetData("unlocked_door_right", tileWidth, tileHeight, 1, 1);
        private Texture2D UnlockedDoorUpTexture;
        private readonly SpriteSheetData UnlockedDoorUpData = new SpriteSheetData("unlocked_door_up", tileWidth, tileHeight, 1, 1);

        private Texture2D LockedDoorDownTexture;
        private readonly SpriteSheetData LockedDoorDownData = new SpriteSheetData("locked_door_down", tileWidth, tileHeight, 1, 1);
        private Texture2D LockedDoorLeftTexture;
        private readonly SpriteSheetData LockedDoorLeftData = new SpriteSheetData("locked_door_left", tileWidth, tileHeight, 1, 1);
        private Texture2D LockedDoorRightTexture;
        private readonly SpriteSheetData LockedDoorRightData = new SpriteSheetData("locked_door_right", tileWidth, tileHeight, 1, 1);
        private Texture2D LockedDoorUpTexture;
        private readonly SpriteSheetData LockedDoorUpData = new SpriteSheetData("locked_door_up", tileWidth, tileHeight, 1, 1);

        private Texture2D SpecialDoorDownTexture;
        private readonly SpriteSheetData SpecialDoorDownData = new SpriteSheetData("special_door_down", tileWidth, tileHeight, 1, 1);
        private Texture2D SpecialDoorLeftTexture;
        private readonly SpriteSheetData SpecialDoorLeftData = new SpriteSheetData("special_door_left", tileWidth, tileHeight, 1, 1);
        private Texture2D SpecialDoorRightTexture;
        private readonly SpriteSheetData SpecialDoorRightData = new SpriteSheetData("special_door_right", tileWidth, tileHeight, 1, 1);
        private Texture2D SpecialDoorUpTexture;
        private readonly SpriteSheetData SpecialDoorUpData = new SpriteSheetData("special_door_up", tileWidth, tileHeight, 1, 1);

        private Texture2D FireTexture;
        private readonly SpriteSheetData fireData = new SpriteSheetData("fire", tileWidth, tileHeight, 1, 2);
        private Texture2D FloorTileTexture;
        private readonly SpriteSheetData floorTileData = new SpriteSheetData("floor_tile", tileWidth, tileHeight, 1, 1);
        private Texture2D GapTileTexture;
        private readonly SpriteSheetData gapTileData = new SpriteSheetData("gap_tile", tileWidth, tileHeight, 1, 1);
        private Texture2D MovableSquareTexture;
        private readonly SpriteSheetData movableSquareData = new SpriteSheetData("movable_square", tileWidth, tileHeight, 1, 1);

        private Texture2D BombedOpeningDownTexture;
        private readonly SpriteSheetData bombedOpeningDownData = new SpriteSheetData("bombed_opening_down", tileWidth, tileHeight, 1, 1);
        private Texture2D BombedOpeningUpTexture;
        private readonly SpriteSheetData bombedOpeningUpData = new SpriteSheetData("bombed_opening_up", tileWidth, tileHeight, 1, 1);
        private Texture2D BombedOpeningRightTexture;
        private readonly SpriteSheetData bombedOpeningRightData = new SpriteSheetData("bombed_opening_right", tileWidth, tileHeight, 1, 1);
        private Texture2D BombedOpeningLeftTexture;
        private readonly SpriteSheetData bombedOpeningLeftData = new SpriteSheetData("bombed_opening_left", tileWidth, tileHeight, 1, 1);

        private Texture2D BlueStatueRightTexture;
        private readonly SpriteSheetData blueStatueRightData = new SpriteSheetData("blue_statue_right", tileWidth, tileHeight, 1, 1);
        private Texture2D BlueStatueLeftTexture;
        private readonly SpriteSheetData blueStatueLeftData = new SpriteSheetData("blue_statue_left", tileWidth, tileHeight, 1, 1);
        private Texture2D TurquoiseStatueTexture;
        private readonly SpriteSheetData turquoiseStatueData = new SpriteSheetData("turquoise_statue", tileWidth, tileHeight, 1, 2);

        private Texture2D SpottedTileTexture;
        private readonly SpriteSheetData spottedTileData = new SpriteSheetData("spotted_tile", tileWidth, tileHeight, 1, 1);
        private Texture2D WaterTileTexture;
        private readonly SpriteSheetData waterTileData = new SpriteSheetData("water_tile", tileWidth, tileHeight, 1, 1);

        private Texture2D OrangeMovableSquareTexture;
        private readonly SpriteSheetData orangeMovableSquareData = new SpriteSheetData("orange_movable_square", tileWidth, tileHeight, 1, 1);
        private Texture2D EnemyDeathExplosionTexture;
        private readonly SpriteSheetData enemyDeathExplosionData = new SpriteSheetData("enemyDeath", tileWidth, tileHeight, 1, 6);
        private Texture2D EnemySpawnTexture;
        private readonly SpriteSheetData enemySpawnData = new SpriteSheetData("enemySpawn", tileWidth, tileHeight, 3, 1);
        private Texture2D BasementBrickTileTexture;
        private readonly SpriteSheetData basementBrickTileData = new SpriteSheetData("basement_brick_tile", tileWidth, tileHeight, 1, 1);
        private Texture2D LadderTileTexture;
        private readonly SpriteSheetData ladderTileData = new SpriteSheetData("ladder_tile", tileWidth, tileHeight, 1, 1);
        private Texture2D HorizontalBricksTexture;
        private readonly SpriteSheetData horizontalBricksData = new SpriteSheetData("horizontal_bricks", HorizontalBlockWidth, HorizontalBlockHeight, 1, 1);
        private Texture2D VerticalBricksTexture;
        private readonly SpriteSheetData verticalBricksData = new SpriteSheetData("vertical_bricks", VerticalBlockWidth, VerticalBlockHeight, 1, 1);

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

        public int VerticalOffset
        {
            get { return verticalOffset; }
        }

        public int HorizontalOffset
        {
            get { return horizontalOffset; }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.FloorTileTexture = content.Load<Texture2D>(this.floorTileData.FilePath);
            this.StairsTexture = content.Load<Texture2D>(this.stairsData.FilePath);
            this.MovableSquareTexture = content.Load<Texture2D>(this.movableSquareData.FilePath);
            this.GapTileTexture = content.Load<Texture2D>(this.gapTileData.FilePath);
            this.UnlockedDoorDownTexture = content.Load<Texture2D>(this.UnlockedDoorDownData.FilePath);
            this.UnlockedDoorLeftTexture = content.Load<Texture2D>(this.UnlockedDoorLeftData.FilePath);
            this.UnlockedDoorRightTexture = content.Load<Texture2D>(this.UnlockedDoorRightData.FilePath);
            this.UnlockedDoorUpTexture = content.Load<Texture2D>(this.UnlockedDoorUpData.FilePath);
            this.LockedDoorDownTexture = content.Load<Texture2D>(this.LockedDoorDownData.FilePath);
            this.LockedDoorLeftTexture = content.Load<Texture2D>(this.LockedDoorLeftData.FilePath);
            this.LockedDoorRightTexture = content.Load<Texture2D>(this.LockedDoorRightData.FilePath);
            this.LockedDoorUpTexture = content.Load<Texture2D>(this.LockedDoorUpData.FilePath);
            this.SpecialDoorDownTexture = content.Load<Texture2D>(this.SpecialDoorDownData.FilePath);
            this.SpecialDoorLeftTexture = content.Load<Texture2D>(this.SpecialDoorLeftData.FilePath);
            this.SpecialDoorRightTexture = content.Load<Texture2D>(this.SpecialDoorRightData.FilePath);
            this.SpecialDoorUpTexture = content.Load<Texture2D>(this.SpecialDoorUpData.FilePath);
            this.FireTexture = content.Load<Texture2D>(this.fireData.FilePath);
            this.BombedOpeningDownTexture = content.Load<Texture2D>(this.bombedOpeningDownData.FilePath);
            this.BombedOpeningUpTexture = content.Load<Texture2D>(this.bombedOpeningUpData.FilePath);
            this.BombedOpeningRightTexture = content.Load<Texture2D>(this.bombedOpeningRightData.FilePath);
            this.BombedOpeningLeftTexture = content.Load<Texture2D>(this.bombedOpeningLeftData.FilePath);
            this.BlueStatueRightTexture = content.Load<Texture2D>(this.blueStatueRightData.FilePath);
            this.BlueStatueLeftTexture = content.Load<Texture2D>(this.blueStatueLeftData.FilePath);
            this.TurquoiseStatueTexture = content.Load<Texture2D>(this.turquoiseStatueData.FilePath);
            this.SpottedTileTexture = content.Load<Texture2D>(this.spottedTileData.FilePath);
            this.WaterTileTexture = content.Load<Texture2D>(this.waterTileData.FilePath);
            this.OrangeMovableSquareTexture = content.Load<Texture2D>(this.orangeMovableSquareData.FilePath);
            this.EnemyDeathExplosionTexture = content.Load<Texture2D>(this.enemyDeathExplosionData.FilePath);
            this.EnemySpawnTexture = content.Load<Texture2D>(this.enemySpawnData.FilePath);
            this.BasementBrickTileTexture = content.Load<Texture2D>(this.basementBrickTileData.FilePath);
            this.LadderTileTexture = content.Load<Texture2D>(this.ladderTileData.FilePath);
            this.HorizontalBricksTexture = content.Load<Texture2D>(this.horizontalBricksData.FilePath);
            this.VerticalBricksTexture = content.Load<Texture2D>(this.verticalBricksData.FilePath);
        }


        public StairsSprite Stairs(Vector2 loc)
        {
            return new StairsSprite(this.StairsTexture, loc, this.stairsData);
        }

        public UnlockedDoorDownSprite UnlockedDoorDown(Vector2 loc)
        {
            return new UnlockedDoorDownSprite(this.UnlockedDoorDownTexture, loc, this.UnlockedDoorDownData);
        }

        public UnlockedDoorLeftSprite UnlockedDoorLeft(Vector2 loc)
        {
            return new UnlockedDoorLeftSprite(this.UnlockedDoorLeftTexture, loc, this.UnlockedDoorLeftData);
        }

        public UnlockedDoorRightSprite UnlockedDoorRight(Vector2 loc)
        {
            return new UnlockedDoorRightSprite(this.UnlockedDoorRightTexture, loc, this.UnlockedDoorRightData);
        }

        public UnlockedDoorUpSprite UnlockedDoorUp(Vector2 loc)
        {
            return new UnlockedDoorUpSprite(this.UnlockedDoorUpTexture, loc, this.UnlockedDoorUpData);
        }

        public LockedDoorDownSprite LockedDoorDown(Vector2 loc)
        {
            return new LockedDoorDownSprite(this.LockedDoorDownTexture, loc, this.LockedDoorDownData);
        }

        public LockedDoorLeftSprite LockedDoorLeft(Vector2 loc)
        {
            return new LockedDoorLeftSprite(this.LockedDoorLeftTexture, loc, this.LockedDoorLeftData);
        }

        public LockedDoorRightSprite LockedDoorRight(Vector2 loc)
        {
            return new LockedDoorRightSprite(this.LockedDoorRightTexture, loc, this.LockedDoorRightData);
        }

        public LockedDoorUpSprite LockedDoorUp(Vector2 loc)
        {
            return new LockedDoorUpSprite(this.LockedDoorUpTexture, loc, this.LockedDoorUpData);
        }

        public SpecialDoorDownSprite SpecialDoorDown(Vector2 loc)
        {
            return new SpecialDoorDownSprite(this.SpecialDoorDownTexture, loc, this.SpecialDoorDownData);
        }

        public SpecialDoorLeftSprite SpecialDoorLeft(Vector2 loc)
        {
            return new SpecialDoorLeftSprite(this.SpecialDoorLeftTexture, loc, this.SpecialDoorLeftData);
        }

        public SpecialDoorRightSprite SpecialDoorRight(Vector2 loc)
        {
            return new SpecialDoorRightSprite(this.SpecialDoorRightTexture, loc, this.SpecialDoorRightData);
        }

        public SpecialDoorUpSprite SpecialDoorUp(Vector2 loc)
        {
            return new SpecialDoorUpSprite(this.SpecialDoorUpTexture, loc, this.SpecialDoorUpData);
        }

        public FireSprite Fire(Vector2 loc)
        {
            return new FireSprite(this.FireTexture, loc, this.fireData);
        }

        public FloorTileSprite FloorTile(Vector2 loc)
        {
            return new FloorTileSprite(this.FloorTileTexture, loc, this.floorTileData);
        }

        public GapTileSprite GapTile(Vector2 loc)
        {
            return new GapTileSprite(this.GapTileTexture, loc, this.gapTileData);
        }

        public MovableSquareSprite MovableSquare(Vector2 loc)
        {
            return new MovableSquareSprite(this.MovableSquareTexture, loc, this.movableSquareData);
        }

        public BombedOpeningDownSprite BombedOpeningDown(Vector2 loc)
        {
            return new BombedOpeningDownSprite(this.BombedOpeningDownTexture, loc, this.bombedOpeningDownData);
        }

        public BombedOpeningUpSprite BombedOpeningUp(Vector2 loc)
        {
            return new BombedOpeningUpSprite(this.BombedOpeningUpTexture, loc, this.bombedOpeningUpData);
        }

        public BombedOpeningLeftSprite BombedOpeningLeft(Vector2 loc)
        {
            return new BombedOpeningLeftSprite(this.BombedOpeningLeftTexture, loc, this.bombedOpeningLeftData);
        }

        public BombedOpeningRightSprite BombedOpeningRight(Vector2 loc)
        {
            return new BombedOpeningRightSprite(this.BombedOpeningRightTexture, loc, this.bombedOpeningRightData);
        }

        public BlueStatueRightSprite BlueStatueRight(Vector2 loc)
        {
            return new BlueStatueRightSprite(this.BlueStatueRightTexture, loc, this.blueStatueRightData);
        }

        public BlueStatueLeftSprite BlueStatueLeft(Vector2 loc)
        {
            return new BlueStatueLeftSprite(this.BlueStatueLeftTexture, loc, this.blueStatueLeftData);
        }

        public TurquoiseStatueLeftSprite TurquoiseStatueLeft(Vector2 loc)
        {
            return new TurquoiseStatueLeftSprite(this.TurquoiseStatueTexture, loc, this.turquoiseStatueData);
        }

        public TurquoiseStatueRightSprite TurquoiseStatueRight(Vector2 loc)
        {
            return new TurquoiseStatueRightSprite(this.TurquoiseStatueTexture, loc, this.turquoiseStatueData);
        }

        public SpottedTileSprite SpottedTile(Vector2 loc)
        {
            return new SpottedTileSprite(this.SpottedTileTexture, loc, this.spottedTileData);
        }

        public WaterTileSprite WaterTile(Vector2 loc)
        {
            return new WaterTileSprite(this.WaterTileTexture, loc, this.waterTileData);
        }

        public OrangeMovableSquareSprite OrangeMovableSquare(Vector2 loc)
        {
            return new OrangeMovableSquareSprite(this.OrangeMovableSquareTexture, loc, this.orangeMovableSquareData);
        }

        public EnemyDeathExplosionSprite EnemyDeathExplosion(Vector2 loc)
        {
            return new EnemyDeathExplosionSprite(this.EnemyDeathExplosionTexture, loc, this.enemyDeathExplosionData);
        }

        public EnemySpawnSprite EnemySpawn(Vector2 loc)
        {
            return new EnemySpawnSprite(this.EnemySpawnTexture, loc, this.enemySpawnData);
        }

        public BasementBrickTileSprite BasementBrickTile(Vector2 loc)
        {
            return new BasementBrickTileSprite(this.BasementBrickTileTexture, loc, this.basementBrickTileData);
        }

        public LadderTileSprite LadderTile(Vector2 loc)
        {
            return new LadderTileSprite(this.LadderTileTexture, loc, this.ladderTileData);
        }

        public HorizontalBricksSprite HorizontalBricks(Vector2 loc)
        {
            return new HorizontalBricksSprite(this.HorizontalBricksTexture, loc, this.horizontalBricksData);
        }

        public VerticalBricksSprite VerticalBricks(Vector2 loc)
        {
            return new VerticalBricksSprite(this.VerticalBricksTexture, loc, this.verticalBricksData);
        }
    }
}