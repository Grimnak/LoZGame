namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class EnemyManager
    {
        private LoZGame game;
        private List<IEnemy> enemyList;

        public List<IEnemy> EnemyList
        {
            get { return this.enemyList; }
        }

        public IEnemy CurrentEnemy;
        private int currentIndex;
        private int maxIndex;
        public Vector2 Location;
        private readonly EntityManager entity;

        public EnemyManager(LoZGame game, EntityManager entity)
        {
            this.game = game;
            this.entity = entity;
            this.currentIndex = 0;
            this.maxIndex = 0;
            this.enemyList = new List<IEnemy>();
        }

        private void LoadEnemies()
        {
            this.enemyList.Add(new Dodongo(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new Stalfos(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new Goriya(this.game, this.entity, new Vector2(650, 200)));
            this.enemyList.Add(new Dragon(this.game, this.entity, new Vector2(650, 200)));
            this.enemyList.Add(new OldMan(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new Merchant(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new SpikeCross(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new WallMaster(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new Rope(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new Zol(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new Gel(this.game, new Vector2(650, 200)));
            this.enemyList.Add(new Keese(this.game, new Vector2(650, 200)));
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
