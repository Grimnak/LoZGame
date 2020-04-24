namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class GameStateEssentials : IGameState
    {
        private int transitionSpeed;
        private int lockout;

        /// <inheritdoc></inheritdoc>
        public virtual void Death()
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void OpenInventory()
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void CloseInventory()
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void PlayGame()
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void TitleScreen()
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void TransitionRoom(Physics.Direction direction)
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void WinGame()
        {
        }

        public virtual void Pause()
        {
        }

        public virtual void Unpause()
        {
        }

        public virtual void Options()
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void Update()
        {
        }

        /// <inheritdoc></inheritdoc>
        public virtual void Draw()
        {
        }

        public virtual void CreditsScreen()
        {
        }
    }
}