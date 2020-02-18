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

    class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private Texture2D fireSpriteSheet;
        private static readonly int DRAW_SCALE = 2;

        private static readonly ItemSpriteFactory InstanceValue = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance => InstanceValue;

        public int Scale => DRAW_SCALE;

        public Texture2D SpriteSheet => this.itemSpriteSheet;

        private ItemSpriteFactory()
        { }

        public void LoadAllTextures(ContentManager content)
        {
            this.itemSpriteSheet = content.Load<Texture2D>("Items");
            this.fireSpriteSheet = content.Load<Texture2D>("fire");
        }

        public List<IItemSprite> getAll(int x, int y)
        {
            List<IItemSprite> allItems = new List<IItemSprite>();
            allItems.Add(this.Fairy(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Health(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Triforce(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.YellowRupee(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.FullHeart(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.HalfHeart(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.EmptyHeart(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.HeartContainer(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Clock(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Rupee(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.LifePotion(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.SecondPotion(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Letter(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Map(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Food(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.WoodenSword(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.WhiteSword(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.MagicSword(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.MagicShield(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Boomerang(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.MagicBoomerang(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Bomb(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Bow(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Arrow(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.SilverArrow(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.RedCandle(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.BlueCandle(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.RedRing(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.BlueRing(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.PowerBracelet(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Flute(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Raft(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.StepLadder(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.MagicRod(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.MagicBook(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Key(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.MagicKey(new Vector2(x, y), DRAW_SCALE));
            allItems.Add(this.Compass(new Vector2(x, y), DRAW_SCALE));
            return allItems;
        }

        public IItemSprite Fairy(Vector2 loc, int scale)
        {
            return new Fairy(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Health(Vector2 loc, int scale)
        {
            return new Health(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Triforce(Vector2 loc, int scale)
        {
            return new TriForce(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite YellowRupee(Vector2 loc, int scale)
        {
            return new YellowRupee(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite FullHeart(Vector2 loc, int scale)
        {
            return new FullHeart(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite HalfHeart(Vector2 loc, int scale)
        {
            return new HalfHeart(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite EmptyHeart(Vector2 loc, int scale)
        {
            return new EmptyHeart(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite HeartContainer(Vector2 loc, int scale)
        {
            return new HeartContainer(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Clock(Vector2 loc, int scale)
        {
            return new Clock(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Rupee(Vector2 loc, int scale)
        {
            return new Rupee(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite LifePotion(Vector2 loc, int scale)
        {
            return new LifePotion(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite SecondPotion(Vector2 loc, int scale)
        {
            return new SecondPotion(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Letter(Vector2 loc, int scale)
        {
            return new Letter(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Map(Vector2 loc, int scale)
        {
            return new Map(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Food(Vector2 loc, int scale)
        {
            return new Food(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite WoodenSword(Vector2 loc, int scale)
        {
            return new WoodenSword(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite WhiteSword(Vector2 loc, int scale)
        {
            return new WhiteSword(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite MagicSword(Vector2 loc, int scale)
        {
            return new MagicSword(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite MagicShield(Vector2 loc, int scale)
        {
            return new MagicShield(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Boomerang(Vector2 loc, int scale)
        {
            return new Boomerang(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite MagicBoomerang(Vector2 loc, int scale)
        {
            return new MagicBoomerang(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Bomb(Vector2 loc, int scale)
        {
            return new Bomb(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Bow(Vector2 loc, int scale)
        {
            return new Bow(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Arrow(Vector2 loc, int scale)
        {
            return new Arrow(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite SilverArrow(Vector2 loc, int scale)
        {
            return new SilverArrow(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite RedCandle(Vector2 loc, int scale)
        {
            return new RedCandle(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite BlueCandle(Vector2 loc, int scale)
        {
            return new BlueCandle(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite RedRing(Vector2 loc, int scale)
        {
            return new RedRing(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite BlueRing(Vector2 loc, int scale)
        {
            return new BlueRing(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite PowerBracelet(Vector2 loc, int scale)
        {
            return new PowerBracelet(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Flute(Vector2 loc, int scale)
        {
            return new Flute(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Raft(Vector2 loc, int scale)
        {
            return new Raft(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite StepLadder(Vector2 loc, int scale)
        {
            return new StepLadder(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite MagicRod(Vector2 loc, int scale)
        {
            return new MagicRod(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite MagicBook(Vector2 loc, int scale)
        {
            return new MagicBook(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Key(Vector2 loc, int scale)
        {
            return new Key(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite MagicKey(Vector2 loc, int scale)
        {
            return new MagicKey(this.itemSpriteSheet, loc, scale);
        }

        public IItemSprite Compass(Vector2 loc, int scale)
        {
            return new Compass(this.itemSpriteSheet, loc, scale);
        }
    }
}
