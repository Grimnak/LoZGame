namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class ProjectileManager
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
        private bool candleLock;
        private int swordInstance;
        private int boomerangInstance;
        private int triforceInstance;
        private int candleInstance;
        private int spamCounter;
        private int primaryAttackCoolDown;
        private bool primaryAttackLock;

        public static int MaxWaitTime => 30;

        public List<IProjectile> Projectiles { get { return this.projectiles; } }

        public bool BoomerangOut => this.boomerangLock;

        public bool FlameInUse => this.candleLock;

        public bool PrimaryAttackLock => primaryAttackLock;

        public ProjectileManager()
        {
            this.projectileList = new Dictionary<int, IProjectile>();
            this.projectiles = new List<IProjectile>();
            this.projectileId = 0;
            this.projectileListSize = 0;
            this.deletable = new List<int>();
            this.swordLock = false;
            this.boomerangLock = false;
            this.spamLock = false;
            this.triforceLock = false;
            this.candleLock = false;
            this.primaryAttackLock = false;
            this.swordInstance = 0;
            this.boomerangInstance = 0;
            this.spamCounter = 0;
            this.triforceInstance = 0;
            this.candleInstance = 0;
            this.primaryAttackCoolDown = 0;
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

        public void AddItem(int itemType, IPlayer player)
        {
            this.projectileId++;
            this.projectileListSize++;
            ProjectileType item = (ProjectileType)itemType;
            if (item == ProjectileType.WoodenSword /*|| item == ProjectileType.WhiteSword || item == ProjectileType.MagicSword*/)
            {
                this.primaryAttackCoolDown = 20;
                this.primaryAttackLock = true;
                switch (item)
                {
                    case ProjectileType.WoodenSword:
                        this.projectileList.Add(this.projectileId, new WoodenSwordProjectile(player));
                        break;
                    default:
                        break;
                }
            }
            else if (!this.spamLock && !this.triforceLock)
            {
                this.spamCounter = MaxWaitTime;
                this.spamLock = true;
                switch (item)
                {
                    case ProjectileType.Bomb:
                        this.projectileList.Add(this.projectileId, new BombProjectile(player.Physics.Location, player.CurrentDirection));
                        break;

                    case ProjectileType.Arrow:
                        this.projectileList.Add(this.projectileId, new ArrowProjectile(player.Physics.Location, player.CurrentDirection));
                        break;

                    case ProjectileType.SilverArrow:
                        this.projectileList.Add(this.projectileId, new SilverArrowProjectile(player.Physics.Location, player.CurrentDirection));
                        break;

                    case ProjectileType.RedCandle:
                        this.projectileList.Add(this.projectileId, new RedCandleProjectile(player.Physics.Location, player.CurrentDirection));
                        break;

                    case ProjectileType.BlueCandle:
                        if (!this.candleLock)
                        {
                            this.projectileList.Add(this.projectileId, new BlueCandleProjectile(player.Physics.Location, player.CurrentDirection));
                            this.candleLock = true;
                            this.candleInstance = this.projectileId;
                        }
                        break;

                    case ProjectileType.Boomerang:
                        if (!this.boomerangLock)
                        {
                            this.projectileList.Add(this.projectileId, new BoomerangProjectile(player));
                            this.boomerangLock = true;
                            this.boomerangInstance = this.projectileId;
                        }

                        break;

                    case ProjectileType.MagicBoomerang:
                        if (!this.boomerangLock)
                        {
                            this.projectileList.Add(this.projectileId, new MagicBoomerangProjectile(player));
                            this.boomerangLock = true;
                            this.boomerangInstance = this.projectileId;
                        }

                        break;

                    case ProjectileType.SwordBeam:
                        if (!this.swordLock)
                        {
                            this.projectileList.Add(this.projectileId, new SwordBeamProjectile(player));
                            this.swordLock = true;
                            this.swordInstance = this.projectileId;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void RemoveItem(int instance)
        {
            this.projectileList.Remove(instance);
            this.projectileListSize--;
            if (this.projectileListSize == 0)
            {
                this.projectileId = 0;
            }
        }

        public void Update()
        {
            if (this.spamCounter <= 0)
            {
                this.spamLock = false;
            }
            else
            {
                this.spamCounter--;
            }
            if (this.primaryAttackCoolDown <= 0)
            {
                this.primaryAttackLock = false;
            }
            else
            {
                this.primaryAttackCoolDown--;
            }

            foreach (KeyValuePair<int, IProjectile> item in this.projectileList)
            {
                if (item.Value.IsExpired)
                {
                    if (item.Key == this.swordInstance)
                    {
                        this.swordLock = false;
                    }

                    if (item.Key == this.boomerangInstance)
                    {
                        this.boomerangLock = false;
                    }

                    if (item.Key == this.triforceInstance)
                    {
                        this.triforceLock = false;
                    }

                    if (item.Key == this.candleInstance)
                    {
                        this.candleLock = false;
                    }

                    this.deletable.Add(item.Key);
                }
            }

            foreach (int index in this.deletable)
            {
                this.RemoveItem(index);
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
            foreach (KeyValuePair<int, IProjectile> item in this.projectileList)
            {
                item.Value.Draw();
            }
        }
    }
}