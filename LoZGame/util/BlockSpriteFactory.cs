using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Collections.Generic;


namespace LoZClone
{
    public class BlockSpriteFactory
    {
        private static int blockWidth = 50, blockHeight = 50;
        private static int verticalBlockWidth = 16, verticalBlockHeight = 64;
        private static int horizontalBlockWidth = 64, horizontalBlockHeight = 16;

        private Texture2D StairsTexture;
        private SpriteSheetData stairsData = new SpriteSheetData("stairs", blockWidth, blockHeight, 1, 1);

        private Texture2D DoorDownTexture;
        private SpriteSheetData doorDownData = new SpriteSheetData("door_down", blockWidth, blockHeight, 3, 1);
        private Texture2D DoorLeftTexture;
        private SpriteSheetData doorLeftData = new SpriteSheetData("door_left", blockWidth, blockHeight, 3, 1);
        private Texture2D DoorRightTexture;
        private SpriteSheetData doorRightData = new SpriteSheetData("door_right", blockWidth, blockHeight, 3, 1);
        private Texture2D DoorUpTexture;
        private SpriteSheetData doorUpData = new SpriteSheetData("door_up", blockWidth, blockHeight, 3, 1);

        private Texture2D FireTexture;
        private SpriteSheetData fireData = new SpriteSheetData("fire", blockWidth, blockHeight, 1, 2);
        private Texture2D FloorTileTexture;
        private SpriteSheetData floorTileData = new SpriteSheetData("floor_tile", blockWidth, blockHeight, 1, 1);
        private Texture2D GapTileTexture;
        private SpriteSheetData gapTileData = new SpriteSheetData("gap_tile", blockWidth, blockHeight, 1, 1);
        private Texture2D MovableSquareTexture;
        private SpriteSheetData movableSquareData = new SpriteSheetData("movable_square", blockWidth, blockHeight, 1, 1);

        private Texture2D BombedOpeningDownTexture;
        private SpriteSheetData bombedOpeningDownData = new SpriteSheetData("bombed_opening_down", blockWidth, blockHeight, 1, 1);
        private Texture2D BombedOpeningUpTexture;
        private SpriteSheetData bombedOpeningUpData = new SpriteSheetData("bombed_opening_up", blockWidth, blockHeight, 1, 1);
        private Texture2D BombedOpeningRightTexture;
        private SpriteSheetData bombedOpeningRightData = new SpriteSheetData("bombed_opening_right", blockWidth, blockHeight, 1, 1);
        private Texture2D BombedOpeningLeftTexture;
        private SpriteSheetData bombedOpeningLeftData = new SpriteSheetData("bombed_opening_left", blockWidth, blockHeight, 1, 1);

        private Texture2D BlueStatueRightTexture;
        private SpriteSheetData blueStatueRightData = new SpriteSheetData("blue_statue_right", blockWidth, blockHeight, 1, 1);
        private Texture2D BlueStatueLeftTexture;
        private SpriteSheetData blueStatueLeftData = new SpriteSheetData("blue_statue_left", blockWidth, blockHeight, 1, 1);
        private Texture2D TurquoiseStatueTexture;
        private SpriteSheetData turquoiseStatueData = new SpriteSheetData("turquoise_statue", blockWidth, blockHeight, 1, 2);

        private Texture2D SpottedTileTexture;
        private SpriteSheetData spottedTileData = new SpriteSheetData("spotted_tile", blockWidth, blockHeight, 1, 1);
        private Texture2D WaterTileTexture;
        private SpriteSheetData waterTileData = new SpriteSheetData("water_tile", blockWidth, blockHeight, 1, 1);

