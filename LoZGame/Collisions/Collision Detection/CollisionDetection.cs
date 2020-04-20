namespace LoZClone
{
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Contains the update checks necessary to determine if two or more objects are currently colliding.
    /// </summary>
    public partial class CollisionDetection
    {
        private Dungeon dungeon;
        private bool moveToBasement = false;

        public bool MoveToBasement { get { return moveToBasement; } set { moveToBasement = value; } }

        public CollisionDetection(Dungeon dungeon)
        {
            this.dungeon = dungeon;
        }

        public void Update(ReadOnlyCollection<IPlayer> players, ReadOnlyCollection<IEnemy> enemies, ReadOnlyCollection<IBlock> blocks, ReadOnlyCollection<IDoor> doors, ReadOnlyCollection<IItem> items, ReadOnlyCollection<IProjectile> playerProjectiles, ReadOnlyCollection<IProjectile> enemyProjectiles)
        {
            CheckPlayers(players, enemies, enemyProjectiles, doors, items);
            CheckEnemies(enemies, playerProjectiles);
            CheckBlocks(blocks, players, enemies);
            CheckItems(items, playerProjectiles);
            CheckProjectiles(playerProjectiles, enemyProjectiles, doors, blocks);

            // Unable to change rooms mid-foreach loop, so set a flag and change directly after.
            if (moveToBasement)
            {
                dungeon.MoveDown();
                moveToBasement = false;
            }
        }

        private void CheckPlayers(ReadOnlyCollection<IPlayer> players, ReadOnlyCollection<IEnemy> enemies, ReadOnlyCollection<IProjectile> enemyProjectiles, ReadOnlyCollection<IDoor> doors, ReadOnlyCollection<IItem> items)
        {
            foreach (IPlayer player in players)
            {
                if (!(player.State is DieState) && !(player.State is GrabbedState))
                {
                    CheckCollisions<IItem>(player, items);
                    if (!CheckCollisions<IDoor>(player, doors))
                    {
                        CheckBorders(player, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
                    }

                    if (player.DamageTimer <= 0)
                    {
                        CheckCollisions<IEnemy>(player, enemies);
                        CheckCollisions<IProjectile>(player, enemyProjectiles);
                    }
                }
            }
        }

        private void CheckEnemies(ReadOnlyCollection<IEnemy> enemies, ReadOnlyCollection<IProjectile> playerProjectiles)
        {
            foreach (IEnemy enemy in enemies)
            {
                // Do not check borders for the Old Man/Merchant since they are static NPCs.
                if (!(enemy is OldMan || enemy is Merchant))
                {
                    if(!enemy.Physics.IsJumping)
                    {
                        CheckBorders(enemy, EnemySpriteFactory.GetEnemyWidth(enemy), EnemySpriteFactory.GetEnemyHeight(enemy));
                    }else
                    {
                        CheckSideBorders(enemy, EnemySpriteFactory.GetEnemyWidth(enemy), EnemySpriteFactory.GetEnemyHeight(enemy));
                    }
                }
                CheckCollisions<IProjectile>(enemy, playerProjectiles);
            }
        }

        private void CheckBlocks(ReadOnlyCollection<IBlock> blocks, ReadOnlyCollection<IPlayer> players, ReadOnlyCollection<IEnemy> enemies)
        {
            foreach (IBlock block in blocks)
            {
                if (block is BlockTile || block is MovableTile || block is CrossableTile)
                {
                    CheckCollisions<IPlayer>(block, players);
                    CheckCollisions<IEnemy>(block, enemies);
                    CheckBorders(block, block.Physics.Bounds.Width, block.Physics.Bounds.Height);
                }
                else if (block is Tile && (((Tile)block).Name.Equals("stairs") || ((Tile)block).Name.Equals("stairs3")))
                {
                    CheckCollisions<IPlayer>(block, players);
                }
            }
        }

        private void CheckItems(ReadOnlyCollection<IItem> items, ReadOnlyCollection<IProjectile> projectiles)
        {
            foreach (IItem item in items)
            {
                if (item is Fairy)
                {
                    CheckBorders(item, ItemSpriteFactory.FairyWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.FairyHeight * ItemSpriteFactory.Instance.Scale);
                } 
                else
                {
                    CheckCollisions<IProjectile>(item, projectiles);
                }
            }
        }

        private void CheckProjectiles(ReadOnlyCollection<IProjectile> playerProjectiles, ReadOnlyCollection<IProjectile> enemyProjectiles, ReadOnlyCollection<IDoor> doorsList, ReadOnlyCollection<IBlock> blockList)
        {
            foreach (IProjectile playerProjectile in playerProjectiles)
            {
                CheckBorders(playerProjectile, ProjectileSpriteFactory.GetProjectileWidth(playerProjectile), ProjectileSpriteFactory.GetProjectileHeight(playerProjectile));
                CheckCollisions(playerProjectile, doorsList);
                CheckCollisions(playerProjectile, blockList);
            }

            foreach (IProjectile enemyProjectile in enemyProjectiles)
            {
                CheckBorders(enemyProjectile, ProjectileSpriteFactory.GetProjectileWidth(enemyProjectile), ProjectileSpriteFactory.GetProjectileHeight(enemyProjectile));
                CheckCollisions(enemyProjectile, blockList);
            }
        }
    }
}