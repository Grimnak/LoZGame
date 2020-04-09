namespace LoZClone
{
    using System.Media;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

    public class SoundFactory
    {
        private bool musicEnabled = true;
        private SoundPlayer titleSong = new SoundPlayer(Properties.Resources.title_song);
        private SoundPlayer dungeonSong = new SoundPlayer(Properties.Resources.dungeon_song);
        private SoundPlayer triforceTune = new SoundPlayer(Properties.Resources.triforce_tune);

        private SoundEffect swordSlash = SoundEffect.FromStream(Properties.Resources.LOZ_Sword_Slash);
        private SoundEffect swordShoot = SoundEffect.FromStream(Properties.Resources.LOZ_Sword_Shoot);
        private SoundEffect enemyHit = SoundEffect.FromStream(Properties.Resources.LOZ_Enemy_Hit);
        private SoundEffect enemyDie = SoundEffect.FromStream(Properties.Resources.LOZ_Enemy_Die);
        private SoundEffect bombDrop = SoundEffect.FromStream(Properties.Resources.LOZ_Enemy_Die);
        private SoundEffect bombExplosion = SoundEffect.FromStream(Properties.Resources.LOZ_Bomb_Blow);
        private SoundEffect getHeartOrKey = SoundEffect.FromStream(Properties.Resources.LOZ_Get_Heart);
        private SoundEffect getRupee = SoundEffect.FromStream(Properties.Resources.LOZ_Get_Rupee);
        private SoundEffect linkHurt = SoundEffect.FromStream(Properties.Resources.LOZ_Link_Hurt);
        private SoundEffect linkDie = SoundEffect.FromStream(Properties.Resources.LOZ_Link_Die);
        private SoundEffect candleShoot = SoundEffect.FromStream(Properties.Resources.LOZ_Candle);
        private SoundEffect getItem = SoundEffect.FromStream(Properties.Resources.LOZ_Get_Item);
        private SoundEffect dragonDie = SoundEffect.FromStream(Properties.Resources.LOZ_Boss_Scream1);
        private SoundEffect climbStairs = SoundEffect.FromStream(Properties.Resources.LOZ_Stairs);
        private SoundEffect solved = SoundEffect.FromStream(Properties.Resources.LOZ_Secret);
        private SoundEffect arrowOrBoomShoot = SoundEffect.FromStream(Properties.Resources.LOZ_Arrow_Boomerang);
        private SoundEffect doorUnlock = SoundEffect.FromStream(Properties.Resources.LOZ_Door_Unlock);
        private SoundEffect keyAppears = SoundEffect.FromStream(Properties.Resources.LOZ_Key_Appear);

        private static readonly SoundFactory instance = new SoundFactory();

        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }

        // Sound effects
        public void PlaySwordSlash()
        {
            swordSlash.Play();
        }

        public void PlaySwordShoot()
        {
            swordShoot.Play();
        }

        public void PlayEnemyHit()
        {
            enemyHit.Play();
        }

        public void PlayEnemyDie()
        {
            enemyDie.Play();
        }

        public void PlayBombDrop()
        {
            bombDrop.Play();
        }

        public void PlayBombExplosion()
        {
            bombExplosion.Play();
        }

        public void PlayGetHeartOrKey()
        {
            getHeartOrKey.Play();
        }

        public void PlayGetRupee()
        {
            getRupee.Play();
        }

        public void PlayLinkHurt()
        {
            linkHurt.Play();
        }

        public void PlayLinkDie()
        {
            linkDie.Play();
        }

        public void PlayCandleShoot()
        {
            candleShoot.Play();
        }

        public void PlayGetItem()
        {
            getItem.Play();
        }

        public void PlayDragonDie()
        {
            dragonDie.Play();
        }

        public void PlayClimbStairs()
        {
            climbStairs.Play();
        }

        public void PlaySolved()
        {
            solved.Play();
        }

        public void PlayArrowOrBoomShoot()
        {
            arrowOrBoomShoot.Play();
        }

        public void PlayDoorUnlock()
        {
            doorUnlock.Play();
        }

        public void PlayKeyAppears()
        {
            keyAppears.Play();
        }

        // Music
        public void PlayTitleSong()
        {
            if (musicEnabled)
            {
                titleSong.PlayLooping();
            }
        }

        public void PlayDungeonSong()
        {
            if (musicEnabled)
            {
                dungeonSong.PlayLooping();
            }
        }

        public void PlayTriforceTune()
        {
            if (musicEnabled)
            {
                triforceTune.PlayLooping();
            }
        }

        public void StopDungeonSong()
        {
            dungeonSong.Stop();
        }
    }
}
