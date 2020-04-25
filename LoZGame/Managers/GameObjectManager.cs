namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public class GameObjectManager : IManager
    {
        private ItemManager itemManager;
        private BlockManager blockManager;
        private EntityManager entityManager;
        private EnemyManager enemyManager;
        private DoorManager doorManager;
        private int loadedRoomX;
        private int loadedRoomY;

        public GameObjectManager()
        {
            itemManager = new ItemManager();
            blockManager = new BlockManager();
            entityManager = new EntityManager();
            enemyManager = new EnemyManager();
            doorManager = new DoorManager();
            loadedRoomX = -1;
            loadedRoomY = -1;
        }

        public ItemManager Items { get { return itemManager; } }

        public BlockManager Blocks { get { return blockManager; } }

        public EntityManager Entities { get { return entityManager; } }

        public EnemyManager Enemies { get { return enemyManager; } }

        public DoorManager Doors { get { return doorManager; } }

        public int LoadedRoomX { get { return loadedRoomX; } set { loadedRoomX = value; } }

        public int LoadedRoomY { get { return loadedRoomY; } set { loadedRoomY = value; } }

        public void Clear()
        {
            itemManager.Clear();
            blockManager.Clear();
            entityManager.Clear();
            enemyManager.Clear();
            doorManager.Clear();
        }

        public void Copy(GameObjectManager manager)
        {
            Clear();
            itemManager = manager.Items;
            blockManager = manager.Blocks;
            entityManager = manager.Entities;
            enemyManager = manager.Enemies;
            doorManager = manager.Doors;
        }

        public void Draw()
        {
            blockManager.Draw();
            itemManager.Draw();
            doorManager.Draw();
        }

        public void Update()
        {
            itemManager.Update();
            blockManager.Update();
            entityManager.Update();
            enemyManager.Update();
            doorManager.Update();
        }

        /// <summary>
        /// Saves the current state of every game object in the room.
        /// </summary>
        public void Save()
        {
            LoZGame.Instance.Dungeon.DungeonLayout[loadedRoomY][loadedRoomX].Enemies.Clear();
            LoZGame.Instance.Dungeon.DungeonLayout[loadedRoomY][loadedRoomX].Items.Clear();
            foreach (IEnemy enemy in enemyManager.EnemyList)
            {
                LoZGame.Instance.Dungeon.DungeonLayout[loadedRoomY][loadedRoomX].Enemies.Add(enemy);
            }
            foreach (IItem item in itemManager.ItemList)
            {
                LoZGame.Instance.Dungeon.DungeonLayout[loadedRoomY][loadedRoomX].Items.Add(item);
            }
        }

        /// <summary>
        /// Loads new room info into managers.
        /// </summary>
        public void LoadNewRoom()
        {
            // If X isn't equal to -1, we know Y also isn't equal to -1.
            if (loadedRoomX != -1)
            {
                Save();
            }
            Clear();

            foreach (IEnemy enemy in LoZGame.Instance.Dungeon.DungeonLayout[LoZGame.Instance.Dungeon.CurrentRoomY][LoZGame.Instance.Dungeon.CurrentRoomX].Enemies)
            {
                LoZGame.Instance.GameObjects.Enemies.Add(enemy);
            }

            foreach (IBlock block in LoZGame.Instance.Dungeon.DungeonLayout[LoZGame.Instance.Dungeon.CurrentRoomY][LoZGame.Instance.Dungeon.CurrentRoomX].Tiles)
            {
                LoZGame.Instance.GameObjects.Blocks.Add(block);
            }

            foreach (IItem item in LoZGame.Instance.Dungeon.DungeonLayout[LoZGame.Instance.Dungeon.CurrentRoomY][LoZGame.Instance.Dungeon.CurrentRoomX].Items)
            {
                LoZGame.Instance.GameObjects.Items.Add(item);
            }

            foreach (Door door in LoZGame.Instance.Dungeon.DungeonLayout[LoZGame.Instance.Dungeon.CurrentRoomY][LoZGame.Instance.Dungeon.CurrentRoomX].Doors)
            {
                LoZGame.Instance.GameObjects.Doors.Add(door);
            }

            loadedRoomX = LoZGame.Instance.Dungeon.CurrentRoomX;
            loadedRoomY = LoZGame.Instance.Dungeon.CurrentRoomY;
        }

        /// <summary>
        /// Sets the mastermovement vector for all objects in this managaer.
        /// </summary>
        /// <param name="movement">The movement vector to set for all objects</param>
        public void SetObjectMovement(Vector2 movement)
        {
            foreach (IProjectile projectile in Entities.EnemyProjectileManager.Projectiles)
            {
                projectile.Physics.MasterMovement = movement;
            }
            foreach (IProjectile projectile in Entities.ProjectileManager.Projectiles)
            {
                projectile.Physics.MasterMovement = movement;
            }
            foreach (IProjectile projectile in Entities.ExplosionManager.Explosions)
            {
                projectile.Physics.MasterMovement = movement;
            }
            foreach (IBlock block in Blocks.BlockList)
            {
                block.Physics.MasterMovement = movement;
            }
            foreach (IDoor door in Doors.DoorList)
            {
                door.Physics.MasterMovement = movement;
            }
            foreach (IItem item in Items.ItemList)
            {
                item.Physics.MasterMovement = movement;
            }
            foreach (IEnemy enemy in Enemies.EnemyList)
            {
                enemy.Physics.MasterMovement = movement;
            }
        }

        /// <summary>
        /// Calls move master on every object in the manager, forcing them to move by this value.
        /// </summary>
        public void MoveObjects()
        {
            foreach (IProjectile projectile in Entities.EnemyProjectileManager.Projectiles)
            {
                projectile.Physics.MoveMaster();
            }
            foreach (IProjectile projectile in Entities.ProjectileManager.Projectiles)
            {
                projectile.Physics.MoveMaster();
            }
            foreach (IProjectile projectile in Entities.ExplosionManager.Explosions)
            {
                projectile.Physics.MoveMaster();
            }
            foreach (IBlock block in Blocks.BlockList)
            {
                block.Physics.MoveMaster();
            }
            foreach (IDoor door in Doors.DoorList)
            {
                door.Physics.MoveMaster();
            }
            foreach (IItem item in Items.ItemList)
            {
                item.Physics.MoveMaster();
            }
            foreach (IEnemy enemy in Enemies.EnemyList)
            {
                enemy.Physics.MoveMaster();
            }
        }

        /// <summary>
        /// shifts the bounds of all objects by a certain offset.
        /// </summary>
        /// <param name="Offset">the amount to shift the objects bounds by</param>
        public void UpdateObjectLocations(Point Offset)
        {
            foreach (IProjectile projectile in Entities.EnemyProjectileManager.Projectiles)
            {
                projectile.Physics.Bounds = new Rectangle(projectile.Physics.Bounds.Location + Offset, projectile.Physics.Bounds.Size);
                projectile.Physics.SetLocation();
            }
            foreach (IProjectile projectile in Entities.ProjectileManager.Projectiles)
            {
                projectile.Physics.Bounds = new Rectangle(projectile.Physics.Bounds.Location + Offset, projectile.Physics.Bounds.Size);
                projectile.Physics.SetLocation();
            }
            foreach (IProjectile projectile in Entities.ExplosionManager.Explosions)
            {
                projectile.Physics.Bounds = new Rectangle(projectile.Physics.Bounds.Location + Offset, projectile.Physics.Bounds.Size);
                projectile.Physics.SetLocation();
            }
            foreach (IBlock block in Blocks.BlockList)
            {
                block.Physics.Bounds = new Rectangle(block.Physics.Bounds.Location + Offset, block.Physics.Bounds.Size);
                block.Physics.SetLocation();
            }
            foreach (IDoor door in Doors.DoorList)
            {
                door.Physics.Bounds = new Rectangle(door.Physics.Bounds.Location + Offset, door.Physics.Bounds.Size);
                door.Physics.SetLocation();
            }
            foreach (IItem item in Items.ItemList)
            {
                item.Physics.Bounds = new Rectangle(item.Physics.Bounds.Location + Offset, item.Physics.Bounds.Size);
                item.Physics.SetLocation();
            }
            foreach (IEnemy enemy in Enemies.EnemyList)
            {
                enemy.Physics.Bounds = new Rectangle(enemy.Physics.Bounds.Location + Offset, enemy.Physics.Bounds.Size);
                enemy.Physics.SetLocation();
            }
        }
    }
}
