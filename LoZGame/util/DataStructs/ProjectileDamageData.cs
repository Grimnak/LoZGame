namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct ProjectileDamageData
    {
        private const int LinkArrowDmg = 2;
        private const int LinkSilverArrowDmg = 4;
        private const int LinkBoomerangDmg = 0;
        private const int LinkMagicBoomerangDmg = 0;
        private const int SwordBeamDmg = 4;
        private const int WoodSwordDmg = 4;
        private const int WhiteSwordDmg = 6;
        private const int MagicSwordDmg = 8;
        private const int CandleDmg = 8;
        private const int BombDmg = 8;
        private const int FireballDmg = 4;
        private const int EnemyBoomerangDmg = 2;
        private const int EnemyArrowDmg = 2;


        public int LinkArrowDamage => LinkArrowDmg;

        public int LinkSilverArrowDamage => LinkSilverArrowDmg;

        public int LinkBoomerangDamage => LinkBoomerangDmg;

        public int LinkMagicBoomerangDamage => LinkMagicBoomerangDmg;

        public int SwordBeamDamage => SwordBeamDmg;

        public int WoodSwordDamage => WoodSwordDmg;

        public int WhiteSwordDamage => WhiteSwordDmg;

        public int MagicSwordDamage => MagicSwordDmg;

        public int CandleDamage => CandleDmg;

        public int BombDamage => BombDmg;

        public int FireballDamage => FireballDmg;

        public int EnemyBoomerangDamage => EnemyBoomerangDmg;

        public int EnemyMagicBoomerangDamage => EnemyMagicBoomerangDamage;
    }
}