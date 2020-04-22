namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeathState : GameStateEssentials, IGameState
    {
        private int deathTime;
        private int deathTimeMax;
        private int gameOverTime;
        private ISprite sprite;

        public DeathState()
        {
            deathTime = 0;
            deathTimeMax = GameData.Instance.GameStateDataConstants.DeathTimeMax;
            gameOverTime = GameData.Instance.GameStateDataConstants.GameOverTime;
            sprite = ScreenSpriteFactory.Instance.GameOverScreen();
        }

        /// <inheritdoc></inheritdoc>
        public override void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public override void Update()
        {
            deathTime++;
            if (deathTime < deathTimeMax)
            {
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Update();
                }
            }
            else if (deathTime > gameOverTime)
            {
                LoZGame.Instance.GameState.TitleScreen();
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            LoZGame.Instance.Dungeon.CurrentRoom.Draw(Point.Zero);
            LoZGame.Instance.GameObjects.Draw();
            LoZGame.Instance.GameObjects.Entities.Draw();
            LoZGame.Instance.GameObjects.Enemies.Draw();

            if (deathTime < deathTimeMax)
            {
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Draw();
                }
            }
            else if (deathTime > deathTimeMax && deathTime < gameOverTime)
            {
                LoZGame.Instance.SpriteBatch.End();
                LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
                sprite.Draw(new Vector2(0, 0), Color.White, 0);
            }
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}