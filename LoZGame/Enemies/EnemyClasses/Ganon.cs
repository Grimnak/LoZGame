namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Ganon : EnemyEssentials, IEnemy
    {
        private int visibilityTimer;

        public int VisibilityTimer { get { return visibilityTimer; } set { visibilityTimer = value; } }

        public Ganon(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GanonTeleportingStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.GanonHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.GanonMass;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Physics.IsMovable = false;
            visibilityTimer = LoZGame.Instance.UpdateSpeed;
            Damage = GameData.Instance.EnemyDamageConstants.GanonDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.GanonSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
            ApplyLargeHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            CurrentState = new AttackingGanonState(this);
        }

        public override void HandleDamage()
        {
            if (DamageTimer > 0 && Health.CurrentHealth > 4)
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
            }
        }

        public override void TakeDamage(int damageAmount)
        {
            if (DamageTimer <= 0)
            {
                Health.DamageHealth(damageAmount);
                if (damageAmount > 0)
                {
                    SoundFactory.Instance.PlayEnemyHit();
                    DamageTimer = LoZGame.Instance.UpdateSpeed;
                    visibilityTimer = LoZGame.Instance.UpdateSpeed;
                }
            }
            if (Health.CurrentHealth <= 4 && Health.CurrentHealth > 0)
            {
                DamageTimer = 0;
                visibilityTimer = 0;
                States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GanonParalyzedStateList);
            }
            else if (Health.CurrentHealth <= 0)
            {
                SoundFactory.Instance.PlayBossDie();
                LoZGame.Instance.Dungeon.DefeatedBoss = true;
                IsDead = true;
                CurrentState.Die();
            }
        }

        public override void Update()
        {
            HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || IsSpawning || IsDead)
            {
                CurrentState.Update();
                Physics.Move();
                Physics.SetDepth();
            }

            // If Ganon is in phase 1 and has recently been hit, make him visible to the player and decrement the visibility timer.
            if (Health.CurrentHealth > 4 && visibilityTimer > 0)
            {
                IsInvisible = false;
                visibilityTimer--;
            }
            // If Ganon is in phase 1 and the visibility timer reaches zero, make him invisible to the player once again.
            else if (Health.CurrentHealth > 4 && visibilityTimer == 0)
            {
                IsInvisible = true;
                visibilityTimer--;
            }
            // As soon as Ganon regains invisibility, teleport him to a new location to avoid the player combining sword strikes onto him.
            else if (Health.CurrentHealth > 4 && visibilityTimer == -1)
            {
                CurrentState = new TeleportEnemyState(this);
                visibilityTimer--;
            }
            // If Ganon is still in phase 1 and not being hit, ensure he remains invisible while not decrementing the visibility counter to infinity.
            else if (Health.CurrentHealth > 4 && visibilityTimer < -1)
            {
                IsInvisible = true;
            }
            // If Ganon is paralyzed in phase 2, he is always visible to the player.
            else
            {
                IsInvisible = false;
            }
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            if (Health.CurrentHealth > 4)
            {
                return EnemySpriteFactory.Instance.CreateGanonVisibleSprite();
            }
            else
            {
                return EnemySpriteFactory.Instance.CreateGanonParalyzedSprite();
            }
        }
    }
}