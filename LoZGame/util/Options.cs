using System;
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
            Debug
        };

        private OptionType selectedOption;


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
                    selectedOption = OptionType.Debug;
                    break;
                case OptionType.Cheats:
                    selectedOption = OptionType.Difficulty;
                    break;
                case OptionType.Debug:
                    selectedOption = OptionType.Cheats;
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
            if (LoZGame.DebugMode)
            {
                LoZGame.DebugMode = false;
            }
            else
            {
                LoZGame.DebugMode = true;
            }
        }

        private void ToggleCheats()
        {
            if (LoZGame.Cheats)
            {
                LoZGame.Cheats = false;
            }
            else
            {
                LoZGame.Cheats = true;
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
                default:
                    break;
            }
        }

    }
}
