namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FluteGameState : GameStateEssentials, IGameState
    {
        private int lifeTime;
        private readonly int flutePlayTime = 3 * LoZGame.Instance.UpdateSpeed; // should be duration of flute song

        public FluteGameState()
        {
            lifeTime = 0;
            SoundFactory.Instance.PlayFlute();
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Physics.KnockbackVelocity = Vector2.Zero;
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public override void Update()
        {
            lifeTime++;
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Update();
            }
            if (lifeTime >= flutePlayTime)
            {
                foreach (IEnemy enemy in LoZGame.Instance.GameObjects.Enemies.EnemyList)
                {
                    if (enemy.AI == EnemyEssentials.EnemyAI.LargeDigDogger)
                    {
                        enemy.UpdateChild();
                    }
                }
                PlayGame();
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            LoZGame.Instance.Dungeon.CurrentRoom.Draw(Point.Zero);
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            LoZGame.Instance.GameObjects.Draw();
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            LoZGame.Instance.GameObjects.Enemies.Draw();
            LoZGame.Instance.GameObjects.Entities.Draw();
            LoZGame.Instance.Dungeon.DrawText();
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawInventoryElements();
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}