namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedDodongoState : EnemyStateEssentials, IEnemyState
    {
        private int stunDuration;

        public StunnedDodongoState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Sprite.SetFrame(GameData.Instance.EnemyMiscConstants.DodongoMaximumFrame);
            stunDuration = GameData.Instance.EnemyMiscConstants.DirectionChange;
            Enemy.CurrentState = this;
            Enemy.Physics.MovementVelocity = Vector2.Zero;
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
                    Enemy.UpdateState();
                    Enemy.TakeDamage(GameData.Instance.ProjectileDamageConstants.BombDodongoDamage);
                }
            }
        }
    }
}