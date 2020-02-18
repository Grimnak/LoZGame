namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class EnemyManager
    {
        private List<IEnemy> enemyList;
        public IEnemy CurrentEnemy;
        private int currentIndex;
        private int maxIndex;
        public Vector2 Location;
        private readonly EntityManager entity;

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
            this.enemyList.Add(new Dragon(this.entity));
            this.enemyList.Add(new OldMan());
            this.enemyList.Add(new Merchant());
            this.enemyList.Add(new SpikeCross());
            this.enemyList.Add(new WallMaster());
            this.enemyList.Add(new Rope());
            this.enemyList.Add(new Zol());
            this.enemyList.Add(new Gel());
            this.enemyList.Add(new Keese());
        }

        public void LoadSprites()
        {
            this.LoadEnemies();
            this.CurrentEnemy = this.enemyList[this.currentIndex];
            foreach (IEnemy sprite in this.enemyList)
            {
                this.maxIndex++;
            }
        }

        public void CycleLeft()
        {
            this.currentIndex--;

            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }

            this.CurrentEnemy = this.enemyList[this.currentIndex];
        }

        public void CycleRight()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }

            this.CurrentEnemy = this.enemyList[this.currentIndex];
        }

        public void Clear()
        {
            this.enemyList = new List<IEnemy>();
            this.maxIndex = 0;
            this.loadSprites();
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}
