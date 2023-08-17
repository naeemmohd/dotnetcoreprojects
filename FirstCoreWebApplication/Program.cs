using System.Runtime.CompilerServices;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 1 - using keys from different configs
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/", () => "Worker Process Name : " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);


//Configuring UseDeveloperExceptionPage Middleware Component if the Environment is Development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//Configuring UseRouting Middleware Component
//It matches a request to an endpoint.
app.UseRouting();

// Get the Configuration Service.
ConfigurationManager configuration = builder.Configuration;

//Get the Value from different config files with different keys
string MyCustomKeyAppSettings = configuration.GetValue<string>("MyCustomKeyAppSettings");
string MyCustomKeyAppSettingsDev = configuration.GetValue<string>("MyCustomKeyAppSettingsDev");
string MyCustomKeyAppSettingsLaunch = configuration.GetValue<string>("MyCustomKeyAppSettingsLaunch");
//string MyCustomKeyValue = configuration["MyCustomKey"];
string MyCustomKeyAppSettingsValue =$" The config key coming from appsettings is : {MyCustomKeyAppSettings}";
string MyCustomKeyAppSettingsDevValue =$" The config key coming from appsettings DEV is : {MyCustomKeyAppSettingsDev}";
string MyCustomKeyAppSettingsLaunchValue =$" The config key coming from appsettings Launch is : {MyCustomKeyAppSettingsLaunch}";


//Get the Value from different config files with same key
string MyCustomKey = configuration.GetValue<string>("MyCustomKey");
string MyCustomKeyValue =$" The config key overriden if same key : {MyCustomKey}";

string finalValue = "\n" + MyCustomKeyValue + "\n" + MyCustomKeyAppSettingsValue + "\n" +MyCustomKeyAppSettingsDevValue + "\n" +MyCustomKeyAppSettingsLaunchValue;



//app.MapGet("/", () => $"Final Values: {finalValue}");

//Configuring UseEndpoints Middleware Component
//It executes the matched endpoint.
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        int y=10;
        int z=10;
        int x= y/z;
        await context.Response.WriteAsync($"Final Values: {finalValue}");
 
    });
});
app.Run();
*/





////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 2 - how to call one pipeline from other - ex 1 - only 1 is called as .Run() becomes the terminal component
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Configuring New Middleware Component using Run Extension Method
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Getting Response from First Middleware");
});
//Configuring New Middleware Component using Run Extension Method
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Getting Response from Second Middleware");
});
//This will Run Application
app.Run();
*/


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 3 - how to call one pipeline from other - ex 2 - use app.use for the first component and call the next component from there
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Configuring New Middleware Component using Run Extension Method
//changes here - 1st component is using app.use and calls the next component
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Getting Response from First Middleware\n");
    await next();
});
//Configuring New Middleware Component using Run Extension Method
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Getting Response from Second Middleware\n");
});
//This will Run Application
app.Run();
*/

// Example to Understand ASP.NET Core Request Processing Pipeline
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Configuring Middleware Component using Use and Run Extension Method
//First Middleware Component Registered using Use Extension Method
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware1: Incoming Request\n");
    //Calling the Next Middleware Component
    await next();
    await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
});
//Second Middleware Component Registered using Use Extension Method

Key Points to Remember:
The ASP.NET Core Request Processing Pipeline consists of a sequence of Middleware Components that are going to be called one after the other.
Each Middleware Component can perform some operations before and after invoking the next Middleware Component using the next method. A middleware component can also decide not to call the next middleware component, which is called short-circuiting the request pipeline.
The Middleware Component in ASP.NET Core has access to both the incoming request and the outgoing response.
The most important point that you need to remember is the order in which the Middleware Components are added in the Main method of the Program class defines the order in which these Middleware Components will be invoked on requests and the reverse order for the response. So, the order is critical for defining the application’s Security, Performance, and Functionality.

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware2: Incoming Request\n");
    //Calling the Next Middleware Component
    await next();
    await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
});
//Third Middleware Component Registered using Run Extension Method
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Middleware3: Incoming Request handled and response generated\n");
    //Terminal Middleware Component i.e. cannot call the Next Component
});
//This will Start the Application
app.Run();
*/

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 4 - Creating a new ASP.NET Core Empty Web Application
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
$"ApplicationName: {app.Environment.ApplicationName} \n" +
$"WebRootPath: {app.Environment.WebRootPath} \n" +
$"ContentRootPath: {app.Environment.ContentRootPath}");
//This will Run the Application
app.Run();

*/


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///?*// Series 5 - rename the wwwroot Folder in ASP.NET Core (.NET 6)?
/*
//Step1: Creating an Instance of WebApplicationOptions Class
WebApplicationOptions webApplicationOptions = new WebApplicationOptions
{
    WebRootPath = "MyWebRoot", //Setting the WebRootPath as MyWebRoot
    Args = args, //Setting the Command Line Arguments in Args
    EnvironmentName = "Production", //Changing to Production
};
//Step2: Pass WebApplicationOptions Instance to the CreateBuilder Method
var builder = WebApplication.CreateBuilder(webApplicationOptions);
var app = builder.Build();
app.MapGet("/", () => $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
$"ApplicationName: {app.Environment.ApplicationName} \n" +
$"WebRootPath: {app.Environment.WebRootPath} \n" +
$"ContentRootPath: {app.Environment.ContentRootPath}");
//This will Run the Application
app.Run();
*/


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 6 - How to Configure the Static Files Middleware in ASP.NET Core Application?
// UseStaticFiles() middleware is an inbuilt middleware component
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Adding Static Files Middleware Component to serve the static files
app.UseStaticFiles();

