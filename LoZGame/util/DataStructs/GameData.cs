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
        private static EnemyDamageData enemyDamageData;
        private static EnemySpeedData enemySpdData;
        private static EnemyMassData enemyMassData;
        private static EnemyResistanceData enemyResData;

        public PlayerData PlayerData => playerData;

        public ProjectileDamageData ProjectileDamageData => projectileDmgData;

        public ProjectileSpeedData ProjectileSpeedData => projectileSpdData;

        public ProjectileMassData ProjectileMassData => projectileMassData;

        public EnemyDamageData EnemyDamageData => enemyDamageData;

        public EnemySpeedData EnemySpeedData => enemySpdData;

        public EnemyMassData EnemyMassData => enemyMassData;

        public EnemyResistanceData EnemyResistanceData => enemyResData;


        private static readonly GameData InstanceValue = new GameData();

        public static GameData Instance => InstanceValue;

        public void LoadAllData()
        {
            playerData = default;
            projectileDmgData = default;
            projectileSpdData = default;
            projectileMassData = default;
            enemyDamageData = default;
            enemySpdData = default;
            enemyMassData = default;
            enemyResData = default;
        }
    }
}