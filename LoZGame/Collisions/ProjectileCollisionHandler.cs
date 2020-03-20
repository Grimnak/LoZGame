namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class ProjectileCollisionHandler
    {
        private IProjectile projectile;

        public ProjectileCollisionHandler(IProjectile projectile)
        {
            this.projectile = projectile;
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                this.projectile.Returning = true;
            }
            else if (this.projectile is BombProjectile || this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
        }
        
        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
            {
                this.projectile.Returning = true;
            }
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile || this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
            {
                this.projectile.Returning = true;
            }
            else if (this.projectile is BombExplosion)
            {
                Console.WriteLine("Bomb Explosion");
                if (door.State is HiddenDoorState)
                {
                    Door cousin = new Door(string.Empty, string.Empty);
                    int Y = LoZGame.Instance.Dungeon.CurrentRoomY;
                    int X = LoZGame.Instance.Dungeon.CurrentRoomX;
                    switch (((Door)door).GetLoc())
                    {
                        case "N":
                            foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y - 1, X).Doors)
                            {
                                if (cDoor.GetLoc().Equals("S"))
                                {
                                    cousin = cDoor;
                                    break;
                                }
                            }
                            break;
                        case "S":
                            foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y + 1, X).Doors)
                            {
                                if (cDoor.GetLoc().Equals("N"))
                                {
                                    cousin = cDoor;
                                    break;
                                }
                            }
                            break;
                        case "E":
                            foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y, X + 1).Doors)
                            {
                                if (cDoor.GetLoc().Equals("W"))
                                {
                                    cousin = cDoor;
                                    break;
                                }
                            }
                            break;
                        default:
                            foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y, X - 1).Doors)
                            {
                                if (cDoor.GetLoc().Equals("E"))
                                {
                                    cousin = cDoor;
                                    break;
                                }
                            }
                            break;
                    }
                    Console.WriteLine("Cousin Location: " + cousin.GetLoc());
                    Console.WriteLine("Door Location: " + ((Door)door).GetLoc());
                    door.Bombed();
                    cousin.Bombed();
                }
            }
            else
            {
                this.projectile.IsExpired = true;
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile || this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
            {
                this.projectile.Returning = true;
            }
            else if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile || this.projectile is BombProjectile)
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.projectile.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.projectile.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.projectile.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, this.projectile.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
                {
                    this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
                }
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
        }

        private void PushOut(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, this.projectile.Physics.Location.Y + 1);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, this.projectile.Physics.Location.Y - 1);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X + 1, this.projectile.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X - 1, this.projectile.Physics.Location.Y);
            }
        }
    }
}