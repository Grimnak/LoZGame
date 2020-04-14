namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public partial class ItemManager
    {
        public enum ItemType
        {
            Fairy,
            Health,
            Triforce,
            YellowRupee,
            HeartContainer,
            Clock,
            Rupee,
            LifePotion,
            SecondPotion,
            Letter,
            Map,
            Food,
            WoodenSword,
            WhiteSword, 
            MagicSword,
            MagicShield,
            Boomerang,
            MagicBoomerang,
            Bomb,
            Bow,
            Arrow,
            SilverArrow,
            RedCandle,
            BlueCandle,
            RedRing,
            BlueRing,
            PowerBracelet,
            Flute,
            Raft,
            Ladder,
            MagicRod,
            MagicBook,
            Key,
            MagicKey,
            Compass
        }

        public void AddItem(ItemType item, Vector2 location)
        {
            switch (item)
            {
                case ItemType.Fairy:
                    this.Add(new Fairy(location));
                    break;
                case ItemType.Health:
                    this.Add(new Health(location));
                    break;
                case ItemType.Triforce:
                    this.Add(new Triforce(location));
                    break;
                case ItemType.HeartContainer:
                    this.Add(new HeartContainer(location));
                    break;
                case ItemType.Clock:
                    this.Add(new Clock(location));
                    break;
                case ItemType.Rupee:
                    this.Add(new Rupee(location));
                    break;
                case ItemType.LifePotion:
                    this.Add(new LifePotion(location));
                    break;
                case ItemType.SecondPotion:
                    this.Add(new SecondPotion(location));
                    break;
                case ItemType.Letter:
                    this.Add(new Letter(location));
                    break;
                case ItemType.Map:
                    this.Add(new Map(location));
                    break;
                case ItemType.Food:
                    this.Add(new Food(location));
                    break;
                case ItemType.WoodenSword:
                    this.Add(new WoodenSword(location));
                    break;
                case ItemType.WhiteSword:
                    this.Add(new WhiteSword(location));
                    break;
                case ItemType.MagicSword:
                    this.Add(new MagicSword(location));
                    break;
                case ItemType.Bomb:
                    this.Add(new Bomb(location));
                    break;
                case ItemType.Boomerang:
                    this.Add(new Boomerang(location));
                    break;
                case ItemType.MagicBoomerang:
                    this.Add(new MagicBoomerang(location));
                    break;
                case ItemType.Arrow:
                    this.Add(new Arrow(location));
                    break;
                case ItemType.SilverArrow:
                    this.Add(new SilverArrow(location));
                    break;
                case ItemType.RedCandle:
                    this.Add(new RedCandle(location));
                    break;
                case ItemType.BlueCandle:
                    this.Add(new BlueCandle(location));
                    break;
                case ItemType.RedRing:
                    this.Add(new RedRing(location));
                    break;
                case ItemType.BlueRing:
                    this.Add(new BlueRing(location));
                    break;
                case ItemType.PowerBracelet:
                    this.Add(new PowerBracelet(location));
                    break;
                case ItemType.Flute:
                    this.Add(new Flute(location));
                    break;
                case ItemType.MagicRod:
                    this.Add(new MagicRod(location));
                    break;
                case ItemType.MagicBook:
                    this.Add(new MagicBook(location));
                    break;
                case ItemType.Key:
                    this.Add(new Key(location));
                    break;
                case ItemType.MagicKey:
                    this.Add(new MagicKey(location));
                    break;
                case ItemType.Compass:
                    this.Add(new Compass(location));
                    break;
            }
        }

        public ItemType Item { get; }
    }
}