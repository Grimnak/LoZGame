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
            Sprite = ItemSpriteFactory.Instance.Fairy();
            FrameDelay = 5;
            itemCollisionHandler = new ItemCollisionHandler(this);
            Physics = new Physics(loc);
            PickUpItemTime = -1;
            LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)size.X, (int)size.Y);
            Expired = false;
            GetNewDirection();
        }

        private void GetNewDirection()
        {
            Random randomselect = LoZGame.Instance.Random;
            currentDirection = (Direction)randomselect.Next(0, 8);
            switch (currentDirection)
            {
                case Direction.North:
                    Physics.MovementVelocity = new Vector2(0, -2);
                    break;

                case Direction.South:
                    Physics.MovementVelocity = new Vector2(0, 2);
                    break;

                case Direction.East:
                    Physics.MovementVelocity = new Vector2(2, 0);
                    break;

                case Direction.West:
                    Physics.MovementVelocity = new Vector2(-2, 0);
                    break;

                case Direction.NorthEast:
                    Physics.MovementVelocity = new Vector2(1.454f, -1.454f);
                    break;

                case Direction.NorthWest:
                    Physics.MovementVelocity = new Vector2(-1.454f, -1.454f);
                    break;

                case Direction.SouthEast:
                    Physics.MovementVelocity = new Vector2(1.454f, 1.454f);
                    break;

                case Direction.SouthWest:
                    Physics.MovementVelocity = new Vector2(-1.454f, 1.454f);
                    break;

                default:
                    break;
            }
        }

        public override void Update()
        {
            base.Update();
            if (LifeTime % DirectionChange == 0)
            {
                GetNewDirection();
            }
            if (LifeTime > DespawnTimer)
            {
                Expired = true;
            }
        }

        public override void Draw(Color spriteTint)
        {
            if ((LifeTime > SpawnTimer && LifeTime < (DespawnTimer - (4 * SpawnTimer))) || LifeTime % 4 < 2)
            {
                base.Draw(spriteTint);
            }
        }
    }
}