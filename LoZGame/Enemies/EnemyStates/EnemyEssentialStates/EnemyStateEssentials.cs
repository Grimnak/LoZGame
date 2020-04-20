namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static RandomStateGenerator;
    using static EnemyEssentials;

    public partial class EnemyStateEssentials
    {
        public ISprite Sprite { get; set; }

        public int DirectionChange { get; set; }

        public int Lifetime { get; set; }

        public IEnemy Enemy { get; set; }

        private bool isMoving = false;

        private List<EnemyNames> spawnBlackList = new List<EnemyNames>()
        {
            EnemyNames.NoAI,
            EnemyNames.Dragon,
            EnemyNames.Firesnakehead,
        };

        public virtual void MoveLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
            this.Enemy.CurrentState = new LeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
            this.Enemy.CurrentState = new RightMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUp()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDown()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUpLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpLeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUpRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpRightMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDownLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownLeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDownRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownRightMovingEnemyState(this.Enemy);
        }

        public virtual void Attack()
        {
            this.Enemy.Attack();
        }

        public virtual void Stop()
        {
            this.Enemy.CurrentState = new IdleEnemyState(this.Enemy);
        }

        public virtual void Die()
        {
            if (this.Enemy.IsDead)
            {
                this.Enemy.CurrentState = new DeadEnemyState(this.Enemy);
            }
        }

        public virtual void Spawn()
        {
            if (!this.spawnBlackList.Contains(this.Enemy.EnemyName))
            {
                this.Enemy.CurrentState = new SpawnEnemyState(this.Enemy);
            }
        }

        public virtual void Stun(int stunTime)
        {
            if (!(this.Enemy.IsSpawning || this.Enemy.IsDead))
            {
                this.Enemy.CurrentState = new StunnedEnemyState(this.Enemy, this.Enemy.CurrentState, stunTime);
            }
        }

        public void DefaultUpdate()
        {
            this.Lifetime++;
            this.Sprite.Update();
            if (this.Lifetime > this.DirectionChange)
            {
                this.Enemy.UpdateState();
                this.Lifetime = 0;
            }
        }

        public virtual void Update()
        {
            switch (this.Enemy.EnemyName)
            {
                case EnemyNames.Darknut:
                    UpdateDarknut();
                    break;
                case EnemyNames.Dodongo:
                    UpdateDodongo();
                    break;
                case EnemyNames.Firesnakehead:
                    UpdateFireSnake();
                    break;
                case EnemyNames.Gel:
                    UpdateGel();
                    break;
                case EnemyNames.Goriya:
                    UpdateGoriya();
                    break;
                case EnemyNames.Keese:
                    UpdateKeese();
                    break;
                case EnemyNames.Rope:
                    UpdateRope();
                    break;
                case EnemyNames.Stalfos:
                    UpdateStalfos();
                    break;
                case EnemyNames.WallMaster:
                    UpdateWallMaster();
                    break;
                case EnemyNames.Zol:
                    UpdateZol();
                    break;
                case EnemyNames.NoAI:
                    break;
                case EnemyNames.Likelike:
                    UpdateLikelike();
                    break;
                default:
                    DefaultUpdate();
                    break;
            }
        }

        public virtual void Draw()
        {
            this.Sprite.Draw(this.Enemy.Physics.Location, this.Enemy.CurrentTint, this.Enemy.Physics.Depth);
        }
    }
}