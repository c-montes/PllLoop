using OpenTap;
using System;

namespace OpenTap.Qualcomm.PllLoop
{// Factory class to create objects based on the selected option
    public static class PllObjectFactory
    {
        static readonly TraceSource PllObjectFactoryLog = OpenTap.Log.CreateSource("PllObjectFactory");
        public static IPllObject Create(OptionType option)
        {
            //return option switch
            //{
            //    OptionType.TX_PLL => new TxPllObject(),
            //    OptionType.RX_PLL => new RxPllObject(),
            //    OptionType.XO_PLL => new XoPllObject(),
            //    _ => throw new ArgumentException("Invalid option type", nameof(option)),
            //};
            switch (option)
            {
                case OptionType.TX_PLL:
                    return new TxPllObject();
                case OptionType.RX_PLL:
                    return new RxPllObject();
                case OptionType.XO_PLL:
                    return new XoPllObject();
                default:
                    throw new ArgumentException("Invalid option type", nameof(option));
            }
        }
    }
}