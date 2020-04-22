namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class DropManager
    {
        private const int DropChance = 35; // percent chance of drop (0 - 100)
        private const int RupeeWeight = 40;
        private const int YellowRupeeWeight = 20;
        private const int BombWeight = 20;
        private const int PotionWeight = 10;
        private const int SecondPotionWeight = 5;
        private const int HealthWeight = 25;
        private const int ClockWeight = 5;
        private const int FairyWeight = 10;

        public enum DropType
        {
            Rupee,
            YellowRupee,
            Bomb,
            Potion,
            SecondPotion,
            Health,
            Clock,
            Fairy,
            None
        }

        private List<Tuple<DropType, int, int, int>> defaultTable = new List<Tuple<DropType, int, int, int>>()
        {
            Tuple.Create(DropType.Rupee, RupeeWeight, 1, 1),
            Tuple.Create(DropType.YellowRupee, YellowRupeeWeight, 1, 1),
            Tuple.Create(DropType.Bomb, BombWeight, 1, 4),
            Tuple.Create(DropType.Potion, PotionWeight, 1, 1),
            Tuple.Create(DropType.SecondPotion, SecondPotionWeight, 1, 1),
            Tuple.Create(DropType.Health, HealthWeight, 1, 1),
            Tuple.Create(DropType.Clock, ClockWeight, 1, 1),
            Tuple.Create(DropType.Fairy, FairyWeight, 1, 1)
        };

        public void AttemptDrop(Vector2 loc, int dropChance = DropChance, List<Tuple<DropType, int, int, int>> dropTable = null)
        {
            if (LoZGame.Instance.Random.Next(100) <= dropChance)
            {
                if (dropTable is null)
                {
                    dropTable = defaultTable;
                }
                if (this.CanDropItem())
                {
                    Tuple<DropType, int, int, int> item = this.DetermineDrop(dropTable);
                    this.DropItem(item.Item1, loc, LoZGame.Instance.Random.Next(item.Item3, item.Item4));
                }
            }
        }

        private void DropItem(DropType item, Vector2 loc, int amount)
        {
            switch (item)
            {
                case DropType.Rupee:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedRupee(loc));
                    break;
                case DropType.YellowRupee:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedYellowRupee(loc));
                    break;
                case DropType.Bomb:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedBomb(loc));
                    break;
                case DropType.Potion:
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedPotion(loc));
                    break;
                case DropType.SecondPotion:
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

        public void DropMagicKey(Vector2 loc) { LoZGame.Instance.GameObjects.Items.Add(new MagicKey(loc)); }
    }
}
