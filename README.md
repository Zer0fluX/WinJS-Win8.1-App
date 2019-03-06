n# WinJS-Win8.1-App
This project consists of a [WinJS](https://github.com/winjs/winjs) demonstration application for Windows and Windows Phone 8.1 (or better), the PowerPoint presentation from the San Antonio .NET User Group session where the demo app was used, and instructions for getting everything working on your local machine.

## Project Notes
This demo application was built using [Visual Studio 2015](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx) and is intended for use within that environment.  Also, the samples use a WebAPI service as an interface to Microsoft's sample Adventure Works database.  While it's possible to get the application to build and run without Visual Studio or the Adventure Works database, doing so is beyond the scope of this README file.

## Installation
You'll need to do a couple things to get the sample application working in your environment.

#### 1. Close the project repository:
```
git clone https://github.com/Zer0fluX/WinJS-Win8.1-App.git
```

#### 2. Grab the AdventureWorksLT2012 sample database from CodePlex:
```
http://msftdbprodsamples.codeplex.com/
```
To restore the database locally open SQL Server Management Studio, right-click on the *Databases* node, and choose **Restore Database**.

#### 3. Configure the application:
Open the AWDemo solution, expand the AWDemo.Web.API, and edit the connection string in the project's **Web.config** file.  Add your SQL Server UserID and Password:
```XML
<connectionStrings>
    <add name="AWDemoContext" 
      connectionString="data source=localhost;initial catalog=AdventureWorksLT2012;persist security info=True;user id=<YourUserID>;password=<YourPassword>;MultipleActiveResultSets=True;App=EntityFramework" 
      providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Build and Run
You need to start the web service before you run the WinJS applications.

1. First, build the entire solution (**ctrl+shift+B**)
2. Set the AWDemo.Web.API project as the startup project
3. Run the WebAPI service (**ctrl+F5**)

Run the Windows app:

1. Set the AWDemo.Windows project as the startup project
2. Run the application with either **ctrl+F5** or **F5**

Run the Windows Phone app:

1. Set the AWDemo.WindowsPhone project as the startup project
2. Run the application with either **ctrl+F5** or **F5**
