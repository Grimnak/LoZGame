namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : IGameState
    {
        private Physics.Direction direction;
        private int transitionSpeed;
        private int lockout;
        private Room currentRoom;
        private Point currentRoomLocation;
        private Room nextRoom;
        private Point nextRoomLocation;
        private Dungeon dungeon;
        Vector2 MasterMovement;
        private GameObjectManager oldObjects;
        private GameObjectManager newObjects;

        public TransitionRoomState(Dungeon dungeon, Physics.Direction direction)
        {
            this.lockout = 0;
            this.dungeon = dungeon;
            this.currentRoom = this.dungeon.CurrentRoom;
            this.currentRoomLocation = new Point(this.dungeon.CurrentRoomX, this.dungeon.CurrentRoomY);
            switch (direction)
            {
                case Physics.Direction.North:
                    lockout = LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X, this.currentRoomLocation.Y - 1);
                    break;
                case Physics.Direction.South:
                    lockout = LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X, this.currentRoomLocation.Y + 1);
                    break;
                case Physics.Direction.East:
                    lockout = LoZGame.Instance.ScreenWidth;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X, this.currentRoomLocation.Y + 1);
                    break;
                case Physics.Direction.West:
                    lockout = LoZGame.Instance.ScreenWidth;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X, this.currentRoomLocation.Y - 1);
                    break;
            }
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
                case 3:
                    return ScreenSpriteFactory.Instance.CreateLevelThreeMaster();
                default:
                    return ScreenSpriteFactory.Instance.CreateLevelOneMaster();
            }
        }
    }
}