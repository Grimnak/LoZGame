using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class ProjectileManager
    {
        private enum ProjectileType { Bomb, SilverArrow, Triforce, Boomerang, MagicBoomerang, Arrow, RedCandle, BlueCandle, SwordBeam };
        private enum ExplosionType { BombExplode, SwordExplode };
        private ProjectileType item;
        private Dictionary<int, IProjectile> itemList;
        private Dictionary<int, IProjectile> explosionList;
        private List<int> deletable;
        private List<int> explosionDeletable;
        private int scale;
        private int projectileId;
        private int explosionId;
        private int projectileListSize;
        private int explosionListSize;
        private bool swordLock;
        private bool boomerangLock;
        private bool spamLock;
        private int swordInstance;
        private int boomerangInstance;
        private int spamCounter;

        public bool BoomerangOut {get {return boomerangLock;} }

        public ProjectileManager()
        {
            this.itemList = new Dictionary<int, IProjectile>();
            this.explosionList = new Dictionary<int, IProjectile>();
            this.projectileId = 0;
            this.explosionId = 0;
            this.explosionListSize = 0;
            this.projectileListSize = 0;
            this.scale = (int)ProjectileSpriteFactory.Instance.Scale;
            deletable = new List<int>();
            explosionDeletable  = new List<int>();
            swordLock = false;
            boomerangLock = false;
            spamLock = false;
            swordInstance = 0;
            boomerangInstance = 0;
            spamCounter = 0;
        }

        public int Arrow
        {
            get { return (int)ProjectileType.Arrow; }
        }
        public int SilverArrow
        {
            get { return (int)ProjectileType.SilverArrow; }
        }
        public int Boomerang
        {
            get { return (int)ProjectileType.Boomerang; }
        }
        public int MagicBoomerang
        {
            get { return (int)ProjectileType.MagicBoomerang; }
        }
        public int BlueCandle
        {
            get { return (int)ProjectileType.BlueCandle; }
        }
        public int RedCandle
        {
            get { return (int)ProjectileType.RedCandle; }
        }
        public int Bomb
        {
            get { return (int)ProjectileType.Bomb; }
        }
        public int Triforce
        {
            get { return (int)ProjectileType.Triforce; }
        }
        public int Swordbeam
        {
            get { return (int)ProjectileType.SwordBeam; }
        }
        public int SwordExplosion
        {
            get { return (int)ExplosionType.SwordExplode; }
        }
        public int Explosion
        {
            get { return (int)ExplosionType.BombExplode; }
        }

        public void addItem(int item, Vector2 loc, string direction)
        {
            projectileId++;
            projectileListSize++;
            this.item = (ProjectileType)item;
            if (!spamLock)
            {
                spamCounter = 30;
                spamLock = true;
                switch (this.item)
                {
                    case (ProjectileType.Bomb):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.Bomb(loc, direction, scale, projectileId, this));
                        break;
                    case (ProjectileType.Triforce):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.Triforce(loc, scale, projectileId));
                        break;
                    case (ProjectileType.Arrow):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.Arrow(loc, direction, scale, projectileId));
                        break;
                    case (ProjectileType.SilverArrow):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.SilverArrow(loc, direction, scale, projectileId));
                        break;
                    case (ProjectileType.RedCandle):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.RedCandle(loc, direction, scale, projectileId));
                        break;
                    case (ProjectileType.BlueCandle):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.BlueCandle(loc, direction, scale, projectileId));
                        break;
                    default:
                        break;
                }
            }
        }

        public void addItem(int item, Link player)
        {
            this.item = (ProjectileType)item;
            projectileId++;
            projectileListSize++;
            if (!spamLock)
            {
                spamCounter = 30;
                spamLock = true;
                switch (this.item)
                {
                    case (ProjectileType.Boomerang):
                        if (!boomerangLock)
                        {
                            this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.Boomerang(player, scale, projectileId));
                            boomerangLock = true;
                            boomerangInstance = projectileId;
                        }
                        break;
                    case (ProjectileType.MagicBoomerang):
                        if (!boomerangLock)
                        {
                            this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.MagicBoomerang(player, scale, projectileId));
                            boomerangLock = true;
                            boomerangInstance = projectileId;
                        }

                        break;
                    case (ProjectileType.SwordBeam):
                        if (!swordLock)
                        {
                            this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.SwordBeam(player, scale, projectileId, this));
                            swordLock = true;
                            swordInstance = projectileId;
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        public void addExplosion(int explosion, Vector2 loc)
        {
            ExplosionType type = (ExplosionType)explosion;

            explosionId++;
            explosionListSize++;
            switch (type)
            {
                case (ExplosionType.SwordExplode):
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "NorthEast", scale, explosionId));
                    explosionId++;
                    explosionListSize++;
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "NorthWest", scale, explosionId));
                    explosionId++;
                    explosionListSize++;
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "SouthEast", scale, explosionId));
                    explosionId++;
                    explosionListSize++;
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "SouthWest", scale, explosionId));
                    break;
                case (ExplosionType.BombExplode):
                    Random numGen = new Random();
                    int selectBomb = numGen.Next(0, 4);
                    switch (selectBomb)
                    {
                        case (0):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionOne(loc, scale, explosionId));
                            break;
                        case (1):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionTwo(loc, scale, explosionId));
                            break;
                        case (2):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionThree(loc, scale, explosionId));
                            break;
                        case (3):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionFour(loc, scale, explosionId));
                            break;
                        case (4):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionFive(loc, scale, explosionId));
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        public void removeItem(int instance)
        {
            itemList.Remove(instance);
            projectileListSize--;
            if (projectileListSize == 0)
            {
                projectileId = 0;
            }
        }

        public void removeExplosion(int instance)
        {
            explosionList.Remove(instance);
            explosionListSize--;
            if (explosionListSize == 0)
            {
                explosionId = 0;
            }
        }

        private void UpdateProjectiles()
        {
            spamCounter--;
            if (spamCounter <= 0)
            {
                spamLock = false;
            }
            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
            {
                if (item.Value.IsExpired)
                {
                    if (item.Value.Instance == swordInstance)
                    {
                        swordLock = false;
                    }
                    if (item.Value.Instance == boomerangInstance)
                    {
                        boomerangLock = false;
                    }
                    

                    deletable.Add(item.Value.Instance);
                }
            }
            foreach (int index in deletable)
            {
                this.removeItem(index);
            }
            deletable.Clear();
            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
            {
                item.Value.Update();
            }
        }

        private void UpdateExplosions()
        {
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                if (explosion.Value.IsExpired)
                {
                    explosionDeletable.Add(explosion.Value.Instance);
                }
            }
            foreach (int index in explosionDeletable)
            {
                this.removeExplosion(index);
            }
            explosionDeletable.Clear();
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                explosion.Value.Update();
            }
        }

        public void Update()
        {
            this.UpdateProjectiles();
            this.UpdateExplosions();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
            {
                item.Value.Draw(spritebatch);
            }
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                explosion.Value.Draw(spritebatch);
            }
        }

        public void Clear()
        {
            this.itemList = new Dictionary<int, IProjectile>();
            this.explosionList = new Dictionary<int, IProjectile>();
            this.explosionDeletable = new List<int>();
            this.deletable = new List<int>();
            this.projectileId = 0;
            this.explosionId = 0;
            this.explosionListSize = 0;
            this.projectileListSize = 0;
        }
    }
}
