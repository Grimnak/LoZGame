namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class InventorySpriteFactory
    {
        private readonly Vector2 itemSelectorSize = new Vector2(50, 50);
        private readonly Vector2 selectionBoxSize = new Vector2(70, 60);
        private readonly Vector2 heartSize = new Vector2(24, 24);
        private readonly Vector2 mapSize = new Vector2(30, 50);
        private readonly Vector2 compassSize = new Vector2(60, 60);
        private readonly Vector2 itemSize = new Vector2(40, 40);

        public Vector2 SelectionBoxSize { get { return selectionBoxSize; } }

        public Vector2 HeartSize { get { return heartSize; } }

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
        private Texture2D bombSpriteSheet;
        private SpriteData bombData;
        private Texture2D boomerangSpriteSheet;
        private SpriteData boomerangData;
        private Texture2D arrowSpriteSheet;
        private SpriteData arrowData;
        private Texture2D blueCandleSpriteSheet;
        private SpriteData blueCandleData;
        private Texture2D redHealthPotionSpriteSheet;
        private SpriteData redHealthPotionData;
        private Texture2D blueHealthPotionSpriteSheet;
        private SpriteData blueHealthPotionData;
        private Texture2D magicBoomerangSpriteSheet;
        private SpriteData magicBoomerangData;
        private Texture2D silverArrowSpriteSheet;
        private SpriteData silverArrowData;
        private Texture2D redCandleSpriteSheet;
        private SpriteData redCandleData;
        private Texture2D selectionReticuleSpriteSheet;
        private SpriteData selectionReticuleData;

        private static readonly InventorySpriteFactory InstanceValue = new InventorySpriteFactory();

        public static InventorySpriteFactory Instance => InstanceValue;

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
            this.bombSpriteSheet = content.Load<Texture2D>("Bomb");
            this.bombData = new SpriteData(itemSize, bombSpriteSheet, 1, 1);
            this.boomerangSpriteSheet = content.Load<Texture2D>("Boomerang");
            this.boomerangData = new SpriteData(itemSize, boomerangSpriteSheet, 1, 1);
            this.arrowSpriteSheet = content.Load<Texture2D>("WoodenArrow");
            this.arrowData = new SpriteData(itemSize, arrowSpriteSheet, 1, 1);
            this.blueCandleSpriteSheet = content.Load<Texture2D>("BlueCandle");
            this.blueCandleData = new SpriteData(itemSize, blueCandleSpriteSheet, 1, 1);
            this.redHealthPotionSpriteSheet = content.Load<Texture2D>("LifePotion");
            this.redHealthPotionData = new SpriteData(itemSize, redHealthPotionSpriteSheet, 1, 1);
            this.blueHealthPotionSpriteSheet = content.Load<Texture2D>("SecondPotion");
            this.blueHealthPotionData = new SpriteData(itemSize, blueHealthPotionSpriteSheet, 1, 1);
            this.magicBoomerangSpriteSheet = content.Load<Texture2D>("MagicBoomerang");
            this.magicBoomerangData = new SpriteData(itemSize, magicBoomerangSpriteSheet, 1, 1);
            this.silverArrowSpriteSheet = content.Load<Texture2D>("SilverArrow");
            this.silverArrowData = new SpriteData(itemSize, silverArrowSpriteSheet, 1, 1);
            this.redCandleSpriteSheet = content.Load<Texture2D>("RedCandle");
            this.redCandleData = new SpriteData(itemSize, redCandleSpriteSheet, 1, 1);
            this.selectionReticuleSpriteSheet = content.Load<Texture2D>("HUDSelector");
            this.selectionReticuleData = new SpriteData(itemSelectorSize, selectionReticuleSpriteSheet, 1, 1);
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

        public ISprite CreateInventoryBomb()
        {
            return new ObjectSprite(this.bombSpriteSheet, this.bombData);
        }

        public ISprite CreateInventoryBoomerang()
        {
            return new ObjectSprite(this.boomerangSpriteSheet, this.boomerangData);
        }

        public ISprite CreateInventoryArrow()
        {
            return new ObjectSprite(this.arrowSpriteSheet, this.arrowData);
        }

        public ISprite CreateInventoryBlueCandle()
        {
            return new ObjectSprite(this.blueCandleSpriteSheet, this.blueCandleData);
        }

        public ISprite CreateInventoryRedHealthPotion()
        {
            return new ObjectSprite(this.redHealthPotionSpriteSheet, this.redHealthPotionData);
        }

        public ISprite CreateInventoryBlueHealthPotion()
        {
            return new ObjectSprite(this.blueHealthPotionSpriteSheet, this.blueHealthPotionData);
        }

        public ISprite CreateInventoryMagicBoomerang()
        {
            return new ObjectSprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData);
        }

        public ISprite CreateInventorySilverArrow()
        {
            return new ObjectSprite(this.silverArrowSpriteSheet, this.silverArrowData);
        }

        public ISprite CreateInventoryRedCandle()
        {
            return new ObjectSprite(this.redCandleSpriteSheet, this.redCandleData);
        }

        public ISprite CreateInventoryItemSelector()
        {
            return new ObjectSprite(this.selectionReticuleSpriteSheet, this.selectionReticuleData);
        }

    }
}