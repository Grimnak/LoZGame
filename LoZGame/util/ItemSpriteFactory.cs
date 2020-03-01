﻿namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class ItemSpriteFactory
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
        private Texture2D arrowSpriteSheet;
        private readonly SpriteSheetData arrowData = new SpriteSheetData("WoodenArrow", ArrowWidth, ArrowHeight, 1, 1);
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

    }



        public List<IItem> getAll(int x, int y)
        {
            List<IItem> allItems = new List<IItem>();
            allItems.Add(this.Fairy(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Health(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Triforce(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.YellowRupee(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.HeartContainer(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Clock(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Rupee(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.LifePotion(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.SecondPotion(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Letter(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Map(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Food(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.WoodenSword(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.WhiteSword(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.MagicSword(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.MagicShield(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Boomerang(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.MagicBoomerang(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Bomb(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Bow(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Arrow(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.SilverArrow(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.RedCandle(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.BlueCandle(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.RedRing(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.BlueRing(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.PowerBracelet(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Flute(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Raft(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Ladder(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.MagicRod(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.MagicBook(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Key(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.MagicKey(new Vector2(x, y), DRAWSCALE));
            allItems.Add(this.Compass(new Vector2(x, y), DRAWSCALE));
            return allItems;
        }

        public IItem Fairy(Vector2 loc, int scale)
        {
            return new Fairy(this.fairySpriteSheet, this.fairyData, loc, scale);
        }

        public IItem Health(Vector2 loc, int scale)
        {
            return new Health(this.healthSpriteSheet, this.healthData, loc, scale);
        }

        public IItem Triforce(Vector2 loc, int scale)
        {
            return new TriForce(this.triforceSpriteSheet, this.triforceData, loc, scale);
        }

        public IItem YellowRupee(Vector2 loc, int scale)
        {
            return new YellowRupee(this.yellowRupeeSpriteSheet, this.yellowRupeeData, loc, scale);
        }

        /*public IItem FullHeart(Vector2 loc, int scale)
        {
            return new FullHeart(this.SpriteSheet, this.Data, loc, scale);
        }

        public IItem HalfHeart(Vector2 loc, int scale)
        {
            return new HalfHeart(this.SpriteSheet, this.Data, loc, scale);
        }

        public IItem EmptyHeart(Vector2 loc, int scale)
        {
            return new Fairy(this.SpriteSheet, this.Data, loc, scale);
        }*/

        public IItem HeartContainer(Vector2 loc, int scale)
        {
            return new HeartContainer(this.heartContainerSpriteSheet, this.heartContainerData, loc, scale);
        }

        public IItem Clock(Vector2 loc, int scale)
        {
            return new Clock(this.clockSpriteSheet, this.clockData, loc, scale);
        }

        public IItem Rupee(Vector2 loc, int scale)
        {
            return new Rupee(this.rupeeSpriteSheet, this.rupeeData, loc, scale);
        }

        public IItem LifePotion(Vector2 loc, int scale)
        {
            return new LifePotion(this.lifePotionSpriteSheet, this.lifePotionData, loc, scale);
        }

        public IItem SecondPotion(Vector2 loc, int scale)
        {
            return new SecondPotion(this.secondPotionSpriteSheet, this.secondPotionData, loc, scale);
        }

        public IItem Letter(Vector2 loc, int scale)
        {
            return new Letter(this.letterSpriteSheet, this.letterData, loc, scale);
        }

        public IItem Map(Vector2 loc, int scale)
        {
            return new Map(this.mapSpriteSheet, this.mapData, loc, scale);
        }

        public IItem Food(Vector2 loc, int scale)
        {
            return new Food(this.foodSpriteSheet, this.foodData, loc, scale);
        }

        public IItem WoodenSword(Vector2 loc, int scale)
        {
            return new WoodenSword(this.woodenSwordSpriteSheet, this.woodenSwordData, loc, scale);
        }

        public IItem WhiteSword(Vector2 loc, int scale)
        {
            return new WhiteSword(this.whiteSwordSpriteSheet, this.whiteSwordData, loc, scale);
        }

        public IItem MagicSword(Vector2 loc, int scale)
        {
            return new MagicSword(this.magicSwordSpriteSheet, this.magicSwordData, loc, scale);
        }

        public IItem MagicShield(Vector2 loc, int scale)
        {
            return new MagicShield(this.shieldSpriteSheet, this.shieldData, loc, scale);
        }

        public IItem Boomerang(Vector2 loc, int scale)
        {
            return new Boomerang(this.boomerangSpriteSheet, this.boomerangData, loc, scale);
        }

        public IItem MagicBoomerang(Vector2 loc, int scale)
        {
            return new MagicBoomerang(this.magicBoomerangSpriteSheet, this.magicBoomerangData, loc, scale);
        }

        public IItem Bomb(Vector2 loc, int scale)
        {
            return new Bomb(this.bombSpriteSheet, this.bombData, loc, scale);
        }

        public IItem Bow(Vector2 loc, int scale)
        {
            return new Bow(this.bowSpriteSheet, this.bowData, loc, scale);
        }

        public IItem Arrow(Vector2 loc, int scale)
        {
            return new Arrow(this.arrowSpriteSheet, this.arrowData, loc, scale);
        }

        public IItem SilverArrow(Vector2 loc, int scale)
        {
            return new SilverArrow(this.silverArrowSpriteSheet, this.silverArrowData, loc, scale);
        }

        public IItem RedCandle(Vector2 loc, int scale)
        {
            return new RedCandle(this.redCandleSpriteSheet, this.redCandleData, loc, scale);
        }

        public IItem BlueCandle(Vector2 loc, int scale)
        {
            return new BlueCandle(this.blueCandleSpriteSheet, this.blueCandleData, loc, scale);
        }

        public IItem RedRing(Vector2 loc, int scale)
        {
            return new RedRing(this.redRingSpriteSheet, this.redRingData, loc, scale);
        }

        public IItem BlueRing(Vector2 loc, int scale)
        {
            return new BlueRing(this.blueRingSpriteSheet, this.blueRingData, loc, scale);
        }

        public IItem PowerBracelet(Vector2 loc, int scale)
        {
            return new PowerBracelet(this.powerBraceletSpriteSheet, this.powerBraceletData, loc, scale);
        }

        public IItem Flute(Vector2 loc, int scale)
        {
            return new Flute(this.fluteSpriteSheet, this.fluteData, loc, scale);
        }

        public IItem Raft(Vector2 loc, int scale)
        {
            return new Raft(this.raftSpriteSheet, this.raftData, loc, scale);
        }

        public IItem Ladder(Vector2 loc, int scale)
        {
            return new Ladder(this.ladderSpriteSheet, this.ladderData, loc, scale);
        }

        public IItem MagicRod(Vector2 loc, int scale)
        {
            return new MagicRod(this.magicRodSpriteSheet, this.magicRodData, loc, scale);
        }

        public IItem MagicBook(Vector2 loc, int scale)
        {
            return new MagicBook(this.magicBookSpriteSheet, this.magicBookData, loc, scale);
        }

        public IItem Key(Vector2 loc, int scale)
        {
            return new Key(this.keySpriteSheet, this.keyData, loc, scale);
        }

        public IItem MagicKey(Vector2 loc, int scale)
        {
            return new MagicKey(this.magicKeySpriteSheet, this.magicKeyData, loc, scale);
        }

        public IItem Compass(Vector2 loc, int scale)
        {
            return new Compass(this.compassSpriteSheet, this.compassData, loc, scale);
        }
    }
}
