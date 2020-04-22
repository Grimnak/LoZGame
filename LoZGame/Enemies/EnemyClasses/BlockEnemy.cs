namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class BlockEnemy : EnemyEssentials, IEnemy
    {
        public BlockEnemy(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>()
            {
                { RandomStateGenerator.StateType.Attack, 1 },
                { RandomStateGenerator.StateType.Idle, 5 }
            };
            this.Health = new HealthManager(1);
            this.Physics = new Physics(location);
            this.Physics.IsMoveable = false;
            this.Physics.Mass = 1;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.TileHeight, (int)BlockSpriteFactory.Instance.TileWidth);
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.IsKillable = false;
            this.IsTransparent = true;
            this.DamageTimer = 0;
            this.AI = EnemyAI.NoAI;
            this.CurrentState = new BlockEnemyIdleState(this);
            this.CurrentTint = LoZGame.Instance.DefaultTint;
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
            this.CurrentState.Update();
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