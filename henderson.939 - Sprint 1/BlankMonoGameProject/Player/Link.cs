using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class Link : IPlayer
    {
        private LoZGame game;
        private IPlayerState playerState;
        public IPlayerState State
        {
            set
            {
                playerState = value;
            }
        }
        private string currentColor;
        public string CurrentColor
        {
            get { return currentColor; }
            set { currentColor = value; }
        }
        private string currentDirection;
        public string CurrentDirection
        {
            get { return currentDirection; }
            set { currentDirection = value; }
        }
        private Vector2 currentLocation;
        public Vector2 CurrentLocation
        {
            get { return currentLocation; }
            set { currentLocation = value; }
        }
        private Color currentTint;
        public Color CurrentTint
        {
            get { return currentTint; }
            set { currentTint = value; }
        }
        private bool isDamaged;
        private int damageTimer;

        public Link(LoZGame game)
        {
            this.game = game;
            currentColor = "Green";
            currentDirection = "Down";
            currentLocation = new Vector2(400, 200);
            currentTint = Color.White;
            isDamaged = false;
            damageTimer = 0;

            playerState = new NullState(game, this);
        }
        private void handleDamage()
        {
            if (isDamaged)
            {
                damageTimer = 1000;
                isDamaged = false;
            }
            else
            {
                damageTimer = 0;
            }
            if (damageTimer > 0)
            {
                damageTimer--;
                if (damageTimer % 100 > 50)
                {
                    currentTint = Color.Purple;
                }
                else
                {
                    currentTint = Color.White;
                }
            }
        }
        private void handleBounds()
        {
            if (currentLocation.X + 25 > game.GraphicsDevice.Viewport.Width)
            {
                currentLocation.X = game.GraphicsDevice.Viewport.Width - 25;
            }
            else if (currentLocation.X < 0)
            {
                currentLocation.X = 0;
            }
            if (currentLocation.Y + 25 > game.GraphicsDevice.Viewport.Height)
            {
                currentLocation.Y = game.GraphicsDevice.Viewport.Height - 25;
            }
            else if (currentLocation.Y < 0)
            {
                currentLocation.Y = 0;
            }
        }
        public void idle()
        {
            playerState.idle();
        }
        public void moveUp()
        {
            playerState.moveUp();
        }
        public void moveDown()
        {
            playerState.moveDown();
        }
        public void moveLeft()
        {
            playerState.moveLeft();
        }
        public void moveRight()
        {
            playerState.moveRight();
        }
        public void takeDamage()
        {
            isDamaged = true;
        }
        public void attack()
        {
            playerState.attack();
        }
        public void Update()
        {
            handleDamage();
            handleBounds();

            playerState.Update();
        }
        public void Draw()
        {
            playerState.Draw();
        }
    }
}