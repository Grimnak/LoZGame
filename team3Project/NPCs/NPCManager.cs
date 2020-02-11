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
            NPCs.SetValue(new Dragon(), 0);
            NPCs.SetValue(new Stalfos(), 0);
            NPCs.SetValue(new Keese(), 0);
            NPCs.SetValue(new Gel(), 0);
            NPCs.SetValue(new Zol(), 0);
            NPCs.SetValue(new Goriya(), 0);
            NPCs.SetValue(new Rope(), 0);
            NPCs.SetValue(new SpikeCross(), 0);
            NPCs.SetValue(new WallMaster(), 0);

           // NPCs.SetValue(new OldMan(), 0);
           // NPCs.SetValue(new Merchant(), 0);
           // NPCs.SetValue(new Flame(), 0);
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