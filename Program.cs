using System;

namespace cssbs_ex06
{
    abstract class Military
    {
        protected double _TotalDefenseBudget = 934_000_000_000;
        protected double _BranchBudget;
        protected decimal _DefenseBudgetPercent;
        protected int _SMCount = 1_300_000;
        protected decimal _BranchSMCountPercent;
        protected decimal _BranchSMCount;
        protected string BranchName;
        public Military()
        {
        }
        public virtual void DisplayInfrastructure()
        {
            Console.WriteLine($"{this.BranchName}'s Branch Budget = ${ConvertToCommaNum(this._BranchBudget)}\n" +
                $"Personnel allotment = {Math.Round(this._BranchSMCount),0}");
        }
        public void DisplayUtilities()
        {
            Console.WriteLine($"We spend our money on {PrimaryModeOfTransportation()}!\n But do we have our own Medics?: {HasMedics()}!\n ");
        }

        //I used virtual here because each branch(derived class) may or may not have medics
        public virtual bool HasMedics()
        {
            return true;
        }


        //I used virtual here because each branch(derived class) spends money on different things, so they need to specify
       /* public virtual string PrimaryModeOfTransportation()
        {
            return "N/A";
        }*/
        //You can also use 'abstract' here instead of virtual, signifying that each branch HAS to override the string here like this:
        public abstract string PrimaryModeOfTransportation();

        public string ConvertToCommaNum(double branchBudget)
        {
            branchBudget = (long)branchBudget;
            string strA = branchBudget.ToString();
            int strLen = strA.Length;
            switch (strLen % 3)
            {
                case 0:
                    for (int i = 3; i <= strLen; i += 4)
                    {
                        strA = strA.Insert(i, ",");

                    }
                    return strA;

                case 1:
                    for (int i = 1; i <= strLen + 1; i += 4)
                    {
                        strA = strA.Insert(i, ",");

                    }
                    return strA;

                case 2:
                    for (int i = 2; i <= strLen + 2; i += 4)
                    {
                        strA = strA.Insert(i, ",");
                    }
                    return strA;
                default:
                    return strA;
            }
        }
    }
    class Army : Military
    {
        public Army()
        {
            this.BranchName = "Army";
            this._DefenseBudgetPercent = .257M;
            this._BranchSMCountPercent = .36M;
            this._BranchBudget = (double)_DefenseBudgetPercent * _TotalDefenseBudget;
            this._BranchSMCount = _SMCount * _BranchSMCountPercent;
        }

        //I used override here because each branch spends money on different things
        public override string PrimaryModeOfTransportation()
        {
            return "Airplanes";
        }
    }

    class AirForce : Military
    {
        public AirForce()
        {
            this.BranchName = "Air Force";
            this._DefenseBudgetPercent = .288M;
            this._BranchSMCountPercent = .23M;
            this._BranchBudget = (double)_DefenseBudgetPercent * _TotalDefenseBudget;
            this._BranchSMCount = _SMCount * _BranchSMCountPercent;
        }

        //I used override here because each branch spends money on different things
        public override string PrimaryModeOfTransportation()
        {
            return "Airplanes";
        }
    }

    class Navy : Military
    {

        public Navy()
        {
            this.BranchName = "Navy";
            this._DefenseBudgetPercent = .225M;
            this._BranchSMCountPercent = .28M;
            this._BranchBudget = (double)_DefenseBudgetPercent * _TotalDefenseBudget;
            this._BranchSMCount = _SMCount * _BranchSMCountPercent;
        }
        public double BranchBudget
        {
            get
            {
                return this._BranchBudget;
            }
        }

        //I used override here because each branch spends money on different things
        public override string PrimaryModeOfTransportation()
        {
            return "Boats and Airplanes";
        }
    }

    class Marines : Navy
    {
        private new double _TotalDefenseBudget;
        public Marines()
        {
            this.BranchName = "Marines";

            Navy navya = new Navy();
            this._TotalDefenseBudget = navya.BranchBudget;
            this._DefenseBudgetPercent = .228M;
            this._BranchSMCountPercent = .13M;
            this._BranchBudget = (double)_DefenseBudgetPercent * _TotalDefenseBudget;
            this._BranchSMCount = _SMCount * _BranchSMCountPercent;
        }
        //I used override here because 'Marines' end with an 's', so Marines's wouldn't make sense.

        public override void DisplayInfrastructure()
        {
            Console.WriteLine($"{this.BranchName}'s Branch Budget = ${ConvertToCommaNum(this._BranchBudget)}\n" +
                $"Personnel allotment = {Math.Round(this._BranchSMCount),0}");
        }

        //I used override here, because the base class defaults medics to true, 
        public override bool HasMedics()
        {
            return false;
        }

        //I used override here because each branch spends money on different things
        public override string PrimaryModeOfTransportation()
        {
            return "Boats";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Army army = new Army();
            Navy navy = new Navy();
            AirForce airForce = new AirForce();
            Marines marines = new Marines();
            army.DisplayInfrastructure();
            army.DisplayUtilities();
            navy.DisplayInfrastructure();
            navy.DisplayUtilities();
            airForce.DisplayInfrastructure();
            airForce.DisplayUtilities();
            marines.DisplayInfrastructure();
            marines.DisplayUtilities();

        }
    }
}
