namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class InventorySpriteFactory
    {
        private readonly int DRAWSCALE = 1;
        private readonly Vector2 heartSize = new Vector2(24, 24);
        private readonly Vector2 mapSize = new Vector2(30, 50);
        private readonly Vector2 compassSize = new Vector2(60, 60);

        public Vector2 HeartSize { get { return heartSize; } }

        public Vector2 MapSize { get { return mapSize; } }

        public Vector2 CompassSize { get { return compassSize; } }

        private Texture2D inventoryBackgroundSpriteSheet;
        private SpriteData inventoryBackgroundData;
        private Texture2D fullHeartSpriteSheet;
        private SpriteData fullHeartData;
        private Texture2D threeQuarterHeartSpriteSheet;
        private SpriteData threeQuarterHeartData;
        private Texture2D halfHeartSpriteSheet;
        private SpriteData halfHeartData;
        private Texture2D quarterHeartSpriteSheet;
        private SpriteData quarterHeartData;
        private Texture2D emptyHeartSpriteSheet;
        private SpriteData emptyHeartData;
        private Texture2D mapSpriteSheet;
        private SpriteData mapData;
        private Texture2D compassSpriteSheet;
        private SpriteData compassData;

        private static readonly InventorySpriteFactory InstanceValue = new InventorySpriteFactory();

        public static InventorySpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        public void LoadAllTextures(ContentManager content)
        {
            this.inventoryBackgroundSpriteSheet = content.Load<Texture2D>("Inventory");
            this.inventoryBackgroundData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), inventoryBackgroundSpriteSheet, 1, 1);
            this.fullHeartSpriteSheet = content.Load<Texture2D>("HUDFullHeart");
            this.fullHeartData = new SpriteData(heartSize, fullHeartSpriteSheet, 1, 1);
            this.threeQuarterHeartSpriteSheet = content.Load<Texture2D>("HUDThreeQuarterHeart");
            this.threeQuarterHeartData = new SpriteData(heartSize, threeQuarterHeartSpriteSheet, 1, 1);
            this.halfHeartSpriteSheet = content.Load<Texture2D>("HUDHalfHeart");
            this.halfHeartData = new SpriteData(heartSize, halfHeartSpriteSheet, 1, 1);
            this.quarterHeartSpriteSheet = content.Load<Texture2D>("HUDQuarterHeart");
            this.quarterHeartData = new SpriteData(heartSize, quarterHeartSpriteSheet, 1, 1);
            this.emptyHeartSpriteSheet = content.Load<Texture2D>("HUDEmptyHeart");
            this.emptyHeartData = new SpriteData(heartSize, emptyHeartSpriteSheet, 1, 1);
            this.mapSpriteSheet = content.Load<Texture2D>("Map");
            this.mapData = new SpriteData(mapSize, mapSpriteSheet, 1, 1);
            this.compassSpriteSheet = content.Load<Texture2D>("Compass");
            this.compassData = new SpriteData(compassSize, compassSpriteSheet, 1, 1);
        }

        public ISprite CreateInventoryBackground()
        {
            return new ObjectSprite(this.inventoryBackgroundSpriteSheet, this.inventoryBackgroundData);
        }

        public ISprite CreateFullHeart()
        {
            return new ObjectSprite(this.fullHeartSpriteSheet, this.fullHeartData);
        }

        public ISprite CreateThreeQuarterHeart()
        {
            return new ObjectSprite(this.threeQuarterHeartSpriteSheet, this.threeQuarterHeartData);
        }

        public ISprite CreateHalfHeart()
        {
            return new ObjectSprite(this.halfHeartSpriteSheet, this.halfHeartData);
        }

        public ISprite CreateQuarterHeart()
        {
            return new ObjectSprite(this.quarterHeartSpriteSheet, this.quarterHeartData);
        }

        public ISprite CreateEmptyHeart()
        {
            return new ObjectSprite(this.emptyHeartSpriteSheet, this.emptyHeartData);
        }

        public ISprite CreateInventoryMap()
        {
            return new ObjectSprite(this.mapSpriteSheet, this.mapData);
        }

        public ISprite CreateInventoryCompass()
        {
            return new ObjectSprite(this.compassSpriteSheet, this.compassData);
        }
    }
}