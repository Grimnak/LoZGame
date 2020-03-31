namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class DeathState : IGameState
    {
        private int deathTime;
        private static int deathTimeMax = 85;
        private static int gameOverTime = 300;

        public DeathState()
        {
            this.deathTime = 0;
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
            this.deathTime++;
            if (this.deathTime < deathTimeMax)
            {
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Update();
                }
            }
            else if(this.deathTime > gameOverTime)
            {
                LoZGame.Instance.GameState.TitleScreen();
            }
        }

        public void Draw()
        {
            // TODO
            if (this.deathTime < deathTimeMax)
            {
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Draw();
                }
            }
            else if (this.deathTime > deathTimeMax && this.deathTime < gameOverTime)
            {
                LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "GAME OVER", new Vector2(100, 100), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
            }
        }
    }
}
