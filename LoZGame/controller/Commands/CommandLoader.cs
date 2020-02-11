namespace LoZClone
{
    public class CommandLoader
    {
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
        private CommandFive commandFive;
        private CommandSix commandSix;
        private CommandSeven commandSeven;

        private CommandU commandU;
        private CommandI commandI;

        private CommandO commandO;
        private CommandP commandP;

        private CommandQ commandQ;

        private CommandR commandR;

        public CommandLoader(LoZGame game, IPlayer player , ItemManager item/*, InventoryManager inventory, NpcManager npc*/)
        {
            commandIdle = new CommandIdle(player);

            commandW = new CommandW(player);
            commandA = new CommandA(player);
            commandS = new CommandS(player);
            commandD = new CommandD(player);

            commandZ = new CommandZ(player);
            commandN = new CommandN(player);

            commandE = new CommandE(player);

            commandOne = new CommandOne(player/*, inventory*/);
            commandTwo = new CommandTwo(player/*, inventory*/);
            commandThree = new CommandThree(player/*, inventory*/);
            commandFour = new CommandFour(player/*, inventory*/);
            commandFive = new CommandFive(player/*, inventory*/);
            commandSix = new CommandSix(player/*, inventory*/);
            commandSeven = new CommandSeven(player/*, inventory*/);

            commandU = new CommandU(item);
            commandI = new CommandI(item);

            commandO = new CommandO(/*npc*/);
            commandP = new CommandP(/*npc*/);

            commandQ = new CommandQ(game);

            commandR = new CommandR(game, player, item);
        }

        public ICommand getIdle
        {
            get { return commandIdle; }
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

        public ICommand getFour
        {
            get { return commandFour; }
        }

        public ICommand getFive
        {
            get { return commandFive; }
        }

        public ICommand getSix
        {
            get { return commandSix; }
        }

        public ICommand getSeven
        {
            get { return commandSeven; }
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
