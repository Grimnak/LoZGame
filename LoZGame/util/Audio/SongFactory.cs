namespace LoZClone
{
    using System.Media;

    class SongFactory
    {
        bool musicEnabled = false;
        SoundPlayer titleSong = new SoundPlayer(Properties.Resources.title_song);
        SoundPlayer dungeonSong = new SoundPlayer(Properties.Resources.dungeon_song);
        SoundPlayer triforceTune = new SoundPlayer(Properties.Resources.triforce_tune);

        private static readonly SongFactory instance = new SongFactory();

        public static SongFactory Instance
        {
            get
            {
                return instance;
            }
        }

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
