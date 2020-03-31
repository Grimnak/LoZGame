namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DeathState : IGameState
    {
        public DeathState()
        {

        }

        public void Death()
        {
            // Can't transition to a state you're already in.
        }

        public void Inventory()
        {
            // Can't access inventory while dead.
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
            // Can't transition room while dead.
        }

        public void WinGame()
        {
            // Can't win game while dead.
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
