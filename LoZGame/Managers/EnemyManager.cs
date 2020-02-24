namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class EnemyManager
    {
        private List<IEnemy> enemyList;

        private static readonly EnemyManager instance = new EnemyManager(EntityManager.Instance);

        public static EnemyManager Instance
        {
            get
            {
                return instance;
            }
        }

        public List<IEnemy> EnemyList
        {
            get { return this.enemyList; }
        }

        public IEnemy CurrentEnemy;
        private int currentIndex;
        private int maxIndex;
        public Vector2 Location;
        private readonly EntityManager entity;

        private EnemyManager(EntityManager entity)
        {
            this.entity = entity;
            this.currentIndex = 0;
            this.maxIndex = 0;
            this.enemyList = new List<IEnemy>();
        }

        private void LoadEnemies()
        {
            this.enemyList.Add(new Dodongo(new Vector2(650, 200)));
            this.enemyList.Add(new Stalfos(new Vector2(650, 200)));
            this.enemyList.Add(new Goriya(new Vector2(650, 200)));
            this.enemyList.Add(new Dragon(new Vector2(650, 200)));
            this.enemyList.Add(new OldMan(new Vector2(650, 200)));
            this.enemyList.Add(new Merchant(new Vector2(650, 200)));
            this.enemyList.Add(new SpikeCross(new Vector2(650, 200)));
            this.enemyList.Add(new WallMaster(new Vector2(650, 200)));
            this.enemyList.Add(new Rope(new Vector2(650, 200)));
            this.enemyList.Add(new Zol(new Vector2(650, 200)));
            this.enemyList.Add(new Gel(new Vector2(650, 200)));
            this.enemyList.Add(new Keese(new Vector2(650, 200)));
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
            this.LoadSprites();
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}
