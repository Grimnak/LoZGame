namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class AttackingLikelikeState : EnemyStateEssentials, IEnemyState
    {
        public AttackingLikelikeState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            Enemy.Physics.MovementVelocity = Vector2.Zero;
        }
    }
}
