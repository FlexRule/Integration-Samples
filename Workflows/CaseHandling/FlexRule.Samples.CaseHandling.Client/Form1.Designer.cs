using System;
using System.Windows;
using global::System.Windows.Forms;
namespace FlexRule.Samples.CaseHandling.Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new global::System.Windows.Forms.TabControl();
            this.tabPage1 = new global::System.Windows.Forms.TabPage();
            this.groupBox1 = new global::System.Windows.Forms.GroupBox();
            this.label5 = new global::System.Windows.Forms.Label();
            this.textClientEmail = new global::System.Windows.Forms.TextBox();
            this.label3 = new global::System.Windows.Forms.Label();
            this.textCaseDescription = new global::System.Windows.Forms.TextBox();
            this.label2 = new global::System.Windows.Forms.Label();
            this.textCaseTitle = new global::System.Windows.Forms.TextBox();
            this.buttonLaunchCase = new global::System.Windows.Forms.Button();
            this.label1 = new global::System.Windows.Forms.Label();
            this.tabPage2 = new global::System.Windows.Forms.TabPage();
            this.buttonRefreshCaseOfficersStep2 = new global::System.Windows.Forms.Button();
            this.comboBoxUsers = new global::System.Windows.Forms.ComboBox();
            this.groupBox2 = new global::System.Windows.Forms.GroupBox();
            this.listViewAcceptables = new global::System.Windows.Forms.ListView();
            this.columnHeader4 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.buttonAcceptCaseOfficer = new global::System.Windows.Forms.Button();
            this.label6 = new global::System.Windows.Forms.Label();
            this.tabPage3 = new global::System.Windows.Forms.TabPage();
            this.groupBox3 = new global::System.Windows.Forms.GroupBox();
            this.listViewMonitor = new global::System.Windows.Forms.ListView();
            this.columnHeader1 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.buttonRefreshCaseOfficersMonitor = new global::System.Windows.Forms.Button();
            this.label4 = new global::System.Windows.Forms.Label();
            this.panel1 = new global::System.Windows.Forms.Panel();
            this.label7 = new global::System.Windows.Forms.Label();
            this.columnHeader9 = ((global::System.Windows.Forms.ColumnHeader)(new global::System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new global::System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new global::System.Drawing.Size(567, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new global::System.Drawing.Size(559, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users Portal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textClientEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textCaseDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textCaseTitle);
            this.groupBox1.Controls.Add(this.buttonLaunchCase);
            this.groupBox1.Location = new global::System.Drawing.Point(22, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new global::System.Drawing.Size(521, 221);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Case";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new global::System.Drawing.Point(18, 19);
            this.label5.Name = "label5";
            this.label5.Size = new global::System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Client Email";
            // 
            // textClientEmail
            // 
            this.textClientEmail.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.textClientEmail.Location = new global::System.Drawing.Point(93, 16);
            this.textClientEmail.Name = "textClientEmail";
            this.textClientEmail.Size = new global::System.Drawing.Size(412, 20);
            this.textClientEmail.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new global::System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new global::System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // textCaseDescription
            // 
            this.textCaseDescription.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.textCaseDescription.Location = new global::System.Drawing.Point(93, 68);
            this.textCaseDescription.Multiline = true;
            this.textCaseDescription.Name = "textCaseDescription";
            this.textCaseDescription.Size = new global::System.Drawing.Size(412, 115);
            this.textCaseDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new global::System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new global::System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // textCaseTitle
            // 
            this.textCaseTitle.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.textCaseTitle.Location = new global::System.Drawing.Point(93, 42);
            this.textCaseTitle.Name = "textCaseTitle";
            this.textCaseTitle.Size = new global::System.Drawing.Size(412, 20);
            this.textCaseTitle.TabIndex = 1;
            // 
            // buttonLaunchCase
            // 
            this.buttonLaunchCase.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLaunchCase.Location = new global::System.Drawing.Point(389, 189);
            this.buttonLaunchCase.Name = "buttonLaunchCase";
            this.buttonLaunchCase.Size = new global::System.Drawing.Size(116, 23);
            this.buttonLaunchCase.TabIndex = 3;
            this.buttonLaunchCase.Text = "Launch a Case";
            this.buttonLaunchCase.UseVisualStyleBackColor = true;
            this.buttonLaunchCase.Click += new global::System.EventHandler(this.buttonLaunchCase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new global::System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new global::System.Drawing.Size(341, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is an initializing step and allows an actor create a case. \r\ne.g. manager, a" +
                "dministrator or any other system.\r\n\r\nThen system automatically assigns the newly" +
                " created case to an officer";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonRefreshCaseOfficersStep2);
            this.tabPage2.Controls.Add(this.comboBoxUsers);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new global::System.Drawing.Size(559, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Officers Portal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonRefreshCaseOfficersStep2
            // 
            this.buttonRefreshCaseOfficersStep2.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshCaseOfficersStep2.Location = new global::System.Drawing.Point(403, 70);
            this.buttonRefreshCaseOfficersStep2.Name = "buttonRefreshCaseOfficersStep2";
            this.buttonRefreshCaseOfficersStep2.Size = new global::System.Drawing.Size(78, 23);
            this.buttonRefreshCaseOfficersStep2.TabIndex = 2;
            this.buttonRefreshCaseOfficersStep2.Text = "Refresh";
            this.buttonRefreshCaseOfficersStep2.UseVisualStyleBackColor = true;
            this.buttonRefreshCaseOfficersStep2.Click += new global::System.EventHandler(this.buttonRefrehCaseOfficers_Click);
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new global::System.Drawing.Point(172, 72);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new global::System.Drawing.Size(225, 21);
            this.comboBoxUsers.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewAcceptables);
            this.groupBox2.Controls.Add(this.buttonAcceptCaseOfficer);
            this.groupBox2.Location = new global::System.Drawing.Point(22, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new global::System.Drawing.Size(515, 227);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available assigned cases for";
            // 
            // listViewAcceptables
            // 
            this.listViewAcceptables.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAcceptables.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewAcceptables.FullRowSelect = true;
            this.listViewAcceptables.Location = new global::System.Drawing.Point(9, 29);
            this.listViewAcceptables.Name = "listViewAcceptables";
            this.listViewAcceptables.Size = new global::System.Drawing.Size(496, 163);
            this.listViewAcceptables.TabIndex = 4;
            this.listViewAcceptables.UseCompatibleStateImageBehavior = false;
            this.listViewAcceptables.View = global::System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Title";
            this.columnHeader4.Width = 223;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Assigned";
            this.columnHeader5.Width = 135;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Accepted";
            // 
            // buttonAcceptCaseOfficer
            // 
            this.buttonAcceptCaseOfficer.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAcceptCaseOfficer.Location = new global::System.Drawing.Point(431, 198);
            this.buttonAcceptCaseOfficer.Name = "buttonAcceptCaseOfficer";
            this.buttonAcceptCaseOfficer.Size = new global::System.Drawing.Size(78, 23);
            this.buttonAcceptCaseOfficer.TabIndex = 0;
            this.buttonAcceptCaseOfficer.Text = "Accept";
            this.buttonAcceptCaseOfficer.UseVisualStyleBackColor = true;
            this.buttonAcceptCaseOfficer.Click += new global::System.EventHandler(this.buttonAcceptCaseOfficer_Click);
            // 
            // label6
            // 
            this.label6.Location = new global::System.Drawing.Point(19, 21);
            this.label6.Name = "label6";
            this.label6.Size = new global::System.Drawing.Size(518, 46);
            this.label6.TabIndex = 3;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new global::System.Drawing.Size(559, 325);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Monitoring";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listViewMonitor);
            this.groupBox3.Controls.Add(this.buttonRefreshCaseOfficersMonitor);
            this.groupBox3.Location = new global::System.Drawing.Point(22, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new global::System.Drawing.Size(521, 239);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Case list";
            // 
            // listViewMonitor
            // 
            this.listViewMonitor.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMonitor.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewMonitor.FullRowSelect = true;
            this.listViewMonitor.Location = new global::System.Drawing.Point(6, 20);
            this.listViewMonitor.Name = "listViewMonitor";
            this.listViewMonitor.Size = new global::System.Drawing.Size(509, 181);
            this.listViewMonitor.TabIndex = 3;
            this.listViewMonitor.UseCompatibleStateImageBehavior = false;
            this.listViewMonitor.View = global::System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Active";
            this.columnHeader1.Width = 99;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Officer";
            this.columnHeader2.Width = 135;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Assigned";
            this.columnHeader3.Width = 97;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Accepted";
            this.columnHeader7.Width = 118;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Title";
            // 
            // buttonRefreshCaseOfficersMonitor
            // 
            this.buttonRefreshCaseOfficersMonitor.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRefreshCaseOfficersMonitor.Location = new global::System.Drawing.Point(6, 207);
            this.buttonRefreshCaseOfficersMonitor.Name = "buttonRefreshCaseOfficersMonitor";
            this.buttonRefreshCaseOfficersMonitor.Size = new global::System.Drawing.Size(78, 23);
            this.buttonRefreshCaseOfficersMonitor.TabIndex = 2;
            this.buttonRefreshCaseOfficersMonitor.Text = "Refresh";
            this.buttonRefreshCaseOfficersMonitor.UseVisualStyleBackColor = true;
            this.buttonRefreshCaseOfficersMonitor.Click += new global::System.EventHandler(this.buttonRefreshCaseOfficers_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new global::System.Drawing.Point(19, 22);
            this.label4.Name = "label4";
            this.label4.Size = new global::System.Drawing.Size(336, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "This is a monitoring tab page. \r\nIt allows the administrator, manager... monitor " +
                "the cases with its status.";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new global::System.Drawing.Point(229, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new global::System.Drawing.Size(127, 45);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new global::System.Drawing.Point(15, 14);
            this.label7.Name = "label7";
            this.label7.Size = new global::System.Drawing.Size(93, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Please wait...";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Workflow";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new global::System.Drawing.Size(592, 376);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Case Handling System Sample";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private global::System.Windows.Forms.TabControl tabControl1;
        private global::System.Windows.Forms.TabPage tabPage1;
        private global::System.Windows.Forms.TabPage tabPage2;
        private global::System.Windows.Forms.Button buttonLaunchCase;
        private global::System.Windows.Forms.GroupBox groupBox1;
        private global::System.Windows.Forms.Label label2;
        private global::System.Windows.Forms.Label label1;
        private global::System.Windows.Forms.Label label3;
        private global::System.Windows.Forms.TextBox textCaseDescription;
        private global::System.Windows.Forms.TextBox textCaseTitle;
        private global::System.Windows.Forms.Button buttonRefreshCaseOfficersStep2;
        private global::System.Windows.Forms.ComboBox comboBoxUsers;
        private global::System.Windows.Forms.GroupBox groupBox2;
        private global::System.Windows.Forms.Button buttonAcceptCaseOfficer;
        private global::System.Windows.Forms.Label label6;
        private global::System.Windows.Forms.TabPage tabPage3;
        private global::System.Windows.Forms.GroupBox groupBox3;
        private global::System.Windows.Forms.Button buttonRefreshCaseOfficersMonitor;
        private global::System.Windows.Forms.Label label4;
        private global::System.Windows.Forms.Label label5;
        private global::System.Windows.Forms.TextBox textClientEmail;
        private global::System.Windows.Forms.ListView listViewMonitor;
        private global::System.Windows.Forms.ColumnHeader columnHeader1;
        private global::System.Windows.Forms.ColumnHeader columnHeader2;
        private global::System.Windows.Forms.ColumnHeader columnHeader3;
        private global::System.Windows.Forms.ListView listViewAcceptables;
        private global::System.Windows.Forms.ColumnHeader columnHeader4;
        private global::System.Windows.Forms.ColumnHeader columnHeader5;
        private global::System.Windows.Forms.ColumnHeader columnHeader6;
        private global::System.Windows.Forms.ColumnHeader columnHeader7;
        private global::System.Windows.Forms.Panel panel1;
        private global::System.Windows.Forms.Label label7;
        private global::System.Windows.Forms.ColumnHeader columnHeader8;
        private global::System.Windows.Forms.ColumnHeader columnHeader9;
    }
}

