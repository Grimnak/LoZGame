namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class InventoryState : IGameState
    {
        private ISprite sprite;
        private int transitionSpeed;
        private int lockout;
        private Vector2 position;

        public InventoryState()
        {
            this.lockout = 0;
            this.transitionSpeed = 5;
            this.sprite = CreateCorrectLevelSprite();
            this.position = new Vector2(0, -LoZGame.Instance.GraphicsDevice.Viewport.Height);
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

        public void TransitionRoom(string direction)
        {
            // Can't transition room while accessing inventory.
        }

        public void WinGame()
        {
            // Can't win game while accessing inventory.
        }

        public void Update()
        {
            this.lockout += this.transitionSpeed;
            if (this.lockout < LoZGame.Instance.GraphicsDevice.Viewport.Height)
            {
                this.position.Y += transitionSpeed;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(position, LoZGame.Instance.DungeonTint, 1.0f);
        }

        private ISprite CreateCorrectLevelSprite()
        {
            return ScreenSpriteFactory.Instance.CreateInventory();
        }
    }
}