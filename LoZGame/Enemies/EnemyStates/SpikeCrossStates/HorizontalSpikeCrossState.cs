namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class HorizontalSpikeCrossState : SpikeCrossEssentials, IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly ISprite sprite;

        public HorizontalSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.Physics.MovementVelocity = new Vector2(1 * spikeCross.MoveSpeed, 0);
            this.sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
        }

        public override void Stop()
        {
            this.spikeCross.CurrentState = new IdleSpikeCrossState(this.spikeCross);
        }

        public void Update()
        {
            this.spikeCross.Physics.Move();
            retreatCheckHorizontal();
        }
    }
}