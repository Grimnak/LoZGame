namespace LoZClone
{
    public partial class InventoryManager
    {
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
                if (!LoZGame.Cheats)
                {
                    this.numBombs--;
                }
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Bomb, this.player);
            }
        }

        public void UseArrow()
        {
            if (this.numRupees > 0 && this.hasBow)
            {
                if (!LoZGame.Cheats)
                {
                    this.numRupees--;
                }
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Arrow, this.player);
            }
        }

        public void UseBoomerang()
        {
            if (!LoZGame.Instance.GameObjects.Entities.ProjectileManager.BoomerangOut && this.hasBoomerang)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Boomerang, this.player);
            }
        }

        public void UseMagicBoomerang()
        {
            if (!LoZGame.Instance.GameObjects.Entities.ProjectileManager.BoomerangOut && this.hasMagicBoomerang)
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
            if (!LoZGame.Instance.GameObjects.Entities.ProjectileManager.FlameInUse && this.HasBlueFlame)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.BlueCandle, this.player);
            }
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
    }
}
