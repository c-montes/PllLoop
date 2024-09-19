using OpenTap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenTap.Qualcomm.PllLoop
{

    [AllowAnyChild]
    [Display("Spurs Read Test Case File", Description: "Insert a description here", Group: "OpenTap.Qualcomm.PllLoop")]

    public class SpursReadTestCaseFile : TestStep
    {
        #region Settings
        private string _ScriptList;
        [Display("Test Case File", Group: "Test Case File", Order: 10)]
        [FilePath]
        public string TestCaseFile
        {
            get
            {
                return _ScriptList;
            }
            set
            {
                _ScriptList = value;
                // Parse ScriptList file
                ParseTestCaseFile();
            }
        }

        public Dictionary<string, string> CsvCacheSpur;

        #endregion



        public SpursReadTestCaseFile()
        {
            TestCaseFile = "SampleFiles\\SDR875_spurtestcases_F18904_RX_short.csv";
        }

        public override void Run()
        {
            // Only reading the map file once at the beginning of the test
            //ParseTestCaseFile();


            RunChildSteps();

            UpgradeVerdict(Verdict.Pass);
        }

        public void ParseTestCaseFile()
        {
            // Start Timer
            //Stopwatch stopWatch = new Stopwatch();

            CsvCacheSpur = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(TestCaseFile))
            {
                int lineCount = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lineCount++;
                    string[] script = line.Split(',');
                    if (lineCount > 2)
                    {
                        // Find if the script has already been added to the dictionary
                        if (CsvCacheSpur.ContainsKey(script[1]))
                        {
                            throw new Exception("Duplicate test case found: " + script[1]);
                        }

                        // Add the script to the dictionary
                        CsvCacheSpur.Add(script[1], line);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            // TODO
            // stop timer
            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            // log .Info("Time to parse map file: " + elapsedTime);

        }



    }
}
