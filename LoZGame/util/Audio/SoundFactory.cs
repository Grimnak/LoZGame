﻿namespace LoZClone
{
    using System.Media;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;
    using SharpDX.Direct3D9;

    public class SoundFactory
    {
        private bool musicEnabled = LoZGame.Music;
        private static SoundEffect titleSong = SoundEffect.FromStream(Properties.Resources.title_song);
        SoundEffectInstance titleLoop = titleSong.CreateInstance();
        private static SoundEffect dungeonSong = SoundEffect.FromStream(Properties.Resources.The_Legend_of_Zelda_Spirit_Tracks_Music___Tower_of_Spirits_Dungeon);
        SoundEffectInstance dungeonLoop = dungeonSong.CreateInstance();
        private static SoundEffect triforceTune = SoundEffect.FromStream(Properties.Resources.triforce_tune);
        SoundEffectInstance triforceLoop = triforceTune.CreateInstance();
        private static SoundEffect bossTune = SoundEffect.FromStream(Properties.Resources.The_Legend_of_Zelda__Spirit_Tracks_Soundtrack___66_Stagnox__Armored_Colossus);
        SoundEffectInstance bossLoop = bossTune.CreateInstance();
        private static SoundEffect lobbyTune = SoundEffect.FromStream(Properties.Resources.The_Legend_of_Zelda_Spirit_Tracks_Music___File_Select);
        SoundEffectInstance lobbyLoop = lobbyTune.CreateInstance();
        private SoundEffect swordSlash = SoundEffect.FromStream(Properties.Resources.LOZ_Sword_Slash);
        private SoundEffect swordShoot = SoundEffect.FromStream(Properties.Resources.LOZ_Sword_Shoot);
        private SoundEffect laserBlast = SoundEffect.FromStream(Properties.Resources.SpartanLaser_mixdown);
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
        private SoundEffect bossDie = SoundEffect.FromStream(Properties.Resources.LOZ_Boss_Scream1);
        private SoundEffect climbStairs = SoundEffect.FromStream(Properties.Resources.LOZ_Stairs);
        private SoundEffect solved = SoundEffect.FromStream(Properties.Resources.LOZ_Secret);
        private SoundEffect arrowOrBoomShoot = SoundEffect.FromStream(Properties.Resources.LOZ_Arrow_Boomerang);
        private SoundEffect doorUnlock = SoundEffect.FromStream(Properties.Resources.LOZ_Door_Unlock);
        private SoundEffect specialItemAppears = SoundEffect.FromStream(Properties.Resources.LOZ_Key_Appear);
        private SoundEffect flute = SoundEffect.FromStream(Properties.Resources.LOZ_Recorder);
        private SoundEffect coolFlute = SoundEffect.FromStream(Properties.Resources.coolFlute);

        private static readonly SoundFactory instance = new SoundFactory();

        public bool EnableMusic { get { return musicEnabled; } set { musicEnabled = value; } }
        
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

        public void PlayCoolFlute()
        {
            coolFlute.Play();
        }

        public void PlayLaserBlast()
        {
            laserBlast.Play();
            //System.Threading.Thread.Sleep(2700); // laser blast
        }

        public void PlayFlute()
        {
            flute.Play();
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

        public void PlayBossDie()
        {
            bossDie.Play();
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

        public void PlaySpecialItemAppears()
        {
            specialItemAppears.Play();
        }

        // Music
        public void PlayTitleSong()
        {
            titleLoop.IsLooped = true;
            titleLoop.Volume = 0.5f;
            if (musicEnabled)
            {
                titleLoop.Play();
            }
        }

        public void PlayDungeonSong()
        {
            dungeonLoop.IsLooped = true;
            dungeonLoop.Volume = 0.5f;
            if (musicEnabled)
            {
                dungeonLoop.Play();
            }
        }

        public void PlayBossSong()
        {
            bossLoop.IsLooped = true;
            bossLoop.Volume = 0.5f;
            if (musicEnabled)
            {
                bossLoop.Play();
            }
        }

        public void PlayTriforceTune()
        {
            triforceLoop.IsLooped = true;
            triforceLoop.Volume = 0.5f;
            if (musicEnabled)
            {
                triforceLoop.Play();
            }
        }

        public void PlayLobbyTune()
        {
            lobbyLoop.IsLooped = true;
            lobbyLoop.Volume = 0.5f;
            if (musicEnabled)
            {
                lobbyLoop.Play();
            }
        }

        public void StopDungeonSong()
        {
            dungeonLoop.Stop();
        }

        public void StopCreditsSong()
        {
            lobbyLoop.Stop();
        }

        public void StopBossSong()
        {
            bossLoop.Stop();
        }

        public void StopAll()
        {
            titleLoop.Stop();
            dungeonLoop.Stop();
            triforceLoop.Stop();
            bossLoop.Stop();
            lobbyLoop.Stop();
        }
    }
}
