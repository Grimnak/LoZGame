namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InventoryState : IGameState
    {
        public InventoryState()
        {

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

        public void TransitionRoom()
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
