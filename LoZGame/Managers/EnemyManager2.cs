namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyManager2
    {
        private List<IEnemy> enemyList;
        private int enemyListSize;

        private static readonly EnemyManager2 instance = new EnemyManager2();

        public EnemyManager2()
        {
            this.enemyList = new List<IEnemy>();
            this.enemyListSize = 0;
        }

        public void Add(IEnemy enemy)
        {
            enemyListSize++;
            enemyList.Add(enemy);
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            this.enemyList.Remove(enemy);
            this.enemyListSize--;
        }

        public void Update()
        {
            foreach (IEnemy enemy in this.enemyList)
            {
                if (enemy.Health < 1)
                {
                    RemoveEnemy(enemy);
                }
            }

            foreach (IEnemy enemy in this.enemyList)
            {
                enemy.Update();
            }
        }

        public void Draw()
        {
            foreach (IEnemy enemy in this.enemyList)
            {
                enemy.Draw();
            }
        }

        public void Clear()
        {
            enemyList = new List<IEnemy>();
        }
    }
}