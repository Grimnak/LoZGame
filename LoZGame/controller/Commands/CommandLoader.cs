using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    public class CommandLoader
    {
        private CommandIdle commandIdle;

        private CommandUp commandUp;
        private CommandLeft commandLeft;
        private CommandDown commandDown;
        private CommandRight commandRight;

        private CommandAttackA commandAttackA;
        private CommandAttackB commandAttackB;

        private CommandDamage commandDamage;

        private CommandBomb commandBomb;
        private CommandArrow commandArrow;
        private CommandBoomerang commandBoomerang;
        private CommandBlueCandle commandBlueCandle;
        private CommandSilverArrow commandSilverArrow;
        private CommandMagicBoomerang commandMagicBoomerang;
        private CommandRedCandle commandRedCandle;
        private CommandTriforce commandTriforce;

        private CommandItemLeft commandItemLeft;
        private CommandItemRight commandItemRight;

        private CommandBlockLeft commandBlockLeft;
        private CommandBlockRight commandBlockRight;

        private CommandEnemyLeft commandEnemyLeft;
        private CommandEnemyRight commandEnemyRight;

        private CommandQuit commandQuit;

        private CommandReset commandReset;

        private Dictionary<Keys, ICommand> dictionary;

        public CommandLoader(LoZGame game, IPlayer player, ItemManager item, BlockManager block, ProjectileManager projectile/*, NpcManager npc*/)
        {
            dictionary = new Dictionary<Keys, ICommand>();

            commandIdle = new CommandIdle(player);

            commandUp = new CommandUp(player);
            dictionary.Add(Keys.W, commandUp);
            commandLeft = new CommandLeft(player);
            dictionary.Add(Keys.A, commandLeft);
            commandDown = new CommandDown(player);
            dictionary.Add(Keys.S, commandDown);
            commandRight = new CommandRight(player);
            dictionary.Add(Keys.D, commandRight);

            commandAttackA = new CommandAttackA(player, projectile);
            dictionary.Add(Keys.Z, commandAttackA);
            commandAttackB = new CommandAttackB(player, projectile);
            dictionary.Add(Keys.N, commandAttackB);

            commandDamage = new CommandDamage(player);
            dictionary.Add(Keys.E, commandDamage);

            commandBomb = new CommandBomb(player, projectile);
            dictionary.Add(Keys.D1, commandBomb);
            commandArrow = new CommandArrow(player, projectile);
            dictionary.Add(Keys.D2, commandArrow);
            commandBoomerang = new CommandBoomerang(player, projectile);
            dictionary.Add(Keys.D3, commandBoomerang);
            commandBlueCandle = new CommandBlueCandle(player, projectile);
            dictionary.Add(Keys.D4, commandBlueCandle);
            commandSilverArrow = new CommandSilverArrow(player, projectile);
            dictionary.Add(Keys.D5, commandSilverArrow);
            commandMagicBoomerang = new CommandMagicBoomerang(player, projectile);
            dictionary.Add(Keys.D6, commandMagicBoomerang);
            commandRedCandle = new CommandRedCandle(player, projectile);
            dictionary.Add(Keys.D7, commandRedCandle);
            commandTriforce = new CommandTriforce(player, projectile);
            dictionary.Add(Keys.D8, commandTriforce);

            commandItemLeft = new CommandItemLeft(item);
            dictionary.Add(Keys.U, commandItemLeft);
            commandItemRight = new CommandItemRight(item);
            dictionary.Add(Keys.I, commandItemRight);

            commandBlockLeft = new CommandBlockLeft(block);
            dictionary.Add(Keys.K, commandBlockLeft);
            commandBlockRight = new CommandBlockRight(block);
            dictionary.Add(Keys.L, commandBlockRight);

            commandEnemyLeft = new CommandEnemyLeft(/*npc*/);
            dictionary.Add(Keys.O, commandEnemyLeft);
            commandEnemyRight = new CommandEnemyRight(/*npc*/);
            dictionary.Add(Keys.P, commandEnemyRight);

            commandQuit = new CommandQuit(game);
            dictionary.Add(Keys.Q, commandQuit);

            commandReset = new CommandReset(game, player, item, block, projectile);
            dictionary.Add(Keys.R, commandReset);
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
