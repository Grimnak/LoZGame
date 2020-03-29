namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PlayGameState : IGameState
    {

        public PlayGameState()
        {

        }

        public void Death()
        {
            LoZGame.Instance.GameState = new DeathState();
        }

        public void Inventory()
        {
            LoZGame.Instance.GameState = new InventoryState();
        }

        public void PlayGame()
        {
            // Can't transition into a state you are already in.
        }

        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public void TransitionRoom()
        {
            LoZGame.Instance.GameState = new TransitionRoomState();
        }

        public void WinGame()
        {
            LoZGame.Instance.GameState = new WinGameState();
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
