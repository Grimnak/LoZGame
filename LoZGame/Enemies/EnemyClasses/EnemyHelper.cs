namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class EnemyEssentials
    {
        public enum EnemyAI
        {
            Bubble,
            Darknut,
            Dodongo,
            Dragon,
            MoldormHead,
            Gel,
            GleeokHead,
            GleeokHeadOff,
            Gibdo,
            Goriya,
            Keese,
            Oldman,
            Rope,
            SpikeCross,
            Stalfos,
            Vire,
            VireKeese,
            WallMaster,
            Zol,
            Manhandla,
            ManHandlaHead,
            NoSpawn,
            None,
            Likelike,
            PolsVoice,
            LargeDigDogger,
            SmallDigDogger,
            RedWizzrobe,
            BlueWizzrobe,
            Gohma,
            Segment,
            Patra,
            MiniPatra,
            NoAI
        }

        private Point minMaxWander = new Point(LoZGame.Instance.UpdateSpeed / 2, (LoZGame.Instance.UpdateSpeed * 3) / 2);

        private bool isDead = false;

        private bool isSpawning = false;

        private bool isKillable = true;

        private bool isTransparent = false;

        private bool isInvisible = false;
      
        private EnemyAI Name = EnemyAI.None;

        private List<Tuple<DropManager.DropType, int, int, int>> dropTable;

        public Point SpawnPoint => Point.Zero;

        public Dictionary<RandomStateGenerator.StateType, int> States { get; set; }

        public EnemyCollisionHandler EnemyCollisionHandler { get; set; }

        public RandomStateGenerator RandomStateGenerator { get; set; }

        public IEnemyState CurrentState { get; set; }

        public bool HasChild { get; set; }

        public bool IsSpawning { get { return isSpawning; } set { isSpawning = value; } }

        public bool Expired { get; set; }

        public bool IsDead { get { return isDead; } set { isDead = value; } }

        public bool IsKillable { get { return isKillable; } set { isKillable = value; } }

        public bool IsTransparent { get { return isTransparent; } set { isTransparent = value; } }

        public bool IsInvisible { get { return isInvisible; } set { isInvisible = value; } }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public Color CurrentTint { get; set; }

        public float MoveSpeed { get; set; }

        public int Damage { get; set; }

        public int DamageTimer { get; set; }

        public Point MinMaxWander { get { return minMaxWander; } set { minMaxWander = value; } }

        public EnemyAI AI { get { return Name; } set { Name = value; } }

        public List<Tuple<DropManager.DropType, int, int, int>> DropTable { get { return dropTable; } set { dropTable = value; } }
    }
}