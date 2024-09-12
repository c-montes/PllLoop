using OpenTap;
using System;

namespace OpenTap.Qualcomm.PllLoop
{
    // Implement the interface for TX_PLL
    public class TxPllObject : IPllObject
    {
        static readonly TraceSource TxPllObjectLog = OpenTap.Log.CreateSource("TxPllObject");

        public void Execute()
        {
            // Add logic for TX_PLL
            TxPllObjectLog.Info("Executing TX_PLL logic.");
        }
    }

    // Implement the interface for RX_PLL
    public class RxPllObject : IPllObject
    {
        static readonly TraceSource RxPllObjectLog = OpenTap.Log.CreateSource("RxPllObject");

        public void Execute()
        {
            // Add logic for RX_PLL
            RxPllObjectLog.Info("Executing RX_PLL logic.");
        }
    }

    // Implement the interface for XO_PLL
    public class XoPllObject : IPllObject
    {
        static readonly TraceSource XoPllObjectLog = OpenTap.Log.CreateSource("XoPllObject");

        public void Execute()
        {
            // Add logic for XO_PLL
            XoPllObjectLog.Info("Executing XO_PLL logic.");
        }
    }
}