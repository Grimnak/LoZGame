namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : IGameState
    {
        private int YTransition = LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset;
        private int XTransition = LoZGame.Instance.ScreenWidth;
        private int transitionSpeed = GameData.Instance.GameStateDataConstants.TransitionRoomStateTransitionTime;
        private int maxPlayerMovement = GameData.Instance.GameStateDataConstants.PlayerTransitionMaxDistance;
        private Physics.Direction direction;
        private float transitionDistance;
        private Point currentRoomLocation;
        private Point nextRoomLocation;
        private Point nextRoomOffset;
        private Dungeon dungeon;
        private Vector2 MasterMovement;
        private Room NextRoom;
        private Vector2 nextRoomBorderOffset;
        private Vector2 currentRoomBorderOffset;
        private GameObjectManager oldObjects;
        private GameObjectManager newObjects;
        private bool done;

        public TransitionRoomState(Physics.Direction direction)
        {
            Console.WriteLine("Attempted to enter transition State");
            this.oldObjects = LoZGame.Instance.GameObjects;
            this.newObjects = new GameObjectManager();
            this.done = false;
            this.transitionDistance = 0;
            this.dungeon = LoZGame.Instance.Dungeon;
            this.currentRoomLocation = new Point(this.dungeon.CurrentRoomX, this.dungeon.CurrentRoomY);
            this.currentRoomBorderOffset = Vector2.Zero;
            switch (direction)
            {
                case Physics.Direction.North:
                    transitionDistance = YTransition;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X, this.currentRoomLocation.Y - 1);
                    this.nextRoomOffset = new Point(0, -YTransition);
                    break;
                case Physics.Direction.South:
                    transitionDistance = YTransition;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X, this.currentRoomLocation.Y + 1);
                    this.nextRoomOffset = new Point(0, YTransition);
                    break;
                case Physics.Direction.East:
                    transitionDistance = XTransition;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X + 1, this.currentRoomLocation.Y);
                    this.nextRoomOffset = new Point(XTransition, 0);
                    break;
                case Physics.Direction.West:
                    transitionDistance = XTransition;
                    this.nextRoomLocation = new Point(this.currentRoomLocation.X - 1, this.currentRoomLocation.Y);
                    this.nextRoomOffset = new Point(-XTransition, 0);
                    break;
            }
            this.NextRoom = this.dungeon.GetRoom(nextRoomLocation.Y, nextRoomLocation.X);
            this.nextRoomBorderOffset = this.nextRoomOffset.ToVector2();
            if (this.NextRoom.Exists)
            {
                Console.WriteLine("Room exists, attempting to enter");
                this.MasterMovement = new Vector2((float)(-1 * nextRoomOffset.X) / transitionSpeed, (float)(-1 * nextRoomOffset.Y) / transitionSpeed);
                this.oldObjects.Entities.Clear();
                this.dungeon.LoadNewRoom(newObjects, this.nextRoomLocation, this.nextRoomOffset);
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    switch (direction)
                    {
                        case Physics.Direction.North:
                            player.MoveUp();
                            player.Physics.MovementVelocity = new Vector2(0, -(float)maxPlayerMovement / transitionSpeed);
                            break;
                        case Physics.Direction.South:
                            player.MoveDown();
                            player.Physics.MovementVelocity = new Vector2(0, (float)maxPlayerMovement / transitionSpeed);
                            break;
                        case Physics.Direction.East:
                            player.MoveRight();
                            player.Physics.MovementVelocity = new Vector2((float)maxPlayerMovement / transitionSpeed, 0);
                            break;
                        case Physics.Direction.West:
                            player.MoveLeft();
                            player.Physics.MovementVelocity = new Vector2(-(float)maxPlayerMovement / transitionSpeed, 0);
                            break;
                    }
                    player.Physics.MovementVelocity += MasterMovement;
                    this.oldObjects.SetObjectMovement(this.MasterMovement);
                    this.newObjects.SetObjectMovement(this.MasterMovement);
                }
            }
            else
            {
                Console.WriteLine("Room did not exist, No entry, Return to game");
                this.PlayGame();
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
            if (!this.done)
            {
                if (this.MasterMovement.Length() >= transitionDistance)
                {
                    this.MasterMovement.Normalize();
                    this.MasterMovement *= transitionDistance;
                    this.done = true;
                }
                else
                {
                    this.transitionDistance -= Math.Abs(MasterMovement.X + MasterMovement.Y);
                    Console.WriteLine(transitionDistance);
                }
                this.nextRoomBorderOffset += MasterMovement;
                this.currentRoomBorderOffset += MasterMovement;
                this.oldObjects.MoveObjects();
                this.newObjects.MoveObjects();
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Update();
                }
            }
            else
            {
                this.dungeon.CurrentRoomX = nextRoomLocation.X;
                this.dungeon.CurrentRoomY = nextRoomLocation.Y;
                this.oldObjects.UpdateObjectLocations(nextRoomOffset);
                this.oldObjects.Clear();
                LoZGame.Instance.GameObjects.Copy(newObjects);
                this.dungeon.MiniMap.Explore();
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Physics.MasterMovement = Vector2.Zero;
                    player.Idle();
                }
                this.dungeon.SpawnEnemies();
                this.PlayGame();
            }
        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            // Draw Room Backgrounds
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.NextRoom.Draw(nextRoomBorderOffset.ToPoint());
            this.dungeon.CurrentRoom.Draw(currentRoomBorderOffset.ToPoint());
            LoZGame.Instance.SpriteBatch.End();

            // Draw Game Objects
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.oldObjects.Draw();
            this.newObjects.Draw();
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }
            LoZGame.Instance.SpriteBatch.End();

            // Ensure inventory objects draw above the game objects while transitioning.
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawInventoryElements();
            LoZGame.Instance.SpriteBatch.End();

            if (LoZGame.DebugMode)
            {
                LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
                LoZGame.Instance.Debugger.Draw(newObjects);
                LoZGame.Instance.SpriteBatch.End();
            }
        }
    }
}