using OpenTap;
using System;
using System.Collections.Generic;

namespace OpenTap.Qualcomm.PllLoop
{
    // Implement the interface for TX_PLL0
    public class TxPll0Object : IPllObject
    {
        static readonly TraceSource TxPll0ObjectLog = OpenTap.Log.CreateSource("TxPll0Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for TX_PLL
            TxPll0ObjectLog.Info("Executing TX_PLL0 logic.");
        }
    }

    // Implement the interface for TX_PLL1
    public class TxPll1Object : IPllObject
    {
        static readonly TraceSource TxPll1ObjectLog = OpenTap.Log.CreateSource("TxPll1Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for TX_PLL
            TxPll1ObjectLog.Info("Executing TX_PLL1 logic.");
        }
    }

    // Implement the interface for TX_PLL2
    public class TxPll2Object : IPllObject
    {
        static readonly TraceSource TxPll2ObjectLog = OpenTap.Log.CreateSource("TxPll2Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for TX_PLL
            TxPll2ObjectLog.Info("Executing TX_PLL2 logic.");
        }
    }

    // Implement the interface for RX_PLL0
    public class RxPll0Object : IPllObject
    {
        static readonly TraceSource RxPll0ObjectLog = OpenTap.Log.CreateSource("RxPll0Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL0
            RxPll0ObjectLog.Info("Executing RX_PLL0 logic.");

            RxPll0ObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPll0ObjectLog.Info(value);
            }

        }
    }

    // Implement the interface for RX_PLL1
    public class RxPll1Object : IPllObject
    {
        static readonly TraceSource RxPll1ObjectLog = OpenTap.Log.CreateSource("RxPll1Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL1
            RxPll1ObjectLog.Info("Executing RX_PLL1 logic.");

            RxPll1ObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPll1ObjectLog.Info(value);
            }
        }
    }

    // Implement the interface for RX_PLL2
    public class RxPll2Object : IPllObject
    {
        static readonly TraceSource RxPll2ObjectLog = OpenTap.Log.CreateSource("RxPll2Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL2
            RxPll2ObjectLog.Info("Executing RX_PLL2 logic.");

            RxPll2ObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPll2ObjectLog.Info(value);
            }
        }
    }

    // Implement the interface for RX_PLL3
    public class RxPll3Object : IPllObject
    {
        static readonly TraceSource RxPll3ObjectLog = OpenTap.Log.CreateSource("RxPll3Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL2
            RxPll3ObjectLog.Info("Executing RX_PLL3 logic.");

            RxPll3ObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPll3ObjectLog.Info(value);
            }
        }
    }

    // Implement the interface for RX_PLL4
    public class RxPll4Object : IPllObject
    {
        static readonly TraceSource RxPll4ObjectLog = OpenTap.Log.CreateSource("RxPll4Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL2
            RxPll4ObjectLog.Info("Executing RX_PLL4 logic.");

            RxPll4ObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPll4ObjectLog.Info(value);
            }
        }
    }

    // Implement the interface for RX_PLL5
    public class RxPll5Object : IPllObject
    {
        static readonly TraceSource RxPll5ObjectLog = OpenTap.Log.CreateSource("RxPll5Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL2
            RxPll5ObjectLog.Info("Executing RX_PLL5 logic.");

            RxPll5ObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPll5ObjectLog.Info(value);
            }
        }
    }

    // Implement the interface for RX_PLL6
    public class RxPll6Object : IPllObject
    {
        static readonly TraceSource RxPll6ObjectLog = OpenTap.Log.CreateSource("RxPll6Object");

        public void Execute(List<string> MapFileValues)
        {
            // Add logic for RX_PLL2
            RxPll6ObjectLog.Info("Executing RX_PLL6 logic.");

            RxPll6ObjectLog.Info("Map File Values");
            int i = 0;
            foreach (string value in MapFileValues)
            {
                i++;
                if (i == 1) continue;
                RxPll6ObjectLog.Info(value);
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