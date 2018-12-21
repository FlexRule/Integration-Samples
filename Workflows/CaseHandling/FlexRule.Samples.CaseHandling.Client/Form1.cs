using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Client
{
    public partial class Form1 : Form
    {
        private IEnumerable<Assignment> _step2Officers;
        public Form1()
        {
            InitializeComponent();
            comboBoxUsers.SelectedIndexChanged += new EventHandler(comboBoxUsers_SelectedIndexChanged);
        }

        private void Wait(bool show)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
            panel1.Visible = show;
            panel1.Refresh();
        }
        void ProcessRequest(Action action)
        {
            try
            {
                Wait(true);
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Error Ocurred", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                Wait(false);
            }
        }
        DialogResult ShowError(string title, string msg)
        {
            return MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void buttonLaunchCase_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textCaseTitle.Text.Trim()))
            {
                ShowError("Missing", "Title is required.");
                return;
            }

            ProcessRequest(() =>
                {
                    using (CaseHandlingServiceProxy proxy = new CaseHandlingServiceProxy())
                        proxy.LaunchCase(textCaseTitle.Text, textCaseDescription.Text, textClientEmail.Text);

                    MessageBox.Show(this, "New case has been added successfully.", "New case", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                });
        }

        private void ResetForm()
        {
            textCaseTitle.Text = "";
            textClientEmail.Text = "";
            textCaseDescription.Text = "";
        }

        private void buttonRefreshCaseOfficers_Click(object sender, EventArgs e)
        {
            ProcessRequest(() =>
                {
                    using (CaseHandlingServiceProxy proxy = new CaseHandlingServiceProxy())
                    {
                        listViewMonitor.Items.Clear();
                        var list = proxy.ListCaseOfficers();
                        foreach (var co in list)
                        {
                            ListViewItem item =
                                new ListViewItem(new string[]
                                    {
                                        co.Active.ToString(),
                                        co.Officer.Name, 
                                        co.Assigned != null ? co.Assigned.ToString() : "<NA>",
                                        co.Accepted != null ? co.Accepted.ToString() : "<NA>",
                                        co.Case.Task,
                                        co.FlowInstanceIdentifier == null ? "<NA>": co.FlowInstanceIdentifier.ToString(),
                                    });
                            item.Tag = co;
                            listViewMonitor.Items.Add(item);
                        }
                    }
                });
        }

        private void buttonRefrehCaseOfficers_Click(object sender, EventArgs e)
        {
            ProcessRequest(() =>
                {
                    using (CaseHandlingServiceProxy proxy = new CaseHandlingServiceProxy())
                    {
                        listViewAcceptables.Items.Clear();
                        _step2Officers = proxy.ListAcceptables();
                        var list = new BindingList<Officer>();
                        foreach (
                            var officer in
                                _step2Officers.GroupBy(x => x.Officer.Identifier).Select(x => x.First().Officer))
                            list.Add(officer);

                        fillUsersCombo(list);
                    }
                });
        }

        private void fillUsersCombo(BindingList<Officer> offices)
        {
            comboBoxUsers.DataSource = null;
            comboBoxUsers.DataSource = offices;
            comboBoxUsers.DisplayMember = "Name";
            comboBoxUsers.ValueMember = "Identifier";
        }

        void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewAcceptables.Items.Clear();
            Officer officer = comboBoxUsers.SelectedItem as Officer;
            if (officer == null)
                return;

            var list = _step2Officers.Where(x => x.Officer.Identifier == officer.Identifier);
            foreach (var co in list)
            {
                AddAcceptableItem(co);
            }
        }

        private void AddAcceptableItem(Assignment co)
        {
            ListViewItem item =
                new ListViewItem(new string[] { co.Case.Task, co.Assigned.ToString(), co.Accepted != null ? co.Accepted.ToString() : "<NA>" });
            item.Tag = co;
            listViewAcceptables.Items.Add(item);
        }

        private void buttonAcceptCaseOfficer_Click(object sender, EventArgs e)
        {
            if (listViewAcceptables.SelectedItems.Count != 1)
            {
                MessageBox.Show(this, "Please first select an item from list.", "No item selected", MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                return;
            }
            Assignment co = (Assignment)listViewAcceptables.SelectedItems[0].Tag;
            if (co.Accepted != null)
            {
                MessageBox.Show(this, "This case has already been accepted.", "Error", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                return;
            }
            Assignment result = null;
            ProcessRequest(() =>
                {
                    using (CaseHandlingServiceProxy proxy = new CaseHandlingServiceProxy())
                        result = proxy.Accept(co);

                });

            if (result != null && result.Identifier == co.Identifier)
            {
                // successfully accepted and we add new updated ones
                AddAcceptableItem(result);
            }
            else
            {
                MessageBox.Show(this, "Old case has been expired and you were not be able to accept it.",
                                "Case expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // we remove the old one
            listViewAcceptables.SelectedItems[0].Remove();
        }
    }
}
