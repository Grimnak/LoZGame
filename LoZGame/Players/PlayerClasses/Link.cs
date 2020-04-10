namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;

    public class Link : PlayerEssentials, IPlayer
    {
        private PlayerCollisionHandler linkCollisionHandler;

        public Link(Vector2 location)
        {
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.PlayerData.Mass;
            this.Health = new HealthManager(GameData.Instance.PlayerData.StartingHealth);
            this.Inventory = new InventoryManager(this);
            this.linkCollisionHandler = new PlayerCollisionHandler(this);
            this.CurrentColor = "Green";
            this.Physics.CurrentDirection = Physics.Direction.North;
            this.CurrentWeapon = "Wood";
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.MoveSpeed = GameData.Instance.PlayerData.PlayerSpeed;
            this.DamageTimer = 0;
            this.State = new IdleState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.linkCollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.linkCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.linkCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IDoor)
            {
                this.linkCollisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
            else if (otherCollider is IItem)
            {
                this.linkCollisionHandler.OnCollisionResponse((IItem)otherCollider, collisionSide);
            }

        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.linkCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }
    }
}
