using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class GameObjectManager : IManager
    {

        private ItemManager itemManager;
        private BlockManager blockManager;
        private EntityManager entityManager;
        private EnemyManager enemyManager;
        private DoorManager doorManager;

        public GameObjectManager()
        {
            this.itemManager = new ItemManager();
            this.blockManager = new BlockManager();
            this.entityManager = new EntityManager();
            this.enemyManager = new EnemyManager();
            this.doorManager = new DoorManager();
        }

        public ItemManager Items { get { return itemManager; } }

        public BlockManager Blocks { get { return blockManager; } }

        public EntityManager Entities { get { return entityManager; } }

        public EnemyManager Enemies { get { return enemyManager; } }

        public DoorManager Doors { get { return doorManager; } }

        public void Clear()
        {
            itemManager.Clear();
            blockManager.Clear();
            entityManager.Clear();
            enemyManager.Clear();
            doorManager.Clear();
        }

        public void Draw()
        {
            blockManager.Draw();
            itemManager.Draw();
            entityManager.Draw();
            enemyManager.Draw();
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
    }
}
