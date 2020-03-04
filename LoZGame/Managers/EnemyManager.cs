namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class EnemyManager
    {
        private Dictionary<int, IEnemy> enemyList;
        private int enemyListSize;
        private int enemyID;
        private readonly List<int> deletable;

        private List<IEnemy> enemies;

        public List<IEnemy> EnemyList { get { return enemies; } }

        public EnemyManager()
        {
            enemyList = new Dictionary<int, IEnemy>();
            enemies = new List<IEnemy>();
            enemyListSize = 0;
            deletable = new List<int>();
        }

        public void Add(IEnemy enemy)
        {
            enemyListSize++;
            enemyList.Add(enemyID, enemy);
            enemyID++;
        }

        public void RemoveEnemy(int instance)
        {
            enemyList.Remove(instance);
            enemyListSize--;
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IEnemy> enemy in this.enemyList)
            {
                if (enemy.Value.Health.CurrentHealth < 1)
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
