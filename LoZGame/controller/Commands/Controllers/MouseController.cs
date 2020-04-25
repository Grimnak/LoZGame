namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Controller for mouse inputs.
    /// </summary>
    public class MouseController : IController
    {
        private readonly MouseCommandLoader allCommands;
        private ICommand currentCommand;
        private MouseState oldState;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseController"/> class.
        /// </summary>
        /// <param name="allCommands">The command loader for mouse commands.</param>
        public MouseController(MouseCommandLoader allCommands)
        {
            this.allCommands = allCommands;
            oldState = Mouse.GetState();
        }

        /// <inheritdoc/>
        public void Update()
        {
            MouseState state = Mouse.GetState();
            Vector2 position = new Vector2(state.X, state.Y);

            if (state.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                // Vector logic
                if (position.X > 400)
                {
                    if (position.Y - 174 > (3 * position.X) / 5)
                    {
                        currentCommand = allCommands.GetCommandRoomDown;
                    }
                    else if (position.Y - 174 < (480 - ((3 * position.X) / 5)))
                    {
                        currentCommand = allCommands.GetCommandRoomUp;
                    }
                    else
                    {
                        currentCommand = allCommands.GetCommandRoomRight;
                    }
                }
                else
                {
                    if (position.Y - 174 > (480 - ((3 * position.X) / 5)))
                    {
                        currentCommand = allCommands.GetCommandRoomDown;
                    }
                    else if (position.Y - 174 < (3 * position.X) / 5)
                    {
                        currentCommand = allCommands.GetCommandRoomUp;
                    }
                    else
                    {
                        currentCommand = allCommands.GetCommandRoomLeft;
                    }
                }

                currentCommand.Execute();
            }

            oldState = state;
        }
    }
}
