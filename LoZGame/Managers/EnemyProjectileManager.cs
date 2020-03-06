namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyProjectileManager
    {
        private const int Scale = 2;
        private readonly Dictionary<int, IProjectile> projectileList;
        private readonly List<int> deletable;
        private List<IProjectile> projectiles;
        private int projectileId;
        private int listSize;

        public List<IProjectile> Projectiles { get { return this.projectiles; } }

        public EnemyProjectileManager()
        {
            this.projectileList = new Dictionary<int, IProjectile>();
            this.projectiles = new List<IProjectile>();
            this.deletable = new List<int>();
            this.projectileId = 0;
            this.listSize = 0;
        }

        public void AddFireballs(Vector2 location)
        {
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new DragonFireBall(location, "NorthWest"));
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new DragonFireBall(location, "West"));
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new DragonFireBall(location, "SouthWest"));
        }

        public void AddEnemyRang(Goriya enemy)
        {
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new BoomerangEnemy(enemy));
        }

        public void Remove(int instance)
        {
            this.projectileList.Remove(instance);
            this.listSize--;
            if (this.listSize == 0)
            {
                this.projectileId = 0;
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IProjectile> item in this.projectileList)
            {
                if (item.Value.IsExpired)
                {
                    this.deletable.Add(item.Key);
                }
            }
            foreach (int index in this.deletable)
            {
                this.Remove(index);
            }

            this.projectiles.Clear();
            this.deletable.Clear();

            foreach (KeyValuePair<int, IProjectile> item in this.projectileList)
            {
                this.projectiles.Add(item.Value);
                item.Value.Update();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IProjectile> projectile in this.projectileList)
            {
                projectile.Value.Draw();
            }

        }
    }
}