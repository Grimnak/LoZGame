namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class IdleKeeseState : KeeseEssentials, IEnemyState
    {
        public IdleKeeseState(IEnemy enemy)
        {
            Console.WriteLine("KeeseStaate: Started Construction");
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            Console.WriteLine("KeeseStaate: Finished Construction");
        }

        public override void Update()
        {
            Console.WriteLine("KeeseState: Attempted to Update to New State");
            this.Enemy.UpdateState();
            Console.WriteLine("KeeseState: Updated State Successfully");
        }
    }
}
