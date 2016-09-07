using System;
using System.Collections.Generic;

namespace WhyRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WhyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WhyService.svc or WhyService.svc.cs at the Solution Explorer and start debugging.
    public class WhyService : IWhyService
    {

        public List<Effect> GetFXList()
        {
            return Effects.Instance.EffectList;
        }

        public Effect GetFx(string id)
        {
            return Effects.Instance.EffectList[Int32.Parse(id)];
        }

        public string Fire(string id)
        {
            //1 -7 in the api corresponds to 2 - 8
            int ident = Int32.Parse(id);
            Effects.Instance.Fire(ident);
            return "Fired Effect: " + id; 
        }

        public string sweepLeft()
        {
            Effects.sendSerial("2\n");
            return "Sweep Left Executed";
        }

        public string sweepRight()
        {
            Effects.sendSerial("3\n");
            return "Sweep Right Executed";
        }

        public string alternate()
        {
            Effects.sendSerial("4\n");
            return "Alternate Executed";
        }

        public string winston()
        {
            Effects.sendSerial("5\n");
            return "Winston Executed";
        }

        public string rollcall()
        {
            Effects.sendSerial("6\n");
            return "Rollcall Executed";
        }

        public string middlefinger()
        {
            Effects.sendSerial("7\n");
            return "Middlefinger Executed";
        }

        public string stayout()
        {
            Effects.sendSerial("8\n");
            return "Stay Out Executed";
        }

        public string ynot()
        {
            Effects.sendSerial("9\n");
            return "Why Not Executed";
        }

        public string all()
        {
            Effects.sendSerial("0\n");
            return "All Fire Executed";
        }
    }
}
