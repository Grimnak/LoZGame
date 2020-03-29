namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public abstract class EnemyEssentials
    {
        public EnemyCollisionHandler EnemyCollisionHandler { get; set; }

        public RandomStateGenerator RandomStateGenerator { get; set; }

        public IEnemyState CurrentState { get; set; }

        public bool Expired { get; set; }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public Color CurrentTint { get; set; }

        public float MoveSpeed { get; set; }

        public int Damage { get; set; }

        public int DamageTimer { get; set; }

        public virtual void Stun(int stunTime)
        {
        }

        public Vector2 UnitVectorToPlayer(Vector2 origin)
        {
            Vector2 difference = new Vector2(LoZGame.Instance.Link.Physics.Location.X - origin.X, LoZGame.Instance.Link.Physics.Location.Y - origin.Y);
            float magnitude = (float)Math.Sqrt(Math.Pow(difference.X, 2) + Math.Pow(difference.Y, 2));
            return new Vector2(difference.X / magnitude, difference.Y / magnitude);
        }

        public Vector2 RotateVector(Vector2 oldVector, float rot)
        {
            float cosRot = (float)Math.Cos(rot);
            float sinRot = (float)Math.Sin(rot);
            float newX = (cosRot * oldVector.X) - (sinRot * oldVector.Y);
            float newY = (sinRot * oldVector.X) + (cosRot * oldVector.Y);
            return new Vector2(newX, newY);
        }

        public virtual void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = 50;
            }
            if (this.Health.CurrentHealth <= 0)
            {
                this.CurrentState.Die();
            }
        }

        public void HandleDamage()
        {
            if (this.DamageTimer > 0 && this.Health.CurrentHealth > 0)
            {
                this.DamageTimer--;
                if (this.DamageTimer % 10 > 5)
                {
                    this.CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.CurrentTint = LoZGame.Instance.DungeonTint;
                }
            } else
            {
                this.Physics.StopKnockback();
            }
        }

        public virtual void Update()
        {
            this.HandleDamage();
            this.Physics.Move();
            this.CurrentState.Update();
        }

        public virtual void Draw()
        {
            this.CurrentState.Draw();
        }

        public virtual void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            EnemyCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }
    }
}