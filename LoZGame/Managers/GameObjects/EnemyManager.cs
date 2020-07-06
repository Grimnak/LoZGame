namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class EnemyManager : IManager
    {
        private Dictionary<int, IEnemy> enemyList;
        private Queue<IEnemy> queuedEnemies;
        private int enemyID;
        private readonly List<int> deletable;

        private List<IEnemy> enemies;

        public List<IEnemy> EnemyList { get { return enemies; } }

        public EnemyManager()
        {
            enemyList = new Dictionary<int, IEnemy>();
            queuedEnemies = new Queue<IEnemy>();
            enemies = new List<IEnemy>();
            deletable = new List<int>();
            enemyID = 0;
        }

        // queue to add enemies mid update cycle (for Patra mostly)
        public void Queue(IEnemy enemy)
        {
            queuedEnemies.Enqueue(enemy);
        }

        public void Add(IEnemy enemy)
        {
            // This check is necessary to ensure that enemies do not respawn if they were in the middle of their death sequence.
            if (!enemy.IsDead)
            {
                enemy.CurrentState.Spawn();
                enemyList.Add(enemyID, enemy);
                enemyID++;
                enemy.AddChild();
            }
        }

        public void RemoveEnemy(int instance)
        {
            enemyList.Remove(instance);
        }

        public void Update()
        {
            while (queuedEnemies.Count > 0)
            {
                IEnemy enemy = queuedEnemies.Dequeue();
                enemyList.Add(enemyID, enemy);
                enemyID++;
                enemy.AddChild();
            }

            foreach (KeyValuePair<int, IEnemy> enemy in enemyList)
            {
                if (enemy.Value.Expired)
                {
                    deletable.Add(enemy.Key);
                }
            }

            foreach (int index in deletable)
            {
                RemoveEnemy(index);
            }

            deletable.Clear();

            enemies.Clear();

            foreach (KeyValuePair<int, IEnemy> enemy in enemyList)
            {
                enemies.Add(enemy.Value);
                enemy.Value.Update();
            }

            DropItemsEmptyRoom();
        }

        public void DropItemsEmptyRoom()
        {
            int enemyCount = enemyList.Count;
            foreach (IEnemy enemy in enemyList.Values)
            {
                if (!enemy.IsKillable)
                {
                    enemyCount--;
                }
            }
            if (enemyCount == 0)
            {
                // Ensure statues stop shooting projectiles once the room has been cleared to prevent cheap damage.
                foreach (IEnemy fireBlockEnemy in enemyList.Values)
                {
                    if (fireBlockEnemy is BlockEnemy)
                    {
                        fireBlockEnemy.Expired = true;
                    }
                }
                LoZGame.Instance.Drops.DropItemsEmptyRoom();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IEnemy> enemy in enemyList)
            {
                enemy.Value.Draw();
            }
        }

        public void Clear()
        {
            enemyList = new Dictionary<int, IEnemy>();
        }
    }
}
