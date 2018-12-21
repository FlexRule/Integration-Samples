using System;

namespace FlexRule.Samples.CarInsuranceApplication
{
    [Flags]
    public enum AirbagType
    {
        None = 0,
        Driver = 1,
        FrontPassenger = 2,
        SidePanel = 4
    }
}