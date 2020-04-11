namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class EnemyManager : IManager
    {
        private Dictionary<int, IEnemy> enemyList;
        private int enemyID;
        private readonly List<int> deletable;

        private List<IEnemy> enemies;

        public List<IEnemy> EnemyList { get { return enemies; } }

        public EnemyManager()
        {
            enemyList = new Dictionary<int, IEnemy>();
            enemies = new List<IEnemy>();
            deletable = new List<int>();
            enemyID = 0;
        }

        public void Add(IEnemy enemy)
        {
            if (!enemy.Expired)
            {
                Console.WriteLine("EnemyManager: Attempted to Add Enemy");
                enemyList.Add(enemyID, enemy);
                enemyID++;
                enemy.AddChild();
                Console.WriteLine("Enemy Manager: Successfully added enemy");
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
                    Console.WriteLine("Enemy Manager: Enemy at" + enemy.Key + " Expired.");
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
