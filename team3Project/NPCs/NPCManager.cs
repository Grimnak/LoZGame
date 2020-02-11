using System;
namespace LoZClone
{
    public class NPCManager
    {
        private Array<IEnemySprite> NPCs;
        private int currentNPC;
        public NPCManager()
        {
            NPCs = addNPCs();
        }

        private Array<IEnemySprite> addNPCs()
        {
            NPCs = new Array<IEnemySprite>();
            NPCs.SetValue(new Dodongo(), 0);
            NPCs.SetValue(new Dragon(), 1);
            NPCs.SetValue(new Stalfos(), 2);
            NPCs.SetValue(new Keese(), 3);
            NPCs.SetValue(new Gel(), 4);
            NPCs.SetValue(new Zol(), 5);
            NPCs.SetValue(new Goriya(), 6);
            NPCs.SetValue(new Rope(), 7);
            NPCs.SetValue(new SpikeCross(), 8);
            NPCs.SetValue(new WallMaster(), 9);

           // NPCs.SetValue(new OldMan(), 10);
           // NPCs.SetValue(new Merchant(), 11);
           // NPCs.SetValue(new Flame(), 12);
        }

        public IEnemySprite cycleRight()
        {
            currentNPC++;
            return NPCs.GetValue(currentNPC);
        }

        public IEnemySprite cycleLeft()
        {
            currentNPC--;
            return NPCs.GetValue(currentNPC);
        }
    }
}
