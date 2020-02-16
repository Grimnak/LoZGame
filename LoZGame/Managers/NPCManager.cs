using System;
using System.Collections.Generic;

namespace LoZClone
{
    public class NPCManager
    {
        private List<IEnemy> NPCs;
        private int currentNPC; 
        private static int totalNPCs = 13;
        public NPCManager()
        {
            NPCs = addNPCs();
        }

        private List<IEnemy> addNPCs()
        {
            NPCs = new List<IEnemy>();
            NPCs.Add(new Dodongo());
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

            return NPCs;
        }

        public IEnemy cycleRight()
        {
            currentNPC++;
            if (currentNPC >= totalNPCs)
            {
                currentNPC = 0;
            }
            return NPCs[currentNPC];
        }

        public IEnemy cycleLeft()
        {
            currentNPC--;
            if (currentNPC < 0)
            {
                currentNPC = totalNPCs - 1;
            }
            return NPCs[currentNPC];
        }
    }
}