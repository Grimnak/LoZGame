namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : IGameState
    {
        private LevelMasterSprite sprite;
        private Physics.Direction direction;
        private int transitionSpeed;
        private int lockout;

        public TransitionRoomState(Physics.Direction direction)
        {
            this.direction = direction;
            this.lockout = 0;
            this.transitionSpeed = 8;
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
        public void TransitionRoom(Physics.Direction direction)
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
                case Physics.Direction.North:
                    if (this.lockout < LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset)
                    {
                        this.sprite.Update(this.direction, this.transitionSpeed);
                    }
                    else
                    {
                        LoZGame.Instance.Dungeon.MoveUp();
                        LoZGame.Instance.GameState.PlayGame();
                    }
                    break;

                case Physics.Direction.South:
                    if (this.lockout < LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset)
                    {
                        this.sprite.Update(this.direction, this.transitionSpeed);
                    }
                    else
                    {
                        LoZGame.Instance.Dungeon.MoveDown();
                        LoZGame.Instance.GameState.PlayGame();
                    }
                    break;

                case Physics.Direction.West:
                    if (this.lockout < LoZGame.Instance.ScreenWidth)
                    {
                        this.sprite.Update(this.direction, this.transitionSpeed);
                    }
                    else
                    {
                        LoZGame.Instance.Dungeon.MoveLeft();
                        LoZGame.Instance.GameState.PlayGame();
                    }
                    break;

                case Physics.Direction.East:
                    if (this.lockout < LoZGame.Instance.ScreenWidth)
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
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.sprite.Draw(LoZGame.Instance.DefaultTint);
            LoZGame.Instance.SpriteBatch.End();

            // Ensure inventory objects draw above the game objects while transitioning.
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawInventoryElements();
            LoZGame.Instance.SpriteBatch.End();
        }

        private LevelMasterSprite CreateCorrectLevelSprite()
        {
            switch (LoZGame.Instance.Dungeon.DungeonNumber)
            {
                case 1:
                    return ScreenSpriteFactory.Instance.CreateLevelOneMaster();
                case 2:
                    return ScreenSpriteFactory.Instance.CreateLevelTwoMaster();
                default:
                    return ScreenSpriteFactory.Instance.CreateLevelOneMaster();
            }
        }
    }
}