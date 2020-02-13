using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    public class CommandLoader
    {
        private CommandIdle commandIdle;

        private CommandW commandW;
        private CommandA commandA;
        private CommandS commandS;
        private CommandD commandD;

        private CommandL commandL;
        private CommandK commandK;

        private CommandZ commandZ;
        private CommandN commandN;

        private CommandE commandE;

        private CommandOne commandOne;
        private CommandTwo commandTwo;
        private CommandThree commandThree;
        private CommandFour commandFour;
        private CommandFive commandFive;
        private CommandSix commandSix;
        private CommandSeven commandSeven;

        private CommandU commandU;
        private CommandI commandI;

        private CommandO commandO;
        private CommandP commandP;

        private CommandQ commandQ;

        private CommandR commandR;

        private Dictionary<Keys, ICommand> dictionary;

        public CommandLoader(LoZGame game, IPlayer player, ItemManager item, BlockManager block, InventoryManager inventory/*, NpcManager npc*/)
        {
            dictionary = new Dictionary<Keys, ICommand>();

            commandIdle = new CommandIdle(player);

            commandW = new CommandW(player);
            dictionary.Add(Keys.W, commandW);
            commandA = new CommandA(player);
            dictionary.Add(Keys.A, commandA);
            commandS = new CommandS(player);
            dictionary.Add(Keys.S, commandS);
            commandD = new CommandD(player);
            dictionary.Add(Keys.D, commandD);

            commandZ = new CommandZ(player);
            dictionary.Add(Keys.Z, commandZ);
            commandN = new CommandN(player);
            dictionary.Add(Keys.N, commandN);

            commandE = new CommandE(player);
            dictionary.Add(Keys.E, commandE);

            commandOne = new CommandOne(player, inventory);
            dictionary.Add(Keys.D1, commandOne);
            commandTwo = new CommandTwo(player, inventory);
            dictionary.Add(Keys.D2, commandTwo);
            commandThree = new CommandThree(player, inventory);
            dictionary.Add(Keys.D3, commandThree);
            commandFour = new CommandFour(player, inventory);
            dictionary.Add(Keys.D4, commandFour);
            commandFive = new CommandFive(player, inventory);
            dictionary.Add(Keys.D5, commandFive);
            commandSix = new CommandSix(player, inventory);
            dictionary.Add(Keys.D6, commandSix);
            commandSeven = new CommandSeven(player, inventory);
            dictionary.Add(Keys.D7, commandSeven);

            commandU = new CommandU(item);
            dictionary.Add(Keys.U, commandU);
            commandI = new CommandI(item);
            dictionary.Add(Keys.I, commandI);

            commandK = new CommandK(block);
            dictionary.Add(Keys.K, commandK);
            commandL = new CommandL(block);
            dictionary.Add(Keys.L, commandL);

            commandO = new CommandO(/*npc*/);
            dictionary.Add(Keys.O, commandO);
            commandP = new CommandP(/*npc*/);
            dictionary.Add(Keys.P, commandP);

            commandQ = new CommandQ(game);
            dictionary.Add(Keys.Q, commandQ);

            commandR = new CommandR(game, player, item, block, inventory);
            dictionary.Add(Keys.R, commandR);
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
