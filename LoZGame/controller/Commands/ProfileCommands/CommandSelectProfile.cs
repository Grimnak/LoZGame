namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.IO;

    /// <summary>
    /// Command that confirms the user's profile choice.
    /// </summary>
    public class CommandSelectProfile : ICommand
    {
        private string[] lines;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSelectProfile"/> class.
        /// </summary>
        public CommandSelectProfile()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            lines = File.ReadAllLines("Content/Profile" + LoZGame.Instance.SelectedProfile + ".txt");
            LoZGame.Instance.Dungeon = new Dungeon(int.Parse(lines[0]));
            LoZGame.Instance.Link.Inventory = new InventoryManager(LoZGame.Instance.Link);
            LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);
            LoZGame.Instance.Dungeon.LoadNewRoom();

            LoZGame.Instance.Dungeon.Player = LoZGame.Instance.Link;
            LoZGame.Instance.GameState.PlayGame();
        }
    }
}