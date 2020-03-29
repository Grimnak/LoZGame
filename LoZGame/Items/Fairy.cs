﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Fairy : IItem
    {
        private const int DirectionChange = 100;
        private static readonly int DespawnTimer = 60 * LoZGame.Instance.UpdateSpeed;
        private ISprite sprite;
        private ItemCollisionHandler itemCollisionHandler;
        private readonly Texture2D Texture;      // the texture to pull frames from
        private Vector2 Size;
        private float layer;
        private int lifeTime;
        private Vector2 Border;
        private bool expired;
        private int pickUpItemTime = -1;

        public int PickUpItemTime { get { return this.pickUpItemTime; } }

        public bool Expired { get { return this.expired; } set { this.expired = value; } }

        public Physics Physics { get; set; }

        

        private enum Direction
        {
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest,
        }

        private Direction currentDirection;

        public Fairy(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.Fairy(ItemSpriteFactory.Instance.Scale);
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc);
            this.Size = new Vector2(ItemSpriteFactory.FairyWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.FairyHeight * ItemSpriteFactory.Instance.Scale);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.Border = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width, LoZGame.Instance.GraphicsDevice.Viewport.Height);
            this.lifeTime = 0;
            this.expired = false;
            this.GetNewDirection();
        }

        private void GetNewDirection()
        {
            Random randomselect = LoZGame.Instance.Random;
            this.currentDirection = (Direction)randomselect.Next(0, 8);
            switch (this.currentDirection)
            {
                case Direction.North:
                    this.Physics.MovementVelocity = new Vector2(0, -1);
                    break;

                case Direction.South:
                    this.Physics.MovementVelocity = new Vector2(0, 1);
                    break;

                case Direction.East:
                    this.Physics.MovementVelocity = new Vector2(1, 0);
                    break;

                case Direction.West:
                    this.Physics.MovementVelocity = new Vector2(-1, 0);
                    break;

                case Direction.NorthEast:
                    this.Physics.MovementVelocity = new Vector2(0.727f, -0.727f);
                    break;

                case Direction.NorthWest:
                    this.Physics.MovementVelocity = new Vector2(-0.727f, -0.727f);
                    break;

                case Direction.SouthEast:
                    this.Physics.MovementVelocity = new Vector2(0.727f, 0.727f);
                    break;

                case Direction.SouthWest:
                    this.Physics.MovementVelocity = new Vector2(-0.727f, 0.727f);
                    break;

                default:
                    break;
            }
        }

        private void UpdateLoc()
        {
            this.Physics.Move();
            this.CheckBorder();
        }

        private void CheckBorder()
        {
            if (this.Physics.Location.Y < this.Size.Y)
            {
                this.Physics.Location = new Vector2(this.Physics.Location.X, this.Size.Y);
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Physics.Location.Y > this.Border.Y - this.Size.Y)
            {
                this.Physics.Location = new Vector2(this.Physics.Location.X, this.Border.Y - this.Size.Y);
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Physics.Location.X < this.Size.X)
            {
                this.Physics.Location = new Vector2(this.Size.X, this.Physics.Location.Y);
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Physics.Location.X > this.Border.X - this.Size.X)
            {
                this.Physics.Location = new Vector2(this.Border.X - this.Size.X, this.Physics.Location.Y);
                this.lifeTime = DirectionChange + 1;
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                itemCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            itemCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime % DirectionChange == 0)
            {
                this.GetNewDirection();
            }
            if (this.lifeTime > DespawnTimer)
            {
                this.expired = true;
            }
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.UpdateLoc();
            this.sprite.Update();
        }

        public void Draw(Color spriteTint)
        {
            this.sprite.Draw(this.Physics.Location, spriteTint);
        }
    }
}