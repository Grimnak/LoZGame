
namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class DropManager
    {
        private const int DropChance = 100; // percent chance of drop (0 - 100)
        private const int RupeeWeight = 40;
        private const int YellowRupeeWeight = 10;
        private const int BombWeight = 20;
        private const int FoodWeight = 10;
        private const int PotionWeight = 4;
        private const int SecondPotionWeight = 1;
        private const int HealthWeight = 6;
        private const int FairyWeight = 4;

        private Dictionary<string, int> itemWeights;

        private int totalWeight;

        public DropManager()
        {
            itemWeights = new Dictionary<string, int>();
            itemWeights.Add("Rupee", RupeeWeight);
            itemWeights.Add("YellowRupee", YellowRupeeWeight);
            itemWeights.Add("Bomb", BombWeight);
            itemWeights.Add("Food", FoodWeight);
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
                } else
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
                    LoZGame.Instance.Items.Add(new DroppedRupee(loc));
                    break;
                case "YellowRupee":
                    LoZGame.Instance.Items.Add(new DroppedYellowRupee(loc));
                    break;
                case "Bomb":
                    LoZGame.Instance.Items.Add(new DroppedBomb(loc));
                    break;
                case "Food":
                    LoZGame.Instance.Items.Add(new DroppedFood(loc));
                    break;
                case "Potion":
                    LoZGame.Instance.Items.Add(new DroppedPotion(loc));
                    break;
                case "SecondPotion":
                    LoZGame.Instance.Items.Add(new DroppedSecondPotion(loc));
                    break;
                case "Health":
                    LoZGame.Instance.Items.Add(new DroppedHealth(loc));
                    break;
                case "Fairy":
                    LoZGame.Instance.Items.Add(new Fairy(loc));
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

        public void DropKey(Vector2 loc) { LoZGame.Instance.Items.Add(new Key(loc)); }

        public void DropMagicKey(Vector2 loc) { LoZGame.Instance.Items.Add(new MagicKey(loc)); }
    }
}
