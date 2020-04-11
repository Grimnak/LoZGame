namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDodongoState : DodongoEssentals, IEnemyState
    {
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int attackDuration;

        public AttackingDodongoState(IEnemy enemy, IEnemyState oldState)
        {
            this.Enemy = enemy;
            this.oldState = oldState;
            this.oldVelocity = this.Enemy.Physics.MovementVelocity;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Sprite.SetFrame(GameData.Instance.EnemySpeedData.DodongoMaxFrame);
            attackDuration = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(0, this.Enemy.MoveSpeed);
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
                attackDuration--;
                if (attackDuration <= 0)
                {
                    this.Enemy.Physics.MovementVelocity = this.oldVelocity;
                    this.Enemy.CurrentState = this.oldState;
                    this.Enemy.TakeDamage(GameData.Instance.ProjectileDamageData.BombDodongoDamage);
                }
            }
        }
    }
}