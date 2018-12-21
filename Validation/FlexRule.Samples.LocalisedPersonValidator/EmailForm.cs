using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FlexRule.Core.Model;
using FlexRule.Samples.LocalisedPersonValidation.Properties;
using FlexRule.Translation;
using FlexRule.Validation;

namespace FlexRule.Samples.LocalisedPersonValidation
{
    public partial class EmailForm : Form
    {
        private readonly IRuntimeEngine _validator;
        public EmailForm()
        {
            InitializeComponent();
            comboLanguage.SelectedIndex = 0;

            _validator = RuntimeEngine.FromXml(File.OpenRead("LocalisedValidationRule.xml"));
            // Prepare engine for different culture messaging
            _validator.OnRunning = (eng) => SetupLocalisation(eng.ExecutorSetup);
        }


        private string[] ValidateEmail()
        {
            // Creating entity to be validated
            var per = new Person { Email = textBox1.Text };

            var runParameter = new RunParameter("check email", per);

            // Calling into engine for validation
            var result = _validator.Run(runParameter);

            // we select only text here to display in the UI
            // In a real application you can do more interesting stuff with notifications
            return result.Context.Notifications.Default.Notices.Select(x => x.Message).ToArray();
        }

        /// <summary>
        /// By calling this method after creation of any engine we register messaging translation
        /// </summary>
        /// <param name="setup"></param>
        private void SetupLocalisation(ExecutorSetupInformation setup)
        {
            // registering default messaging for all cultures
            // passing null for culture parameter defaults this translation for all cultures
            setup.MultilingualMessages.Register(Language_en.ResourceManager, null);

            // override the culture specific messaging
            setup.MultilingualMessages.Register(Language_fa.ResourceManager, CultureInfo.GetCultureInfo("fa"));
            setup.MultilingualMessages.Register(Language_en.ResourceManager, CultureInfo.GetCultureInfo("en"));
            setup.MultilingualMessages.Register(Language_fr.ResourceManager, CultureInfo.GetCultureInfo("fr"));
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            CultureInfo culture = GetCultureInfo();
            if (culture == null)
                MessageBox.Show(this,
                    string.Format("No language resource file were found for '{0}'. The default language translation will be chosen.", comboLanguage.Text),
                    @"No language specific language overload", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // The translation will be picked up automatically based on 'Thread.CurrentThread.CurrentUICulture'
            Thread.CurrentThread.CurrentUICulture = culture ?? Thread.CurrentThread.CurrentCulture;

            var result = ValidateEmail();
            if (result != null)
            {
                var validationResult = string.Join(Environment.NewLine, result);
                errorProvider1.SetError(textBox1, validationResult);
                MessageBox.Show(this, validationResult, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private CultureInfo GetCultureInfo()
        {
            switch (comboLanguage.Text)
            {
                case "Default":
                case "English":
                    return CultureInfo.GetCultureInfo("en");

                case "Farsi":
                    return CultureInfo.GetCultureInfo("fa");

                case "French":
                    return CultureInfo.GetCultureInfo("fr");

                default:
                    return null;
            }
        }
    }
}
