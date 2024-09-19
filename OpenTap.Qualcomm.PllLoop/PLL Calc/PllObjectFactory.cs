using OpenTap;
using System;

namespace OpenTap.Qualcomm.PllLoop
{// Factory class to create objects based on the selected option
    public static class PllObjectFactory
    {
        static readonly TraceSource PllObjectFactoryLog = OpenTap.Log.CreateSource("PllObjectFactory");
        public static IPllObject Create(string pllType)
        {
            if (pllType.Contains("RP0") || pllType.Equals("RX0"))
            {
                return new RxPll0Object();
            }
            else if (pllType.Contains("RP1") || pllType.Equals("RX1"))
            {
                return new RxPll1Object();
            }
            else if (pllType.Contains("RP2") || pllType.Equals("RX2"))
            {
                return new RxPll2Object();
            }
            else if (pllType.Contains("RP3") || pllType.Equals("RX3"))
            {
                return new RxPll3Object();
            }
            else if (pllType.Contains("RP4") || pllType.Equals("RX4"))
            {
                return new RxPll4Object();
            }
            else if (pllType.Contains("RP5") || pllType.Equals("RX5"))
            {
                return new RxPll5Object();
            }
            else if (pllType.Contains("RP6") || pllType.Equals("RX6"))
            {
                return new RxPll6Object();
            }
            else if (pllType.Contains("TP0") || pllType.Equals("TX0"))
            {
                return new TxPll0Object();
            }
            else if (pllType.Contains("TP1") || pllType.Equals("TX1"))
            {
                return new TxPll1Object();
            }
            else if (pllType.Contains("TP2") || pllType.Equals("TX2"))
            {
                return new TxPll2Object();
            }
            else
            {
                PllObjectFactoryLog.Error("Invalid option type");
                throw new ArgumentException("Invalid option type", nameof(pllType));
            }
        }
    }
}