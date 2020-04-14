namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Fairy : ItemEssentials, IItem
    {
        private const int DirectionChange = 100;
        private static readonly int DespawnTimer = 60 * LoZGame.Instance.UpdateSpeed;
        private static readonly int SpawnTimer = LoZGame.Instance.UpdateSpeed * 1;

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
            this.Sprite = ItemSpriteFactory.Instance.Fairy();
            this.FrameDelay = 5;
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc);
            this.PickUpItemTime = -1;
            this.LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)size.X, (int)size.Y);
            this.Expired = false;
            this.GetNewDirection();
        }

        private void GetNewDirection()
        {
            Random randomselect = LoZGame.Instance.Random;
            this.currentDirection = (Direction)randomselect.Next(0, 8);
            switch (this.currentDirection)
            {
                case Direction.North:
                    this.Physics.MovementVelocity = new Vector2(0, -2);
                    break;

                case Direction.South:
                    this.Physics.MovementVelocity = new Vector2(0, 2);
                    break;

                case Direction.East:
                    this.Physics.MovementVelocity = new Vector2(2, 0);
                    break;

                case Direction.West:
                    this.Physics.MovementVelocity = new Vector2(-2, 0);
                    break;

                case Direction.NorthEast:
                    this.Physics.MovementVelocity = new Vector2(1.454f, -1.454f);
                    break;

                case Direction.NorthWest:
                    this.Physics.MovementVelocity = new Vector2(-1.454f, -1.454f);
                    break;

                case Direction.SouthEast:
                    this.Physics.MovementVelocity = new Vector2(1.454f, 1.454f);
                    break;

                case Direction.SouthWest:
                    this.Physics.MovementVelocity = new Vector2(-1.454f, 1.454f);
                    break;

                default:
                    break;
            }
        }

        public override void Update()
        {
            base.Update();
            if (this.LifeTime % DirectionChange == 0)
            {
                this.GetNewDirection();
            }
            if (this.LifeTime > DespawnTimer)
            {
                this.Expired = true;
            }
        }

        public override void Draw(Color spriteTint)
        {
            if ((this.LifeTime > SpawnTimer && this.LifeTime < (DespawnTimer - (4 * SpawnTimer))) || this.LifeTime % 4 < 2)
            {
                base.Draw(spriteTint);
            }
        }
    }
}