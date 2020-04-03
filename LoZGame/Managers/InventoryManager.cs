using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class InventoryManager
    {
        private static readonly int maxBombs = 8;

        private IPlayer player;

        private int numBombs;
        private int numRupees;
        private int numKeys;
        private bool hasBoomerang;
        private bool hasMagicBoomerang;
        private bool hasBow;
        private bool hasSilverArrow;
        private bool hasRedFlame;
        private bool hasBlueFlame;

        public InventoryManager(IPlayer player)
        {
            this.player = player;

            this.numBombs = 4;
            this.numKeys = 0;
            this.numRupees = 5;
            this.hasBoomerang = false;
            this.hasMagicBoomerang = false;
            this.hasBow = false;
            this.hasSilverArrow = false;
            this.hasRedFlame = false;
            this.hasBlueFlame = false;
        }

        public void GainRupees(int amount)
        {
            this.numRupees += amount;
        }

        public void GainBombs()
        {
            int temp = this.numBombs + 2;
            if (temp > maxBombs)
            {
                numBombs = maxBombs;
            }
            else
            {
                numBombs = temp;
            }
        }

        public void GainKey()
        {
            this.numKeys++;
        }

        public bool HasKey()
        {
            return this.numKeys > 0;
        }

        public void UseKey()
        {
            if (this.numKeys > 0)
            {
                this.numKeys--;
            }
        }

        public void UseBomb()
        {
            if (this.numBombs > 0)
            {
                this.numBombs--;
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Bomb, this.player);
            }
        }

        public void UseArrow()
        {
            if (this.numRupees > 0 && this.hasBow)
            {
                this.numRupees--;
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Arrow, this.player);
            }
        }

        public void UseBoomerang()
        {
            if (this.hasBoomerang)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Boomerang, this.player);
            }
        }

        public void UseMagicBoomerang()
        {
            if (this.hasMagicBoomerang)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.MagicBoomerang, this.player);
            }
        }

        public void UseSilverArrow()
        {
            if (this.numRupees > 0 && this.hasBow && this.hasSilverArrow)
            {
                this.numRupees--;
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.SilverArrow, this.player);
            }
        }

        public void UseRedCandle()
        {
            if (this.hasRedFlame)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.RedCandle, this.player);
            }
        }

        public void UseBlueCandle()
        {
            if (this.HasBlueFlame)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.BlueCandle, this.player);
            }
        }

        public int Rupees { get { return this.numRupees; } }

        public int Bombs { get { return this.numBombs; } }

        public int Keys { get { return this.numKeys; } }

        public bool HasBow { get { return this.hasBow; } set { this.hasBow = value; } }

        public bool HasBoomerang { get { return this.hasBoomerang; } set { this.hasBoomerang = value; } }

        public bool HasMagicBoomerang { get { return this.hasMagicBoomerang; } set { this.hasMagicBoomerang = value; } }

        public bool HasSilverArrow { get { return this.hasSilverArrow; } set { this.hasSilverArrow = value; } }

        public bool HasBlueFlame { get { return this.hasBlueFlame; } set { this.hasBlueFlame = value; } }

        public bool HasRedFlame { get { return this.hasRedFlame; } set { this.hasRedFlame = value; } }

    }
}
