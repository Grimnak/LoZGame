using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandOptions : ICommand
    {
        public CommandOptions()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (LoZGame.Instance.GameState is OptionsState)
            {
                LoZGame.Instance.GameState.Unpause();
            }
            else
            {
                LoZGame.Instance.GameState.Options();
            }
        }
    }
}
