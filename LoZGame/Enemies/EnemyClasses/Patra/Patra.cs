namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Patra : EnemyEssentials, IEnemy
    {
        private bool spawnedChildren;
        private Dictionary<int, IEnemy> children;
        private List<int> deadChildren;
        private int numChildren = 8 + (2 * LoZGame.Instance.Difficulty);
        private int addedChildren;
        private float rotationCheck;
        private IEnemy child;
        private int childID;

        public Patra(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.StalfosStateList);
            Health = new HealthManager(24);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.IsMovable = false;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            IsTransparent = false;
            Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            DamageTimer = 0;
            MoveSpeed = 1;
            CurrentTint = LoZGame.Instance.DefaultTint;
            spawnedChildren = false;
            AI = EnemyAI.Stalfos;
            DropTable = GameData.Instance.EnemyDropTables.GleeokDropTable;
            IsSpawning = false;
            children = new Dictionary<int, IEnemy>();
            deadChildren = new List<int>();
            addedChildren = 0;
            rotationCheck = 0;
            childID = 0;
        }

        public override void TakeDamage(int damageAmount)
        {
            Console.WriteLine(children.Count);
            if (children.Count <= 0)
            {
                base.TakeDamage(damageAmount);
            }
        }

        public override void AddChild()
        {
            if (!spawnedChildren)
            {
                if (rotationCheck <= 0)
                {
                    rotationCheck = MathHelper.TwoPi / (float)numChildren;
                    addedChildren++;
                    IEnemy child = new MiniPatra(this);
                    children.Add(childID, child);
                    childID++;
                    LoZGame.Instance.GameObjects.Enemies.Queue(child);
                }
                if (addedChildren == numChildren)
                {
                    spawnedChildren = true;
                }
            }
        }

        private void RemoveDeadChildren()
        {
            foreach (KeyValuePair<int, IEnemy> child in children)
            {
                if (child.Value.Expired)
                {
                    deadChildren.Add(child.Key);
                }
            }

            foreach (int index in deadChildren)
            {
                children.Remove(index);
            }

            deadChildren.Clear();
        }

        public override void UpdateChild()
        {
            RemoveDeadChildren();
            float rotationSpeed = MathHelper.TwoPi / (float)(10 * numChildren);
            rotationCheck -= rotationSpeed;
            foreach (KeyValuePair<int, IEnemy> child in children)
            {
                if (!child.Value.IsDead)
                {
                    child.Value.MoveSpeed += rotationSpeed;
                }
            }
        }

        public override void Update()
        {
            HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || IsSpawning || IsDead)
            {
                AddChild();
                CurrentState.Update();
                Physics.Move();
                Physics.SetDepth();
                UpdateChild();
            }
        }

        public override void Stun(int stunTime)
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreatePatraSprite();
        }
    }
}
