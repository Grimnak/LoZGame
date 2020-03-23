namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    public partial class EnemyProjectileManager : IManager
    {
        private const int Scale = 2;
        private readonly Dictionary<int, IProjectile> projectileList;
        private readonly List<int> deletable;
        private List<IProjectile> projectiles;
        private int projectileId;
        private int listSize;

        public List<IProjectile> Projectiles { get { return this.projectiles; } }

        public int Fireball => (int)ProjectileType.Fireball;

        public int Boomerang => (int)ProjectileType.Boomerang;

        public EnemyProjectileManager()
        {
            this.projectileList = new Dictionary<int, IProjectile>();
            this.projectiles = new List<IProjectile>();
            this.deletable = new List<int>();
            this.projectileId = 0;
            this.listSize = 0;
        }

        public void Add(int projectileType,  Physics physics)
        {
            ProjectileType projectile = (ProjectileType)projectileType;
            this.projectileId++;
            this.listSize++;
            switch(projectile)
            {
                case ProjectileType.Fireball:
                    projectileList.Add(projectileId, new FireballProjectile(physics));
                    break;
            }
        }
        public void Add(int projectileType, IEnemy enemy, string direction)
        {
            ProjectileType projectile = (ProjectileType)projectileType;
            this.projectileId++;
            this.listSize++;
            switch (projectile)
            {
                case ProjectileType.Boomerang:
                    projectileList.Add(projectileId, new BoomerangEnemy(enemy, direction));
                    break;
            }
        }

        /*public void AddDragonFireballs(Dragon dragon)
        {
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new FireballProjectile(dragon.Physics.Location, new Vector2(-3, -1)));
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new FireballProjectile(dragon.Physics.Location, new Vector2(-3, 0)));
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new FireballProjectile(dragon.Physics.Location, new Vector2(-3, 1)));
        }

        public void AddOldManFireballs(OldMan oldMan, IPlayer player)
        {
            Vector2 leftFireBlockLocation = new Vector2(oldMan.Physics.Location.X - 100, oldMan.Physics.Location.Y + 20);
            Vector2 rightFireBlockLocation = new Vector2(oldMan.Physics.Location.X + 160, oldMan.Physics.Location.Y + 20);

            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new FireballProjectile(leftFireBlockLocation, DetermineOldManLeftFireballVelocity(oldMan, player)));
            this.projectileId++;
            this.listSize++;
            this.projectileList.Add(this.projectileId, new FireballProjectile(rightFireBlockLocation, DetermineOldManRightFireballVelocity(oldMan, player)));
        }

        private Vector2 DetermineOldManLeftFireballVelocity(OldMan oldMan, IPlayer player)
        {
            Vector2 leftFireBlockLocation = new Vector2(oldMan.Physics.Location.X - 100, oldMan.Physics.Location.Y + 20);
            float leftBlockDiffX = player.Physics.Location.X - leftFireBlockLocation.X;
            float leftBlockDiffY = player.Physics.Location.Y - leftFireBlockLocation.Y;

            float leftBlockDiffTotal = (float)Math.Sqrt(Math.Pow(leftBlockDiffX, 2) + Math.Pow(leftBlockDiffY, 2));

            return new Vector2(leftBlockDiffX / leftBlockDiffTotal * 2, leftBlockDiffY / leftBlockDiffTotal * 2);
        }

        private Vector2 DetermineOldManRightFireballVelocity(OldMan oldMan, IPlayer player)
        {
            Vector2 rightFireBlockLocation = new Vector2(oldMan.Physics.Location.X + 100, oldMan.Physics.Location.Y + 20);
            float rightBlockDiffX = player.Physics.Location.X - rightFireBlockLocation.X;
            float rightBlockDiffY = player.Physics.Location.Y - rightFireBlockLocation.Y;

            float rightBlockDiffTotal = (float)Math.Sqrt(Math.Pow(rightBlockDiffX, 2) + Math.Pow(rightBlockDiffY, 2));

            return new Vector2(rightBlockDiffX / rightBlockDiffTotal * 2, rightBlockDiffY / rightBlockDiffTotal * 2);
        }*/

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

        public void Clear()
        {
            this.projectileList.Clear();
        }
    }
}