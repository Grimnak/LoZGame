namespace LoZClone
{
    using System;
    using System.Collections.Generic;
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
        private List<IDoor> puzzleDoors;
        private List<IDoor> specialDoors;
        private bool done;

        public TransitionRoomState(Physics.Direction direction)
        {
            oldObjects = LoZGame.Instance.GameObjects;
            newObjects = new GameObjectManager();
            done = false;
            transitionDistance = 0;
            dungeon = LoZGame.Instance.Dungeon;
            currentRoomLocation = new Point(dungeon.CurrentRoomX, dungeon.CurrentRoomY);
            currentRoomBorderOffset = Vector2.Zero;
            puzzleDoors = new List<IDoor>();
            specialDoors = new List<IDoor>();
            switch (direction)
            {
                case Physics.Direction.North:
                    transitionDistance = YTransition;
                    nextRoomLocation = new Point(currentRoomLocation.X, currentRoomLocation.Y - 1);
                    nextRoomOffset = new Point(0, -YTransition);
                    break;
                case Physics.Direction.South:
                    transitionDistance = YTransition;
                    nextRoomLocation = new Point(currentRoomLocation.X, currentRoomLocation.Y + 1);
                    nextRoomOffset = new Point(0, YTransition);
                    break;
                case Physics.Direction.East:
                    transitionDistance = XTransition;
                    nextRoomLocation = new Point(currentRoomLocation.X + 1, currentRoomLocation.Y);
                    nextRoomOffset = new Point(XTransition, 0);
                    break;
                case Physics.Direction.West:
                    transitionDistance = XTransition;
                    nextRoomLocation = new Point(currentRoomLocation.X - 1, currentRoomLocation.Y);
                    nextRoomOffset = new Point(-XTransition, 0);
                    break;
            }
            NextRoom = dungeon.GetRoom(nextRoomLocation.Y, nextRoomLocation.X);
            nextRoomBorderOffset = nextRoomOffset.ToVector2();
            if (NextRoom.Exists)
            {
                MasterMovement = new Vector2((float)(-1 * nextRoomOffset.X) / transitionSpeed, (float)(-1 * nextRoomOffset.Y) / transitionSpeed);
                oldObjects.Entities.Clear();
                dungeon.LoadNewRoom(newObjects, nextRoomLocation, nextRoomOffset);
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
                    oldObjects.SetObjectMovement(MasterMovement);
                    newObjects.SetObjectMovement(MasterMovement);
                    foreach (IDoor door in oldObjects.Doors.DoorList)
                    {
                        door.Physics.Depth = 1;
                    }
                    foreach (IDoor door in newObjects.Doors.DoorList)
                    {
                        door.Physics.Depth = 1;
                    }
                    foreach (IDoor door in newObjects.Doors.DoorList)
                    {
                        if (door.DoorType == Door.DoorTypes.Special)
                        {
                            specialDoors.Add(door);
                            door.Open();
                        }
                    }
                    foreach (IDoor door in newObjects.Doors.DoorList)
                    {
                        if (door.DoorType == Door.DoorTypes.Puzzle)
                        {
                            puzzleDoors.Add(door);
                            door.Open();
                        }
                    }
                }
            }
            else
            {
                PlayGame();
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
            if (!done)
            {
                if (MasterMovement.Length() >= transitionDistance)
                {
                    MasterMovement.Normalize();
                    MasterMovement *= transitionDistance;
                    done = true;
                }
                else
                {
                    transitionDistance -= Math.Abs(MasterMovement.X + MasterMovement.Y);
                }
                nextRoomBorderOffset += MasterMovement;
                currentRoomBorderOffset += MasterMovement;
                oldObjects.MoveObjects();
                newObjects.MoveObjects();
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Update();
                }
            }
            else
            {
                oldObjects.LoadedRoomX = dungeon.CurrentRoomX;
                oldObjects.LoadedRoomY = dungeon.CurrentRoomY;
                dungeon.CurrentRoomX = nextRoomLocation.X;
                dungeon.CurrentRoomY = nextRoomLocation.Y;
                foreach (IDoor door in oldObjects.Doors.DoorList)
                {
                    door.Physics.SetDepth();
                }
                foreach (IDoor door in newObjects.Doors.DoorList)
                {
                    door.Physics.SetDepth();
                }
                foreach (IDoor door in puzzleDoors)
                {
                    door.State = new PuzzleDoorState(door);
                    door.DoorType = Door.DoorTypes.Puzzle;
                }
                foreach (IDoor door in specialDoors)
                {
                    door.State = new SpecialDoorState(door);
                    door.DoorType = Door.DoorTypes.Special;
                }
                puzzleDoors.Clear();
                specialDoors.Clear();
                oldObjects.UpdateObjectLocations(nextRoomOffset);
                oldObjects.Save();
                LoZGame.Instance.GameObjects = newObjects;
                dungeon.MiniMap.Explore();
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Physics.MasterMovement = Vector2.Zero;
                    player.Idle();
                }
                dungeon.SpawnObjects();
                PlayGame();
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            // Draw Room Backgrounds
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            NextRoom.Draw(nextRoomBorderOffset.ToPoint());
            dungeon.CurrentRoom.Draw(currentRoomBorderOffset.ToPoint());
            LoZGame.Instance.SpriteBatch.End();

            // Draw Game Objects
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            oldObjects.Draw();
            newObjects.Draw();
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