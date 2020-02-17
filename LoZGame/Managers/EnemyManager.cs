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
        readonly EntityManager entity;

        public EnemyManager(EntityManager entity)
        {
            this.entity = entity;
            this.currentIndex = 0;
            this.maxIndex = 0;
            this.enemyList = new List<IEnemy>();
        }

        private void LoadEnemies()
        {
            this.enemyList.Add(new Dodongo());
            this.enemyList.Add(new Stalfos());
            this.enemyList.Add(new Goriya(this.entity));
            this.enemyList.Add(new Dragon());
            this.enemyList.Add(new OldMan());
            this.enemyList.Add(new Merchant());
            this.enemyList.Add(new SpikeCross());
            this.enemyList.Add(new WallMaster());
            this.enemyList.Add(new Rope());
            this.enemyList.Add(new Zol());
            this.enemyList.Add(new Gel());
            this.enemyList.Add(new Keese());
        }

        public void loadSprites()
        {
            this.LoadEnemies();
            this.currentEnemy = this.enemyList[this.currentIndex];
            foreach (IEnemy sprite in this.enemyList)
            {
                this.maxIndex++;
            }
        }

        public void cycleLeft()
        {
            this.currentIndex--;

            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }

            this.currentEnemy = this.enemyList[this.currentIndex];
        }

        public void cycleRight()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }

            this.currentEnemy = this.enemyList[this.currentIndex];
        }

        public void clear()
        {
            this.enemyList = new List<IEnemy>();
            this.loadSprites();
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}
