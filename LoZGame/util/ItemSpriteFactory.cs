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
        private static readonly int DRAWSCALE = 2;
        private static readonly int TriforceSize = 12;
        private static readonly int SmallHeight = 10;
        private static readonly int StandardHeight = 18;
        private static readonly int StandardWidth = 8;
        private static readonly int LargeWidth = 16;
        private static readonly int SmallWidth = 5;

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
        private readonly SpriteSheetData healthData = new SpriteSheetData("Health", HealthWidth, HealthHeight, 1, 2);
        private Texture2D fairySpriteSheet;
        private readonly SpriteSheetData fairyData = new SpriteSheetData("Fairy", FairyWidth, FairyHeight, 1, 2);
        private Texture2D yellowRupeeSpriteSheet;
        private readonly SpriteSheetData yellowRupeeData = new SpriteSheetData("YellowRupee", RupeeWidth, RupeeHeight, 1, 2);
        private Texture2D blueCandleSpriteSheet;
        private readonly SpriteSheetData blueCandleData = new SpriteSheetData("BlueCandle", CandleWidth, CandleHeight, 1, 1);
        private Texture2D redCandleSpriteSheet;
        private readonly SpriteSheetData redCandleData = new SpriteSheetData("RedCandle", CandleWidth, CandleHeight, 1, 1);
        private Texture2D blueRingSpriteSheet;
        private readonly SpriteSheetData blueRingData = new SpriteSheetData("BlueRing", RingWidth, RingHeight, 1, 1);
        private Texture2D redRingSpriteSheet;
        private readonly SpriteSheetData redRingData = new SpriteSheetData("RedRing", RingWidth, RingHeight, 1, 1);
        private Texture2D bombSpriteSheet;
        private readonly SpriteSheetData bombData = new SpriteSheetData("Bomb", BombWidth, BombHeight, 1, 1);
        private Texture2D magicBookSpriteSheet;
        private readonly SpriteSheetData magicBookData = new SpriteSheetData("Book", BookWidth, BookHeight, 1, 1);
        private Texture2D boomerangSpriteSheet;
        private readonly SpriteSheetData boomerangData = new SpriteSheetData("Boomerang", BoomerangWidth, BoomerangHeight, 1, 1);
        private Texture2D magicBoomerangSpriteSheet;
        private readonly SpriteSheetData magicBoomerangData = new SpriteSheetData("MagicBoomerang", BoomerangWidth, BoomerangHeight, 1, 1);
        private Texture2D bowSpriteSheet;
        private readonly SpriteSheetData bowData = new SpriteSheetData("Bow", BowWidth, BowHeight, 1, 1);
        private Texture2D clockSpriteSheet;
        private readonly SpriteSheetData clockData = new SpriteSheetData("Clock", ClockWidth, ClockHeight, 1, 1);
        private Texture2D compassSpriteSheet;
        private readonly SpriteSheetData compassData = new SpriteSheetData("Compass", CompassWidth, CompassHeight, 1, 1);
        private Texture2D foodSpriteSheet;
        private readonly SpriteSheetData foodData = new SpriteSheetData("Food", FoodWidth, FoodHeight, 1, 1);
        private Texture2D heartContainerSpriteSheet;
        private readonly SpriteSheetData heartContainerData = new SpriteSheetData("HeartContainer", HeartContainerWidth, HeartContainerHeight, 1, 1);
        private Texture2D keySpriteSheet;
        private readonly SpriteSheetData keyData = new SpriteSheetData("Key", KeyWidth, KeyHeight, 1, 1);
        private Texture2D ladderSpriteSheet;
        private readonly SpriteSheetData ladderData = new SpriteSheetData("Ladder", LadderWidth, LadderHeight, 1, 1);
        private Texture2D letterSpriteSheet;
        private readonly SpriteSheetData letterData = new SpriteSheetData("Letter", LetterWidth, LetterHeight, 1, 1);
        private Texture2D lifePotionSpriteSheet;
        private readonly SpriteSheetData lifePotionData = new SpriteSheetData("LifePotion", PotionWidth, PotionHeight, 1, 1);
        private Texture2D magicKeySpriteSheet;
        private readonly SpriteSheetData magicKeyData = new SpriteSheetData("MagicKey", KeyWidth, KeyHeight, 1, 1);
        private Texture2D magicRodSpriteSheet;
        private readonly SpriteSheetData magicRodData = new SpriteSheetData("MagicRod", MagicRodWidth, MagicRodHeight, 1, 1);
        private Texture2D woodenSwordSpriteSheet;
        private readonly SpriteSheetData woodenSwordData = new SpriteSheetData("WoodenSword", SwordWidth, SwordHeight, 1, 1);
        private Texture2D whiteSwordSpriteSheet;
        private readonly SpriteSheetData whiteSwordData = new SpriteSheetData("WhiteSword", SwordWidth, SwordHeight, 1, 1);
        private Texture2D magicSwordSpriteSheet;
        private readonly SpriteSheetData magicSwordData = new SpriteSheetData("MagicSword", SwordWidth, SwordHeight, 1, 1);
        private Texture2D mapSpriteSheet;
        private readonly SpriteSheetData mapData = new SpriteSheetData("Map", MapWidth, MapHeight, 1, 1);
        private Texture2D powerBraceletSpriteSheet;
        private readonly SpriteSheetData powerBraceletData = new SpriteSheetData("PowerBracelet", PowerBraceletWidth, PowerBraceletHeight, 1, 1);
        private Texture2D raftSpriteSheet;
        private readonly SpriteSheetData raftData = new SpriteSheetData("Raft", RaftWidth, RaftHeight, 1, 1);
        private Texture2D rupeeSpriteSheet;
        private readonly SpriteSheetData rupeeData = new SpriteSheetData("Rupee", RupeeWidth, RupeeHeight, 1, 1);
        private Texture2D secondPotionSpriteSheet;
        private readonly SpriteSheetData secondPotionData = new SpriteSheetData("SecondPotion", PotionWidth, PotionHeight, 1, 1);
        private Texture2D shieldSpriteSheet;
        private readonly SpriteSheetData shieldData = new SpriteSheetData("Shield", ShieldWidth, ShieldHeight, 1, 1);
        private Texture2D silverArrowSpriteSheet;
        private readonly SpriteSheetData silverArrowData = new SpriteSheetData("SilverArrow", ArrowWidth, ArrowHeight, 1, 1);
        private Texture2D woodenArrowSpriteSheet;
        private readonly SpriteSheetData woodenArrowData = new SpriteSheetData("WoodenArrow", ArrowWidth, ArrowHeight, 1, 1);
        private Texture2D triforceSpriteSheet;
        private readonly SpriteSheetData triforceData = new SpriteSheetData("Triforce", TriforceWidth, TriforceHeight, 1, 2);
        private Texture2D fluteSpriteSheet;
        private readonly SpriteSheetData fluteData = new SpriteSheetData("Flute", FluteWidth, FluteHeight, 1, 2);

        private static readonly ItemSpriteFactory InstanceValue = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        private ItemSpriteFactory()
        { }

        public void LoadAllTextures(ContentManager content)
        {
            healthSpriteSheet = content.Load<Texture2D>(this.healthData.FilePath);
            fairySpriteSheet = content.Load<Texture2D>(this.fairyData.FilePath);
            yellowRupeeSpriteSheet = content.Load<Texture2D>(this.yellowRupeeData.FilePath);
            blueCandleSpriteSheet = content.Load<Texture2D>(this.blueCandleData.FilePath);
            redCandleSpriteSheet = content.Load<Texture2D>(this.redCandleData.FilePath);
            blueRingSpriteSheet = content.Load<Texture2D>(this.blueRingData.FilePath);
            redRingSpriteSheet = content.Load<Texture2D>(this.redRingData.FilePath);
            bombSpriteSheet = content.Load<Texture2D>(this.bombData.FilePath);
            magicBookSpriteSheet = content.Load<Texture2D>(this.magicBookData.FilePath);
            boomerangSpriteSheet = content.Load<Texture2D>(this.boomerangData.FilePath);
            magicBoomerangSpriteSheet = content.Load<Texture2D>(this.magicBoomerangData.FilePath);
            bowSpriteSheet = content.Load<Texture2D>(this.bowData.FilePath);
            clockSpriteSheet = content.Load<Texture2D>(this.clockData.FilePath);
            compassSpriteSheet = content.Load<Texture2D>(this.compassData.FilePath);
            foodSpriteSheet = content.Load<Texture2D>(this.foodData.FilePath);
            heartContainerSpriteSheet = content.Load<Texture2D>(this.heartContainerData .FilePath);
            keySpriteSheet = content.Load<Texture2D>(this.keyData.FilePath);
            ladderSpriteSheet = content.Load<Texture2D>(this.ladderData.FilePath);
            letterSpriteSheet = content.Load<Texture2D>(this.letterData.FilePath);
            lifePotionSpriteSheet = content.Load<Texture2D>(this.lifePotionData.FilePath);
            magicKeySpriteSheet = content.Load<Texture2D>(this.magicKeyData.FilePath);
            magicRodSpriteSheet = content.Load<Texture2D>(this.magicRodData.FilePath);
            woodenSwordSpriteSheet = content.Load<Texture2D>(this.woodenSwordData.FilePath);
            whiteSwordSpriteSheet = content.Load<Texture2D>(this.whiteSwordData.FilePath);
            magicSwordSpriteSheet = content.Load<Texture2D>(this.magicSwordData.FilePath);
            mapSpriteSheet = content.Load<Texture2D>(this.mapData.FilePath);
            powerBraceletSpriteSheet = content.Load<Texture2D>(this.powerBraceletData.FilePath);
            raftSpriteSheet = content.Load<Texture2D>(this.raftData.FilePath);
            rupeeSpriteSheet = content.Load<Texture2D>(this.rupeeData.FilePath);
            secondPotionSpriteSheet = content.Load<Texture2D>(this.secondPotionData.FilePath);
            shieldSpriteSheet = content.Load<Texture2D>(this.shieldData.FilePath);
            silverArrowSpriteSheet = content.Load<Texture2D>(this.silverArrowData.FilePath);
            woodenArrowSpriteSheet = content.Load<Texture2D>(this.woodenArrowData.FilePath);
            triforceSpriteSheet = content.Load<Texture2D>(this.triforceData.FilePath);
            fluteSpriteSheet = content.Load<Texture2D>(this.fluteData.FilePath);

    }

        public ISprite Fairy(int scale)
        {
            return new FairySprite(this.fairySpriteSheet, this.fairyData, scale);
        }

        public ISprite Health(int scale)
        {
            return new HealthSprite(this.healthSpriteSheet, this.healthData, scale);
        }

        public ISprite Triforce(int scale)
        {
            return new TriForceSprite(this.triforceSpriteSheet, this.triforceData, scale + 1);
        }

        public ISprite YellowRupee(int scale)
        {
            return new YellowRupeeSprite(this.yellowRupeeSpriteSheet, this.yellowRupeeData, scale);
        }

        public ISprite HeartContainer(int scale)
        {
            return new HeartContainerSprite(this.heartContainerSpriteSheet, this.heartContainerData, scale);
        }

        public ISprite Clock(int scale)
        {
            return new ClockSprite(this.clockSpriteSheet, this.clockData, scale);
        }

        public ISprite Rupee(int scale)
        {
            return new RupeeSprite(this.rupeeSpriteSheet, this.rupeeData, scale);
        }

        public ISprite LifePotion(int scale)
        {
            return new LifePotionSprite(this.lifePotionSpriteSheet, this.lifePotionData, scale);
        }

        public ISprite SecondPotion(int scale)
        {
            return new SecondPotionSprite(this.secondPotionSpriteSheet, this.secondPotionData, scale);
        }

        public ISprite Letter(int scale)
        {
            return new LetterSprite(this.letterSpriteSheet, this.letterData, scale);
        }

        public ISprite Map(int scale)
        {
            return new MapSprite(this.mapSpriteSheet, this.mapData, scale);
        }

        public ISprite Food(int scale)
        {
            return new FoodSprite(this.foodSpriteSheet, this.foodData, scale);
        }

        public ISprite WoodenSword(int scale)
        {
            return new WoodenSwordSprite(this.woodenSwordSpriteSheet, this.woodenSwordData, scale);
        }

        public ISprite WhiteSword(int scale)
        {
            return new WhiteSwordSprite(this.whiteSwordSpriteSheet, this.whiteSwordData, scale);
        }

        public ISprite MagicSword(int scale)
        {
            return new MagicSwordSprite(this.magicSwordSpriteSheet, this.magicSwordData, scale);
        }

        public ISprite MagicShield(int scale)
        {
            return new MagicShieldSprite(this.shieldSpriteSheet, this.shieldData, scale);
        }

        public ISprite Boomerang(int scale)
        {
            return new BoomerangSprite(this.boomerangSpriteSheet, this.boomerangData, scale);
        }

        public ISprite MagicBoomerang(int scale)
        {
            return new MagicBoomerangSprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData, scale);
        }

        public ISprite Bomb(int scale)
        {
            return new BombSprite(this.bombSpriteSheet, this.bombData, scale);
        }

        public ISprite Bow(int scale)
        {
            return new BowSprite(this.bowSpriteSheet, this.bowData, scale);
        }

        public ISprite Arrow(int scale)
        {
            return new ArrowSprite(this.woodenArrowSpriteSheet, this.woodenArrowData, scale);
        }

        public ISprite SilverArrow( int scale)
        {
            return new SilverArrowSprite(this.silverArrowSpriteSheet, this.silverArrowData, scale);
        }

        public ISprite RedCandle(int scale)
        {
            return new RedCandleSprite(this.redCandleSpriteSheet, this.redCandleData, scale);
        }

        public ISprite BlueCandle(int scale)
        {
            return new BlueCandleSprite(this.blueCandleSpriteSheet, this.blueCandleData, scale);
        }

        public ISprite RedRing(int scale)
        {
            return new RedRingSprite(this.redRingSpriteSheet, this.redRingData, scale);
        }

        public ISprite BlueRing(int scale)
        {
            return new BlueRingSprite(this.blueRingSpriteSheet, this.blueRingData, scale);
        }

        public ISprite PowerBracelet(int scale)
        {
            return new PowerBraceletSprite(this.powerBraceletSpriteSheet, this.powerBraceletData, scale);
        }

        public ISprite Flute(int scale)
        {
            return new FluteSprite(this.fluteSpriteSheet, this.fluteData, scale);
        }

        public ISprite Raft(int scale)
        {
            return new RaftSprite(this.raftSpriteSheet, this.raftData, scale);
        }

        public ISprite Ladder(int scale)
        {
            return new LadderSprite(this.ladderSpriteSheet, this.ladderData, scale);
        }

        public ISprite MagicRod(int scale)
        {
            return new MagicRodSprite(this.magicRodSpriteSheet, this.magicRodData, scale);
        }

        public ISprite MagicBook(int scale)
        {
            return new MagicBookSprite(this.magicBookSpriteSheet, this.magicBookData, scale);
        }

        public ISprite Key(int scale)
        {
            return new KeySprite(this.keySpriteSheet, this.keyData, scale);
        }

        public ISprite MagicKey(int scale)
        {
            return new MagicKeySprite(this.magicKeySpriteSheet, this.magicKeyData, scale);
        }

        public ISprite Compass(int scale)
        {
            return new CompassSprite(this.compassSpriteSheet, this.compassData, scale);
        }
    }
}
