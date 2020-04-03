namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class InventoryState : IGameState
    {
        public InventoryState()
        {
            // No need to change.
        }

        public void Death()
        {
            // Can't die while accessing inventory.
        }

        public void Inventory()
        {
            // Can't transition to a state you're already in.
        }

        public void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public void TransitionRoom(string direction)
        {
            // Can't transition room while accessing inventory.
        }

        public void WinGame()
        {
            // Can't win game while accessing inventory.
        }

        public void Update()
        {
            // TODO
        }

        public void Draw()
        {
            // TODO
        }
    }
}