using OpenTap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenTap.Qualcomm.PllLoop
{

    [AllowAnyChild]
    [Display("Config Spur Search Test", Description: "Insert a description here", Group: "OpenTap.Qualcomm.PllLoop")]

    public class ConfigSpurSearch : TestStep
    {
        #region Settings

        private Dictionary<string, string> CsvCacheSpur;

        #endregion



        public ConfigSpurSearch()
        {
        }

        public override void Run()
        {
            // Get dictionary from parent
            CsvCacheSpur = this.GetParent<SpursReadTestCaseFile>().CsvCacheSpur;
            string ExportedScriptName = GetParent<PllCalcCATestStep>().ExportedScriptName;
            ExportedScriptName = ExportedScriptName.Replace(".csv", "");

            string SpurSearch;
            if (CsvCacheSpur.TryGetValue(ExportedScriptName, out SpurSearch))
            {
                string Headers = CsvCacheSpur.First().Value;
                string[] SpurSearchArray = SpurSearch.Split(',');
                string[] HeadersArray = Headers.Split(',');
                for (int i = 0; i < SpurSearchArray.Length; i++)
                {
                    Log.Info("Spur Search: " + HeadersArray[i] + " = " + SpurSearchArray[i]);
                }
                // TODO
                // Push the dictionary to Test Settings dictionary
                // TODO

            }

            RunChildSteps();

            UpgradeVerdict(Verdict.Pass);
        }




    }
}
