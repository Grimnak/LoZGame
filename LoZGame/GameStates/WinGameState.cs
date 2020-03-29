namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WinGameState : IGameState
    {
        public WinGameState()
        {

        }

        public void Death()
        {
            // Can't die while winning.
        }

        public void Inventory()
        {
            // Can't access inventory while winning.
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
            // Can't transition room while winning.
        }

        public void WinGame()
        {
            // Can't transition to a state you're already in.
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
