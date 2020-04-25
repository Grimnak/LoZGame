﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public partial class Link
    {
        public IPlayerState State { get; set; }

        public LinkWeapon CurrentWeapon { get; set; }

        public LinkColor CurrentColor { get; set; }

        public Color CurrentTint { get; set; }

        public int LadderTimer { get; set; }

        public float MoveSpeed { get; set; }

        public int DamageTimer { get; set; }

        public int DisarmedTimer { get; set; }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public InventoryManager Inventory { get; set; }

        public InventoryManager BackupInventory { get; set; }

        public void TakeDamage(int damageAmount)
        {
            if (DamageTimer <= 0)
            {
                if (!LoZGame.Cheats)
                {
                    Health.DamageHealth(damageAmount);
                }
                else
                {
                    Health.CurrentHealth = Health.MaxHealth;
                }
                if (damageAmount > 0)
                {
                    SoundFactory.Instance.PlayLinkHurt();
                    DamageTimer = LoZGame.Instance.UpdateSpeed;
                }
            }
            if (Health.CurrentHealth <= 0)
            {
                SoundFactory.Instance.StopDungeonSong();
                SoundFactory.Instance.PlayLinkDie();
                State.Die();
                LoZGame.Instance.GameState.Death();
            }
        }

        public void HandleDamage()
        {
            if (DamageTimer > 0 && Health.CurrentHealth > 0)
            {
                DamageTimer--;
                if (DamageTimer % 10 > 5)
                {
                    CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    CurrentTint = LoZGame.Instance.DefaultTint;
                }
                Physics.HandleKnockBack();
            }
        }

        public void HandleDisarm()
        {
            if (DisarmedTimer > 0)
            {
                DisarmedTimer--;
            }
        }

        public void HandleLadder()
        {
            if (LadderTimer > 0)
            {
                LadderTimer--;
            }
        }

        public void Idle()
        {
            State.Idle();
        }

        public void MoveUp()
        {
            State.MoveUp();
        }

        public void MoveDown()
        {
            State.MoveDown();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
        }

        public void Attack()
        {
            State.Attack();
        }

        public void PickupItem(IItem item)
        {
            State.PickupItem(item);
        }

        public void UseItem(int waitTime)
        {
            State.UseItem(waitTime);
        }

        public void Stun(int stunTime)
        {
            State.Stun(stunTime);
        }

        public void Update()
        {
            Physics.SetDepth();
            HandleDamage();
            HandleDisarm();
            HandleLadder();
            Physics.Move();
            State.Update();
        }

        public void Draw()
        {
            State.Draw();
        }
    }
}