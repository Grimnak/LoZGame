namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGameState
    {
        /// <summary>
        /// Game state goes to title screen.
        /// </summary>
        void TitleScreen();

        /// <summary>
        /// Game state goes to game in progress.
        /// </summary>
        void PlayGame();

        /// <summary>
        /// Game state goes to player death.
        /// </summary>
        void Death();

        /// <summary>
        /// Game state goes to access inventory.
        /// </summary>
        void OpenInventory();

        /// <summary>
        /// Game state goes to close inventory.
        /// </summary>
        void CloseInventory();

        /// <summary>
        /// Game state goes to win state.
        /// </summary>
        void WinGame();

        /// <summary>
        /// Game state for room transitions.
        /// </summary>
        void TransitionRoom(string direction);

        /// <summary>
        /// Updates the current state.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the objects associated with the current state.
        /// </summary>
        void Draw();
    }
}
