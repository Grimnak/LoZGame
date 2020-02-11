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
            NPCs.SetValue(new Dodongo(), 1);
            NPCs.SetValue(new Dragon(), 2);
            NPCs.SetValue(new Stalfos(), 3);
            NPCs.SetValue(new Keese(), 4);
            NPCs.SetValue(new Gel(), 5);
            NPCs.SetValue(new Zol(), 6);
            NPCs.SetValue(new Goriya(), 7);
            NPCs.SetValue(new Rope(), 8);
            NPCs.SetValue(new SpikeCross(), 9);
            NPCs.SetValue(new WallMaster(), 10);

           // NPCs.SetValue(new OldMan(), 11);
           // NPCs.SetValue(new Merchant(), 12);
           // NPCs.SetValue(new Flame(), 13);
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
