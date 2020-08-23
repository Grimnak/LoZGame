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
                    Add(new Fairy(location));
                    break;
                case ItemType.Health:
                    Add(new Health(location));
                    break;
                case ItemType.Triforce:
                    Add(new Triforce(location));
                    break;
                case ItemType.HeartContainer:
                    Add(new HeartContainer(location));
                    break;
                case ItemType.Clock:
                    Add(new Clock(location));
                    break;
                case ItemType.Rupee:
                    Add(new Rupee(location));
                    break;
                case ItemType.LifePotion:
                    Add(new BluePotion(location));
                    break;
                case ItemType.SecondPotion:
                    Add(new RedPotion(location));
                    break;
                case ItemType.Letter:
                    Add(new Letter(location));
                    break;
                case ItemType.Map:
                    Add(new Map(location));
                    break;
                case ItemType.Food:
                    Add(new Food(location));
                    break;
                case ItemType.WoodenSword:
                    Add(new WoodenSword(location));
                    break;
                case ItemType.WhiteSword:
                    Add(new WhiteSword(location));
                    break;
                case ItemType.MagicSword:
                    Add(new MagicSword(location));
                    break;
                case ItemType.Bomb:
                    Add(new Bomb(location));
                    break;
                case ItemType.Boomerang:
                    Add(new Boomerang(location));
                    break;
                case ItemType.MagicBoomerang:
                    Add(new MagicBoomerang(location));
                    break;
                case ItemType.Arrow:
                    Add(new Arrow(location));
                    break;
                case ItemType.SilverArrow:
                    Add(new SilverArrow(location));
                    break;
                case ItemType.RedCandle:
                    Add(new RedCandle(location));
                    break;
                case ItemType.BlueCandle:
                    Add(new BlueCandle(location));
                    break;
                case ItemType.RedRing:
                    Add(new RedRing(location));
                    break;
                case ItemType.BlueRing:
                    Add(new BlueRing(location));
                    break;
                case ItemType.PowerBracelet:
                    Add(new PowerBracelet(location));
                    break;
                case ItemType.Flute:
                    Add(new Flute(location));
                    break;
                case ItemType.MagicRod:
                    Add(new MagicRod(location));
                    break;
                case ItemType.MagicBook:
                    Add(new MagicBook(location));
                    break;
                case ItemType.Key:
                    Add(new Key(location));
                    break;
                case ItemType.MagicKey:
                    Add(new MagicKey(location));
                    break;
                case ItemType.Compass:
                    Add(new Compass(location));
                    break;
            }
        }

        public ItemType Item { get; }
    }
}