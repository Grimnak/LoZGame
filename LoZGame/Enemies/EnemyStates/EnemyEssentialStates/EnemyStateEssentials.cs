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
            EnemyAI.MoldormHead,
            EnemyAI.Manhandla,
            EnemyAI.GleeokHead,
            EnemyAI.ManHandlaHead,
            EnemyAI.SmallDigDogger,
            EnemyAI.LargeDigDogger,
            EnemyAI.Gohma,
            EnemyAI.Segment,
            EnemyAI.MiniPatra,
            EnemyAI.NoSpawn
        };

        public void DefaultUpdate()
        {
            Lifetime++;
            Sprite.Update();
            if (Lifetime > DirectionChange && !Enemy.Physics.IsJumping)
            {
                Enemy.UpdateState();
                Lifetime = 0;
            }
        }

        public virtual void Update()
        {
            switch (Enemy.AI)
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
                case EnemyAI.MoldormHead:
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
                case EnemyAI.Patra:
                    UpdatePatra();
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
                    UpdateGleeokHeadOff();
                    break;
                case EnemyAI.GleeokHead:
                    UpdateGleeok();
                    break;
                case EnemyAI.SpikeCross:
                    UpdateSpikeCross();
                    break;
                case EnemyAI.SmallDigDogger:
                    UpdateSmallDigDogger();
                    break;
                case EnemyAI.LargeDigDogger:
                    UpdateLargeDigDogger();
                    break;
                case EnemyAI.Likelike:
                    UpdateLikelike();
                    break;
                case EnemyAI.RedWizzrobe:
                    UpdateRedWizzrobe();
                    break;
                case EnemyAI.BlueWizzrobe:
                    UpdateBlueWizzrobe();
                    break;
                case EnemyAI.NoAI:
                case EnemyAI.Segment:
                    break;
                default:
                    DefaultUpdate();
                    break;
            }
        }

        public virtual void Draw()
        {
            Sprite.Draw(Enemy.Physics.Location, Enemy.CurrentTint, Enemy.Physics.Depth);
        }
    }
}