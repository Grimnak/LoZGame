namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WinGameState : IGameState
    {

        private int currentDungeon;
        private static int maxDungeon = 1;
        private int lockout;
        private int lockoutMax = 15; //verify

        public WinGameState()
        {
            lockout = 0;
            currentDungeon = 1;
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
            this.lockout++;

            // Triforce animation playing time
            if (lockout < lockoutMax)
            {

            }
            else
            {
                // Transition to new dungeon or title screen.
                if (LoZGame.Instance.Dungeon.DungeonNumber < maxDungeon)
                {
                    LoZGame.Instance.Dungeon = new Dungeon(LoZGame.Instance.Dungeon.DungeonNumber + 1);
                    LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);
                    LoZGame.Instance.GameState.PlayGame();
                }
                else
                {
                    //Temporary
                    //LoZGame.Instance.GameState.TitleScreen();
                    LoZGame.Instance.GameState.PlayGame();
                }
            }

        }

        public void Draw()
        {
            // TODO
        }
    }
}