        private Texture2D OrangeMovableSquareTexture;
        private SpriteSheetData orangeMovableSquareData = new SpriteSheetData("orange_movable_square", blockWidth, blockHeight, 1, 1);
        private Texture2D EnemyDeathExplosionTexture;
        private SpriteSheetData enemyDeathExplosionData = new SpriteSheetData("enemyDeath", blockWidth, blockHeight, 1, 6);
        private Texture2D EnemySpawnTexture;
        private SpriteSheetData enemySpawnData = new SpriteSheetData("enemySpawn", blockWidth, blockHeight, 3, 1);
        private Texture2D BasementBrickTileTexture;
        private SpriteSheetData basementBrickTileData = new SpriteSheetData("basement_brick_tile", blockWidth, blockHeight, 1, 1);
        private Texture2D LadderTileTexture;
        private SpriteSheetData ladderTileData = new SpriteSheetData("ladder_tile", blockWidth, blockHeight, 1, 1);
        private Texture2D HorizontalBricksTexture;
        private SpriteSheetData horizontalBricksData = new SpriteSheetData("horizontal_bricks", horizontalBlockWidth, horizontalBlockHeight, 1, 1);
        private Texture2D VerticalBricksTexture;
        private SpriteSheetData verticalBricksData = new SpriteSheetData("vertical_bricks", verticalBlockWidth, verticalBlockHeight, 1, 1);

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

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
            FloorTileTexture = content.Load<Texture2D>(floorTileData.FilePath);
            StairsTexture = content.Load<Texture2D>(stairsData.FilePath);
            MovableSquareTexture = content.Load<Texture2D>(movableSquareData.FilePath);
            GapTileTexture = content.Load<Texture2D>(gapTileData.FilePath);
            DoorDownTexture = content.Load<Texture2D>(doorDownData.FilePath);
            DoorLeftTexture = content.Load<Texture2D>(doorLeftData.FilePath);
            DoorRightTexture = content.Load<Texture2D>(doorRightData.FilePath);
            DoorUpTexture = content.Load<Texture2D>(doorUpData.FilePath);
            FireTexture = content.Load<Texture2D>(fireData.FilePath);
            BombedOpeningDownTexture = content.Load<Texture2D>(bombedOpeningDownData.FilePath);
            BombedOpeningUpTexture = content.Load<Texture2D>(bombedOpeningUpData.FilePath);
            BombedOpeningRightTexture = content.Load<Texture2D>(bombedOpeningRightData.FilePath);
            BombedOpeningLeftTexture = content.Load<Texture2D>(bombedOpeningLeftData.FilePath);
            BlueStatueRightTexture = content.Load<Texture2D>(blueStatueRightData.FilePath);
            BlueStatueLeftTexture = content.Load<Texture2D>(blueStatueLeftData.FilePath);
            TurquoiseStatueTexture = content.Load<Texture2D>(turquoiseStatueData.FilePath);
            SpottedTileTexture = content.Load<Texture2D>(spottedTileData.FilePath);
            WaterTileTexture = content.Load<Texture2D>(waterTileData.FilePath);
            OrangeMovableSquareTexture = content.Load<Texture2D>(orangeMovableSquareData.FilePath);
            EnemyDeathExplosionTexture = content.Load<Texture2D>(enemyDeathExplosionData.FilePath);
            EnemySpawnTexture = content.Load<Texture2D>(enemySpawnData.FilePath);
            BasementBrickTileTexture = content.Load<Texture2D>(basementBrickTileData.FilePath);
            LadderTileTexture = content.Load<Texture2D>(ladderTileData.FilePath);
            HorizontalBricksTexture = content.Load<Texture2D>(horizontalBricksData.FilePath);
            VerticalBricksTexture = content.Load<Texture2D>(verticalBricksData.FilePath);
        }

