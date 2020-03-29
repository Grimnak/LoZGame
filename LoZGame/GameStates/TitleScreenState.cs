namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TitleScreenState : IGameState
    {
        public TitleScreenState()
        {

        }

        public void Death()
        {
            // Can't die on title screen.
        }

        public void Inventory()
        {
            // Can't access inventory on title screen.
        }

        public void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        public void TitleScreen()
        {
            // Can do a hard reset while in this state already.
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public void TransitionRoom()
        {
            // Can't transition room from title screen.
        }

        public void WinGame()
        {
            // Can't win game from the title screen.
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