app.MapGet("/", () => $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
$"ApplicationName: {app.Environment.ApplicationName} \n" +
$"WebRootPath: {app.Environment.WebRootPath} \n" +
$"ContentRootPath: {app.Environment.ContentRootPath}");
//This will Run the Application
app.Run();
*/



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 7 - How to Configure Default Page in ASP.NET Core
// use the UseDefaultFiles() middleware component to set your application’s default page.
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Setting the Default Files
app.UseDefaultFiles();

//Adding Static Files Middleware Component to serve the static files
app.UseStaticFiles();

//Adding Another Middleware Component to the Request Processing Pipeline
app.Run(async (context) =>
{
    await context.Response.WriteAsync( 
        $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
        $"ApplicationName: {app.Environment.ApplicationName} \n" +
        $"WebRootPath: {app.Environment.WebRootPath} \n" +
        $"ContentRootPath: {app.Environment.ContentRootPath}"
    );
});

//This will Run the Application
app.Run();
*/



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 8 - How to Configure CUSTOM Default Page in ASP.NET Core
/*
// use the UseDefaultFiles() middleware component to set your application’s default page.
// but before that set DefaultFilesOptions
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Specify the MyCustomPage1.html as the default page
//First Create an Instance of DefaultFilesOptions
DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();

//Clear any DefaultFileNames if already there
defaultFilesOptions.DefaultFileNames.Clear();

//Add the default HTML Page to the DefaultFilesOptions Instance
defaultFilesOptions.DefaultFileNames.Add("MyCustomDefaultPage.html");

//Setting the Default Files
//Pass the DefaultFilesOptions Instance to the UseDefaultFiles Middleware Component
app.UseDefaultFiles(defaultFilesOptions);

//Adding Static Files Middleware Component to serve the static files
app.UseStaticFiles();

//Adding Another Middleware Component to the Request Processing Pipeline
app.Run(async (context) =>
{
    await context.Response.WriteAsync( 
        $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
        $"ApplicationName: {app.Environment.ApplicationName} \n" +
        $"WebRootPath: {app.Environment.WebRootPath} \n" +
        $"ContentRootPath: {app.Environment.ContentRootPath}"
    );
});

//This will Run the Application
app.Run();
*/


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 9 - How to Configure CUSTOM Default Page in ASP.NET Core using UseFileServer()
/*
// use the UseFileServer()  middleware component 
// UseFileServer() is equal to UseStaticFiles() plus UseDefaultFiles

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Use UseFileServer instead of UseDefaultFiles and UseStaticFiles
FileServerOptions fileServerOptions = new FileServerOptions();
fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("MyCustomDefaultPage.html");
app.UseFileServer(fileServerOptions);

//Adding Another Middleware Component to the Request Processing Pipeline
app.Run(async (context) =>
{
    await context.Response.WriteAsync( 
        $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
        $"ApplicationName: {app.Environment.ApplicationName} \n" +
        $"WebRootPath: {app.Environment.WebRootPath} \n" +
        $"ContentRootPath: {app.Environment.ContentRootPath}"
    );
});

//This will Run the Application
app.Run();
*/


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 10 - Enable directory browsing on the current path

// use the UseDirectoryBrowser()  middleware component 
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Enable directory browsing on the current path
app.UseDirectoryBrowser();

// Use UseFileServer instead of UseDefaultFiles and UseStaticFiles
FileServerOptions fileServerOptions = new FileServerOptions();
fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("MyCustomDefaultPage.html");
app.UseFileServer(fileServerOptions);

//Adding Another Middleware Component to the Request Processing Pipeline
app.Run(async (context) =>
{
    await context.Response.WriteAsync( 
        $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
        $"ApplicationName: {app.Environment.ApplicationName} \n" +
        $"WebRootPath: {app.Environment.WebRootPath} \n" +
        $"ContentRootPath: {app.Environment.ContentRootPath}"
    );
});

//This will Run the Application
app.Run();
*/


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 11 - Developer Exception Page Middleware in ASP.NET Core
//  Without UseDeveloperExceptionPage() Middleware 
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", async context =>
{
    int Number1 = 10, Number2 = 0;
    int Result = Number1 / Number2; //This statement will throw Runtime Exception
    await context.Response.WriteAsync($"Result : {Result}");
});
//This will Run the Application
app.Run();
*/


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Series 11 - Developer Exception Page Middleware in ASP.NET Core
//  With UseDeveloperExceptionPage() Middleware 

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//If the Environment is Development, Please Show the Unhandled Exception Details 
if (app.Environment.IsDevelopment())
{
    //Configure UseDeveloperExceptionPage  
    DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions {
        SourceCodeLineCount = 5,
    };

    //Using UseDeveloperExceptionPage Middleware to Show Exception Details
    app.UseDeveloperExceptionPage(developerExceptionPageOptions);
}

app.MapGet("/", async context =>
{
    int Number1 = 10, Number2 = 0;
    int Result = Number1 / Number2; //This statement will throw Runtime Exception
    await context.Response.WriteAsync($"Result : {Result}");
});
//This will Run the Application
app.Run();
