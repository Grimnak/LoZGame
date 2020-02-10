using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        { }


        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("Items");
        }

        public List<ISprite> getAll(int width, int height)
        {
            int x = width / 2;
            int y = height / 2;
            List<ISprite> allItems = new List<ISprite>();
            allItems.Add(this.Fairy(new Vector2(x, y)));
            allItems.Add(this.Health(new Vector2(x, y)));
            allItems.Add(this.Triforce(new Vector2(x, y)));
            allItems.Add(this.YellowRupee(new Vector2(x, y)));
            allItems.Add(this.FullHeart(new Vector2(x, y)));
            allItems.Add(this.HalfHeart(new Vector2(x, y)));
            allItems.Add(this.EmptyHeart(new Vector2(x, y)));
            allItems.Add(this.HeartContainer(new Vector2(x, y)));
            allItems.Add(this.Clock(new Vector2(x, y)));
            allItems.Add(this.Rupee(new Vector2(x, y)));
            allItems.Add(this.LifePotion(new Vector2(x, y)));
            allItems.Add(this.SecondPotion(new Vector2(x, y)));
            allItems.Add(this.Letter(new Vector2(x, y)));
            allItems.Add(this.Map(new Vector2(x, y)));
            allItems.Add(this.Food(new Vector2(x, y)));
            allItems.Add(this.WoodenSword(new Vector2(x, y)));
            allItems.Add(this.WhiteSword(new Vector2(x, y)));
            allItems.Add(this.MagicSword(new Vector2(x, y)));
            allItems.Add(this.MagicShield(new Vector2(x, y)));
            allItems.Add(this.Boomerang(new Vector2(x, y)));
            allItems.Add(this.MagicBoomerang(new Vector2(x, y)));
            allItems.Add(this.Bomb(new Vector2(x, y)));
            allItems.Add(this.Bow(new Vector2(x, y)));
            allItems.Add(this.Arrow(new Vector2(x, y)));
            allItems.Add(this.SilverArrow(new Vector2(x, y)));
            allItems.Add(this.RedCandle(new Vector2(x, y)));
            allItems.Add(this.BlueCandle(new Vector2(x, y)));
            allItems.Add(this.RedRing(new Vector2(x, y)));
            allItems.Add(this.BlueRing(new Vector2(x, y)));
            allItems.Add(this.PowerBracelet(new Vector2(x, y)));
            allItems.Add(this.Flute(new Vector2(x, y)));
            allItems.Add(this.Raft(new Vector2(x, y)));
            allItems.Add(this.StepLadder(new Vector2(x, y)));
            allItems.Add(this.MagicRod(new Vector2(x, y)));
            allItems.Add(this.MagicBook(new Vector2(x, y)));
            allItems.Add(this.Key(new Vector2(x, y)));
            allItems.Add(this.MagicKey(new Vector2(x, y)));
            allItems.Add(this.Compass(new Vector2(x, y)));
            return allItems;
        }

        public ISprite Fairy(Vector2 loc)
        {
            return new Fairy(itemSpriteSheet, loc);
        }
        public ISprite Health(Vector2 loc)
        {
            return new Health(itemSpriteSheet, loc);
        }
        public ISprite Triforce(Vector2 loc)
        {
            return new TriForce(itemSpriteSheet, loc);
        }
        public ISprite YellowRupee(Vector2 loc)
        {
            return new YellowRupee(itemSpriteSheet, loc);
        }
        public ISprite FullHeart(Vector2 loc)
        {
            return new FullHeart(itemSpriteSheet, loc);
        }
        public ISprite HalfHeart(Vector2 loc)
        {
            return new HalfHeart(itemSpriteSheet, loc);
        }
        public ISprite EmptyHeart(Vector2 loc)
        {
            return new EmptyHeart(itemSpriteSheet, loc);
        }
        public ISprite HeartContainer(Vector2 loc)
        {
            return new HeartContainer(itemSpriteSheet, loc);
        }
        public ISprite Clock(Vector2 loc)
        {
            return new Clock(itemSpriteSheet, loc);
        }
        public ISprite Rupee(Vector2 loc)
        {
            return new Rupee(itemSpriteSheet, loc);
        }
        public ISprite LifePotion(Vector2 loc)
        {
            return new LifePotion(itemSpriteSheet, loc);
        }
        public ISprite SecondPotion(Vector2 loc)
        {
            return new SecondPotion(itemSpriteSheet, loc);
        }
        public ISprite Letter(Vector2 loc)
        {
            return new Letter(itemSpriteSheet, loc);
        }
        public ISprite Map(Vector2 loc)
        {
            return new Map(itemSpriteSheet, loc);
        }
        public ISprite Food(Vector2 loc)
        {
            return new Food(itemSpriteSheet, loc);
        }
        public ISprite WoodenSword(Vector2 loc)
        {
            return new WoodenSword(itemSpriteSheet, loc);
        }
        public ISprite WhiteSword(Vector2 loc)
        {
            return new WhiteSword(itemSpriteSheet, loc);
        }
        public ISprite MagicSword(Vector2 loc)
        {
            return new MagicSword(itemSpriteSheet, loc);
        }
        public ISprite MagicShield(Vector2 loc)
        {
            return new MagicShield(itemSpriteSheet, loc);
        }
        public ISprite Boomerang(Vector2 loc)
        {
            return new Boomerang(itemSpriteSheet, loc);
        }
        public ISprite MagicBoomerang(Vector2 loc)
        {
            return new MagicBoomerang(itemSpriteSheet, loc);
        }
        public ISprite Bomb(Vector2 loc)
        {
            return new Bomb(itemSpriteSheet, loc);
        }
        public ISprite Bow(Vector2 loc)
        {
            return new Bow(itemSpriteSheet, loc);
        }
        public ISprite Arrow(Vector2 loc)
        {
            return new Arrow(itemSpriteSheet, loc);
        }
        public ISprite SilverArrow(Vector2 loc)
        {
            return new SilverArrow(itemSpriteSheet, loc);
        }
        public ISprite RedCandle(Vector2 loc)
        {
            return new RedCandle(itemSpriteSheet, loc);
        }
        public ISprite BlueCandle(Vector2 loc)
        {
            return new BlueCandle(itemSpriteSheet, loc);
        }
        public ISprite RedRing(Vector2 loc)
        {
            return new RedRing(itemSpriteSheet, loc);
        }
        public ISprite BlueRing(Vector2 loc)
        {
            return new BlueRing(itemSpriteSheet, loc);
        }
        public ISprite PowerBracelet(Vector2 loc)
        {
            return new PowerBracelet(itemSpriteSheet, loc);
        }
        public ISprite Flute(Vector2 loc)
        {
            return new Flute(itemSpriteSheet, loc);
        }
        public ISprite Raft(Vector2 loc)
        {
            return new Raft(itemSpriteSheet, loc);
        }
        public ISprite StepLadder(Vector2 loc)
        {
            return new StepLadder(itemSpriteSheet, loc);
        }
        public ISprite MagicRod(Vector2 loc)
        {
            return new MagicRod(itemSpriteSheet, loc);
        }
        public ISprite MagicBook(Vector2 loc)
        {
            return new MagicBook(itemSpriteSheet, loc);
        }
        public ISprite Key(Vector2 loc)
        {
            return new Key(itemSpriteSheet, loc);
        }
        public ISprite MagicKey(Vector2 loc)
        {
            return new MagicKey(itemSpriteSheet, loc);
        }
        public ISprite Compass(Vector2 loc)
        {
            return new Compass(itemSpriteSheet, loc);
        }
    }
}
