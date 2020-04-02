namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PlayGameState : IGameState
    {
        public PlayGameState()
        {

        }

        public void Death()
        {
            LoZGame.Instance.GameState = new DeathState();
        }

        public void Inventory()
        {
            LoZGame.Instance.GameState = new InventoryState();
        }

        public void PlayGame()
        {
            // Can't transition into a state you are already in.
        }

        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public void TransitionRoom(string direction)
        {
            LoZGame.Instance.GameState = new TransitionRoomState(LoZGame.Instance.Dungeon.CurrentRoom, direction);
        }

        public void WinGame()
        {
            LoZGame.Instance.GameState = new WinGameState();
        }

        public void Update()
        {
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Update();
            }
            LoZGame.Instance.GameObjects.Update();
            LoZGame.Instance.CollisionDetector.Update(LoZGame.Instance.Players.AsReadOnly(), LoZGame.Instance.GameObjects.Enemies.EnemyList.AsReadOnly(), LoZGame.Instance.GameObjects.Blocks.BlockList.AsReadOnly(), LoZGame.Instance.GameObjects.Doors.DoorList.AsReadOnly(), LoZGame.Instance.GameObjects.Items.ItemList.AsReadOnly(), LoZGame.Instance.GameObjects.Entities.PlayerProjectiles.AsReadOnly(), LoZGame.Instance.GameObjects.Entities.EnemyProjectiles.AsReadOnly());

        }

        public void Draw()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
            {
                if (LoZGame.Instance.Dungeon.CurrentRoomX != 0 || LoZGame.Instance.Dungeon.CurrentRoomY != 2)
                {
                    LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.Background, new Rectangle(0, 0, 800, 480), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                }
                else
                {
                    LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.BackgroundHole, new Rectangle(0, 0, 800, 480), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                }

            }

            LoZGame.Instance.GameObjects.Draw();

            if (LoZGame.Instance.Dungeon.CurrentRoomX == 0 && LoZGame.Instance.Dungeon.CurrentRoomY == 2)
            {
                LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, new Vector2(100, 100), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
            }

            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }
        }
    }
}