namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public class PlayerCollisionHandler : CollisionInteractions
    {
        private IPlayer player;

        public PlayerCollisionHandler(IPlayer player)
        {
            this.player = player;
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (enemy is WallMaster)
            {
                player.State = new GrabbedState(player, (WallMaster)enemy);
            }
            else if (enemy is Likelike)
            {
                player.State = new SwallowedState(player, (Likelike)enemy);
            }
            else if (enemy is Bubble)
            {
                if (player.DamageTimer <= 0)
                {
                    player.DamageTimer = LoZGame.Instance.UpdateSpeed / 2;
                    player.DisarmedTimer = LoZGame.Instance.UpdateSpeed * 3;
                    DeterminePushbackValues(enemy.Physics, player.Physics);
                    SoundFactory.Instance.PlayLinkHurt();
                }
            }
            else if (enemy is OldMan || enemy is Merchant || enemy is BlockEnemy || enemy.IsTransparent)
            {
                // do nothing
            }
            else
            {
                if (!(player.State is PickupItemState || player.State is AttackState))
                {
                    if (player.DamageTimer <= 0)
                    {
                        DeterminePushbackValues(enemy.Physics, player.Physics);
                    }
                    int damage = enemy.Damage;
                    damage += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.DamageMod;
                    damage = damage <= 0 ? 1 : damage;
                    player.TakeDamage(damage);
                }
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
            if (item.PickUpItemTime >= 0)
            {
                item.Physics.Location = new Vector2(player.Physics.Location.X + 5, player.Physics.Location.Y - 45);
                item.Physics.Bounds = new Rectangle(new Point((int)item.Physics.Location.X, (int)item.Physics.Location.Y), new Point(0, 0));
                player.State = new PickupItemState(player, item);
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            if (!(player.State is PickupItemState))
            {
                if (!(projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile) && player.DamageTimer <= 0)
                {
                    DetermineDirectPushback(projectile.Physics, player.Physics);
                }
                player.TakeDamage(projectile.Damage);
            }
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            if (block is CrossableTile)
            {
                player.LadderTimer = 5;
            }
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            if (door.DoorType != Door.DoorTypes.Unlocked)
            {
                PreventDoorEntry(door);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            SetBounds(player.Physics, collisionSide);
        }

        private void PreventDoorEntry(IDoor door)
        {
            if (door.Physics.CurrentDirection == Physics.Direction.West)
            {
                player.Physics.Bounds = new Rectangle((int)BlockSpriteFactory.Instance.HorizontalOffset, player.Physics.Bounds.Y, player.Physics.Bounds.Width, player.Physics.Bounds.Height);
                player.Physics.StopMotionX();
            }
            else if (door.Physics.CurrentDirection == Physics.Direction.East)
            {
                player.Physics.Bounds = new Rectangle((int)door.Physics.Bounds.Left - player.Physics.Bounds.Width, player.Physics.Bounds.Y, player.Physics.Bounds.Width, player.Physics.Bounds.Height);
                player.Physics.StopMotionX();
            }
            else if (door.Physics.CurrentDirection == Physics.Direction.South)
            {
                player.Physics.Bounds = new Rectangle(player.Physics.Bounds.X, (int)door.Physics.Bounds.Top - player.Physics.Bounds.Height, player.Physics.Bounds.Width, player.Physics.Bounds.Height);
                player.Physics.StopMotionY();
            }
            else if (door.Physics.CurrentDirection == Physics.Direction.North)
            {
                player.Physics.Bounds = new Rectangle(player.Physics.Bounds.X, (int)BlockSpriteFactory.Instance.TopOffset, player.Physics.Bounds.Width, player.Physics.Bounds.Height);
                player.Physics.StopMotionY();
            }
            player.Physics.SetLocation();
        }
    }
}