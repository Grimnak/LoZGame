using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    class CommandLoader
    {
        private Dictionary<Keys, ICommand> commands = new Dictionary<Keys, ICommand>();


        private CommandIdle commandIdle;

        private CommandW commandW;
        private CommandA commandA;
        private CommandS commandS;
        private CommandD commandD;

        private CommandZ commandZ;
        private CommandN commandN;

        private CommandE commandE;

        private CommandOne commandOne;
        private CommandTwo commandTwo;
        private CommandThree commandThree;
        private CommandFour commandFour;

        private CommandU commandU;
        private CommandI commandI;

        private CommandO commandO;
        private CommandP commandP;

        private CommandQ commandQ;

        private CommandR commandR;

        public CommandLoader(LoZGame game, IPlayer player /*, ItemManager? item, NpcManager npc*/)
        {

            commandIdle = new CommandIdle(player);

            commandW = new CommandW(player);
            commands.Add(Keys.W, commandW);
            commandA = new CommandA(player);
            commands.Add(Keys.A, commandA);
            commandS = new CommandS(player);
            commands.Add(Keys.S, commandS);
            commandD = new CommandD(player);
            commands.Add(Keys.D, commandD);

            commandZ = new CommandZ(player);
            commands.Add(Keys.Z, commandZ);
            commandN = new CommandN(player);
            commands.Add(Keys.N, commandN);

            commandE = new CommandE(player);
            commands.Add(Keys.E, commandE);

            commandOne = new CommandOne(player);
            commands.Add(Keys.D1, commandOne);
            commandTwo = new CommandTwo(player);
            commands.Add(Keys.D2, commandTwo);
            commandThree = new CommandThree(player);
            commands.Add(Keys.D3, commandThree);
            commandFour = new CommandFour(player);
            commands.Add(Keys.D4, commandFour);

            commandU = new CommandU(/*item*/);
            commands.Add(Keys.U, commandU);
            commandI = new CommandI(/*item*/);
            commands.Add(Keys.I, commandI);

            commandO = new CommandO(/*npc*/);
            commands.Add(Keys.O, commandO);
            commandP = new CommandP(/*npc*/);
            commands.Add(Keys.P, commandP);

            commandQ = new CommandQ(game);
            commands.Add(Keys.Q, commandQ);

            commandR = new CommandR(game);
            commands.Add(Keys.R, commandR);


        }

        public ICommand getIdle
        {
            get { return commandIdle; }
        }

        public Dictionary<Keys, ICommand> getCommands
        {
            get { return commands; }
        }


    }
}
