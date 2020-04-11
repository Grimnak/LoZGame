namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class InventorySpriteFactory
    {
        private readonly int DRAWSCALE = 1;
        private readonly Vector2 heartSize = new Vector2(24, 24);

        public Vector2 HeartSize { get { return heartSize; } }

        private Texture2D inventoryBackgroundSpriteSheet;
        private SpriteData inventoryBackgroundData;
        private Texture2D fullHeartSpriteSheet;
        private SpriteData fullHeartData;
        // private Texture2D threeQuarterHeartSpriteSheet;
        // private SpriteData threeQuarterHeartData;
        private Texture2D halfHeartSpriteSheet;
        private SpriteData halfHeartData;
        // private Texture2D quarterHeartSpriteSheet;
        // private SpriteData quarterHeartData;
        private Texture2D emptyHeartSpriteSheet;
        private SpriteData emptyHeartData;

        private static readonly InventorySpriteFactory InstanceValue = new InventorySpriteFactory();

        public static InventorySpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        public void LoadAllTextures(ContentManager content)
        {
            this.inventoryBackgroundSpriteSheet = content.Load<Texture2D>("Inventory");
            this.inventoryBackgroundData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), inventoryBackgroundSpriteSheet, 1, 1);
            this.fullHeartSpriteSheet = content.Load<Texture2D>("HUDFullHeart");
            this.fullHeartData = new SpriteData(heartSize, fullHeartSpriteSheet, 1, 1);
            // this.threeQuarterHeartSpriteSheet = content.Load<Texture2D>("");
            // this.threeQuarterHeartData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), threeQuarterHeartSpriteSheet, 1, 1);
            this.halfHeartSpriteSheet = content.Load<Texture2D>("HUDHalfHeart");
            this.halfHeartData = new SpriteData(heartSize, halfHeartSpriteSheet, 1, 1);
            // this.quarterHeartSpriteSheet = content.Load<Texture2D>("");
            // this.quarterHeartData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), quarterHeartSpriteSheet, 1, 1);
            this.emptyHeartSpriteSheet = content.Load<Texture2D>("HUDEmptyHeart");
            this.emptyHeartData = new SpriteData(heartSize, emptyHeartSpriteSheet, 1, 1);
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
            return new ObjectSprite(this.halfHeartSpriteSheet, this.halfHeartData);
        }

        public ISprite CreateHalfHeart()
        {
            return new ObjectSprite(this.halfHeartSpriteSheet, this.halfHeartData);
        }

        public ISprite CreateQuarterHeart()
        {
            return new ObjectSprite(this.halfHeartSpriteSheet, this.halfHeartData);
        }

        public ISprite CreateEmptyHeart()
        {
            return new ObjectSprite(this.emptyHeartSpriteSheet, this.emptyHeartData);
        }
    }
}