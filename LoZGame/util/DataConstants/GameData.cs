namespace LoZClone
{
    public class GameData
    {
        private static readonly GameData InstanceValue = new GameData();
        private static PlayerConstants playerConstants;
        private static ProjectileDamageConstants projectileDmgConstants;
        private static ProjectileSpeedConstants projectileSpdConstants;
        private static ProjectileMassConstants projectileMassConstants;
        private static EnemyDamageConstants enemyDamageConstants;
        private static EnemyHealthConstants enemyHealthConstants;
        private static EnemySpeedConstants enemySpdConstants;
        private static EnemyMassConstants enemyMassConstants;
        private static EnemyMiscConstants enemyMiscConstants;
        private static EnemyStateWeights enemyStateWeights;

        public static GameData Instance => InstanceValue;

        public PlayerConstants PlayerConstants => playerConstants;

        public ProjectileDamageConstants ProjectileDamageConstants => projectileDmgConstants;

        public ProjectileSpeedConstants ProjectileSpeedConstants => projectileSpdConstants;

        public ProjectileMassConstants ProjectileMassConstants => projectileMassConstants;

        public EnemyDamageConstants EnemyDamageConstants => enemyDamageConstants;

        public EnemyHealthConstants EnemyHealthConstants => enemyHealthConstants;

        public EnemySpeedConstants EnemySpeedConstants => enemySpdConstants;

        public EnemyMassConstants EnemyMassConstants => enemyMassConstants;

        public EnemyMiscConstants EnemyMiscConstants => enemyMiscConstants;

        public EnemyStateWeights EnemyStateWeights => enemyStateWeights;
    }
}