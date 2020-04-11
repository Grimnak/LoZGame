namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class Keese : EnemyEssentials, IEnemy
    {
        public Keese(Vector2 location)
        {
            Console.WriteLine("Keese: Started Construction");
            this.Physics = new Physics(location);
            this.CurrentState = new IdleDragonState(this);
            this.States = GameData.Instance.DefaultEnemyStates.DragonStatelist;
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.KeeseHealth);
            this.Physics.Mass = GameData.Instance.EnemyMassData.KeeseMass;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.KeeseDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.MinKeeseSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            Console.WriteLine("Keese: Ended Construction");
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override ISprite CreateCorrectSprite()
        {
            Console.WriteLine("Keese: Created Correct Sprite");
            return EnemySpriteFactory.Instance.CreateKeeseSprite();
        }
    }
}