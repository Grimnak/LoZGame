namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpawnEnemyState : EnemyStateEssentials, IEnemyState
    {
        private int spawnTimer = 0;
        private int spawnTimerMax;

        public SpawnEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = EnemySpriteFactory.Instance.CreateEnemySpawn();
            Enemy.CurrentState = this;
            Enemy.Physics.MovementVelocity = Vector2.Zero;
            spawnTimerMax = GameData.Instance.EnemyMiscConstants.SpawnTimerMaximum;
            Enemy.IsSpawning = true;
        }

        public override void Update()
        {
            spawnTimer++;
            Sprite.Update();
            if (spawnTimer >= spawnTimerMax)
            {
                Enemy.IsSpawning = false;
                Enemy.UpdateState();
            }
        }

        public override void Stun(int stunTime)
        {
        }
    }
}
