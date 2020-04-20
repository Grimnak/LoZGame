namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class VerticalSpikeCrossState : SpikeCrossEssentials, IEnemyState
    {

        public VerticalSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.Physics.MovementVelocity = new Vector2(0, 1 * spikeCross.MoveSpeed);
        }

        public override void Stop()
        {
            this.spikeCross.CurrentState = new IdleSpikeCrossState(this.spikeCross);
        }

        public void Update()
        {
            this.spikeCross.Physics.Move();
            retreatCheckVertical();
        }
    }
}