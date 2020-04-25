namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class BlockEnemy : EnemyEssentials, IEnemy
    {
        public BlockEnemy(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>()
            {
                { RandomStateGenerator.StateType.Attack, 1 },
                { RandomStateGenerator.StateType.Idle, 5 }
            };
            Health = new HealthManager(1);
            Physics = new Physics(location);
            Physics.IsMoveable = false;
            Physics.Mass = 1;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, BlockSpriteFactory.Instance.TileHeight, (int)BlockSpriteFactory.Instance.TileWidth);
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            IsKillable = false;
            IsTransparent = true;
            DamageTimer = 0;
            AI = EnemyAI.NoAI;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            CurrentState = new BlockEnemyIdleState(this);
            CurrentTint = LoZGame.Instance.DefaultTint;
        }

        // This block does not interact with any sort of collision at all
        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void Update()
        {
            // only needs to update current state
            CurrentState.Update();
        }

        public override void Draw()
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return ItemSpriteFactory.Instance.HeartContainer();
        }
    }
}