namespace LoZClone
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class BlockSpriteFactory
    {
        private static readonly int BlockWidth = 50;
        private static readonly int BlockHeight = 50;
        private static readonly int VerticalBlockWidth = 16;
        private static readonly int VerticalBlockHeight = 64;
        private static readonly int HorizontalBlockWidth = 64;
        private static readonly int HorizontalBlockHeight = 16;

        private Texture2D StairsTexture;
        private readonly SpriteSheetData stairsData = new SpriteSheetData("stairs", BlockWidth, BlockHeight, 1, 1);

        private Texture2D DoorDownTexture;
        private readonly SpriteSheetData doorDownData = new SpriteSheetData("door_down", BlockWidth, BlockHeight, 3, 1);
        private Texture2D DoorLeftTexture;
        private readonly SpriteSheetData doorLeftData = new SpriteSheetData("door_left", BlockWidth, BlockHeight, 3, 1);
        private Texture2D DoorRightTexture;
        private readonly SpriteSheetData doorRightData = new SpriteSheetData("door_right", BlockWidth, BlockHeight, 3, 1);
        private Texture2D DoorUpTexture;
        private readonly SpriteSheetData doorUpData = new SpriteSheetData("door_up", BlockWidth, BlockHeight, 3, 1);

        private Texture2D FireTexture;
        private readonly SpriteSheetData fireData = new SpriteSheetData("fire", BlockWidth, BlockHeight, 1, 2);
        private Texture2D FloorTileTexture;
        private readonly SpriteSheetData floorTileData = new SpriteSheetData("floor_tile", BlockWidth, BlockHeight, 1, 1);
        private Texture2D GapTileTexture;
        private readonly SpriteSheetData gapTileData = new SpriteSheetData("gap_tile", BlockWidth, BlockHeight, 1, 1);
        private Texture2D MovableSquareTexture;
        private readonly SpriteSheetData movableSquareData = new SpriteSheetData("movable_square", BlockWidth, BlockHeight, 1, 1);

        private Texture2D BombedOpeningDownTexture;
        private readonly SpriteSheetData bombedOpeningDownData = new SpriteSheetData("bombed_opening_down", BlockWidth, BlockHeight, 1, 1);
        private Texture2D BombedOpeningUpTexture;
        private readonly SpriteSheetData bombedOpeningUpData = new SpriteSheetData("bombed_opening_up", BlockWidth, BlockHeight, 1, 1);
        private Texture2D BombedOpeningRightTexture;
        private readonly SpriteSheetData bombedOpeningRightData = new SpriteSheetData("bombed_opening_right", BlockWidth, BlockHeight, 1, 1);
        private Texture2D BombedOpeningLeftTexture;
        private readonly SpriteSheetData bombedOpeningLeftData = new SpriteSheetData("bombed_opening_left", BlockWidth, BlockHeight, 1, 1);

        private Texture2D BlueStatueRightTexture;
        private readonly SpriteSheetData blueStatueRightData = new SpriteSheetData("blue_statue_right", BlockWidth, BlockHeight, 1, 1);
        private Texture2D BlueStatueLeftTexture;
        private readonly SpriteSheetData blueStatueLeftData = new SpriteSheetData("blue_statue_left", BlockWidth, BlockHeight, 1, 1);
        private Texture2D TurquoiseStatueTexture;
        private readonly SpriteSheetData turquoiseStatueData = new SpriteSheetData("turquoise_statue", BlockWidth, BlockHeight, 1, 2);

        private Texture2D SpottedTileTexture;
        private readonly SpriteSheetData spottedTileData = new SpriteSheetData("spotted_tile", BlockWidth, BlockHeight, 1, 1);
        private Texture2D WaterTileTexture;
        private readonly SpriteSheetData waterTileData = new SpriteSheetData("water_tile", BlockWidth, BlockHeight, 1, 1);

        private Texture2D OrangeMovableSquareTexture;
        private readonly SpriteSheetData orangeMovableSquareData = new SpriteSheetData("orange_movable_square", BlockWidth, BlockHeight, 1, 1);
        private Texture2D EnemyDeathExplosionTexture;
        private readonly SpriteSheetData enemyDeathExplosionData = new SpriteSheetData("enemyDeath", BlockWidth, BlockHeight, 1, 6);
        private Texture2D EnemySpawnTexture;
        private readonly SpriteSheetData enemySpawnData = new SpriteSheetData("enemySpawn", BlockWidth, BlockHeight, 3, 1);
        private Texture2D BasementBrickTileTexture;
        private readonly SpriteSheetData basementBrickTileData = new SpriteSheetData("basement_brick_tile", BlockWidth, BlockHeight, 1, 1);
        private Texture2D LadderTileTexture;
        private readonly SpriteSheetData ladderTileData = new SpriteSheetData("ladder_tile", BlockWidth, BlockHeight, 1, 1);
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

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.FloorTileTexture = content.Load<Texture2D>(this.floorTileData.FilePath);
            this.StairsTexture = content.Load<Texture2D>(this.stairsData.FilePath);
            this.MovableSquareTexture = content.Load<Texture2D>(this.movableSquareData.FilePath);
            this.GapTileTexture = content.Load<Texture2D>(this.gapTileData.FilePath);
            this.DoorDownTexture = content.Load<Texture2D>(this.doorDownData.FilePath);
            this.DoorLeftTexture = content.Load<Texture2D>(this.doorLeftData.FilePath);
            this.DoorRightTexture = content.Load<Texture2D>(this.doorRightData.FilePath);
            this.DoorUpTexture = content.Load<Texture2D>(this.doorUpData.FilePath);
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

        public List<IBlockSprite> GetAll(int width, int height)
        {
            int x = width;
            int y = height;
            List<IBlockSprite> allBlocks = new List<IBlockSprite>();
            allBlocks.Add(this.Stairs(new Vector2(x, y)));
            allBlocks.Add(this.DoorDown(new Vector2(x, y)));
            allBlocks.Add(this.DoorLeft(new Vector2(x, y)));
            allBlocks.Add(this.DoorRight(new Vector2(x, y)));
            allBlocks.Add(this.DoorUp(new Vector2(x, y)));
            allBlocks.Add(this.Fire(new Vector2(x, y)));
            allBlocks.Add(this.FloorTile(new Vector2(x, y)));
            allBlocks.Add(this.GapTile(new Vector2(x, y)));
            allBlocks.Add(this.MovableSquare(new Vector2(x, y)));
            allBlocks.Add(this.BombedOpeningDown(new Vector2(x, y)));
            allBlocks.Add(this.BombedOpeningUp(new Vector2(x, y)));
            allBlocks.Add(this.BombedOpeningLeft(new Vector2(x, y)));
            allBlocks.Add(this.BombedOpeningRight(new Vector2(x, y)));
            allBlocks.Add(this.BlueStatueLeft(new Vector2(x, y)));
            allBlocks.Add(this.BlueStatueRight(new Vector2(x, y)));
            allBlocks.Add(this.TurquoiseStatueLeft(new Vector2(x, y)));
            allBlocks.Add(this.TurquoiseStatueRight(new Vector2(x, y)));
            allBlocks.Add(this.SpottedTile(new Vector2(x, y)));
            allBlocks.Add(this.WaterTile(new Vector2(x, y)));
            allBlocks.Add(this.OrangeMovableSquare(new Vector2(x, y)));
            allBlocks.Add(this.EnemyDeathExplosion(new Vector2(x, y)));
            allBlocks.Add(this.EnemySpawn(new Vector2(x, y)));
            allBlocks.Add(this.BasementBrickTile(new Vector2(x, y)));
            allBlocks.Add(this.LadderTile(new Vector2(x, y)));
            allBlocks.Add(this.HorizontalBricks(new Vector2(x, y)));
            allBlocks.Add(this.VerticalBricks(new Vector2(x, y)));

            return allBlocks;
        }

        public StairsSprite Stairs(Vector2 loc)
        {
            return new StairsSprite(this.StairsTexture, loc, this.stairsData);
        }

        public DoorDownSprite DoorDown(Vector2 loc)
        {
            return new DoorDownSprite(this.DoorDownTexture, loc, this.doorDownData);
        }

        public DoorLeftSprite DoorLeft(Vector2 loc)
        {
            return new DoorLeftSprite(this.DoorLeftTexture, loc, this.doorLeftData);
        }

        public DoorRightSprite DoorRight(Vector2 loc)
        {
            return new DoorRightSprite(this.DoorRightTexture, loc, this.doorRightData);
        }

        public DoorUpSprite DoorUp(Vector2 loc)
        {
            return new DoorUpSprite(this.DoorUpTexture, loc, this.doorUpData);
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