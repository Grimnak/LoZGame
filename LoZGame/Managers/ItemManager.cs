namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class ItemManager
    {
        public IItem CurrentItem;
        private int currentIndex;
        private int maxIndex;
        private int timer;

        public List<IItem> itemList {get; set;}
        public ItemManager()
        {
            this.itemList = new List<IItem>();
            this.timer = 0;
            this.currentIndex = 0;
            this.maxIndex = 0;
        }

        public void LoadSprites(int xloc, int yloc)
        {
            itemList.Add(new Fairy(new Vector2(xloc, yloc)));
            itemList.Add(new Health(new Vector2(xloc, yloc)));
            itemList.Add(new Triforce(new Vector2(xloc, yloc)));
            itemList.Add(new YellowRupee(new Vector2(xloc, yloc)));
            itemList.Add(new HeartContainer(new Vector2(xloc, yloc)));
            itemList.Add(new Clock(new Vector2(xloc, yloc)));
            itemList.Add(new Rupee(new Vector2(xloc, yloc)));
            itemList.Add(new LifePotion(new Vector2(xloc, yloc)));
            itemList.Add(new SecondPotion(new Vector2(xloc, yloc)));
            itemList.Add(new Letter(new Vector2(xloc, yloc)));
            itemList.Add(new Map(new Vector2(xloc, yloc)));
            itemList.Add(new Food(new Vector2(xloc, yloc)));
            itemList.Add(new WoodenSword(new Vector2(xloc, yloc)));
            itemList.Add(new WhiteSword(new Vector2(xloc, yloc)));
            itemList.Add(new MagicSword(new Vector2(xloc, yloc)));
            itemList.Add(new MagicShield(new Vector2(xloc, yloc)));
            itemList.Add(new EmptyHeart(new Vector2(xloc, yloc)));
            itemList.Add(new HalfHeart(new Vector2(xloc, yloc)));
            itemList.Add(new FullHeart(new Vector2(xloc, yloc)));
            itemList.Add(new Boomerang(new Vector2(xloc, yloc)));
            itemList.Add(new MagicBoomerang(new Vector2(xloc, yloc)));
            itemList.Add(new Bomb(new Vector2(xloc, yloc)));
            itemList.Add(new Bow(new Vector2(xloc, yloc)));
            itemList.Add(new Arrow(new Vector2(xloc, yloc)));
            itemList.Add(new SilverArrow(new Vector2(xloc, yloc)));
            itemList.Add(new RedCandle(new Vector2(xloc, yloc)));
            itemList.Add(new BlueCandle(new Vector2(xloc, yloc)));
            itemList.Add(new RedRing(new Vector2(xloc, yloc)));
            itemList.Add(new BlueRing(new Vector2(xloc, yloc)));
            itemList.Add(new PowerBracelet(new Vector2(xloc, yloc)));
            itemList.Add(new Flute(new Vector2(xloc, yloc)));
            itemList.Add(new Raft(new Vector2(xloc, yloc)));
            itemList.Add(new Ladder(new Vector2(xloc, yloc)));
            itemList.Add(new MagicRod(new Vector2(xloc, yloc)));
            itemList.Add(new MagicBook(new Vector2(xloc, yloc)));
            itemList.Add(new Key(new Vector2(xloc, yloc)));
            itemList.Add(new MagicKey(new Vector2(xloc, yloc)));
            itemList.Add(new Compass(new Vector2(xloc, yloc)));
            this.CurrentItem = this.itemList[this.currentIndex];
            foreach (IItem sprite in this.itemList)
            {
                this.maxIndex++;
            }
        }

        public void CycleLeft()
        {
            this.currentIndex--;

            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }

            this.CurrentItem = this.itemList[this.currentIndex];
        }

        public void CycleRight()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }

            this.CurrentItem = this.itemList[this.currentIndex];
            System.Console.WriteLine(this.CurrentItem);
        }

        public void Update()
        {
            this.timer++;
            if (this.timer % 10 == 0)
            {
                this.CycleRight();
                this.timer = 0;
            }
            this.CurrentItem.Update();
        }

        public void Draw()
        {
            this.CurrentItem.Draw();
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}