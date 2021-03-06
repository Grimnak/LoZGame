﻿namespace LoZClone
{
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Contains the update checks necessary to determine if two or more objects are currently colliding.
    /// </summary>
    public partial class CollisionDetection
    {
        private Dungeon dungeon;

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
                    CheckBorders(enemy, EnemySpriteFactory.GetEnemyWidth(enemy), EnemySpriteFactory.GetEnemyHeight(enemy));
                }
                CheckCollisions<IProjectile>(enemy, playerProjectiles);
            }
        }

        private void CheckBlocks(ReadOnlyCollection<IBlock> blocks, ReadOnlyCollection<IPlayer> players, ReadOnlyCollection<IEnemy> enemies)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                IBlock block = blocks[i];
                if (block is BlockTile || block is MovableBlock || block is CrossableTile)
                {
                    CheckCollisions<IPlayer>(block, players);
                    CheckCollisions<IEnemy>(block, enemies);
                    CheckBorders(block, block.Physics.Bounds.Width, block.Physics.Bounds.Height);
                }
                else if (block is Stairs)
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