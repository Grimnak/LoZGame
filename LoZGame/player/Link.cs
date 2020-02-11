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
        private int currentSpeed;
        public int CurrentSpeed
        {
            get { return currentSpeed; }
        }
        private int damageTimer;

        public Link(LoZGame game)
        {
            this.game = game;
            currentColor = "Green";
            currentDirection = "Down";
            currentLocation = new Vector2(150, 200);
            currentTint = Color.White;
            currentSpeed = 2;
            damageTimer = 0;

            playerState = new NullState(game, this);
        }
        private void handleDamage()
        {
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
        //This handleBounds method will not remain here past Sprint 2.  This is a form of "collision handling" just so Link will stay in bounds.
        private void handleBounds()
        {
            if (currentLocation.X + 50 > game.GraphicsDevice.Viewport.Width)
            {
                currentLocation.X = game.GraphicsDevice.Viewport.Width - 50;
            }
            else if (currentLocation.X < 0)
            {
                currentLocation.X = 0;
            }
            if (currentLocation.Y + 50 > game.GraphicsDevice.Viewport.Height)
            {
                currentLocation.Y = game.GraphicsDevice.Viewport.Height - 50;
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
            damageTimer = 1000;
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
