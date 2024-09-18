using OpenTap;
using System;
using System.Collections.Generic;

namespace OpenTap.Qualcomm.PllLoop
{
    // Implement the interface for TX_PLL
    public class TxPllObject : IPllObject
    {
        static readonly TraceSource TxPllObjectLog = OpenTap.Log.CreateSource("TxPllObject");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for TX_PLL
            TxPllObjectLog.Info("Executing TX_PLL logic.");
        }
    }

    // Implement the interface for RX_PLL
    public class RxPll0Object : IPllObject
    {
        static readonly TraceSource RxPllObjectLog = OpenTap.Log.CreateSource("RxPll0Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL0
            RxPllObjectLog.Info("Executing RX_PLL0 logic.");

            RxPllObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPllObjectLog.Info(value);
            }

        }
    }

    // Implement the interface for RX_PLL
    public class RxPll1Object : IPllObject
    {
        static readonly TraceSource RxPllObjectLog = OpenTap.Log.CreateSource("RxPll1Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL1
            RxPllObjectLog.Info("Executing RX_PLL1 logic.");

            RxPllObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPllObjectLog.Info(value);
            }
        }
    }

    // Implement the interface for RX_PLL
    public class RxPll2Object : IPllObject
    {
        static readonly TraceSource RxPllObjectLog = OpenTap.Log.CreateSource("RxPll2Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL2
            RxPllObjectLog.Info("Executing RX_PLL2 logic.");

            RxPllObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPllObjectLog.Info(value);
            }
        }
    }

    // Implement the interface for XO_PLL
    public class XoPllObject : IPllObject
    {
        static readonly TraceSource XoPllObjectLog = OpenTap.Log.CreateSource("XoPllObject");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for XO_PLL
            XoPllObjectLog.Info("Executing XO_PLL logic.");
        }
    }
}