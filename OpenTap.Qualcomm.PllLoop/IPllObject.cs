using System.Collections.Generic;

namespace OpenTap.Qualcomm.PllLoop
{// Define an interface for the objects
    public interface IPllObject
    {
        void Execute(List<string> MapFileValues);
    }
}