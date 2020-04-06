namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : IGameState
    {
        private LevelOneMasterSprite sprite;
        private string direction;
        private int transitionSpeed;
        private int lockout;

        public TransitionRoomState(string direction)
        {
            this.direction = direction;
            this.lockout = 0;
            this.transitionSpeed = 5;
            this.sprite = CreateCorrectLevelSprite();
        }

        /// <inheritdoc></inheritdoc>
        public void Death()
        {
            // Can't die in a transition.
        }

        /// <inheritdoc></inheritdoc>
        public void OpenInventory()
        {
            // Can't access inventory while transitioning rooms.
        }

        /// <inheritdoc></inheritdoc>
        public void CloseInventory()
        {
            // Can't close inventory when it's not open.
        }

        /// <inheritdoc></inheritdoc>
        public void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public void TransitionRoom(string direction)
        {
            // Can't go to a state you are already in.
        }

        /// <inheritdoc></inheritdoc>
        public void WinGame()
        {
            // Can't win in a transition.
        }

        /// <inheritdoc></inheritdoc>
        public void Update()
        {
            this.lockout += this.transitionSpeed;
            switch (this.direction)
            {
                case "Up":
                    if (this.lockout < LoZGame.Instance.GraphicsDevice.Viewport.Height)
                    {
                        this.sprite.Update(this.direction, this.transitionSpeed);
                    }
                    else
                    {
                        LoZGame.Instance.Dungeon.MoveUp();
                        LoZGame.Instance.GameState.PlayGame();
                    }
                    break;

                case "Down":
                    if (this.lockout < LoZGame.Instance.GraphicsDevice.Viewport.Height)
                    {
                        this.sprite.Update(this.direction, this.transitionSpeed);
                    }
                    else
                    {
                        LoZGame.Instance.Dungeon.MoveDown();
                        LoZGame.Instance.GameState.PlayGame();
                    }
                    break;

                case "Left":
                    if (this.lockout < LoZGame.Instance.GraphicsDevice.Viewport.Width)
                    {
                        this.sprite.Update(this.direction, this.transitionSpeed);
                    }
                    else
                    {
                        LoZGame.Instance.Dungeon.MoveLeft();
                        LoZGame.Instance.GameState.PlayGame();
                    }
                    break;

                case "Right":
                    if (this.lockout < LoZGame.Instance.GraphicsDevice.Viewport.Width)
                    {
                        this.sprite.Update(this.direction, this.transitionSpeed);
                    }
                    else
                    {
                        LoZGame.Instance.Dungeon.MoveRight();
                        LoZGame.Instance.GameState.PlayGame();
                    }
                    break;

                default:
                    break;
            }
        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            this.sprite.Draw(LoZGame.Instance.DungeonTint);
        }

        private LevelOneMasterSprite CreateCorrectLevelSprite()
        {
            return ScreenSpriteFactory.Instance.CreateLevelOneMaster();
        }
    }
}