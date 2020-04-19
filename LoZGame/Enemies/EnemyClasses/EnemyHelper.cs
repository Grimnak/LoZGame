namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class EnemyEssentials
    {
        public enum EnemyNames
        {
            Goriya,
            Darknut,
            Dodongo,
            Dragon,
            Firesnakehead,
            Gel,
            Keese,
            Oldman,
            Rope,
            SpikeCross,
            Stalfos,
            Vire,
            VireKeese,
            WallMaster,
            Zol,
            None
        }

        private bool isDead = false;

        private bool isSpawning = false;

        private EnemyNames Name = EnemyNames.None;

        public Dictionary<RandomStateGenerator.StateType, int> States { get; set; }

        public EnemyCollisionHandler EnemyCollisionHandler { get; set; }

        public RandomStateGenerator RandomStateGenerator { get; set; }

        public IEnemyState CurrentState { get; set; }

        public bool HasChild { get; set; }

        public bool IsSpawning { get { return isSpawning; } set { isSpawning = value; } }

        public bool Expired { get; set; }

        public bool IsDead { get { return isDead; } set { isDead = value; } }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public Color CurrentTint { get; set; }

        public float MoveSpeed { get; set; }

        public int Damage { get; set; }

        public int DamageTimer { get; set; }

        public EnemyNames EnemyName
        {
            get { return Name; }
            set { Name = value; }
        }
    }
}