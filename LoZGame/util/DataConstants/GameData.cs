namespace LoZClone
{
    public class GameData
    {
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

        private static readonly GameData InstanceValue = new GameData();

        public static GameData Instance => InstanceValue;

        public void LoadAllData()
        {
            playerConstants = PlayerConstants;
            projectileDmgConstants = ProjectileDamageConstants;
            projectileSpdConstants = ProjectileSpeedConstants;
            projectileMassConstants = ProjectileMassConstants;
            enemyDamageConstants = EnemyDamageConstants;
            enemyHealthConstants = EnemyHealthConstants;
            enemySpdConstants = EnemySpeedConstants;
            enemyMassConstants = EnemyMassConstants;
            enemyMiscConstants = EnemyMiscConstants;
            enemyStateWeights = EnemyStateWeights;
        }
    }
}