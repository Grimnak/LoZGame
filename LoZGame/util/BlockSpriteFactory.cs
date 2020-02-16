using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Collections.Generic;


namespace LoZClone
{
    public class BlockSpriteFactory
    {
        private Texture2D StairsTexture;
        private SpriteSheetData stairsData = new SpriteSheetData("stairs", 0, 0, 1, 1);

        private Texture2D DoorDownTexture;
        private SpriteSheetData doorDownData = new SpriteSheetData("door_down", 0, 0, 3, 1);
        private Texture2D DoorLeftTexture;
        private SpriteSheetData doorLeftData = new SpriteSheetData("door_left", 0, 0, 3, 1);
        private Texture2D DoorRightTexture;
        private SpriteSheetData doorRightData = new SpriteSheetData("door_right", 0, 0, 3, 1);
        private Texture2D DoorUpTexture;
        private SpriteSheetData doorUpData = new SpriteSheetData("door_up", 0, 0, 3, 1);

        private Texture2D FireTexture;
        private SpriteSheetData fireData = new SpriteSheetData("fire", 0, 0, 1, 2);
        private Texture2D FloorTileTexture;
        private SpriteSheetData floorTileData = new SpriteSheetData("floor_tile", 0, 0, 1, 1);
        private Texture2D GapTileTexture;
        private SpriteSheetData gapTileData = new SpriteSheetData("gap_tile", 0, 0, 1, 1);
        private Texture2D MovableSquareTexture;
        private SpriteSheetData movableSquareData = new SpriteSheetData("movable_square", 0, 0, 1, 1);

        private Texture2D BombedOpeningDownTexture;
        private SpriteSheetData bombedOpeningDownData = new SpriteSheetData("bombed_opening_down", 0, 0, 1, 1);
        private Texture2D BombedOpeningUpTexture;
        private SpriteSheetData bombedOpeningUpData = new SpriteSheetData("bombed_opening_up", 0, 0, 1, 1);
        private Texture2D BombedOpeningRightTexture;
        private SpriteSheetData bombedOpeningRightData = new SpriteSheetData("bombed_opening_right", 0, 0, 1, 1);
        private Texture2D BombedOpeningLeftTexture;
        private SpriteSheetData bombedOpeningLeftData = new SpriteSheetData("bombed_opening_left", 0, 0, 1, 1);

        private Texture2D BlueStatueRightTexture;
        private SpriteSheetData blueStatueRightData = new SpriteSheetData("blue_statue_right", 0, 0, 1, 1);
        private Texture2D BlueStatueLeftTexture;
        private SpriteSheetData blueStatueLeftData = new SpriteSheetData("blue_statue_left", 0, 0, 1, 1);
        private Texture2D TurquoiseStatueTexture;
        private SpriteSheetData turquoiseStatueData = new SpriteSheetData("turquoise_statue", 0, 0, 1, 2);

        private Texture2D BrickTileTexture;
        private SpriteSheetData brickTileData = new SpriteSheetData("brick_tile", 0, 0, 1, 1);

        private Texture2D OrangeMovableSquareTexture;
        private SpriteSheetData orangeMovableSquareData = new SpriteSheetData("orange_movable_square", 0, 0, 1, 1);
        private Texture2D EnemyDeathExplosionTexture;
        private SpriteSheetData enemyDeathExplosionData = new SpriteSheetData("enemyDeath", 0, 0, 1, 6);
        private Texture2D EnemySpawnTexture;
        private SpriteSheetData enemySpawnData = new SpriteSheetData("enemySpawn", 0, 0, 3, 1);
        private Texture2D HUDElementsTexture;
        private SpriteSheetData HUDElementsData = new SpriteSheetData("hud_elements", 0, 0, 1, 1);

        private int DRAW_SCALE = 2;

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
            BrickTileTexture = content.Load<Texture2D>(brickTileData.FilePath);
            OrangeMovableSquareTexture = content.Load<Texture2D>(orangeMovableSquareData.FilePath);
            EnemyDeathExplosionTexture = content.Load<Texture2D>(enemyDeathExplosionData.FilePath);
            EnemySpawnTexture = content.Load<Texture2D>(enemySpawnData.FilePath);
            HUDElementsTexture = content.Load<Texture2D>(HUDElementsData.FilePath);
        }

