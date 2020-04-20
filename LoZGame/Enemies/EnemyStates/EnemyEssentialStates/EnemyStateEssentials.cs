namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static EnemyEssentials;
    using static RandomStateGenerator;

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
            EnemyAI.GleeokHead,
            EnemyAI.ManHandlaHead,
            EnemyAI.NoSpawn
        };

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
                case EnemyAI.GleeokHeadOff:
                case EnemyAI.GleeokHead:
                    UpdateGleeock();
                    break;
                case EnemyAI.SpikeCross:
                    UpdateSpikeCross();
                    break;
                case EnemyAI.NoAI:
                    break;
                case EnemyAI.Likelike:
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