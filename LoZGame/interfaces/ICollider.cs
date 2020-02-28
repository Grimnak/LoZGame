﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface ICollider
    {
        Rectangle Bounds { get; set; }

        Physics Physics { get; set; }

        void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide);
    }
}