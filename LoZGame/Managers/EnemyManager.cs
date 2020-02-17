using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{

    public class EnemyManager
    {
        private List<IEnemy> enemyList;
        public IEnemy currentEnemy;
        private int currentIndex;
        private int maxIndex;
        public Vector2 location;

        public EnemyManager()
        {
            currentIndex = 0;
            maxIndex = 0;
            enemyList = new List<IEnemy>();
        }

        private void LoadEnemies()
        {
            enemyList.Add(new Dodongo());
            enemyList.Add(new Dragon());
            enemyList.Add(new OldMan());
            enemyList.Add(new Merchant());
            enemyList.Add(new SpikeCross());
            enemyList.Add(new WallMaster());
            enemyList.Add(new Rope());
            enemyList.Add(new Zol());
            enemyList.Add(new Zol());
            enemyList.Add(new Gel());
            enemyList.Add(new Stalfos());
            enemyList.Add(new Keese());


        }

        public void loadSprites(int xloc, int yloc)
        {
            this.LoadEnemies();
            this.currentEnemy = this.enemyList[this.currentIndex];
            location.X = xloc;
            location.Y = yloc;
            foreach (IEnemy sprite in enemyList)
            {
                maxIndex++;
            }
        }

        public void cycleLeft()
        {
            //this.location = currentEnemy.location;
            this.currentIndex--;

            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }

            this.currentEnemy = this.enemyList[this.currentIndex];
            //this.currentEnemy.location = this.location;
        }

        public void cycleRight()
        {
            //this.location = currentItem.location;
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }
            this.currentEnemy = this.enemyList[this.currentIndex];
            //this.currentItem.location = this.location;
        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }
    }
}
