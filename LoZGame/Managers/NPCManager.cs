using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class NPCManager
    {
        private List<IEnemy> NPCs;
        private int currentIndex, totalNPCs;
        private IEnemy currentNPC;
        private LoZGame game;
        private Vector2 location;

        public NPCManager(LoZGame game, Vector2 location)
        {
            this.location = location;
            this.game = game;
            currentIndex = 0;
            totalNPCs = 0;
        }

        public void loadNPCs(LoZGame game)
        {
            NPCs = new List<IEnemy>();
            NPCs.Add(new Dodongo(game));
            NPCs.Add(new Dragon());
            NPCs.Add(new Stalfos());
            NPCs.Add(new Keese());
            NPCs.Add(new Gel());
            NPCs.Add(new Zol());
            NPCs.Add(new Goriya());
            NPCs.Add(new Rope());
            NPCs.Add(new SpikeCross());
            NPCs.Add(new WallMaster());
            NPCs.Add(new OldMan());
            NPCs.Add(new Merchant());
            NPCs.Add(new Flame());

            foreach (IEnemy npc in NPCs)
            {
                totalNPCs++;
            }
            currentNPC = NPCs[currentIndex];
        }

        public void cycleRight()
        {
            currentIndex++;
            if (currentIndex >= totalNPCs)
            {
                currentIndex = 0;
            }
            currentNPC = NPCs[currentIndex];
        }

        public void cycleLeft()
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = totalNPCs - 1;
            }
            currentNPC = NPCs[currentIndex];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentNPC.draw(spriteBatch);
        }

        public void Update()
        {
            currentNPC.update();
        }
    }
}