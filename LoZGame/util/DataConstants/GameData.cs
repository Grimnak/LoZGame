﻿namespace LoZClone
{
    public class GameData
    {
        private static readonly GameData InstanceValue = new GameData();

        public static GameData Instance => InstanceValue;

        public CollisionConstants CollisionConstants { get; }

        public InventoryConstants InventoryConstants { get; }

        public PlayerConstants PlayerConstants { get; }

        public ProjectileDamageConstants ProjectileDamageConstants { get; }

        public ProjectileSpeedConstants ProjectileSpeedConstants { get; }

        public ProjectileMassConstants ProjectileMassConstants { get; }

        public EnemyDamageConstants EnemyDamageConstants { get; }

        public EnemyHealthConstants EnemyHealthConstants { get; }

        public EnemySpeedConstants EnemySpeedConstants { get; }

        public EnemyMassConstants EnemyMassConstants { get; }

        public EnemyMiscConstants EnemyMiscConstants { get; }

        public EnemyStateWeights EnemyStateWeights { get; }
    }
}