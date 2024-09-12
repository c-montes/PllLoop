using OpenTap;

namespace OpenTap.Qualcomm.PllLoop
{
    // Define an enum with three options
    public enum OptionType
    {
        TX_PLL,
        RX_PLL,
        XO_PLL
    }

    [Display("MyTestStep", Description: "Insert a description here", Group: "OpenTap.Qualcomm.PllLoop")]

    public class MyTestStep : TestStep
    {
        #region Settings
        public OptionType SelectedOption { get; set; }

        #endregion
        public MyTestStep()
        {
            SelectedOption = OptionType.TX_PLL;
        }

        public override void PrePlanRun()
        {
            base.PrePlanRun();
            // ToDo: Optionally add any setup code this step needs to run before the testplan starts
        }

        public override void Run()
        {
            // Use the factory to create the appropriate object
            IPllObject pllObject = PllObjectFactory.Create(SelectedOption);
            pllObject.Execute();

            RunChildSteps(); //If step has child steps.
            UpgradeVerdict(Verdict.Pass);
        }

        public override void PostPlanRun()
        {
            // ToDo: Optionally add any cleanup code this step needs to run after the entire testplan has finished
            base.PostPlanRun();
        }
    }
}
