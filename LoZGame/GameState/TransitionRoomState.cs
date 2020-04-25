namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : GameStateEssentials, IGameState
    {
        private int YTransition = LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset;                 // max distance to transition on the Y axis
        private int XTransition = LoZGame.Instance.ScreenWidth;                                                     // max distance to transition on the X axis
        private int transitionSpeed = GameData.Instance.GameStateDataConstants.TransitionRoomStateTransitionTime;   // speed to transition at
        private int maxPlayerMovement = GameData.Instance.GameStateDataConstants.PlayerTransitionMaxDistance;       // secondary player speed to walk at
        private Physics.Direction direction;                                                                        // direction we are transitioning
        private float transitionDistance;           // current transition
        private Point currentRoomLocation;          // room we are starting from
        private Point nextRoomLocation;             // x, y coord of room we are going to
        private Point nextRoomOffset;               // a, y coord offset of where to draw enemies when we start transitioning
        private Dungeon dungeon;                    // current dungeon we are transitioning in
        private Vector2 MasterMovement;             // movement velocity that every object follows for the transition
        private Room NextRoom;                      // all the objects in the next room
        private Vector2 nextRoomBorderOffset;       // offset to draw the dungeon border
        private Vector2 currentRoomBorderOffset;    // offset to draw the original dungeon border
        private GameObjectManager oldObjects;       // tracks all the gameobjects that were loadad before the transition started
        private GameObjectManager newObjects;       // tracks all the gameobjects in the new room we are loaadaing
        private List<IDoor> puzzleDoors;            // used to track puzzle doors that we open during transition
        private List<IDoor> specialDoors;           // used to track special doors we open during transition
        private bool done;                          // tracks when we are done transitioning to return to play state

        public TransitionRoomState(Physics.Direction direction)
        {
            // initialize the variabls and directions we need to check for a transition
            oldObjects = LoZGame.Instance.GameObjects;
            newObjects = new GameObjectManager();
            done = false;
            transitionDistance = 0;
            dungeon = LoZGame.Instance.Dungeon;
            currentRoomLocation = new Point(dungeon.CurrentRoomX, dungeon.CurrentRoomY);
            currentRoomBorderOffset = Vector2.Zero;
            puzzleDoors = new List<IDoor>();
            specialDoors = new List<IDoor>();

            // finds the room we are transitioning to, and sets the variabls needed to transition to it
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

            // loads the nextroom
            NextRoom = dungeon.GetRoom(nextRoomLocation.Y, nextRoomLocation.X);
            nextRoomBorderOffset = nextRoomOffset.ToVector2();

            // checks that the next room actually exists before transitioning
            if (NextRoom.Exists)
            {
                MasterMovement = new Vector2((float)(-1 * nextRoomOffset.X) / transitionSpeed, (float)(-1 * nextRoomOffset.Y) / transitionSpeed);
                oldObjects.Entities.Clear();
                dungeon.LoadNewRoom(newObjects, nextRoomLocation, nextRoomOffset);

                // assigns players movement velocity based on transition direction
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
                }

                // sets moveement velocity for all other objects apart from player;
                oldObjects.SetObjectMovement(MasterMovement);
                newObjects.SetObjectMovement(MasterMovement);

                // sets doors to draw on the top level
                foreach (IDoor door in oldObjects.Doors.DoorList)
                {
                    door.Physics.Depth = 1;
                }
                foreach (IDoor door in newObjects.Doors.DoorList)
                {
                    door.Physics.Depth = 1;
                }

                // opens all special and puzzle doors in the room we are entering
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

            // plays game if the room does not exist
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
            // logic to execute during a transition
            if (!done)
            {
                // if we are going to transition past the desire amount we instead snap to the new location
                if (MasterMovement.Length() >= transitionDistance)
                {
                    MasterMovement.Normalize();
                    MasterMovement *= transitionDistance;
                    done = true;
                }
                // else we track the distance normally
                else
                {
                    transitionDistance -= Math.Abs(MasterMovement.X + MasterMovement.Y);
                }
                // appliees a global movement to all objects new and old
                nextRoomBorderOffset += MasterMovement;
                currentRoomBorderOffset += MasterMovement;
                oldObjects.MoveObjects();
                newObjects.MoveObjects();

                // updates player so he walks through the door
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Update();
                }
            }
            // logic to execute and return to play staate
            else
            {
                oldObjects.LoadedRoomX = dungeon.CurrentRoomX;
                oldObjects.LoadedRoomY = dungeon.CurrentRoomY;
                dungeon.CurrentRoomX = nextRoomLocation.X;
                dungeon.CurrentRoomY = nextRoomLocation.Y;

                // sets depth for doors since they don't do it dynamically once in play state
                foreach (IDoor door in oldObjects.Doors.DoorList)
                {
                    door.Physics.SetDepth();
                }
                foreach (IDoor door in newObjects.Doors.DoorList)
                {
                    door.Physics.SetDepth();
                }

                // restores doors that we opened during transition
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

                // resets locations to be back on the screen (limitation of the game in many other areas, wasn't feasible to redo it in the time we had)
                oldObjects.UpdateObjectLocations(nextRoomOffset);
                oldObjects.Save();

                // sets the main game to track the new objects in the new room
                LoZGame.Instance.GameObjects = newObjects;
                foreach (IBlock block in LoZGame.Instance.GameObjects.Blocks.BlockList)
                {
                    if (block is MovableBlock)
                    {
                        (block as MovableBlock).OriginalLocation = block.Physics.Location;
                    }
                }

                // explores the minimap and resets players transition velocities
                dungeon.MiniMap.Explore();
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Physics.MasterMovement = Vector2.Zero;
                    player.Idle();
                }

                // spawn enemies and into play state
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