A. What is this sample?
	This sample application is a demonstration of workflow engine features. It uses WCF stack to host a workflow.
	And a client application (windows form) connects to the service to: 
	1. Create a task
	2. Accept a task
	3. Monitors opened tasks

B. How to run this sample?
	In order to run this sample successfully:

	1. Make sure it this is run under Visual Studio, it needs to be open/run "As Administrator"
	2. Make sure you have MsSqlCe 3.5 installed on your machine (http://www.microsoft.com/en-au/download/details.aspx?id=5783)
	3. Make sure before running the application the process state database is ready
		1. Create database in database (ms-sql server)
		2. Run script from <FlexRule Installed Folder>\Scrips\SqlProcessStatePersistence300.1.sql
	4. Set the database connection string in FlexRule.Samples.CaseHandling.ConsoleServer configuration file.
	   (The workflow connection string section is named ProcessStateStore)
	5. On solution properties select "Startup projects"
	   And make sure you have selected "Multi startup projects" as :
		1. FlexRule.Samples.CaseHandling.Client 	-> Start
		2. FlexRule.Samples.CaseHandling.ConsoleServer  -> Start
	   This allows to run both client and server side inside VS together.