        public List<ISprite> getAll(int width, int height)
        {
            int x = width / 2;
            int y = height / 2;
            List<ISprite> allBlocks = new List<ISprite>();
            allBlocks.Add(this.Stairs(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.DoorDown(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.DoorLeft(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.DoorRight(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.DoorUp(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.Fire(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.FloorTile(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.GapTile(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.MovableSquare(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.BombedOpeningDown(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.BombedOpeningUp(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.BombedOpeningLeft(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.BombedOpeningRight(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.BlueStatueLeft(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.BlueStatueRight(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.TurquoiseStatueLeft(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.TurquoiseStatueRight(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.BrickTile(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.OrangeMovableSquare(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.EnemyDeathExplosion(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.EnemySpawn(new Vector2(x, y), DRAW_SCALE));
            allBlocks.Add(this.HUDElements(new Vector2(x, y), DRAW_SCALE));

            return allBlocks;
        }

        public StairsSprite Stairs(Vector2 loc, int scale)
        {
            return new StairsSprite(StairsTexture, stairsData, scale);
        }

        public DoorDownSprite DoorDown(Vector2 loc, int scale)
        {
            return new DoorDownSprite(DoorDownTexture, doorDownData, scale);
        }
        public DoorLeftSprite DoorLeft(Vector2 loc, int scale)
        {
            return new DoorLeftSprite(DoorLeftTexture, doorLeftData, scale);
        }
        public DoorRightSprite DoorRight(Vector2 loc, int scale)
        {
            return new DoorRightSprite(DoorRightTexture, doorRightData, scale);
        }
        public DoorUpSprite DoorUp(Vector2 loc, int scale)
        {
            return new DoorUpSprite(DoorUpTexture, doorUpData, scale);
        }
        public FireSprite Fire(Vector2 loc, int scale)
        {
            return new FireSprite(FireTexture, fireData, scale);
        }
        public FloorTileSprite FloorTile(Vector2 loc, int scale)
        {
            return new FloorTileSprite(FloorTileTexture, floorTileData, scale);
        }
        public GapTileSprite GapTile(Vector2 loc, int scale)
        {
            return new GapTileSprite(GapTileTexture, gapTileData, scale);
        }
        public MovableSquareSprite MovableSquare(Vector2 loc, int scale)
        {
            return new MovableSquareSprite(MovableSquareTexture, movableSquareData, scale);
        }
        public BombedOpeningDownSprite BombedOpeningDown(Vector2 loc, int scale)
        {
            return new BombedOpeningDownSprite(BombedOpeningDownTexture, bombedOpeningDownData, scale);
        }
        public BombedOpeningUpSprite BombedOpeningUp(Vector2 loc, int scale)
        {
            return new BombedOpeningUpSprite(BombedOpeningUpTexture, bombedOpeningUpData, scale);
        }
        public BombedOpeningLeftSprite BombedOpeningLeft(Vector2 loc, int scale)
        {
            return new BombedOpeningLeftSprite(BombedOpeningLeftTexture, bombedOpeningLeftData, scale);
        }
        public BombedOpeningRightSprite BombedOpeningRight(Vector2 loc, int scale)
        {
            return new BombedOpeningRightSprite(BombedOpeningRightTexture, bombedOpeningRightData, scale);
        }
        public BlueStatueRightSprite BlueStatueRight(Vector2 loc, int scale)
        {
            return new BlueStatueRightSprite(BlueStatueRightTexture, blueStatueRightData, scale);
        }
        public BlueStatueLeftSprite BlueStatueLeft(Vector2 loc, int scale)
        {
            return new BlueStatueLeftSprite(BlueStatueLeftTexture, blueStatueLeftData, scale);
        }
        public TurquoiseStatueLeftSprite TurquoiseStatueLeft(Vector2 loc, int scale)
        {
            return new TurquoiseStatueLeftSprite(TurquoiseStatueTexture, turquoiseStatueData, scale);
        }
        public TurquoiseStatueRightSprite TurquoiseStatueRight(Vector2 loc, int scale)
        {
            return new TurquoiseStatueRightSprite(TurquoiseStatueTexture, turquoiseStatueData, scale);
        }
        public BrickTileSprite BrickTile(Vector2 loc, int scale)
        {
            return new BrickTileSprite(BrickTileTexture, brickTileData, scale);
        }
        public OrangeMovableSquareSprite OrangeMovableSquare(Vector2 loc, int scale)
        {
            return new OrangeMovableSquareSprite(OrangeMovableSquareTexture, orangeMovableSquareData, scale);
        }
        public EnemyDeathExplosionSprite EnemyDeathExplosion(Vector2 loc, int scale)
        {
            return new EnemyDeathExplosionSprite(EnemyDeathExplosionTexture, enemyDeathExplosionData, scale);
        }
        public EnemySpawnSprite EnemySpawn(Vector2 loc, int scale)
        {
            return new EnemySpawnSprite(EnemySpawnTexture, enemySpawnData, scale);
        }
        public HUDElementsSprite HUDElements(Vector2 loc, int scale)
        {
            return new HUDElementsSprite(HUDElementsTexture, HUDElementsData, scale);
        }
    }
}