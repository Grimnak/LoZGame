namespace LoZClone
{
    using Microsoft.Xna.Framework;

    class SpawnDarknutState : DarknutEssentials, IEnemyState
    {
        private int spawnTimer = 0;
        private int spawnTimerMax;

        public SpawnDarknutState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = EnemySpriteFactory.Instance.CreateEnemySpawn();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            this.spawnTimerMax = GameData.Instance.EnemyMiscConstants.SpawnTimerMaximum;
            this.Enemy.IsSpawning = true;
        }

        public override void Update()
        {
            this.spawnTimer++;
            this.Sprite.Update();
            if (spawnTimer >= spawnTimerMax)
            {
                this.Enemy.IsSpawning = false;
                this.Enemy.UpdateState();
            }
        }
    }
}
