namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GleeokNeck : EnemyEssentials, IEnemy
    {
        private IEnemy parent;

        public GleeokNeck(IEnemy body)
        {
            parent = body;
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ManhandlaHeadStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.GleeokNeckHealth);
            Physics = new Physics(body.Physics.Bounds.Center.ToVector2());
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.IsMovable = false;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = 0;
            DamageTimer = 0;
            MoveSpeed = 0;
            CurrentTint = LoZGame.Instance.DefaultTint;
            IsBossPart = true;
            HasChild = true;
            AI = EnemyAI.NoAI;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            IsTransparent = true;
            ApplyDamageMod();
            ApplyLargeWeightModPos();
            ApplyLargeHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // ignore collisions
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            // ignore obstacles
        }

        public override void Update()
        {
            // Ensure enemy colors correctly correspond with their room's current color tint and continue to adjust their colors accordingly.
            if (LoZGame.Instance.Dungeon.CurrentRoom.IsDark)
            {
                if (LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint == Color.Black)
                {
                    CurrentTint = Color.Black;
                }
                else if (LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint == LoZGame.Instance.DungeonTint)
                {
                    CurrentTint = Color.White;
                }
                else
                {
                    CurrentTint = LoZGame.Instance.DefaultTint;
                }
            }
            else
            {
                CurrentTint = Color.White;
            }

            if (parent.IsDead)
            {
                Expired = true;
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeokNeckSprite();
        }
    }
}