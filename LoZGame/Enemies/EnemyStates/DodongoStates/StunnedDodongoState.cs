namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedDodongoState : DodongoEssentials, IEnemyState
    {
        private int stunDuration;

        public StunnedDodongoState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Sprite.SetFrame(GameData.Instance.EnemyMiscConstants.DodongoMaximumFrame);
            stunDuration = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
            if (Sprite.CurrentFrame < GameData.Instance.EnemyMiscConstants.DodongoMaximumFrame - 1)
            {
                Sprite.Update();
            }
            else
            {
                stunDuration--;
                if (stunDuration <= 0)
                {
                    this.Enemy.UpdateState();
                    this.Enemy.TakeDamage(GameData.Instance.ProjectileDamageConstants.BombDodongoDamage);
                }
            }
        }
    }
}