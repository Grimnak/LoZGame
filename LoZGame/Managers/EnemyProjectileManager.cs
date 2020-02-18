namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyProjectileManager
    {
        private const int scale = 2;
        private readonly Dictionary<int, IProjectile> boomerangList;
        private readonly List<int> boomerangDeletable;
        private int boomerangId;
        private int boomerangListSize;
        private readonly Dictionary<int, FireballSprite> fireBallList;
        private readonly List<int> fireBallDeletable;
        private int fireBallId;
        private int fireBallListSize;


        public EnemyProjectileManager()
        {
            this.boomerangList = new Dictionary<int, IProjectile>();
            this.boomerangDeletable = new List<int>();
            this.boomerangId = 0;
            this.boomerangListSize = 0; 
            this.fireBallList = new Dictionary<int, FireballSprite>();
            this.fireBallDeletable = new List<int>();
            this.fireBallId = 0;
            this.fireBallListSize = 0;
        }

        public void AddFireballs(Dragon dragon, int scale)
        {
            this.fireBallId++;
            this.fireBallListSize++;
            this.fireBallList.Add(this.fireBallId, EnemySpriteFactory.Instance.CreateUpLeftFireballSprite(dragon.currentLocation, fireBallId, scale));
            this.fireBallId++;
            this.fireBallListSize++;
            this.fireBallList.Add(this.fireBallId, EnemySpriteFactory.Instance.CreateLeftFireballSprite(dragon.currentLocation, fireBallId, scale));
            this.fireBallId++;
            this.fireBallListSize++;
            this.fireBallList.Add(this.fireBallId, EnemySpriteFactory.Instance.CreateDownLeftFireballSprite(dragon.currentLocation, fireBallId, scale));
        }

        public void AddEnemyRang(Goriya enemy, string direction)
        {
            this.boomerangId++;
            this.boomerangListSize++;
            this.boomerangList.Add(this.boomerangId, ProjectileSpriteFactory.Instance.BoomerangEnemy(enemy, 2, this.boomerangId));
        }

        public void RemoveBoomerang(int instance)
        {
            this.boomerangList.Remove(instance);
            this.boomerangListSize--;
            if (this.boomerangListSize == 0)
            {
                this.boomerangId = 0;
            }
        }

        public void RemoveFireball(int instance)
        {
            this.fireBallList.Remove(instance);
            this.fireBallListSize--;
            if (this.fireBallListSize == 0)
            {
                this.fireBallId = 0;
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IProjectile> item in this.boomerangList)
            {
                if (item.Value.IsExpired)
                {
                    this.boomerangDeletable.Add(item.Value.Instance);
                }
            }

            foreach (KeyValuePair<int, FireballSprite> fireBall in this.fireBallList)
            {
                if (fireBall.Value.IsExpired)
                {
                    this.fireBallDeletable.Add(fireBall.Value.Instance);
                }
            }

            foreach (int index in this.fireBallDeletable)
            {
                this.RemoveFireball(index);
            }

            this.fireBallDeletable.Clear();
            foreach (KeyValuePair<int, FireballSprite> fireBall in this.fireBallList)
            {
                fireBall.Value.Update();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (KeyValuePair<int, IProjectile> boomerang in this.boomerangList)
            {
                boomerang.Value.Draw(spritebatch);
            }
            foreach (KeyValuePair<int, FireballSprite> fireBall in this.fireBallList)
            {
                fireBall.Value.Draw(spritebatch, scale, Color.White);
            }
        }
    }
}
