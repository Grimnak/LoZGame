﻿namespace LoZClone
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
            if (numBombs > 0)
            {
                if (!LoZGame.Cheats)
                {
                    numBombs--;
                }
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Bomb, player);
            }
        }

        public void UseArrow()
        {
            if (numRupees > 0 && hasBow)
            {
                if (!LoZGame.Cheats && !(player.State is UseItemState))
                {
                    numRupees--;
                }
                player.UseItem(ProjectileManager.MaxWaitTime);
                if (hasSilverArrow)
                {
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.SilverArrow, player);
                } 
                else if (hasArrow)
                {
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Arrow, player);
                }
            }
        }

        public void UseBoomerang()
        {
            if (!LoZGame.Instance.GameObjects.Entities.ProjectileManager.BoomerangOut)
            {
                player.UseItem(ProjectileManager.MaxWaitTime);
                if (hasMagicBoomerang)
                {
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.MagicBoomerang, player);
                }
                else if (hasBoomerang)
                {
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Boomerang, player);
                }
            }
        }

        public void UseCandle()
        {
            if (hasRedFlame)
            {
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.RedCandle, player);
            } 
            else if (!LoZGame.Instance.GameObjects.Entities.ProjectileManager.FlameInUse && HasBlueFlame)
            {
                player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.BlueCandle, player);
            }
        }

        public void UsePotion()
        {
            if (numBluePotions > 0)
            {
                numBluePotions--;
                numRedPotions++;
                LoZGame.Instance.Players[0].Health.CurrentHealth = LoZGame.Instance.Players[0].Health.MaxHealth;
            }
            else if (numRedPotions > 0)
            {
                numRedPotions--;
                LoZGame.Instance.Players[0].Health.CurrentHealth = LoZGame.Instance.Players[0].Health.MaxHealth;
            }
        }

        public void UseFlute()
        {
            if (hasFlute && LoZGame.Instance.GameState is PlayGameState)
            {
                player.UseItem(1);
                LoZGame.Instance.GameState = new FluteGameState();
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
