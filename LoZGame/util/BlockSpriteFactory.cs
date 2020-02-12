using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Collections.Generic;


namespace LoZClone
{
    public class BlockSpriteFactory
    {
        private Texture2D LadderTexture;
        private SpriteSheetData ladderData = new SpriteSheetData("ladder", 0, 0, 1, 1);
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
        private SpriteSheetData fireData = new SpriteSheetData("fire", 0, 0, 2, 1);
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
            LadderTexture = content.Load<Texture2D>(ladderData.FilePath);
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
        }

        public List<ISprite> getAll(int width, int height)
        {
            int x = width / 2;
            int y = height / 2;
            List<ISprite> allBlocks = new List<ISprite>();
            allBlocks.Add(this.Ladder(new Vector2(x, y)));
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
            allBlocks.Add(this.BrickTile(new Vector2(x, y)));

            return allBlocks;
        }

        public LadderSprite Ladder(Vector2 loc)
        {
            return new LadderSprite(LadderTexture, ladderData);
        }

        public StairsSprite Stairs(Vector2 loc)
        {
            return new StairsSprite(StairsTexture, stairsData);
        }

        public DoorDownSprite DoorDown(Vector2 loc)
        {
            return new DoorDownSprite(DoorDownTexture, doorDownData);
        }
        public DoorLeftSprite DoorLeft(Vector2 loc)
        {
            return new DoorLeftSprite(DoorLeftTexture, doorLeftData);
        }
        public DoorRightSprite DoorRight(Vector2 loc)
        {
            return new DoorRightSprite(DoorRightTexture, doorRightData);
        }
        public DoorUpSprite DoorUp(Vector2 loc)
        {
            return new DoorUpSprite(DoorUpTexture, doorUpData);
        }
        public FireSprite Fire(Vector2 loc)
        {
            return new FireSprite(FireTexture, fireData);
        }
        public FloorTileSprite FloorTile(Vector2 loc)
        {
            return new FloorTileSprite(FloorTileTexture, floorTileData);
        }
        public GapTileSprite GapTile(Vector2 loc)
        {
            return new GapTileSprite(GapTileTexture, gapTileData);
        }
        public MovableSquareSprite MovableSquare(Vector2 loc)
        {
            return new MovableSquareSprite(MovableSquareTexture, movableSquareData);
        }
        public BombedOpeningDownSprite BombedOpeningDown(Vector2 loc)
        {
            return new BombedOpeningDownSprite(BombedOpeningDownTexture, bombedOpeningDownData);
        }
        public BombedOpeningUpSprite BombedOpeningUp(Vector2 loc)
        {
            return new BombedOpeningUpSprite(BombedOpeningUpTexture, bombedOpeningUpData);
        }
        public BombedOpeningLeftSprite BombedOpeningLeft(Vector2 loc)
        {
            return new BombedOpeningLeftSprite(BombedOpeningLeftTexture, bombedOpeningLeftData);
        }
        public BombedOpeningRightSprite BombedOpeningRight(Vector2 loc)
        {
            return new BombedOpeningRightSprite(BombedOpeningRightTexture, bombedOpeningRightData);
        }
        public BlueStatueRightSprite BlueStatueRight(Vector2 loc)
        {
            return new BlueStatueRightSprite(BlueStatueRightTexture, blueStatueRightData);
        }
        public BlueStatueLeftSprite BlueStatueLeft(Vector2 loc)
        {
            return new BlueStatueLeftSprite(BlueStatueLeftTexture, blueStatueLeftData);
        }
        public TurquoiseStatueLeftSprite TurquoiseStatueLeft(Vector2 loc)
        {
            return new TurquoiseStatueLeftSprite(TurquoiseStatueTexture, turquoiseStatueData);
        }
        public TurquoiseStatueRightSprite TurquoiseStatueRight(Vector2 loc)
        {
            return new TurquoiseStatueRightSprite(TurquoiseStatueTexture, turquoiseStatueData);
        }
        public BrickTileSprite BrickTile(Vector2 loc)
        {
            return new BrickTileSprite(BrickTileTexture, brickTileData);
        }
    }
}

