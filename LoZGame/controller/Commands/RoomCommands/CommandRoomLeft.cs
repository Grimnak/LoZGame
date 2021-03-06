﻿namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one left.
    /// </summary>
    public class CommandRoomLeft : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomLeft"/> class.
        /// </summary>
        public CommandRoomLeft()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (LoZGame.Instance.GameState is PlayGameState)
            {
                LoZGame.Instance.Dungeon.MoveLeft();
            }
        }
    }
}
