namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedDodongoState : DodongoEssentals, IEnemyState
    {
        private int stunDuration;

        public StunnedDodongoState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Sprite.SetFrame(GameData.Instance.EnemySpeedData.DodongoMaxFrame);
            stunDuration = GameData.Instance.EnemySpeedData.DirectionChange / 2;
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
            if (Sprite.CurrentFrame < GameData.Instance.EnemySpeedData.DodongoMaxFrame - 1)
            {
                Sprite.Update();
            }
            else
            {
                stunDuration--;
                if (stunDuration <= 0)
                {
                    this.Enemy.UpdateState();
                    this.Enemy.TakeDamage(GameData.Instance.ProjectileDamageData.BombDodongoDamage);
                }
            }
        }
    }
}
