namespace LoZClone
{
    public struct CollisionConstants
    {
        private const int RightBndCorrection = 10;
        private const float MovableBlockAccel = -0.5f;

        public int RightBoundCorrection => RightBndCorrection;

        public float MovableBlockAcceleration => MovableBlockAccel;
    }
}