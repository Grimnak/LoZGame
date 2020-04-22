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
            position = new Rectangle((int)currentRoomLocation.X * LoZGame.Instance.ScreenWidth, (int)currentRoomLocation.Y * (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);
        }

        public void Update(Physics.Direction direction, int transitionSpeed)
        {
            if (direction.Equals(Physics.Direction.North))
            {
                position.Y -= transitionSpeed;
            }
            else if (direction.Equals(Physics.Direction.South))
            {
                position.Y += transitionSpeed;
            }
            else if (direction.Equals(Physics.Direction.West))
            {
                position.X -= transitionSpeed;
            }
            else if (direction.Equals(Physics.Direction.East))
            {
                position.X += transitionSpeed;
            }
        }

        public void Draw(Color tint) 
        {
            Rectangle destination = new Rectangle(0, LoZGame.Instance.InventoryOffset, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);
            LoZGame.Instance.SpriteBatch.Draw(texture, destination, position, tint);
        }
    }
}