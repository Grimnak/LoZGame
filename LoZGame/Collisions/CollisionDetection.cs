namespace LoZClone
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

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
            CheckItems(items);
            CheckProjectiles(playerProjectiles, enemyProjectiles, blocks);

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
                if (!(player.State is DieState) && !(player.State is ImmobileState))
                {
                    if (player.DamageTimer <= 0)
                    {
                        CheckCollisions<IEnemy>(player, enemies);
                        CheckCollisions<IProjectile>(player, enemyProjectiles);
                        CheckCollisions<IDoor>(player, doors);
                    }
                    CheckCollisions<IItem>(player, items);
                    CheckBorders(player, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
                }
            }
        }

        private void CheckEnemies(ReadOnlyCollection<IEnemy> enemies, ReadOnlyCollection<IProjectile> playerProjectiles)
        {
            foreach (IEnemy enemy in enemies)
            {
                if (!(enemy is WallMaster))
                {
                    CheckBorders(enemy, EnemySpriteFactory.GetEnemyWidth(enemy), EnemySpriteFactory.GetEnemyHeight(enemy));
                }
                if (!(enemy is OldMan || enemy is Merchant))
                {
                    CheckCollisions<IProjectile>(enemy, playerProjectiles);
                }
            }
        }

        private void CheckBlocks(ReadOnlyCollection<IBlock> blocks, ReadOnlyCollection<IPlayer> players, ReadOnlyCollection<IEnemy> enemies)
        {
            foreach (IBlock block in blocks)
            {
                if (block is BlockTile || block is MovableTile)
                {
                    CheckCollisions<IPlayer>(block, players);
                    CheckCollisions<IEnemy>(block, enemies);
                    CheckBorders(block, BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight);
                }
                else if (block is Tile && ((Tile)block).Name.Equals("stairs"))
                {
                    CheckCollisions<IPlayer>(block, players);
                }
            }
        }

        private void CheckItems(ReadOnlyCollection<IItem> items)
        {
            foreach (IItem item in items)
            {
                if (item is Fairy)
                {
                    CheckBorders(item, ItemSpriteFactory.FairyWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.FairyHeight * ItemSpriteFactory.Instance.Scale);
                }
            }
        }

        private void CheckProjectiles(ReadOnlyCollection<IProjectile> playerProjectiles, ReadOnlyCollection<IProjectile> enemyProjectiles, ReadOnlyCollection<IBlock> blocks)
        {
            foreach (IProjectile playerProjectile in playerProjectiles)
            {
                CheckCollisions<IBlock>(playerProjectile, blocks);
                CheckBorders(playerProjectile, ProjectileSpriteFactory.GetProjectileWidth(playerProjectile), ProjectileSpriteFactory.GetProjectileHeight(playerProjectile));
            }

            foreach (IProjectile enemyProjectile in enemyProjectiles)
            {
                CheckBorders(enemyProjectile, ProjectileSpriteFactory.GetProjectileWidth(enemyProjectile), ProjectileSpriteFactory.GetProjectileHeight(enemyProjectile));
            }
        }
    }
}