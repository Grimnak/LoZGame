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
        private ExplosionManager explosion;
        private Dictionary<int, IProjectile> itemList;
        private List<int> deletable;
        private int scale;
        private int projectileId, projectileListSize;
        private bool swordLock, spamLock, boomerangLock, triforceLock;
        private int swordInstance, boomerangInstance, triforceInstance, spamCounter;
        public static int MaxWaitTime { get { return 30; } }

        public bool BoomerangOut { get { return boomerangLock; } }

        public ProjectileManager(ExplosionManager explosion)
        {
            this.itemList = new Dictionary<int, IProjectile>();
            this.projectileId = 0;
            this.projectileListSize = 0;
            this.scale = (int)ProjectileSpriteFactory.Instance.Scale;
            deletable = new List<int>();
            swordLock = false;
            boomerangLock = false;
            spamLock = false;
            triforceLock = false;
            swordInstance = 0;
            boomerangInstance = 0;
            spamCounter = 0;
            triforceInstance = 0;
            this.explosion = explosion;
        }

        public int Arrow { get { return (int)ProjectileType.Arrow; } }
        public int SilverArrow { get { return (int)ProjectileType.SilverArrow; } }
        public int Boomerang { get { return (int)ProjectileType.Boomerang; } }
        public int MagicBoomerang { get { return (int)ProjectileType.MagicBoomerang; } }
        public int BlueCandle { get { return (int)ProjectileType.BlueCandle; } }
        public int RedCandle { get { return (int)ProjectileType.RedCandle; } }
        public int Bomb { get { return (int)ProjectileType.Bomb; } }
        public int Triforce { get { return (int)ProjectileType.Triforce; } }
        public int Swordbeam { get { return (int)ProjectileType.SwordBeam; }}
        public void addItem(int itemType, Link player)
        {
            projectileId++;
            projectileListSize++;
            ProjectileType item = (ProjectileType)itemType;
            if (!spamLock && !triforceLock)
            {
                spamCounter = MaxWaitTime;
                spamLock = true;
                switch (item)
                {
                    case (ProjectileType.Bomb):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.Bomb(player.CurrentLocation, player.CurrentDirection, scale, projectileId, explosion));
                        break;
                    case (ProjectileType.Triforce):             
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.Triforce(player.CurrentLocation, scale, projectileId));
                        triforceLock = true;
                        triforceInstance = projectileId;
                        break;
                    case (ProjectileType.Arrow):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.Arrow(player.CurrentLocation, player.CurrentDirection, scale, projectileId));
                        break;
                    case (ProjectileType.SilverArrow):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.SilverArrow(player.CurrentLocation, player.CurrentDirection, scale, projectileId));
                        break;
                    case (ProjectileType.RedCandle):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.RedCandle(player.CurrentLocation, player.CurrentDirection, scale, projectileId));
                        break;
                    case (ProjectileType.BlueCandle):
                        this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.BlueCandle(player.CurrentLocation, player.CurrentDirection, scale, projectileId));
                        break;
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
                            this.itemList.Add(projectileId, ProjectileSpriteFactory.Instance.SwordBeam(player, scale, projectileId, explosion));
                            swordLock = true;
                            swordInstance = projectileId;
                        }
                        break;
                    default:
                        break;
                }
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

        public void Update()
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
                    if (item.Value.Instance == triforceInstance)
                    {
                        triforceLock = false;
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

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
            {
                item.Value.Draw(spritebatch);
            }
        }
    }
}
