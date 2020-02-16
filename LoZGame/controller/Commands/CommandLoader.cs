using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    public class CommandLoader
    {
        private CommandIdle commandIdle;
        private Dictionary<Keys, ICommand> dictionary;

        public CommandLoader(LoZGame game, IPlayer player, ItemManager item, BlockManager block, EntityManager entity/*, NpcManager npc*/)
        {
            dictionary = new Dictionary<Keys, ICommand>();

            commandIdle = new CommandIdle(player);

            dictionary.Add(Keys.W, new CommandUp(player));
            dictionary.Add(Keys.A, new CommandLeft(player));
            dictionary.Add(Keys.S, new CommandDown(player));
            dictionary.Add(Keys.D, new CommandRight(player));

            dictionary.Add(Keys.Z, new CommandAttackA(player, entity));
            dictionary.Add(Keys.N, new CommandAttackB(player, entity));

            dictionary.Add(Keys.E, new CommandDamage(player));

            dictionary.Add(Keys.D1, new CommandBomb(player, entity));
            dictionary.Add(Keys.D2, new CommandArrow(player, entity));
            dictionary.Add(Keys.D3, new CommandBoomerang(player, entity));
            dictionary.Add(Keys.D4, new CommandBlueCandle(player, entity));
            dictionary.Add(Keys.D5, new CommandSilverArrow(player, entity));
            dictionary.Add(Keys.D6, new CommandMagicBoomerang(player, entity));
            dictionary.Add(Keys.D7, new CommandRedCandle(player, entity));
            dictionary.Add(Keys.D8, new CommandTriforce(player, entity));

            dictionary.Add(Keys.U, new CommandItemLeft(item));
            dictionary.Add(Keys.I, new CommandItemRight(item));

            dictionary.Add(Keys.K, new CommandBlockLeft(block));
            dictionary.Add(Keys.L, new CommandBlockRight(block));

            dictionary.Add(Keys.O, new CommandEnemyLeft(/*npc*/));
            dictionary.Add(Keys.P, new CommandEnemyRight(/*npc*/));

            dictionary.Add(Keys.Q, new CommandQuit(game));

            dictionary.Add(Keys.R, new CommandReset(game, player, item, block, entity));
        }

        public ICommand getIdle
        {
            get { return commandIdle; }
        }

        public Dictionary<Keys, ICommand> getDict
        {
            get { return dictionary; }
        }

    }
}
