
namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    internal class DropManager
    {
        private const int dropchance = 20;

        private Random RandomGenerator;

        public DropManager()
        {
            this.RandomGenerator = LoZGame.Instance.Random;
        }

        private bool DropItem()
        {
            return this.RandomGenerator.Next(0, 100) <= dropchance;
        }

        public void AttemptDrop(Vector2 loc)
        {
             if (this.DropItem())
            {
                int drop = this.RandomGenerator.Next(0, 100);
                
            }
        }
    }
}
