namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IEnemyState
    {
        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();

        void MoveUpLeft();

        void MoveDownLeft();

        void MoveUpRight();

        void MoveDownRight();

        void JumpLeft();

        void JumpRight();

        void JumpUp();

        void JumpDown();

        void JumpUpLeft();

        void JumpDownLeft();

        void JumpUpRight();

        void JumpDownRight();

        void Attack();

        void Stop();

        void Spawn();

        void Die();

        void Stun(int stunTime);

        void Update();

        void Draw();
    }
}