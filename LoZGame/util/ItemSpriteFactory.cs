namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ItemSpriteFactory
    {
        private static readonly int TriforceSize = 24;
        private static readonly int SmallHeight = 20;
        private static readonly int StandardHeight = 36;
        private static readonly int StandardWidth = 16;
        private static readonly int LargeWidth = 32;
        private static readonly int SmallWidth = 10;

        public static int HealthWidth { get { return StandardWidth; } }

        public static int HealthHeight { get { return SmallHeight; } }

        public static int TriforceWidth { get { return TriforceSize; } }

        public static int TriforceHeight { get { return TriforceSize; } }

        public static int LadderWidth { get { return LargeWidth; } }

        public static int LadderHeight { get { return StandardHeight; } }

        public static int RaftWidth { get { return LargeWidth; } }

        public static int RaftHeight { get { return StandardHeight; } }

        public static int HeartContainerWidth { get { return LargeWidth; } }

        public static int HeartContainerHeight { get { return StandardHeight; } }

        public static int FoodWidth { get { return StandardWidth; } }

        public static int FoodHeight { get { return StandardHeight; } }

        public static int PotionWidth { get { return StandardWidth; } }

        public static int PotionHeight { get { return StandardHeight; } }

        public static int RupeeWidth { get { return StandardWidth; } }

        public static int RupeeHeight { get { return StandardHeight; } }

        public static int FairyWidth { get { return StandardWidth; } }

        public static int FairyHeight { get { return StandardHeight; } }

        public static int CandleWidth { get { return StandardWidth; } }

        public static int CandleHeight { get { return StandardHeight; } }

        public static int BombWidth { get { return StandardWidth; } }

        public static int BombHeight { get { return StandardHeight; } }

        public static int BookWidth { get { return StandardWidth; } }

        public static int BookHeight { get { return StandardHeight; } }

        public static int BowWidth { get { return StandardWidth; } }

        public static int BowHeight { get { return StandardHeight; } }

        public static int KeyWidth { get { return StandardWidth; } }

        public static int KeyHeight { get { return StandardHeight; } }

        public static int MapWidth { get { return StandardWidth; } }

        public static int MapHeight { get { return StandardHeight; } }

        public static int LetterWidth { get { return StandardWidth; } }

        public static int LetterHeight { get { return StandardHeight; } }

        public static int MagicRodWidth { get { return StandardWidth; } }

        public static int MagicRodHeight { get { return StandardHeight; } }

        public static int SwordWidth { get { return StandardWidth; } }

        public static int SwordHeight { get { return StandardHeight; } }

        public static int PowerBraceletWidth { get { return StandardWidth; } }

        public static int PowerBraceletHeight { get { return StandardHeight; } }

        public static int ShieldWidth { get { return StandardWidth; } }

        public static int ShieldHeight { get { return StandardHeight; } }

        public static int ArrowWidth { get { return SmallWidth; } }

        public static int ArrowHeight { get { return StandardHeight; } }

        public static int FluteWidth { get { return SmallWidth; } }

        public static int FluteHeight { get { return StandardHeight; } }

        public static int Width { get { return StandardWidth; } }

        public static int Height { get { return StandardHeight; } }

        public static int BoomerangWidth { get { return StandardWidth; } }

        public static int BoomerangHeight { get { return SmallHeight; } }

        public static int RingWidth { get { return StandardWidth; } }

        public static int RingHeight { get { return SmallHeight; } }

        public static int ClockWidth { get { return LargeWidth; } }

        public static int ClockHeight { get { return StandardHeight; } }

        public static int CompassWidth { get { return LargeWidth; } }

        public static int CompassHeight { get { return StandardHeight; } }

        private Texture2D healthSpriteSheet;
        private SpriteData healthData;
        private Texture2D fairySpriteSheet;
        private SpriteData fairyData;
        private Texture2D yellowRupeeSpriteSheet;
        private SpriteData yellowRupeeData;
        private Texture2D blueCandleSpriteSheet;
        private SpriteData blueCandleData;
        private Texture2D redCandleSpriteSheet;
        private SpriteData redCandleData;
        private Texture2D blueRingSpriteSheet;
        private SpriteData blueRingData;
        private Texture2D redRingSpriteSheet;
        private SpriteData redRingData;
        private Texture2D bombSpriteSheet;
        private SpriteData bombData;
        private Texture2D magicBookSpriteSheet;
        private SpriteData magicBookData;
        private Texture2D boomerangSpriteSheet;
        private SpriteData boomerangData;
        private Texture2D magicBoomerangSpriteSheet;
        private SpriteData magicBoomerangData;
        private Texture2D bowSpriteSheet;
        private SpriteData bowData;
        private Texture2D clockSpriteSheet;
        private SpriteData clockData;
        private Texture2D compassSpriteSheet;
        private SpriteData compassData;
        private Texture2D foodSpriteSheet;
        private SpriteData foodData;
        private Texture2D heartContainerSpriteSheet;
        private SpriteData heartContainerData;
        private Texture2D keySpriteSheet;
        private SpriteData keyData;
        private Texture2D ladderSpriteSheet;
        private SpriteData ladderData;
        private Texture2D letterSpriteSheet;
        private SpriteData letterData;
        private Texture2D lifePotionSpriteSheet;
        private SpriteData lifePotionData;
        private Texture2D magicKeySpriteSheet;
        private SpriteData magicKeyData;
        private Texture2D magicRodSpriteSheet;
        private SpriteData magicRodData;
        private Texture2D woodenSwordSpriteSheet;
        private SpriteData woodenSwordData;
        private Texture2D whiteSwordSpriteSheet;
        private SpriteData whiteSwordData;
        private Texture2D magicSwordSpriteSheet;
        private SpriteData magicSwordData;
        private Texture2D mapSpriteSheet;
        private SpriteData mapData;
        private Texture2D powerBraceletSpriteSheet;
        private SpriteData powerBraceletData;
        private Texture2D raftSpriteSheet;
        private SpriteData raftData;
        private Texture2D rupeeSpriteSheet;
        private SpriteData rupeeData;
        private Texture2D secondPotionSpriteSheet;
        private SpriteData secondPotionData;
        private Texture2D shieldSpriteSheet;
        private SpriteData shieldData;
        private Texture2D silverArrowSpriteSheet;
        private SpriteData silverArrowData;
        private Texture2D woodenArrowSpriteSheet;
        private SpriteData woodenArrowData;
        private Texture2D triforceSpriteSheet;
        private SpriteData triforceData;
        private Texture2D fluteSpriteSheet;
        private SpriteData fluteData;

        private static readonly ItemSpriteFactory InstanceValue = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance => InstanceValue;

        public int Scale => 1;

        private ItemSpriteFactory()
        { }

        public void LoadAllTextures(ContentManager content)
        {
            this.LoadTextures(content);
            this.LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            healthSpriteSheet = content.Load<Texture2D>("Health");
            fairySpriteSheet = content.Load<Texture2D>("Fairy");
            yellowRupeeSpriteSheet = content.Load<Texture2D>("YellowRupee");
            blueCandleSpriteSheet = content.Load<Texture2D>("BlueCandle");
            redCandleSpriteSheet = content.Load<Texture2D>("RedCandle");
            blueRingSpriteSheet = content.Load<Texture2D>("BlueRing");
            redRingSpriteSheet = content.Load<Texture2D>("RedRing");
            bombSpriteSheet = content.Load<Texture2D>("Bomb");
            magicBookSpriteSheet = content.Load<Texture2D>("Book");
            boomerangSpriteSheet = content.Load<Texture2D>("Boomerang");
            magicBoomerangSpriteSheet = content.Load<Texture2D>("MagicBoomerang");
            bowSpriteSheet = content.Load<Texture2D>("Bow");
            clockSpriteSheet = content.Load<Texture2D>("Clock");
            compassSpriteSheet = content.Load<Texture2D>("Compass");
            foodSpriteSheet = content.Load<Texture2D>("Food");
            heartContainerSpriteSheet = content.Load<Texture2D>("HeartContainer");
            keySpriteSheet = content.Load<Texture2D>("Key");
            letterSpriteSheet = content.Load<Texture2D>("Letter");
            lifePotionSpriteSheet = content.Load<Texture2D>("LifePotion");
            magicKeySpriteSheet = content.Load<Texture2D>("MagicKey");
            magicRodSpriteSheet = content.Load<Texture2D>("MagicRod");
            woodenSwordSpriteSheet = content.Load<Texture2D>("WoodenSword");
            whiteSwordSpriteSheet = content.Load<Texture2D>("WhiteSword");
            magicSwordSpriteSheet = content.Load<Texture2D>("MagicSword");
            mapSpriteSheet = content.Load<Texture2D>("Map");
            powerBraceletSpriteSheet = content.Load<Texture2D>("PowerBracelet");
            rupeeSpriteSheet = content.Load<Texture2D>("Rupee");
            secondPotionSpriteSheet = content.Load<Texture2D>("SecondPotion");
            shieldSpriteSheet = content.Load<Texture2D>("Shield");
            silverArrowSpriteSheet = content.Load<Texture2D>("SilverArrow");
            woodenArrowSpriteSheet = content.Load<Texture2D>("WoodenArrow");
            triforceSpriteSheet = content.Load<Texture2D>("Triforce");
            fluteSpriteSheet = content.Load<Texture2D>("Flute");
        }

        private void LoadData()
        {
            healthData = new SpriteData(new Vector2(HealthWidth, HealthHeight), healthSpriteSheet, 1, 2);
            fairyData = new SpriteData(new Vector2(FairyWidth, FairyHeight), fairySpriteSheet, 1, 2);
            yellowRupeeData = new SpriteData(new Vector2(RupeeWidth, RupeeHeight), yellowRupeeSpriteSheet, 1, 2);
            blueCandleData = new SpriteData(new Vector2(CandleWidth, CandleHeight), blueCandleSpriteSheet, 1, 1);
            redCandleData = new SpriteData(new Vector2(CandleWidth, CandleHeight), redCandleSpriteSheet, 1, 1);
            blueRingData = new SpriteData(new Vector2(RingWidth, RingHeight), blueRingSpriteSheet, 1, 1);
            redRingData = new SpriteData(new Vector2(RingWidth, RingHeight), redRingSpriteSheet, 1, 1);
            bombData = new SpriteData(new Vector2(BombWidth, BombHeight), bombSpriteSheet, 1, 1);
            magicBookData = new SpriteData(new Vector2(BookWidth, BookHeight), magicBookSpriteSheet, 1, 1);
            boomerangData = new SpriteData(new Vector2(BoomerangWidth, BoomerangHeight), boomerangSpriteSheet, 1, 1);
            magicBoomerangData = new SpriteData(new Vector2(BoomerangWidth, BoomerangHeight), magicBoomerangSpriteSheet, 1, 1);
            bowData = new SpriteData(new Vector2(BowWidth, BowHeight), bowSpriteSheet, 1, 1);
            clockData = new SpriteData(new Vector2(ClockWidth, ClockHeight), clockSpriteSheet, 1, 1);
            compassData = new SpriteData(new Vector2(CompassWidth, CompassHeight), compassSpriteSheet, 1, 1);
            foodData = new SpriteData(new Vector2(FoodWidth, FoodHeight), foodSpriteSheet, 1, 1);
            heartContainerData = new SpriteData(new Vector2(HeartContainerWidth, HeartContainerHeight), heartContainerSpriteSheet, 1, 1);
            keyData = new SpriteData(new Vector2(KeyWidth, KeyHeight), keySpriteSheet, 1, 1);
            letterData = new SpriteData(new Vector2(LetterWidth, LetterHeight), letterSpriteSheet, 1, 1);
            lifePotionData = new SpriteData(new Vector2(PotionWidth, PotionHeight), lifePotionSpriteSheet, 1, 1);
            magicKeyData = new SpriteData(new Vector2(KeyWidth, KeyHeight), magicKeySpriteSheet, 1, 1);
            magicRodData = new SpriteData(new Vector2(MagicRodWidth, MagicRodHeight), magicRodSpriteSheet, 1, 1);
            woodenSwordData = new SpriteData(new Vector2(SwordWidth, SwordHeight), woodenSwordSpriteSheet, 1, 1);
            whiteSwordData = new SpriteData(new Vector2(SwordWidth, SwordHeight), whiteSwordSpriteSheet, 1, 1);
            magicSwordData = new SpriteData(new Vector2(SwordWidth, SwordHeight), magicSwordSpriteSheet, 1, 1);
            mapData = new SpriteData(new Vector2(MapWidth, MapHeight), mapSpriteSheet, 1, 1);
            powerBraceletData = new SpriteData(new Vector2(PowerBraceletWidth, PowerBraceletHeight), powerBraceletSpriteSheet, 1, 1);
            rupeeData = new SpriteData(new Vector2(RupeeWidth, RupeeHeight), rupeeSpriteSheet, 1, 1);
            secondPotionData = new SpriteData(new Vector2(PotionWidth, PotionHeight), secondPotionSpriteSheet, 1, 1);
            shieldData = new SpriteData(new Vector2(ShieldWidth, ShieldHeight), shieldSpriteSheet, 1, 1);
            silverArrowData = new SpriteData(new Vector2(ArrowWidth, ArrowHeight), silverArrowSpriteSheet, 1, 1);
            woodenArrowData = new SpriteData(new Vector2(ArrowWidth, ArrowHeight), woodenArrowSpriteSheet, 1, 1);
            triforceData = new SpriteData(new Vector2(TriforceWidth, TriforceHeight), triforceSpriteSheet, 1, 2);
            fluteData = new SpriteData(new Vector2(FluteWidth, FluteHeight), fairySpriteSheet, 1, 1);
        }

        public ISprite Fairy()
        {
            return new Sprite(this.fairySpriteSheet, this.fairyData);
        }

        public ISprite Health()
        {
            return new Sprite(this.healthSpriteSheet, this.healthData);
        }

        public ISprite Triforce()
        {
            return new Sprite(this.triforceSpriteSheet, this.triforceData);
        }

        public ISprite YellowRupee()
        {
            return new Sprite(this.yellowRupeeSpriteSheet, this.yellowRupeeData);
        }

        public ISprite HeartContainer()
        {
            return new Sprite(this.heartContainerSpriteSheet, this.heartContainerData);
        }

        public ISprite Clock()
        {
            return new Sprite(this.clockSpriteSheet, this.clockData);
        }

        public ISprite Rupee()
        {
            return new Sprite(this.rupeeSpriteSheet, this.rupeeData);
        }

        public ISprite LifePotion()
        {
            return new Sprite(this.lifePotionSpriteSheet, this.lifePotionData);
        }

        public ISprite SecondPotion()
        {
            return new Sprite(this.secondPotionSpriteSheet, this.secondPotionData);
        }

        public ISprite Letter()
        {
            return new Sprite(this.letterSpriteSheet, this.letterData);
        }

        public ISprite Map()
        {
            return new Sprite(this.mapSpriteSheet, this.mapData);
        }

        public ISprite Food()
        {
            return new Sprite(this.foodSpriteSheet, this.foodData);
        }

        public ISprite WoodenSword()
        {
            return new Sprite(this.woodenSwordSpriteSheet, this.woodenSwordData);
        }

        public ISprite WhiteSword()
        {
            return new Sprite(this.whiteSwordSpriteSheet, this.whiteSwordData);
        }

        public ISprite MagicSword()
        {
            return new Sprite(this.magicSwordSpriteSheet, this.magicSwordData);
        }

        public ISprite MagicShield()
        {
            return new Sprite(this.shieldSpriteSheet, this.shieldData);
        }

        public ISprite Boomerang()
        {
            return new Sprite(this.boomerangSpriteSheet, this.boomerangData);
        }

        public ISprite MagicBoomerang()
        {
            return new Sprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData);
        }

        public ISprite Bomb()
        {
            return new Sprite(this.bombSpriteSheet, this.bombData);
        }

        public ISprite Bow()
        {
            return new Sprite(this.bowSpriteSheet, this.bowData);
        }

        public ISprite Arrow()
        {
            return new Sprite(this.woodenArrowSpriteSheet, this.woodenArrowData);
        }

        public ISprite SilverArrow( )
        {
            return new Sprite(this.silverArrowSpriteSheet, this.silverArrowData);
        }

        public ISprite RedCandle()
        {
            return new Sprite(this.redCandleSpriteSheet, this.redCandleData);
        }

        public ISprite BlueCandle()
        {
            return new Sprite(this.blueCandleSpriteSheet, this.blueCandleData);
        }

        public ISprite RedRing()
        {
            return new Sprite(this.redRingSpriteSheet, this.redRingData);
        }

        public ISprite BlueRing()
        {
            return new Sprite(this.blueRingSpriteSheet, this.blueRingData);
        }

        public ISprite PowerBracelet()
        {
            return new Sprite(this.powerBraceletSpriteSheet, this.powerBraceletData);
        }

        public ISprite Flute()
        {
            return new Sprite(this.fluteSpriteSheet, this.fluteData);
        }

        public ISprite MagicRod()
        {
            return new Sprite(this.magicRodSpriteSheet, this.magicRodData);
        }

        public ISprite MagicBook()
        {
            return new Sprite(this.magicBookSpriteSheet, this.magicBookData);
        }

        public ISprite Key()
        {
            return new Sprite(this.keySpriteSheet, this.keyData);
        }

        public ISprite MagicKey()
        {
            return new Sprite(this.magicKeySpriteSheet, this.magicKeyData);
        }

        public ISprite Compass()
        {
            return new Sprite(this.compassSpriteSheet, this.compassData);
        }
    }
}
