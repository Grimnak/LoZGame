namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class DropManager
    {
        private const int dropChance = 50; // percent chance of drop (0 - 100)
        private const int blueRupeeWeight = 40;
        private const int yellowRupeeWeight = 20;
        private const int bombWeight = 20;
        private const int redPotionWeight = 10;
        private const int bluePotionWeight = 5;
        private const int healthWeight = 25;
        private const int clockWeight = 5;
        private const int fairyWeight = 10;

        public int DropChance => dropChance;

        public int BlueRupeeWeight => blueRupeeWeight;

        public int YellowRupeeWeight => yellowRupeeWeight;

        public int BombWeight => bombWeight;

        public int RedPotionWeight => redPotionWeight;

        public int BluePotionWeight => bluePotionWeight;

        public int HealthWeight => healthWeight;

        public int ClockWeight => clockWeight;

        public int FairyWeight => fairyWeight;

        public enum DropType
        {
            BlueRupee,
            YellowRupee,
            Bomb,
            RedPotion,
            BluePotion,
            Health,
            Clock,
            Fairy,
            None
        }

        private List<Tuple<DropType, int, int, int>> defaultTable = new List<Tuple<DropType, int, int, int>>()
        {
            Tuple.Create(DropType.BlueRupee, blueRupeeWeight, 1, 1),
            Tuple.Create(DropType.YellowRupee, yellowRupeeWeight, 1, 1),
            Tuple.Create(DropType.Bomb, bombWeight, 1, 4),
            Tuple.Create(DropType.RedPotion, redPotionWeight, 1, 1),
            Tuple.Create(DropType.BluePotion, bluePotionWeight, 1, 1),
            Tuple.Create(DropType.Health, healthWeight, 1, 1),
            Tuple.Create(DropType.Clock, clockWeight, 1, 1),
            Tuple.Create(DropType.Fairy, fairyWeight, 1, 1)
        };

        public void AttemptDrop(Vector2 loc, int dropChance, List<Tuple<DropType, int, int, int>> dropTable)
        {
            if (LoZGame.Instance.Random.Next(100) <= dropChance)
            {
                if (dropTable.Count > 0 && CanDropItem(dropChance))
                {
                    Tuple<DropType, int, int, int> item = DetermineDrop(dropTable);
                    DropItem(item.Item1, loc, LoZGame.Instance.Random.Next(item.Item3, item.Item4));
                }
            }
        }

        private void DropItem(DropType item, Vector2 loc, int amount)
        {
            switch (item)
            {
                case DropType.BlueRupee:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedRupee(loc));
                    break;
                case DropType.YellowRupee:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedYellowRupee(loc));
                    break;
                case DropType.Bomb:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedBomb(loc));
                    break;
                case DropType.RedPotion:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedPotion(loc));
                    break;
                case DropType.BluePotion:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedSecondPotion(loc));
                    break;
                case DropType.Health:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedHealth(loc));
                    break;
                case DropType.Fairy:
                    LoZGame.Instance.GameObjects.Items.Add(new Fairy(loc));
                    break;
                case DropType.Clock:
                    LoZGame.Instance.GameObjects.Items.Add(new Clock(loc));
                    break;
                default:
                    break;
            }
        }

        public void DropItemsEmptyRoom()
        {
            DropKey();
            DropBoomerang();
            DropMagicBoomerang();
            DropBomb();
            DropYellowRupee();
        }

        public void DropKey()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedKey != null)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedKey.Item1);
                if (!LoZGame.Instance.Dungeon.CurrentRoom.DroppedKey.Item2)
                {
                    SoundFactory.Instance.PlaySpecialItemAppears();
                }
                LoZGame.Instance.Dungeon.CurrentRoom.DroppedKey = Tuple.Create(LoZGame.Instance.Dungeon.CurrentRoom.DroppedKey.Item1, true);
            }
        }

        public void DropBoomerang()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedBoomerang != null)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedBoomerang.Item1);
                if (!LoZGame.Instance.Dungeon.CurrentRoom.DroppedBoomerang.Item2)
                {
                    SoundFactory.Instance.PlaySpecialItemAppears();
                }
                LoZGame.Instance.Dungeon.CurrentRoom.DroppedBoomerang = Tuple.Create(LoZGame.Instance.Dungeon.CurrentRoom.DroppedBoomerang.Item1, true);
            }
        }

        public void DropHeartContainer()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedHeartContainer != null)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedHeartContainer.Item1);
                if (!LoZGame.Instance.Dungeon.CurrentRoom.DroppedHeartContainer.Item2)
                {
                    SoundFactory.Instance.PlaySpecialItemAppears();
                }
                LoZGame.Instance.Dungeon.CurrentRoom.DroppedHeartContainer = Tuple.Create(LoZGame.Instance.Dungeon.CurrentRoom.DroppedHeartContainer.Item1, true);
            }
        }

        public void DropMagicBoomerang()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedMagicBoomerang != null)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedMagicBoomerang.Item1);
                if (!LoZGame.Instance.Dungeon.CurrentRoom.DroppedMagicBoomerang.Item2)
                {
                    SoundFactory.Instance.PlaySpecialItemAppears();
                }
                LoZGame.Instance.Dungeon.CurrentRoom.DroppedMagicBoomerang = Tuple.Create(LoZGame.Instance.Dungeon.CurrentRoom.DroppedMagicBoomerang.Item1, true);
            }
        }

        public void DropBomb()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedBomb != null)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedBomb.Item1);
                if (!LoZGame.Instance.Dungeon.CurrentRoom.DroppedBomb.Item2)
                {
                    SoundFactory.Instance.PlaySpecialItemAppears();
                }
                LoZGame.Instance.Dungeon.CurrentRoom.DroppedBomb = Tuple.Create(LoZGame.Instance.Dungeon.CurrentRoom.DroppedBomb.Item1, true);
            }
        }

        public void DropYellowRupee()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedYellowRupee != null)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedYellowRupee.Item1);
                if (!LoZGame.Instance.Dungeon.CurrentRoom.DroppedYellowRupee.Item2)
                {
                    SoundFactory.Instance.PlaySpecialItemAppears();
                }
                LoZGame.Instance.Dungeon.CurrentRoom.DroppedYellowRupee = Tuple.Create(LoZGame.Instance.Dungeon.CurrentRoom.DroppedYellowRupee.Item1, true);
            }
        }
    }
}