        public List<IBlockSprite> getAll(int width, int height)
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
            return new StairsSprite(StairsTexture, loc, stairsData);
        }

        public DoorDownSprite DoorDown(Vector2 loc)
        {
            return new DoorDownSprite(DoorDownTexture, loc, doorDownData);
        }
        public DoorLeftSprite DoorLeft(Vector2 loc)
        {
            return new DoorLeftSprite(DoorLeftTexture, loc, doorLeftData);
        }
        public DoorRightSprite DoorRight(Vector2 loc)
        {
            return new DoorRightSprite(DoorRightTexture, loc, doorRightData);
        }
        public DoorUpSprite DoorUp(Vector2 loc)
        {
            return new DoorUpSprite(DoorUpTexture, loc, doorUpData);
        }
        public FireSprite Fire(Vector2 loc)
        {
            return new FireSprite(FireTexture, loc, fireData);
        }
        public FloorTileSprite FloorTile(Vector2 loc)
        {
            return new FloorTileSprite(FloorTileTexture, loc, floorTileData);
        }
        public GapTileSprite GapTile(Vector2 loc)
        {
            return new GapTileSprite(GapTileTexture, loc, gapTileData);
        }
        public MovableSquareSprite MovableSquare(Vector2 loc)
        {
            return new MovableSquareSprite(MovableSquareTexture, loc, movableSquareData);
        }
        public BombedOpeningDownSprite BombedOpeningDown(Vector2 loc)
        {
            return new BombedOpeningDownSprite(BombedOpeningDownTexture, loc, bombedOpeningDownData);
        }
        public BombedOpeningUpSprite BombedOpeningUp(Vector2 loc)
        {
            return new BombedOpeningUpSprite(BombedOpeningUpTexture, loc, bombedOpeningUpData);
        }
        public BombedOpeningLeftSprite BombedOpeningLeft(Vector2 loc)
        {
            return new BombedOpeningLeftSprite(BombedOpeningLeftTexture, loc, bombedOpeningLeftData);
        }
        public BombedOpeningRightSprite BombedOpeningRight(Vector2 loc)
        {
            return new BombedOpeningRightSprite(BombedOpeningRightTexture, loc, bombedOpeningRightData);
        }
        public BlueStatueRightSprite BlueStatueRight(Vector2 loc)
        {
            return new BlueStatueRightSprite(BlueStatueRightTexture, loc, blueStatueRightData);
        }
        public BlueStatueLeftSprite BlueStatueLeft(Vector2 loc)
        {
            return new BlueStatueLeftSprite(BlueStatueLeftTexture, loc, blueStatueLeftData);
        }
        public TurquoiseStatueLeftSprite TurquoiseStatueLeft(Vector2 loc)
        {
            return new TurquoiseStatueLeftSprite(TurquoiseStatueTexture, loc, turquoiseStatueData);
        }
        public TurquoiseStatueRightSprite TurquoiseStatueRight(Vector2 loc)
        {
            return new TurquoiseStatueRightSprite(TurquoiseStatueTexture, loc, turquoiseStatueData);
        }
        public SpottedTileSprite SpottedTile(Vector2 loc)
        {
            return new SpottedTileSprite(SpottedTileTexture, loc, spottedTileData);
        }
        public WaterTileSprite WaterTile(Vector2 loc)
        {
            return new WaterTileSprite(WaterTileTexture, loc, waterTileData);
        }
        public OrangeMovableSquareSprite OrangeMovableSquare(Vector2 loc)
        {
            return new OrangeMovableSquareSprite(OrangeMovableSquareTexture, loc, orangeMovableSquareData);
        }
        public EnemyDeathExplosionSprite EnemyDeathExplosion(Vector2 loc)
        {
            return new EnemyDeathExplosionSprite(EnemyDeathExplosionTexture, loc, enemyDeathExplosionData);
        }
        public EnemySpawnSprite EnemySpawn(Vector2 loc)
        {
            return new EnemySpawnSprite(EnemySpawnTexture, loc, enemySpawnData);
        }
        public BasementBrickTileSprite BasementBrickTile(Vector2 loc)
        {
            return new BasementBrickTileSprite(BasementBrickTileTexture, loc, basementBrickTileData);
        }
        public LadderTileSprite LadderTile(Vector2 loc)
        {
            return new LadderTileSprite(LadderTileTexture, loc, ladderTileData);
        }
        public HorizontalBricksSprite HorizontalBricks(Vector2 loc)
        {
            return new HorizontalBricksSprite(HorizontalBricksTexture, loc, horizontalBricksData);
        }
        public VerticalBricksSprite VerticalBricks(Vector2 loc)
        {
            return new VerticalBricksSprite(VerticalBricksTexture, loc, verticalBricksData);
        }
    }
}