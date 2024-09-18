using OpenTap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenTap.Qualcomm.PllLoop
{
    public class PLLScriptList
    {
        [Display("Enabled", Order: 0.1)]
        public bool Enabled { get; set; }
        [Display("Main Script", Order: 1)]
        public string MainScript { get; set; }
        [Display("Delta Script", Order: 2)]
        public string DeltaScript { get; set; }
        [Display("Delta Script After", Order: 3)]
        public string DeltaScriptAfter { get; set; } 
        [Display("PLL to Meas", Order: 4)]
        public string PLL_to_Meas { get; set; }	
        [Display("AUTO Freq Override", Order: 5)]
        public string AUTO_Freq_Override { get; set; } 
        [Display("AUTO Freq Mode", Order: 6)]
        public string AUTO_Freq_Mode { get; set; } 
        [Display("in step channel sweep", Order: 7)]
        public string in_step_channel_sweep { get; set; }
    }

    [AllowAnyChild]
    [Display("PLL Calculator", Description: "Insert a description here", Group: "OpenTap.Qualcomm.PllLoop")]

    public class PllCalcTestStep : TestStep
    {
        #region Settings
        private string _ScriptList;
        [Display("Script List", Group: "Script List", Order: 10)]
        [FilePath]
        public string ScriptList
        {
            get
            {
                return _ScriptList;
            }
            set
            {
                _ScriptList = value;
                // Parse ScriptList file
                ParseScriptList();
            }
        }

        [Display("Script Folder", Group: "Script List", Order: 11)]
        public string ScriptFolder { get; set; }
        [Display("Map File", Group: "Script List", Order: 12)]
        public string MapFile { get; set; }
        [Display("Script List", Group: "Script List", Order: 13)]
        public List<PLLScriptList> PllScriptList { get; set; }
        #endregion

        private List<string> MapFileList = new List<string>();


        public PllCalcTestStep()
        {
            ScriptList = "SampleFiles\\ScriptListSample.csv";
        }

        public override void Run()
        {
            // Only reading the map file once at the beginning of the test
            ParseMapFile();


            foreach(PLLScriptList script in PllScriptList)
            {

                if (!script.Enabled)
                {
                    continue;
                }
                List<string> MapFileValues = SearchMapFile(script.MainScript);

                // Find what type of PLL is from script headers: i.e. RP0 -> RX_PLL0
                // in the following example: RF_WMSS_MMWIF8P3_RP0-R0_HOME_100_8300P0_1_1212_BF1_0X01_CL7_N
                // the PLL type is RP0 on the 4th position
                String pllType = script.MainScript.Split('_')[3];

                // Use the factory to create the appropriate object
                IPllObject pllObject = PllObjectFactory.Create(pllType);



                if (script.AUTO_Freq_Override.Contains(":"))
                {
                    // Unroll Frequency
                    List<double> freqList = UnrollFrequency(script.AUTO_Freq_Override);
                    foreach (double freq in freqList)
                    {
                        Log.Info("MainScript: " + UpdateKey(script.MainScript, freq));
                        //Log.Info("DeltaScript: " + script.DeltaScript);
                        //Log.Info("DeltaScriptAfter: " + script.DeltaScriptAfter);
                        //Log.Info("PLL_to_Meas: " + script.PLL_to_Meas);
                        Log.Info("AUTO_Freq_Override: " + freq);
                        //Log.Info("AUTO_Freq_Mode: " + script.AUTO_Freq_Mode);
                        //Log.Info("in_step_channel_sweep: " + script.in_step_channel_sweep);

                        pllObject.Execute(MapFileValues);

                        RunChildSteps(); //If step has child steps.

                    }
                }
                else
                {
                    // Single Frequency
                    Log.Info("MainScript: " + script.MainScript);
                    //Log.Info("DeltaScript: " + script.DeltaScript);
                    //Log.Info("DeltaScriptAfter: " + script.DeltaScriptAfter);
                    //Log.Info("PLL_to_Meas: " + script.PLL_to_Meas);
                    Log.Info("AUTO_Freq_Override: " + script.AUTO_Freq_Override);
                    //Log.Info("AUTO_Freq_Mode: " + script.AUTO_Freq_Mode);
                    //Log.Info("in_step_channel_sweep: " + script.in_step_channel_sweep);

                    pllObject.Execute(MapFileValues);

                    RunChildSteps(); //If step has child steps.

                }
            }

            UpgradeVerdict(Verdict.Pass);
        }

        /// <summary>
        /// Parse the ScriptList file and populate the PllScriptList
        /// It also takes the row where the ScriptFolder is located and stores it in ScriptFolder
        /// Additionally, it takes the row where the MapFile is located and stores it in MapFile
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ParseScriptList()
        {
            PllScriptList = new List<PLLScriptList>();
            using (StreamReader sr = new StreamReader(ScriptList))
            {
                string line;
                bool processingList = false;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] script = line.Split(',');
                    if (processingList)
                    {
                        PllScriptList.Add(new PLLScriptList
                        {
                            Enabled = true,
                            MainScript = script[0],
                            DeltaScript = script[1],
                            DeltaScriptAfter = script[2],
                            PLL_to_Meas = script[3],
                            AUTO_Freq_Override = script[4],
                            AUTO_Freq_Mode = script[5],
                            in_step_channel_sweep = script[6]
                        });
                    }
                    else if (script[0].Contains("ScriptFolder"))
                    {
                        string[] scriptLine = script[0].Split('=');
                        ScriptFolder = scriptLine[1];
                    }
                    else if (script[0].Contains("MapFile"))
                    {
                        string[] scriptLine = script[0].Split('=');
                        MapFile = scriptLine[1];
                    }
                    else if (script[0].StartsWith("Note"))
                    {
                        continue;
                    }
                    else if (script[0].Contains("Main_Script"))
                    {
                        processingList = true;
                        continue;
                    }
                    else
                    {
                        throw new Exception("Invalid ScriptList file format");
                    }
                }
            }
        }

        /// <summary>
        /// Opens the MapFile and stores each line in a list MapFileList
        /// </summary>
        public void ParseMapFile()
        {
            MapFileList = new List<string>();
            using (StreamReader sr = new StreamReader(MapFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    MapFileList.Add(line);
                }
            }
        }

        /// <summary>
        /// Searches the MapFileList for a key and returns the values in a list
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> SearchMapFile(string key)
        {
           List<string> result = new List<string>();
            foreach (string line in MapFileList)
            {
                if (line.Contains(key))
                {
                    result = line.Split(',').ToList();
                    return result;
                }
            }
            throw new Exception("Key not found in MapFile");
        }

        /// <summary>
        /// If the Frequency is in the format 8000:1:8040 this function will unroll it to a list of frequencies
        /// where the first item is the start frequency
        /// the second items is the step size
        /// and the third item is the stop frequency
        /// the list will contain all the frequencies between the start and stop frequency with the step size
        /// </summary>
        /// <param name="freq"></param>
        /// <returns></returns>
        public List<double> UnrollFrequency(string freq)
        {
            List<double> freqList = new List<double>();
            string[] freqRange = freq.Split(':');
            double startFreq = double.Parse(freqRange[0]);
            int stepFreq = int.Parse(freqRange[1]);
            double endFreq = double.Parse(freqRange[2]);
            for (double i = startFreq; i <= endFreq; i+= stepFreq)
            {
                freqList.Add(i);
            }
            return freqList;
        }

        /// <summary>
        /// Updates the given key by replacing the frequency value in the 7th position with the new frequency
        /// </summary>
        /// <param name="key"></param>
        /// <param name="freq"></param>
        /// <returns></returns>
        public string UpdateKey(string key, double freq)
        {
            //RF_WMSS_MMWIF8P3_RP0-R0_HOME_100_8300P0_1_1212_BF1_0X01_CL7_N
            string[] values = key.Split('_');
            values[6] = freq.ToString("F1").Replace('.', 'P');
            return string.Join("_", values);
        }

    }
}
