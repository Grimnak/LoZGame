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
        private readonly Vector2 swordSize = new Vector2(40, 50);

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
        private Texture2D woodenSwordSpriteSheet;
        private SpriteData woodenSwordData;
        private Texture2D whiteSwordSpriteSheet;
        private SpriteData whiteSwordData;
        private Texture2D magicSwordSpriteSheet;
        private SpriteData magicSwordData;
        private Texture2D itemSelector2;
        private SpriteData itemSelectorFalse;
        private SpriteData itemSelectorTrue;
        private SpriteData itemSelectorEasy;
        private SpriteData itemSelectorNormal;
        private SpriteData itemSelectorHard;
        private SpriteData itemSelectorNightmare;
        private Texture2D spartanLaserSpriteSheet;
        private SpriteData spartanLaserData;

        private static readonly InventorySpriteFactory InstanceValue = new InventorySpriteFactory();

        public static InventorySpriteFactory Instance => InstanceValue;

        public void LoadAllTextures(ContentManager content)
        {
            inventoryBackgroundSpriteSheet = content.Load<Texture2D>("Inventory");
            inventoryBackgroundData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), inventoryBackgroundSpriteSheet, 1, 1);
            fullHeartSpriteSheet = content.Load<Texture2D>("HUDFullHeart");
            fullHeartData = new SpriteData(heartSize, fullHeartSpriteSheet, 1, 1);
            threeQuarterHeartSpriteSheet = content.Load<Texture2D>("HUDThreeQuarterHeart");
            threeQuarterHeartData = new SpriteData(heartSize, threeQuarterHeartSpriteSheet, 1, 1);
            halfHeartSpriteSheet = content.Load<Texture2D>("HUDHalfHeart");
            halfHeartData = new SpriteData(heartSize, halfHeartSpriteSheet, 1, 1);
            quarterHeartSpriteSheet = content.Load<Texture2D>("HUDQuarterHeart");
            quarterHeartData = new SpriteData(heartSize, quarterHeartSpriteSheet, 1, 1);
            emptyHeartSpriteSheet = content.Load<Texture2D>("HUDEmptyHeart");
            emptyHeartData = new SpriteData(heartSize, emptyHeartSpriteSheet, 1, 1);
            mapSpriteSheet = content.Load<Texture2D>("Map");
            mapData = new SpriteData(mapSize, mapSpriteSheet, 1, 1);
            compassSpriteSheet = content.Load<Texture2D>("Compass");
            compassData = new SpriteData(compassSize, compassSpriteSheet, 1, 1);
            bombSpriteSheet = content.Load<Texture2D>("Bomb");
            bombData = new SpriteData(itemSize, bombSpriteSheet, 1, 1);
            boomerangSpriteSheet = content.Load<Texture2D>("Boomerang");
            boomerangData = new SpriteData(itemSize, boomerangSpriteSheet, 1, 1);
            arrowSpriteSheet = content.Load<Texture2D>("WoodenArrow");
            arrowData = new SpriteData(itemSize, arrowSpriteSheet, 1, 1);
            blueCandleSpriteSheet = content.Load<Texture2D>("BlueCandle");
            blueCandleData = new SpriteData(itemSize, blueCandleSpriteSheet, 1, 1);
            redHealthPotionSpriteSheet = content.Load<Texture2D>("LifePotion");
            redHealthPotionData = new SpriteData(itemSize, redHealthPotionSpriteSheet, 1, 1);
            blueHealthPotionSpriteSheet = content.Load<Texture2D>("SecondPotion");
            blueHealthPotionData = new SpriteData(itemSize, blueHealthPotionSpriteSheet, 1, 1);
            magicBoomerangSpriteSheet = content.Load<Texture2D>("MagicBoomerang");
            magicBoomerangData = new SpriteData(itemSize, magicBoomerangSpriteSheet, 1, 1);
            silverArrowSpriteSheet = content.Load<Texture2D>("SilverArrow");
            silverArrowData = new SpriteData(itemSize, silverArrowSpriteSheet, 1, 1);
            redCandleSpriteSheet = content.Load<Texture2D>("RedCandle");
            redCandleData = new SpriteData(itemSize, redCandleSpriteSheet, 1, 1);
            selectionReticuleSpriteSheet = content.Load<Texture2D>("HUDSelector");
            selectionReticuleData = new SpriteData(itemSelectorSize, selectionReticuleSpriteSheet, 1, 1);
            woodenSwordSpriteSheet = content.Load<Texture2D>("WoodenSword");
            woodenSwordData = new SpriteData(swordSize, woodenSwordSpriteSheet, 1, 1);
            whiteSwordSpriteSheet = content.Load<Texture2D>("WhiteSword");
            whiteSwordData = new SpriteData(swordSize, whiteSwordSpriteSheet, 1, 1);
            magicSwordSpriteSheet = content.Load<Texture2D>("MagicSword");
            magicSwordData = new SpriteData(swordSize, magicSwordSpriteSheet, 1, 1);
            itemSelector2 = content.Load<Texture2D>("SelectorSprite2");
            spartanLaserSpriteSheet = content.Load<Texture2D>("SpartanLaserInventory");
            spartanLaserData = new SpriteData(new Vector2(8, 20), spartanLaserSpriteSheet, 1, 1);
            itemSelectorFalse = new SpriteData(new Vector2(80, 37), itemSelector2, 1, 1);
            itemSelectorTrue = new SpriteData(new Vector2(70, 37), itemSelector2, 1, 1);
            itemSelectorEasy = new SpriteData(new Vector2(87, 37), itemSelector2, 1, 1);
            itemSelectorNormal = new SpriteData(new Vector2(140, 37), itemSelector2, 1, 1);
            itemSelectorHard = new SpriteData(new Vector2(90, 37), itemSelector2, 1, 1);
            itemSelectorNightmare = new SpriteData(new Vector2(192, 37), itemSelector2, 1, 1);
        }

        public ISprite CreateSpartanLaser()
        {
            return new ObjectSprite(spartanLaserSpriteSheet, spartanLaserData);
        }

        public ISprite CreateInventoryBackground()
        {
            return new ObjectSprite(inventoryBackgroundSpriteSheet, inventoryBackgroundData);
        }

        public ISprite CreateFullHeart()
        {
            return new ObjectSprite(fullHeartSpriteSheet, fullHeartData);
        }

        public ISprite CreateThreeQuarterHeart()
        {
            return new ObjectSprite(threeQuarterHeartSpriteSheet, threeQuarterHeartData);
        }

        public ISprite CreateHalfHeart()
        {
            return new ObjectSprite(halfHeartSpriteSheet, halfHeartData);
        }

        public ISprite CreateQuarterHeart()
        {
            return new ObjectSprite(quarterHeartSpriteSheet, quarterHeartData);
        }

        public ISprite CreateEmptyHeart()
        {
            return new ObjectSprite(emptyHeartSpriteSheet, emptyHeartData);
        }

        public ISprite CreateInventoryMap()
        {
            return new ObjectSprite(mapSpriteSheet, mapData);
        }

        public ISprite CreateInventoryCompass()
        {
            return new ObjectSprite(compassSpriteSheet, compassData);
        }

        public ISprite CreateInventoryBomb()
        {
            return new ObjectSprite(bombSpriteSheet, bombData);
        }

        public ISprite CreateInventoryBoomerang()
        {
            return new ObjectSprite(boomerangSpriteSheet, boomerangData);
        }

        public ISprite CreateInventoryArrow()
        {
            return new ObjectSprite(arrowSpriteSheet, arrowData);
        }

        public ISprite CreateInventoryBlueCandle()
        {
            return new ObjectSprite(blueCandleSpriteSheet, blueCandleData);
        }

        public ISprite CreateInventoryRedHealthPotion()
        {
            return new ObjectSprite(redHealthPotionSpriteSheet, redHealthPotionData);
        }

        public ISprite CreateInventoryBlueHealthPotion()
        {
            return new ObjectSprite(blueHealthPotionSpriteSheet, blueHealthPotionData);
        }

        public ISprite CreateInventoryMagicBoomerang()
        {
            return new ObjectSprite(magicBoomerangSpriteSheet, magicBoomerangData);
        }

        public ISprite CreateInventorySilverArrow()
        {
            return new ObjectSprite(silverArrowSpriteSheet, silverArrowData);
        }

        public ISprite CreateInventoryRedCandle()
        {
            return new ObjectSprite(redCandleSpriteSheet, redCandleData);
        }

        public ISprite CreateInventoryItemSelector()
        {
            return new ObjectSprite(selectionReticuleSpriteSheet, selectionReticuleData);
        }

        public ISprite CreateInventoryItemSelectorFalse()
        {
            return new ObjectSprite(itemSelector2, itemSelectorFalse);
        }

        public ISprite CreateInventoryItemSelectorTrue()
        {
            return new ObjectSprite(itemSelector2, itemSelectorTrue);
        }

        public ISprite CreateInventoryItemSelectorEasy()
        {
            return new ObjectSprite(itemSelector2, itemSelectorEasy);
        }

        public ISprite CreateInventoryItemSelectorNormal()
        {
            return new ObjectSprite(itemSelector2, itemSelectorNormal);
        }

        public ISprite CreateInventoryItemSelectorHard()
        {
            return new ObjectSprite(itemSelector2, itemSelectorHard);
        }

        public ISprite CreateInventoryItemSelectorNightmare()
        {
            return new ObjectSprite(itemSelector2, itemSelectorNightmare);
        }

        public ISprite CreateInventoryWoodenSword()
        {
            return new ObjectSprite(woodenSwordSpriteSheet, woodenSwordData);
        }

        public ISprite CreateInventoryWhiteSword()
        {
            return new ObjectSprite(whiteSwordSpriteSheet, whiteSwordData);
        }

        public ISprite CreateInventoryMagicSword()
        {
            return new ObjectSprite(magicSwordSpriteSheet, magicSwordData);
        }
    }
}