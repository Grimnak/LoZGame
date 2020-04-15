using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public struct PhysicsConstants
    {
        private const int zeroVelocity = 0;
        private const int zeroFriction = 0;
        private const int zeroAcceleration = 0;
        private const int defaultMass = 10;
        private const float defaultKnockbackTime = 0.5f;
        private const int zeroLength = 0;
        private const int momentumMultiplier = 2;
        private const int knockbackMultiplier = 10;
        private const int massMultiplier = -4;
        private const float defaultDepth = 1.0f;
        private const float defaultRotation = 0.0f;
        private const int zeroDepth = 0;
        private const int doorWidth = 60;

        public int ZeroVelocity => zeroVelocity;

        public int ZeroFriction => zeroFriction;

        public int ZeroAcceleration => zeroAcceleration;

        public int DefaultMass => defaultMass;

        public float DefaultKnockbackTime => defaultKnockbackTime;

        public int ZeroLength => zeroLength;

        public int MomentumMultiplier => momentumMultiplier;

        public int KnockbackMultiplier => knockbackMultiplier;

        public int MassMultiplier => massMultiplier;

        public float DefaultDepth => defaultDepth;

        public float DefaultRotation => defaultRotation;

        public int ZeroDepth => zeroDepth;

        public int DoorWidth => doorWidth;
    }
}
