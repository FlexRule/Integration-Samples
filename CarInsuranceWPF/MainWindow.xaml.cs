using System;
using System.IO;
using System.Windows;

namespace FlexRule.Samples.CarInsuranceApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private IRuntimeEngine Engine = RuntimeEngine.FromXml(File.OpenRead("Car-Insurance-Rules\\Car Flow.xml"), Path.Combine(Environment.CurrentDirectory, "Car-Insurance-Rules"));
        public MainWindow()
        {
            InitializeComponent();
            comboStyle.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = Engine.Run(GetCar());
            UpdateView((Car)result.Context.VariableContainer["car"]);
        }

        private Car GetCar()
        {
            return new Car()
            {
                Airbags = (checkFront.IsChecked.Value ? AirbagType.FrontPassenger : 0) |
                          (checkSide.IsChecked.Value ? AirbagType.SidePanel : 0) |
                          (checkDriver.IsChecked.Value ? AirbagType.Driver : 0),
                ModelYear = int.Parse(textYear.Text),
                Style = (CarStyle)(comboStyle.SelectedIndex + 1),
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
            labelTotal.Content = string.Format("Total: {0}", result.BasePremium + result.AutoPremium);
        }
    }
}
