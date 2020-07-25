namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.IO;

    /// <summary>
    /// Command that makes the game reset to a default state.
    /// </summary>
    public class CommandContinue : ICommand
    {
        private readonly IPlayer player;
        private string[] lines;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandContinue"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandContinue(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            lines = File.ReadAllLines("Content/Profile" + LoZGame.Instance.SelectedProfile + ".txt");
            LoZGame.Instance.Dungeon = new Dungeon(int.Parse(lines[0]));
            player.Inventory = new InventoryManager(player);
            LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);
            LoZGame.Instance.Dungeon.LoadNewRoom();

            player.Physics.CurrentDirection = Physics.Direction.North;
            player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);
            player.Physics.SetLocation();
            player.Physics.KnockbackVelocity = Vector2.Zero;
            player.State = new IdleState(player);
            player.DamageTimer = 0;
            player.CurrentTint = Color.White;
            LoZGame.Instance.Dungeon.Player = player;
            LoZGame.Instance.GameState.PlayGame();
        }
    }
}