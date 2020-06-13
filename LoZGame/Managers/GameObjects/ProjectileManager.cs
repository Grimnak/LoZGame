namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class ProjectileManager : IManager
    {
        private readonly Dictionary<int, IProjectile> projectileList;
        private readonly List<int> deletable;
        private List<IProjectile> projectiles;
        private int projectileId;
        private int projectileListSize;
        private bool swordLock;
        private bool spamLock;
        private bool boomerangLock;
        private bool triforceLock;
        private int candleCooldown;
        private bool candleLock;
        private int swordInstance;
        private int boomerangInstance;
        private int triforceInstance;
        private int candleInstance;
        private int spamCounter;
        private int primaryAttackCoolDown;
        private bool primaryAttackLock;

        public static int MaxWaitTime => 15;

        public List<IProjectile> Projectiles { get { return projectiles; } }

        public bool BoomerangOut => boomerangLock;

        public bool PrimaryAttackLock => primaryAttackLock;

        public bool CandleLock => candleLock;

        public ProjectileManager()
        {
            projectileList = new Dictionary<int, IProjectile>();
            projectiles = new List<IProjectile>();
            projectileId = 0;
            projectileListSize = 0;
            deletable = new List<int>();
            swordLock = false;
            boomerangLock = false;
            spamLock = false;
            triforceLock = false;
            candleLock = false;
            primaryAttackLock = false;
            swordInstance = 0;
            boomerangInstance = 0;
            spamCounter = 0;
            triforceInstance = 0;
            candleInstance = 0;
            primaryAttackCoolDown = 0;
            candleCooldown = 0;
        }

        public int Arrow => (int)ProjectileType.Arrow;

        public int SilverArrow => (int)ProjectileType.SilverArrow;

        public int Boomerang => (int)ProjectileType.Boomerang;

        public int MagicBoomerang => (int)ProjectileType.MagicBoomerang;

        public int BlueCandle => (int)ProjectileType.BlueCandle;

        public int RedCandle => (int)ProjectileType.RedCandle;

        public int Bomb => (int)ProjectileType.Bomb;

        public int Triforce => (int)ProjectileType.Triforce;

        public int Swordbeam => (int)ProjectileType.SwordBeam;

        public int WoodenSword => (int)ProjectileType.WoodenSword;

        public int SonicBeam => (int)ProjectileType.SonicBeam;

        public void AddItem(int itemType, IPlayer player)
        {
            projectileId++;
            projectileListSize++;
            ProjectileType item = (ProjectileType)itemType;
            if (item == ProjectileType.WoodenSword || item == ProjectileType.WhiteSword || item == ProjectileType.MagicSword)
            {
                primaryAttackCoolDown = 20;
                primaryAttackLock = true;
                projectileList.Add(projectileId, new SwordProjectile(player));
            }
            else if (!spamLock && !triforceLock)
            {
                spamCounter = MaxWaitTime;
                spamLock = true;
                switch (item)
                {
                    case ProjectileType.Bomb:
                        SoundFactory.Instance.PlayBombDrop();
                        projectileList.Add(projectileId, new BombProjectile(player.Physics));
                        break;

                    case ProjectileType.Arrow:
                        SoundFactory.Instance.PlayArrowOrBoomShoot();
                        projectileList.Add(projectileId, new ArrowProjectile(player.Physics));
                        break;

                    case ProjectileType.SilverArrow:
                        SoundFactory.Instance.PlayArrowOrBoomShoot();
                        projectileList.Add(projectileId, new SilverArrowProjectile(player.Physics));
                        break;

                    case ProjectileType.SonicBeam:
                        SoundFactory.Instance.PlaySwordShoot();
                        projectileList.Add(projectileId, new SonicBeamProjectile(player.Physics));
                        break;

                    case ProjectileType.RedCandle:
                        if (!candleLock)
                        {
                            SoundFactory.Instance.PlayCandleShoot();
                            projectileList.Add(projectileId, new RedCandleProjectile(player.Physics));
                            candleCooldown = LoZGame.Instance.UpdateSpeed * 15;
                            candleLock = true;
                            candleInstance = projectileId;
                            LoZGame.Instance.Dungeon.CurrentRoom.LightTimer = LoZGame.Instance.UpdateSpeed * 20;
                        }
                        break;

                    case ProjectileType.BlueCandle:
                        if (!candleLock)
                        {
                            SoundFactory.Instance.PlayCandleShoot();
                            projectileList.Add(projectileId, new BlueCandleProjectile(player.Physics));
                            candleCooldown = LoZGame.Instance.UpdateSpeed * 25;
                            candleLock = true;
                            candleInstance = projectileId;
                            LoZGame.Instance.Dungeon.CurrentRoom.LightTimer = LoZGame.Instance.UpdateSpeed * 20;
                        }
                        break;

                    case ProjectileType.Boomerang:
                        if (!boomerangLock)
                        {
                            projectileList.Add(projectileId, new BoomerangProjectile(player.Physics));
                            SoundFactory.Instance.PlayArrowOrBoomShoot();
                            boomerangLock = true;
                            boomerangInstance = projectileId;
                        }

                        break;

                    case ProjectileType.MagicBoomerang:
                        if (!boomerangLock)
                        {
                            projectileList.Add(projectileId, new MagicBoomerangProjectile(player.Physics));
                            SoundFactory.Instance.PlayArrowOrBoomShoot();
                            boomerangLock = true;
                            boomerangInstance = projectileId;
                        }

                        break;

                    case ProjectileType.SwordBeam:
                        if (!swordLock)
                        {
                            SoundFactory.Instance.PlaySwordShoot();
                            projectileList.Add(projectileId, new SwordBeamProjectile(player.Physics));
                            swordLock = true;
                            swordInstance = projectileId;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void RemoveItem(int instance)
        {
            projectileList.Remove(instance);
            projectileListSize--;
            if (projectileListSize == 0)
            {
                projectileId = 0;
            }
        }

        public void Update()
        {
            if (spamCounter <= 0)
            {
                spamLock = false;
            }
            else
            {
                spamCounter--;
            }
            if (primaryAttackCoolDown <= 0)
            {
                primaryAttackLock = false;
            }
            else
            {
                primaryAttackCoolDown--;
            }
            if (candleCooldown <= 0)
            {
                candleLock = false;
            }
            else
            {
                candleCooldown--;
            }

            foreach (KeyValuePair<int, IProjectile> item in projectileList)
            {
                if (item.Value.IsExpired)
                {
                    if (item.Key == swordInstance)
                    {
                        swordLock = false;
                    }

                    if (item.Key == boomerangInstance)
                    {
                        boomerangLock = false;
                    }

                    if (item.Key == triforceInstance)
                    {
                        triforceLock = false;
                    }

                    if (item.Key == candleInstance && candleCooldown <= 0)
                    {
                        candleLock = false;
                    }

                    deletable.Add(item.Key);
                }
            }

            foreach (int index in deletable)
            {
                RemoveItem(index);
            }

            projectiles.Clear();
            deletable.Clear();

            foreach (KeyValuePair<int, IProjectile> item in projectileList)
            {
                projectiles.Add(item.Value);
                item.Value.Update();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IProjectile> item in projectileList)
            {
                item.Value.Draw();
            }
        }

        public void Clear()
        {
            projectileList.Clear();
        }
    }
}