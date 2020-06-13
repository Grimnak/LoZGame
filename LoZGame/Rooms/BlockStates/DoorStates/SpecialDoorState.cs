namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /*
     * The player must kill all enemies to open these doors.
     */
    public class SpecialDoorState : DoorEssentials, IDoorState
    {
        public SpecialDoorState(IDoor door)
        {
            Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialLeftDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialUpDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialRightDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                default:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
            }
        }

        public override void Update()
        {
            int killableEnemies = 0;

            foreach (IEnemy enemy in LoZGame.Instance.GameObjects.Enemies.EnemyList)
            {
                if (enemy.IsKillable)
                {
                    killableEnemies++;
                }
                if (enemy.IsDead)
                {
                    killableEnemies--;
                }
            }
            if (killableEnemies <= 0)
            {
                Open();
            }
            base.Update();
        }
    }
}