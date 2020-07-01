namespace LoZClone
{
    public partial class InventoryManager
    {
        public void UseKey()
        {
            if (numKeys > 0)
            {
                numKeys--;
            }
        }

        public void UseBomb()
        {
            if ((numBombs > 0) || LoZGame.Cheats)
            {
                if (!LoZGame.Cheats && !(player.State is UseItemState))
                {
                    numBombs--;
                }
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Bomb, player);
            }
        }

        public void UseArrow()
        {
            if ((numRupees > 0 && hasBow) || LoZGame.Cheats)
            {
                if (!LoZGame.Cheats && !(player.State is UseItemState))
                {
                    numRupees--;
                }
                if (hasSilverArrow || LoZGame.Cheats)
                {
                    player.UseItem(ProjectileManager.MaxWaitTime);
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.SilverArrow, player);
                } 
                else if (hasArrow || LoZGame.Cheats)
                {
                    player.UseItem(ProjectileManager.MaxWaitTime);
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Arrow, player);
                }
            }
        }

        public void UseBoomerang()
        {
            if (!LoZGame.Instance.GameObjects.Entities.ProjectileManager.BoomerangOut)
            {
                if (hasMagicBoomerang || LoZGame.Cheats)
                {
                    player.UseItem(ProjectileManager.MaxWaitTime);
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.MagicBoomerang, player);
                }
                else if (hasBoomerang || LoZGame.Cheats)
                {
                    player.UseItem(ProjectileManager.MaxWaitTime);
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Boomerang, player);
                }
            }
        }

        public void UseCandle()
        {
            if ((hasRedFlame || LoZGame.Cheats) && !LoZGame.Instance.GameObjects.Entities.ProjectileManager.CandleLock)
            {
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.RedCandle, player);
            }
            else if ((hasBlueFlame || LoZGame.Cheats) && !LoZGame.Instance.GameObjects.Entities.ProjectileManager.CandleLock)
            {
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.BlueCandle, player);
            }
        }

        public void UsePotion()
        {
            if (numRedPotions > 0 || LoZGame.Cheats)
            {
                if (!LoZGame.Cheats && (LoZGame.Instance.Players[0].Health.CurrentHealth != LoZGame.Instance.Players[0].Health.MaxHealth))
                {
                    numRedPotions--;
                    numBluePotions++;
                }
                LoZGame.Instance.GameState.RestoreHealth();
            }
            else if (numBluePotions > 0 || LoZGame.Cheats)
            {
                if (!LoZGame.Cheats && (LoZGame.Instance.Players[0].Health.CurrentHealth != LoZGame.Instance.Players[0].Health.MaxHealth))
                {
                    numBluePotions--;
                }
                LoZGame.Instance.GameState.RestoreHealth();
            }
        }

        public void UseFlute()
        {
            if ((hasFlute || LoZGame.Cheats) && LoZGame.Instance.GameState is PlayGameState)
            {
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameState = new FluteGameState();
            }
        }

        public void UseRod()
        {
            if ((hasRod || LoZGame.Cheats) && !LoZGame.Instance.GameObjects.Entities.ProjectileManager.BeamLock)
            {
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.SonicBeam, player);
            }
        }

        public void GainRupees(int amount)
        {
            numRupees += amount;
        }

        public void GainBombs()
        {
            int temp = numBombs + 4;
            if (temp > maxBombs)
            {
                numBombs = maxBombs;
            }
            else
            {
                numBombs = temp;
            }
        }

        public void PurchaseBombs()
        {
            SoundFactory.Instance.PlayGetItem();
            player.Inventory.Rupees -= 50;
            player.Inventory.MaxBombs += 4;
            player.Inventory.GainBombs();
        }

        public void GainRedPotion()
        {
            numRedPotions++;
        }

        public void GainBluePotion()
        {
            numBluePotions++;
        }

        public void GainKey()
        {
            numKeys++;
        }

        public void MoveSelectionDown()
        {
            if (selectionY + 1 < maxSelectionY)
            {
                selectionY++;
                SelectItem();
            }
        }

        public void MoveSelectionUp()
        {
            if (selectionY > 0)
            {
                selectionY--;
                SelectItem();
            }
        }

        public void MoveSelectionLeft()
        {
            if (selectionX > 0)
            {
                selectionX--;
                SelectItem();
            }
        }

        public void MoveSelectionRight()
        {
            if (selectionX + 1 < maxSelectionX)
            {
                selectionX++;
                SelectItem();
            }
        }
    }
}
