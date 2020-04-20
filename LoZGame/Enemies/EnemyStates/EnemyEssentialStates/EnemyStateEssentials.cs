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

        private List<EnemyAI> spawnBlackList = new List<EnemyAI>()
        {
            EnemyAI.NoAI,
            EnemyAI.Dragon,
            EnemyAI.Firesnakehead,
            EnemyAI.Manhandla,
            EnemyAI.NoSpawn

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
            if (!this.spawnBlackList.Contains(this.Enemy.AI))
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
            switch (this.Enemy.AI)
            {
                case EnemyAI.Bubble:
                    UpdateBubble();
                    break;
                case EnemyAI.Darknut:
                    UpdateDarknut();
                    break;
                case EnemyAI.Dodongo:
                    UpdateDodongo();
                    break;
                case EnemyAI.Firesnakehead:
                    UpdateFireSnake();
                    break;
                case EnemyAI.Gel:
                    UpdateGel();
                    break;
                case EnemyAI.Goriya:
                    UpdateGoriya();
                    break;
                case EnemyAI.Keese:
                    UpdateKeese();
                    break;
                case EnemyAI.Rope:
                    UpdateRope();
                    break;
                case EnemyAI.Stalfos:
                    UpdateStalfos();
                    break;
                case EnemyAI.WallMaster:
                    UpdateWallMaster();
                    break;
                case EnemyAI.Zol:
                    UpdateZol();
                    break;
                case EnemyAI.Manhandla:
                    UpdateManhandla();
                    break;
                case EnemyAI.NoAI:
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