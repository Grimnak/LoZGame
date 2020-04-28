namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateRedWizzrobe()
        {
            FacePlayer();
            DefaultUpdate();
        }
    }
}