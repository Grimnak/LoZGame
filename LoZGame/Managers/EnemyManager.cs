namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyManager2
    {
        private Dictionary<int, IEnemy> enemyList;
        private int enemyListSize;
        private int enemyID;
        private readonly List<int> deletable;

        private static readonly EnemyManager2 instance = new EnemyManager2();

        public EnemyManager2()
        {
            enemyList = new Dictionary<int, IEnemy>();
            enemyListSize = 0;
        }

        public void Add(IEnemy enemy)
        {
            enemyListSize++;
            enemyList.Add(enemyID, enemy);
            enemyID++;
            if (enemyListSize == 0)
            {
                enemyID = 0;
            }
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
                if (enemy.Value.Health < 1)
                {
                    this.deletable.Add(enemy.Key);
                }
            }
                foreach (int index in this.deletable)
                {
                    this.RemoveEnemy(index);
                }

                this.deletable.Clear();

                foreach (KeyValuePair<int, IEnemy> enemy in this.enemyList)
                {
                    enemy.Value.Update();
                }
        }
        public void Draw(SpriteBatch spritebatch)
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