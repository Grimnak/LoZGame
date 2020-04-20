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
            this.Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialLeftDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialUpDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialRightDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
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
        }
    }
}