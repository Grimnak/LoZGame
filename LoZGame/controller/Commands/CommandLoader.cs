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
            commandA = new CommandA(player);
            commandS = new CommandS(player);
            commandD = new CommandD(player);

            commandZ = new CommandZ(player);
            commandN = new CommandN(player);

            commandE = new CommandE(player);

            commandOne = new CommandOne(player);
            commandTwo = new CommandTwo(player);

            commandU = new CommandU(/*item*/);
            commandI = new CommandI(/*item*/);

            commandO = new CommandO(/*npc*/);
            commandP = new CommandP(/*npc*/);

            commandQ = new CommandQ(game);

            commandR = new CommandR(game);
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