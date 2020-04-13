namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class DropManager
    {
        private const int DropChance = 20; // percent chance of drop (0 - 100)
        private const int RupeeWeight = 40;
        private const int YellowRupeeWeight = 20;
        private const int BombWeight = 20;
        private const int PotionWeight = 10;
        private const int SecondPotionWeight = 5;
        private const int HealthWeight = 25;
        private const int FairyWeight = 5;

        private Dictionary<string, int> itemWeights;

        private int totalWeight;

        public DropManager()
        {
            itemWeights = new Dictionary<string, int>();
            itemWeights.Add("Rupee", RupeeWeight);
            itemWeights.Add("YellowRupee", YellowRupeeWeight);
            itemWeights.Add("Bomb", BombWeight);
            itemWeights.Add("Potion", PotionWeight);
            itemWeights.Add("SecondPotion", SecondPotionWeight);
            itemWeights.Add("Health", HealthWeight);
            itemWeights.Add("Fairy", FairyWeight);
            totalWeight = 0;
            foreach (KeyValuePair<string, int> weight in itemWeights)
            {
                totalWeight += weight.Value;
            }
        }

        private bool CanDropItem()
        {
            return LoZGame.Instance.Random.Next(0, 100) <= DropChance;
        }

        private string DetermineDrop()
        {
            int randomWeight = LoZGame.Instance.Random.Next(0, totalWeight);
            int checkedWeight = 0;
            string item = "None";
            foreach (KeyValuePair<string, int> weight in itemWeights)
            {
                if (randomWeight < checkedWeight + weight.Value)
                {
                    item = weight.Key;
                    break;
                }
                else
                {
                    checkedWeight += weight.Value;
                }
            }

            return item;
        }

        private void DropItem(string item, Vector2 loc)
        {
            switch (item)
            {
                case "Rupee":
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedRupee(loc));
                    break;
                case "YellowRupee":
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedYellowRupee(loc));
                    break;
                case "Bomb":
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedBomb(loc));
                    break;
                case "Potion":
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedPotion(loc));
                    break;
                case "SecondPotion":
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedSecondPotion(loc));
                    break;
                case "Health":
                    LoZGame.Instance.GameObjects.Items.Add(new DroppedHealth(loc));
                    break;
                case "Fairy":
                    LoZGame.Instance.GameObjects.Items.Add(new Fairy(loc));
                    break;
                default:
                    break;
            }
        }

        public void AttemptDrop(Vector2 loc)
        {
             if (this.CanDropItem())
            {
                string item = this.DetermineDrop();
                this.DropItem(item, loc);
            }
        }

        public void DropKey()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedKey != null && LoZGame.Instance.GameObjects.Enemies.EnemyList.Count <= 1)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedKey);
                SoundFactory.Instance.PlayKeyAppears();
            }
        }

        public void DropBoomerang()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedBoomerang != null && LoZGame.Instance.GameObjects.Enemies.EnemyList.Count <= 1)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedBoomerang);
            }
        }

        public void DropHeartContainer()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.DroppedHeartContainer != null && LoZGame.Instance.GameObjects.Enemies.EnemyList.Count <= 1)
            {
                LoZGame.Instance.GameObjects.Items.Add(LoZGame.Instance.Dungeon.CurrentRoom.DroppedHeartContainer);
            }
        }

        public void DropMagicKey(Vector2 loc) { LoZGame.Instance.GameObjects.Items.Add(new MagicKey(loc)); }
    }
}
