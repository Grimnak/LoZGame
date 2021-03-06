﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class Options
    {
        public enum OptionType
        {
            Difficulty,
            Cheats,
            Debug,
            Music
        };

        private OptionType selectedOption;

        public OptionType SelectedOption => selectedOption;

        List<DifficultyMapper> difficulties = DifficultyMapper.GetMyTypes();

        public Options()
        {
            selectedOption = OptionType.Difficulty;
        }

        public void MoveSelectionDown()
        {
            switch (selectedOption)
            {
                case OptionType.Difficulty:
                    selectedOption = OptionType.Cheats;
                    break;
                case OptionType.Cheats:
                    selectedOption = OptionType.Debug;
                    break;
                case OptionType.Debug:
                    selectedOption = OptionType.Music;
                    break;
                case OptionType.Music:
                    selectedOption = OptionType.Difficulty;
                    break;
                default:
                    selectedOption = OptionType.Difficulty;
                    break;
            }
        }

        public void MoveSelectionUp()
        {
            switch (selectedOption)
            {
                case OptionType.Difficulty:
                    selectedOption = OptionType.Music;
                    break;
                case OptionType.Cheats:
                    selectedOption = OptionType.Difficulty;
                    break;
                case OptionType.Debug:
                    selectedOption = OptionType.Cheats;
                    break;
                case OptionType.Music:
                    selectedOption = OptionType.Debug;
                    break;
                default:
                    selectedOption = OptionType.Difficulty;
                    break;
            }
        }

        private void ChangeDifficulty()
        {
            switch (LoZGame.Instance.Difficulty)
            {
                case -1:
                    LoZGame.Instance.Difficulty = 0;
                    break;
                case 0:
                    LoZGame.Instance.Difficulty = 1;
                    break;
                case 1:
                    LoZGame.Instance.Difficulty = 3;
                    break;
                case 3:
                    LoZGame.Instance.Difficulty = -1;
                    break;
                default:
                    LoZGame.Instance.Difficulty = 0;
                    break;
            }
        }

        private void ToggleDebug()
        {
            LoZGame.DebugMode = !LoZGame.DebugMode;
        }

        private void ToggleCheats()
        {
            LoZGame.Cheats = !LoZGame.Cheats;
        }

        private void ToggleMusic()
        {
            LoZGame.Music = !LoZGame.Music;
            if (!LoZGame.Music)
            {
                SoundFactory.Instance.StopAll();
            }
            else
            {
                if (LoZGame.Instance.Dungeon.CurrentRoomX == LoZGame.Instance.Dungeon.DungeonBossLocation.X && LoZGame.Instance.Dungeon.CurrentRoomY == LoZGame.Instance.Dungeon.DungeonBossLocation.Y)
                {
                    SoundFactory.Instance.PlayBossSong();
                }
                else
                {
                    SoundFactory.Instance.PlayDungeonSong();
                }
            }
        }

        public void DetermineWhatToDo()
        {
            switch (selectedOption)
            {
                case OptionType.Difficulty:
                    ChangeDifficulty();
                    break;
                case OptionType.Cheats:
                    ToggleCheats();
                    break;
                case OptionType.Debug:
                    ToggleDebug();
                    break;
                case OptionType.Music:
                    ToggleMusic();
                    break;
                default:
                    break;
            }
        }

    }
}
