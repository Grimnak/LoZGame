using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class CommandLoader
    {
        private CommandIdleUp commandIdleUp;
        private CommandIdleDown commandIdleDown;
        private CommandIdleLeft commandIdleLeft;
        private CommandIdleRight commandIdleRight;

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

        private CommandU commandU;
        private CommandI commandI;

        private CommandO commandO;
        private CommandP commandP;

        private CommandQ commandQ;

        private CommandR commandR;

        public CommandLoader(Game game, Iplayer player /*, ItemManager? item, NpcManager npc*/)
        {
            //TODO constructors for all commands
            commandIdleUp = new CommandIdleUp(player);
            commandIdleDown = new CommandIdleDown(player);
            commandIdleLeft = new CommandIdleLeft(player);
            commandIdleRight = new CommandIdleRight(player);

            commandW = new CommandW(player);
            commandA = new CommandA(player);
            commandS = new CommandS(player);
            commandD = new CommandD(player);

            commandZ = new CommandZ(player);
            commandN = new CommandN(player);

            commandE = new CommandE(player);

            commandOne = new CommandOne(player);
            commandTwo = new CommandTwo(player);
            commandThree = new CommandThree(player);

            commandU = new CommandU(/*item*/);
            commandI = new CommandI(/*item*/);

            commandO = new CommandO(/*npc*/);
            commandP = new CommandP(/*npc*/);

            commandQ = new CommandQ(game);

            commandR = new CommandR(/*game*/);

            //Command Idle

        }

        public ICommand getIdleUp
        {
            get { return commandIdleUp; }
        }

        public ICommand getIdleDown
        {
            get { return commandIdleDown; }
        }

        public ICommand getIdleLeft
        {
            get { return commandIdleLeft; }
        }
        public ICommand getIdleRight
        {
            get { return commandIdleRight; }
        }

        public ICommand getW
        {
            get { return commandW; }
        }

        public ICommand getA
        {
            get { return commandA; }
        }

        public ICommand getS
        {
            get { return commandS; }
        }

        public ICommand getD
        {
            get { return commandD; }
        }

        public ICommand getZ
        {
            get { return commandZ; }
        }

        public ICommand getN
        {
            get { return commandN; }
        }

        public ICommand getE
        {
            get { return commandE; }
        }

        public ICommand getOne
        {
            get { return commandOne; }
        }

        public ICommand getTwo
        {
            get { return commandTwo; }
        }

        public ICommand getThree
        {
            get { return commandThree; }
        }

        public ICommand getU
        {
            get { return commandU; }
        }

        public ICommand getI
        {
            get { return commandI; }
        }

        public ICommand getO
        {
            get { return commandO; }
        }

        public ICommand getP
        {
            get { return commandP; }
        }

        public ICommand getQ
        {
            get { return commandQ; }
        }

        public ICommand getR
        {
            get { return commandR; }
        }


    }
}
