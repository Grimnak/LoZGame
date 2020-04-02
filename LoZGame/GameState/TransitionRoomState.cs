namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TransitionRoomState : IGameState
    {
        private LevelOneMasterSprite sprite;
        private string direction;
        private int transitionSpeed = 5;

        public TransitionRoomState(string direction)
        {
            this.direction = direction;
            this.sprite = CreateCorrectLevelSprite();

            // Unload everything we have to unload.
            // Replace with master level for transition and swap back when finished.
        }

        public void Death()
        {
            // Can't die in a transition.
        }

        public void Inventory()
        {
            // Can't access inventory in a transition.
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
            // Can't go to a state you are already in.
        }

        public void WinGame()
        {
            // Can't win in a transition.
        }

        public void Update()
        {
            this.sprite.Update(direction, transitionSpeed);
        }

        public void Draw()
        {
            this.sprite.Draw(LoZGame.Instance.DungeonTint);
        }

        private LevelOneMasterSprite CreateCorrectLevelSprite()
        {
            return ScreenSpriteFactory.Instance.CreateLevelOneMaster();
        }
    }
}