namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : GameStateEssentials, IGameState
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
                    foreach (IDoor door in oldObjects.Doors.DoorList)
                    {
                        door.Physics.Depth = 1;
                    }
                    foreach (IDoor door in newObjects.Doors.DoorList)
                    {
                        door.Physics.Depth = 1;
                    }
                }
            }
            else
            {
                this.PlayGame();
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public override void Pause()
        {
            LoZGame.Instance.GameState = new PauseState(this);
        }

        public override void Update()
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
                this.oldObjects.LoadedRoomX = this.dungeon.CurrentRoomX;
                this.oldObjects.LoadedRoomY = this.dungeon.CurrentRoomY;
                this.dungeon.CurrentRoomX = nextRoomLocation.X;
                this.dungeon.CurrentRoomY = nextRoomLocation.Y;
                foreach (IDoor door in oldObjects.Doors.DoorList)
                {
                    door.Physics.SetDepth();
                }
                foreach (IDoor door in newObjects.Doors.DoorList)
                {
                    door.Physics.SetDepth();
                }
                this.oldObjects.UpdateObjectLocations(nextRoomOffset);
                this.oldObjects.Save();
                LoZGame.Instance.GameObjects = newObjects;
                this.dungeon.MiniMap.Explore();
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Physics.MasterMovement = Vector2.Zero;
                    player.Idle();
                }
                this.dungeon.SpawnObjects();
                this.PlayGame();
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            // Draw Room Backgrounds
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            this.NextRoom.Draw(nextRoomBorderOffset.ToPoint());
            this.dungeon.CurrentRoom.Draw(currentRoomBorderOffset.ToPoint());
            LoZGame.Instance.SpriteBatch.End();

            // Draw Game Objects
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            this.oldObjects.Draw();
            this.newObjects.Draw();
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }
            LoZGame.Instance.SpriteBatch.End();

            // Ensure inventory objects draw above the game objects while transitioning.
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            InventoryComponents.Instance.DrawInventoryElements();
            LoZGame.Instance.SpriteBatch.End();

            if (LoZGame.DebugMode)
            {
                LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
                LoZGame.Instance.Debugger.Draw(newObjects);
                LoZGame.Instance.SpriteBatch.End();
            }
        }
    }
}