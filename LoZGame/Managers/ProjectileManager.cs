namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;

    public partial class ProjectileManager
    {
        private readonly ExplosionManager explosion;
        private readonly Dictionary<int, IProjectile> itemList;
        private readonly List<int> deletable;
        private readonly int scale;
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

        public static int MaxWaitTime => 30;

        public bool BoomerangOut => this.boomerangLock;

        public bool FlameInUse => this.candleLock;

        public ProjectileManager(ExplosionManager explosion)
        {
            this.itemList = new Dictionary<int, IProjectile>();
            this.projectileId = 0;
            this.projectileListSize = 0;
            this.scale = (int)ProjectileSpriteFactory.Instance.Scale;
            this.deletable = new List<int>();
            this.swordLock = false;
            this.boomerangLock = false;
            this.spamLock = false;
            this.triforceLock = false;
            this.candleLock = false;
            this.swordInstance = 0;
            this.boomerangInstance = 0;
            this.spamCounter = 0;
            this.triforceInstance = 0;
            this.candleInstance = 0;
            this.explosion = explosion;
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

        public void AddItem(int itemType, IPlayer player)
        {
            this.projectileId++;
            this.projectileListSize++;
            ProjectileType item = (ProjectileType)itemType;
            if (!this.spamLock && !this.triforceLock)
            {
                this.spamCounter = MaxWaitTime;
                this.spamLock = true;
                switch (item)
                {
                    case ProjectileType.Bomb:
                        this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.Bomb(player.CurrentLocation, player.CurrentDirection, this.scale, this.projectileId, this.explosion));
                        break;

                    case ProjectileType.Triforce:
                        this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.Triforce(player.CurrentLocation, this.scale, this.projectileId));
                        this.triforceLock = true;
                        this.triforceInstance = this.projectileId;
                        break;

                    case ProjectileType.Arrow:
                        this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.Arrow(player.CurrentLocation, player.CurrentDirection, this.scale, this.projectileId));
                        break;

                    case ProjectileType.SilverArrow:
                        this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.SilverArrow(player.CurrentLocation, player.CurrentDirection, this.scale, this.projectileId));
                        break;

                    case ProjectileType.RedCandle:
                        this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.RedCandle(player.CurrentLocation, player.CurrentDirection, this.scale, this.projectileId));
                        break;

                    case ProjectileType.BlueCandle:
                        if (!this.candleLock)
                        {
                            this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.BlueCandle(player.CurrentLocation, player.CurrentDirection, this.scale, this.projectileId));
                            this.candleLock = true;
                            this.candleInstance = this.projectileId;
                        }

                        break;

                    case ProjectileType.Boomerang:
                        if (!this.boomerangLock)
                        {
                            this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.Boomerang(player, this.scale, this.projectileId));
                            this.boomerangLock = true;
                            this.boomerangInstance = this.projectileId;
                        }

                        break;

                    case ProjectileType.MagicBoomerang:
                        if (!this.boomerangLock)
                        {
                            this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.MagicBoomerang(player, this.scale, this.projectileId));
                            this.boomerangLock = true;
                            this.boomerangInstance = this.projectileId;
                        }

                        break;

                    case ProjectileType.SwordBeam:
                        if (!this.swordLock)
                        {
                            this.itemList.Add(this.projectileId, ProjectileSpriteFactory.Instance.SwordBeam(player, this.scale, this.projectileId, this.explosion));
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
            this.itemList.Remove(instance);
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

            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
            {
                if (item.Value.IsExpired)
                {
                    if (item.Value.Instance == this.swordInstance)
                    {
                        this.swordLock = false;
                    }

                    if (item.Value.Instance == this.boomerangInstance)
                    {
                        this.boomerangLock = false;
                    }

                    if (item.Value.Instance == this.triforceInstance)
                    {
                        this.triforceLock = false;
                    }

                    if (item.Value.Instance == this.candleInstance)
                    {
                        this.candleLock = false;
                    }

                    this.deletable.Add(item.Value.Instance);
                }
            }

            foreach (int index in this.deletable)
            {
                this.RemoveItem(index);
            }

            this.deletable.Clear();
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