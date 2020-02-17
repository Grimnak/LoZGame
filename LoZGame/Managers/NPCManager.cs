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
        private readonly LoZGame game;
        private Vector2 location;

        public NPCManager(LoZGame game, Vector2 location)
        {
            this.location = location;
            this.game = game;
            this.currentIndex = 0;
            this.totalNPCs = 0;
        }

        public void loadNPCs(LoZGame game)
        {
            this.NPCs = new List<IEnemy>();
            this.NPCs.Add(new Dodongo());
            this.NPCs.Add(new Dragon());
            this.NPCs.Add(new Stalfos());
            this.NPCs.Add(new Keese());
            this.NPCs.Add(new Gel());
            this.NPCs.Add(new Zol());
            this.NPCs.Add(new Goriya());
            this.NPCs.Add(new Rope());
            this.NPCs.Add(new SpikeCross());
            this.NPCs.Add(new WallMaster());
            this.NPCs.Add(new OldMan());
            this.NPCs.Add(new Merchant());

            foreach (IEnemy npc in this.NPCs)
            {
                this.totalNPCs++;
            }
            this.currentNPC = this.NPCs[this.currentIndex];
        }

        public void cycleRight()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.totalNPCs)
            {
                this.currentIndex = 0;
            }
            this.currentNPC = this.NPCs[this.currentIndex];
        }

        public void cycleLeft()
        {
            this.currentIndex--;
            if (this.currentIndex < 0)
            {
                this.currentIndex = this.totalNPCs - 1;
            }
            this.currentNPC = this.NPCs[this.currentIndex];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentNPC.Draw(spriteBatch);
        }

        public void Update()
        {
            this.currentNPC.Update();
        }
    }
}