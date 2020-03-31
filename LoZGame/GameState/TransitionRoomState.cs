namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : IGameState
    {
        public TransitionRoomState()
        {

        }

        public void Death()
        {
            // Can't die in a transition.
        }

        public void Inventory()
        {
            // Can't access inventory in a transition.
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
            // Can't go to a state you are already in.
        }

        public void WinGame()
        {
            // Can't win in a transition.
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
