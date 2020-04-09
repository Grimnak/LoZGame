namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class GameData
    {
        private static PlayerData playerData;
        private static ProjectileDamageData projectileDmgData;
        private static ProjectileSpeedData projectileSpdData;
        private static ProjectileMassData projectileMassData;
        private static DefaultData enemyDamageData;
        private static EnemySpeedData enemySpdData;
        private static EnemyMassData enemyMassData;
        private static EnemyResistanceData enemyResData;
        private static EnemyMiscData enemyMiscData;

        public PlayerData PlayerData => playerData;

        public ProjectileDamageData ProjectileDamageData => projectileDmgData;

        public ProjectileSpeedData ProjectileSpeedData => projectileSpdData;

        public ProjectileMassData ProjectileMassData => projectileMassData;

        public DefaultData EnemyDamageData => enemyDamageData;

        public EnemySpeedData EnemySpeedData => enemySpdData;

        public EnemyMassData EnemyMassData => enemyMassData;

        public EnemyResistanceData EnemyResistanceData => enemyResData;

        public EnemyMiscData EnemyMiscData => enemyMiscData;

        private static readonly GameData InstanceValue = new GameData();

        public static GameData Instance => InstanceValue;

        public void LoadAllData()
        {
            playerData = new PlayerData();
            projectileDmgData = new ProjectileDamageData();
            projectileSpdData = new ProjectileSpeedData();
            projectileMassData = new ProjectileMassData();
            enemyDamageData = new DefaultData();
            enemySpdData = new EnemySpeedData();
            enemyMassData = new EnemyMassData();
            enemyResData = new EnemyResistanceData();
            enemyMiscData = default;
        }
    }
}