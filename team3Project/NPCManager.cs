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
            NPCs.SetValue(EnemySpriteFactory.Instance.createDownMovingGelSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createUpMovingZolSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createLeftMovingStalfosSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createLeftMovingGoriyaSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createDownMovingKeeseSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createRightMovingRopeSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createDownMovingSpikeCrossSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createRightMovingWallMasterSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createLeftMovingDragonSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createDownMovingDodongoSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createOldManSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createMerchantSprite(), 0);
            NPCs.SetValue(EnemySpriteFactory.Instance.createFlameSprite(), 0);
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