﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;

    public class Link : PlayerEssentials, IPlayer
    {
        private PlayerCollisionHandler linkCollisionHandler;
        private int startingHealth = 12;
        private bool hasKey;

        public bool HasKey
        {
            get { return hasKey; }
            set { this.hasKey = value; }
        }

        public Link(Vector2 location)
        {
            this.Physics = new Physics(location);
            this.Health = new HealthManager(startingHealth);
            this.linkCollisionHandler = new PlayerCollisionHandler(this);
            this.CurrentColor = "Green";
            this.Physics.CurrentDirection = Physics.Direction.North;
            this.CurrentWeapon = "Wood";
            this.CurrentTint = LoZGame.Instance.DungeonTint;
            this.MoveSpeed = 2.5f;
            this.AnimationSpeed = 5;
            this.FrameDelay = 0;
            this.DamageTimer = 0;
            this.State = new IdleState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
            this.HasKey = false;
        }

        public void Update()
        {
            this.Physics.SetDepth();
            this.HandleDamage();
            this.Physics.Move();
            this.State.Update();
        }

        public void Draw()
        {
            this.State.Draw();
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