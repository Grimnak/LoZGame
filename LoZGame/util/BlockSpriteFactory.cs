namespace LoZClone
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class BlockSpriteFactory
    {
        private Texture2D ladderTexture;
        private SpriteSheetData ladderData = new SpriteSheetData("ladder", 0, 0, 1, 1);
        private Texture2D stairsTexture;
        private SpriteSheetData stairsData = new SpriteSheetData("stairs", 0, 0, 1, 1);

        private Texture2D doorDownTexture;
        private SpriteSheetData doorDownData = new SpriteSheetData("door_down", 0, 0, 3, 1);
        private Texture2D doorLeftTexture;
        private SpriteSheetData doorLeftData = new SpriteSheetData("door_left", 0, 0, 3, 1);
        private Texture2D doorRightTexture;
        private SpriteSheetData doorRightData = new SpriteSheetData("door_right", 0, 0, 3, 1);
        private Texture2D doorUpTexture;
        private SpriteSheetData doorUpData = new SpriteSheetData("door_up", 0, 0, 3, 1);

        private Texture2D fireTexture;
        private SpriteSheetData fireData = new SpriteSheetData("fire", 0, 0, 2, 1);
        private Texture2D floorTileTexture;
        private SpriteSheetData floorTileData = new SpriteSheetData("floor_tile", 0, 0, 1, 1);
        private Texture2D gapTileTexture;
        private SpriteSheetData gapTileData = new SpriteSheetData("gap_tile", 0, 0, 1, 1);
        private Texture2D movableSquareTexture;
        private SpriteSheetData movableSquareData = new SpriteSheetData("movable_square", 0, 0, 1, 1);

        private Texture2D bombedOpeningDownTexture;
        private SpriteSheetData bombedOpeningDownData = new SpriteSheetData("bombed_opening_down", 0, 0, 1, 1);
        private Texture2D bombedOpeningUpTexture;
        private SpriteSheetData bombedOpeningUpData = new SpriteSheetData("bombed_opening_up", 0, 0, 1, 1);
        private Texture2D bombedOpeningRightTexture;
        private SpriteSheetData bombedOpeningRightData = new SpriteSheetData("bombed_opening_right", 0, 0, 1, 1);
        private Texture2D bombedOpeningLeftTexture;
        private SpriteSheetData bombedOpeningLeftData = new SpriteSheetData("bombed_opening_left", 0, 0, 1, 1);

        private Texture2D blueStatueRightTexture;
        private SpriteSheetData blueStatueRightData = new SpriteSheetData("blue_statue_right", 0, 0, 1, 1);
        private Texture2D blueStatueLeftTexture;
        private SpriteSheetData blueStatueLeftData = new SpriteSheetData("blue_statue_left", 0, 0, 1, 1);
        private Texture2D turquoiseStatueTexture;
        private SpriteSheetData turquoiseStatueData = new SpriteSheetData("turquoise_statue", 0, 0, 1, 2);

        private Texture2D brickTileTexture;
        private SpriteSheetData brickTileData = new SpriteSheetData("brick_tile", 0, 0, 1, 1);

        private static readonly BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance => instance;

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.ladderTexture = content.Load<Texture2D>(this.ladderData.FilePath);
            this.floorTileTexture = content.Load<Texture2D>(this.floorTileData.FilePath);
            this.stairsTexture = content.Load<Texture2D>(this.stairsData.FilePath);
            this.movableSquareTexture = content.Load<Texture2D>(this.movableSquareData.FilePath);
            this.gapTileTexture = content.Load<Texture2D>(this.gapTileData.FilePath);
            this.doorDownTexture = content.Load<Texture2D>(this.doorDownData.FilePath);
            this.doorLeftTexture = content.Load<Texture2D>(this.doorLeftData.FilePath);
            this.doorRightTexture = content.Load<Texture2D>(this.doorRightData.FilePath);
            this.doorUpTexture = content.Load<Texture2D>(this.doorUpData.FilePath);
            this.fireTexture = content.Load<Texture2D>(this.fireData.FilePath);
            this.bombedOpeningDownTexture = content.Load<Texture2D>(this.bombedOpeningDownData.FilePath);
            this.bombedOpeningUpTexture = content.Load<Texture2D>(this.bombedOpeningUpData.FilePath);
            this.bombedOpeningRightTexture = content.Load<Texture2D>(this.bombedOpeningRightData.FilePath);
            this.bombedOpeningLeftTexture = content.Load<Texture2D>(this.bombedOpeningLeftData.FilePath);
            this.blueStatueRightTexture = content.Load<Texture2D>(this.blueStatueRightData.FilePath);
            this.blueStatueLeftTexture = content.Load<Texture2D>(this.blueStatueLeftData.FilePath);
            this.turquoiseStatueTexture = content.Load<Texture2D>(this.turquoiseStatueData.FilePath);
            this.brickTileTexture = content.Load<Texture2D>(this.brickTileData.FilePath);
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
            return new LadderSprite(this.ladderTexture, this.ladderData);
        }

        public StairsSprite Stairs(Vector2 loc)
        {
            return new StairsSprite(this.stairsTexture, this.stairsData);
        }

        public DoorDownSprite DoorDown(Vector2 loc)
        {
            return new DoorDownSprite(this.doorDownTexture, this.doorDownData);
        }

        public DoorLeftSprite DoorLeft(Vector2 loc)
        {
            return new DoorLeftSprite(this.doorLeftTexture, this.doorLeftData);
        }

        public DoorRightSprite DoorRight(Vector2 loc)
        {
            return new DoorRightSprite(this.doorRightTexture, this.doorRightData);
        }

        public DoorUpSprite DoorUp(Vector2 loc)
        {
            return new DoorUpSprite(this.doorUpTexture, this.doorUpData);
        }

        public FireSprite Fire(Vector2 loc)
        {
            return new FireSprite(this.fireTexture, this.fireData);
        }

        public FloorTileSprite FloorTile(Vector2 loc)
        {
            return new FloorTileSprite(this.floorTileTexture, this.floorTileData);
        }

        public GapTileSprite GapTile(Vector2 loc)
        {
            return new GapTileSprite(this.gapTileTexture, this.gapTileData);
        }

        public MovableSquareSprite MovableSquare(Vector2 loc)
        {
            return new MovableSquareSprite(this.movableSquareTexture, this.movableSquareData);
        }

        public BombedOpeningDownSprite BombedOpeningDown(Vector2 loc)
        {
            return new BombedOpeningDownSprite(this.bombedOpeningDownTexture, this.bombedOpeningDownData);
        }

        public BombedOpeningUpSprite BombedOpeningUp(Vector2 loc)
        {
            return new BombedOpeningUpSprite(this.bombedOpeningUpTexture, this.bombedOpeningUpData);
        }

        public BombedOpeningLeftSprite BombedOpeningLeft(Vector2 loc)
        {
            return new BombedOpeningLeftSprite(this.bombedOpeningLeftTexture, this.bombedOpeningLeftData);
        }

        public BombedOpeningRightSprite BombedOpeningRight(Vector2 loc)
        {
            return new BombedOpeningRightSprite(this.bombedOpeningRightTexture, this.bombedOpeningRightData);
        }

        public BlueStatueRightSprite BlueStatueRight(Vector2 loc)
        {
            return new BlueStatueRightSprite(this.blueStatueRightTexture, this.blueStatueRightData);
        }

        public BlueStatueLeftSprite BlueStatueLeft(Vector2 loc)
        {
            return new BlueStatueLeftSprite(this.blueStatueLeftTexture, this.blueStatueLeftData);
        }

        public TurquoiseStatueLeftSprite TurquoiseStatueLeft(Vector2 loc)
        {
            return new TurquoiseStatueLeftSprite(this.turquoiseStatueTexture, this.turquoiseStatueData);
        }

        public TurquoiseStatueRightSprite TurquoiseStatueRight(Vector2 loc)
        {
            return new TurquoiseStatueRightSprite(this.turquoiseStatueTexture, this.turquoiseStatueData);
        }

        public BrickTileSprite BrickTile(Vector2 loc)
        {
            return new BrickTileSprite(this.brickTileTexture, this.brickTileData);
        }
    }
}

