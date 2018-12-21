using System;
using System.IO;
using System.Windows.Forms;


namespace FlexRule.Samples.CarInsuranceApplication
{
    public partial class Form1 : Form
    {
        static private IRuntimeEngine Engine = RuntimeEngine.FromXml(File.OpenRead("Car-Insurance-Rules\\Car Flow.xml"), Path.Combine(Environment.CurrentDirectory, "Car-Insurance-Rules"));
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = Engine.Run(GetCar());
            UpdateView((Car)result.Context.VariableContainer["car"]);
        }

        private Car GetCar()
        {
            return new Car()
            {
                Airbags = (checkFront.Checked ? AirbagType.FrontPassenger : 0) |
                          (checkSide.Checked ? AirbagType.SidePanel : 0) |
                          (checkDriver.Checked ? AirbagType.Driver : 0),
                ModelYear = int.Parse(textYearModel.Text),
                Style = (CarStyle)(comboBox1.SelectedIndex + 1),
                Model = textModel.Text,
                Made = textMade.Text
            };
        }

        private void UpdateView(Car result)
        {
            textAuto.Text = result.AutoPremium.ToString();
            textBase.Text = result.BasePremium.ToString();
            textTheft.Text = result.TheftCategory.ToString();
            textInjury.Text = result.OccupantInjuryCategory.ToString();
            labelTotal.Text = string.Format("Total: {0}", result.BasePremium + result.AutoPremium);
        }
    }
}
