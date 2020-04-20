namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class EnemyManager : IManager
    {
        private Dictionary<int, IEnemy> enemyList;
        private List<IEnemy> newEnemies;
        private int enemyID;
        private readonly List<int> deletable;

        private List<IEnemy> enemies;

        public List<IEnemy> EnemyList { get { return enemies; } }

        public EnemyManager()
        {
            enemyList = new Dictionary<int, IEnemy>();
            newEnemies = new List<IEnemy>();
            enemies = new List<IEnemy>();
            deletable = new List<int>();
            enemyID = 0;
        }

        private void AddNewEnemies()
        {
            foreach (IEnemy enemy in newEnemies)
            {
                this.Add(enemy);
            }
            newEnemies.Clear();
        }

        public void AddNew(IEnemy enemy)
        {
            // This check is necessary to ensure that enemies do not respawn if they were in the middle of their death sequence.
            if (!enemy.IsDead)
            {
                newEnemies.Add(enemy);
            }
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
            foreach (KeyValuePair<int, IEnemy> enemy in this.enemyList)
            {
                if (enemy.Value.Expired)
                {
                    this.deletable.Add(enemy.Key);
                }
            }

            foreach (int index in this.deletable)
            {
                this.RemoveEnemy(index);
            }

            this.deletable.Clear();

            this.enemies.Clear();

            foreach (KeyValuePair<int, IEnemy> enemy in this.enemyList)
            {
                this.enemies.Add(enemy.Value);
                enemy.Value.Update();
            }

            AddNewEnemies();
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
                LoZGame.Instance.Drops.DropItemsEmptyRoom();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IEnemy> enemy in this.enemyList)
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
