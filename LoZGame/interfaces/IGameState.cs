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
        /// Game states goes to profile selection.
        /// </summary>
        void ProfilesScreen();

        /// <summary>
        /// Game state goes to credits screen.
        /// </summary>
        void CreditsScreen();

        /// <summary>
        /// Game state goes to game in progress.
        /// </summary>
        void PlayGame();

        /// <summary>
        /// Game state goes to the death state.
        /// </summary>
        void Death();

        /// <summary>
        /// Game state goes to the options menu.
        /// </summary>
        void Options();

        /// <summary>
        /// Game state goes to playing the flute.
        /// </summary>
        void PlayFlute();

        /// <summary>
        /// Game state goes to restoring player health.
        /// </summary>
        void RestoreHealth();

        /// <summary>
        /// Game state goes to access inventory.
        /// </summary>
        void OpenInventory();

        /// <summary>
        /// Game state goes to close inventory.
        /// </summary>
        void CloseInventory();

        /// <summary>
        /// Game state goes to triforce state.
        /// </summary>
        void TriforceState();

        /// <summary>
        /// Game state for room transitions.
        /// </summary>
        /// <param name="direction">Indicates the direction that the player is trying to move relative to the current room.</param>
        void TransitionRoom(Physics.Direction direction);

        /// <summary>
        /// Game state goes to paused.
        /// </summary>
        void Pause();

        /// <summary>
        /// Game state goes to unpaused.
        /// </summary>
        void Unpause();

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
