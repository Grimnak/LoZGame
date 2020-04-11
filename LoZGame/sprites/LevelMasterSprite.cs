namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LevelMasterSprite
    {
        private Texture2D texture;
        private Rectangle position;

        public LevelMasterSprite(Texture2D texture, Vector2 currentRoomLocation)
        {
            this.texture = texture;
            this.position = new Rectangle((int)currentRoomLocation.X * LoZGame.Instance.ScreenWidth, (int)currentRoomLocation.Y * (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);
        }

        public void Update(string direction, int transitionSpeed)
        {
            if (direction == "Up")
            {
                this.position.Y -= transitionSpeed;
            }
            else if (direction == "Down")
            {
                this.position.Y += transitionSpeed;
            }
            else if (direction == "Left")
            {
                this.position.X -= transitionSpeed;
            }
            else if (direction == "Right")
            {
                this.position.X += transitionSpeed;
            }
        }

        public void Draw(Color tint) 
        {
            Rectangle destination = new Rectangle(0, LoZGame.Instance.InventoryOffset, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);
            LoZGame.Instance.SpriteBatch.Draw(this.texture, destination, position, tint);
        }
    }
}