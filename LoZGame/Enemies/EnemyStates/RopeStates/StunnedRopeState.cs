namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly IEnemyState oldState;
        private int stunDuration;

        public StunnedRopeState(Rope rope, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.rope = rope;
            stunDuration = stunTime;
            rope.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.rope.CurrentState = new DeadRopeState(this.rope);
        }

        public void Stun(int stunTime)
        {
            stunDuration = stunTime;
        }

        public void Update()
        {
            stunDuration--;
            if (stunDuration <= 0)
            {
                this.rope.CurrentState = oldState;
            }
        }

        public void Draw()
        {
            this.oldState.Draw();
        }
    }
}