using OpenTap;
using System;

namespace OpenTap.Qualcomm.PllLoop
{// Factory class to create objects based on the selected option
    public static class PllObjectFactory
    {
        static readonly TraceSource PllObjectFactoryLog = OpenTap.Log.CreateSource("PllObjectFactory");
        public static IPllObject Create(string pllType)
        {
            if (pllType.Contains("RP0"))
            {
                return new RxPll0Object();
            }
            else if (pllType.Contains("RP1"))
            {
                return new RxPll1Object();
            }
            else if (pllType.Contains("RP2"))
            {
                return new RxPll2Object();
            }
            else
            {
                PllObjectFactoryLog.Error("Invalid option type");
                throw new ArgumentException("Invalid option type", nameof(pllType));
            }
        }
    }
}