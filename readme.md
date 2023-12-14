## UserManager solution
This is task 1.

`UserManagerApp.Server` is ASP.NET Core project. You will need to have .net 8 to run it.
`usermanagerapp.client` is a front-end part of the web application. It's built with `npm` and angular `ng`.

### Before run
Edit the `appsettings.json` file and put there connection string to your MongoDb instance and database name.

### Easy way to run
Easy way to run the application is to use newer version of Visual Studio. Just run the solution with both projects runable.
Visual Studio will automatically run the server, the frontend application, the proxy and the browser.

### Manual run
If you want to run it manually, then run server as regular .net project from VS or with
```
cd UserManagerApp.Server
dotnet run
```
Then run the frontend in new terminal window with
```
cd usermanagerapp.client
npm install
ng serve
```
`ng serve` will say you should open "http://localhost:4200/", but actually you should use **https** address. 
Open new browser window and go to https://localhost:4200/

Application should open and work.

## BinaryString solution
This is task 2. You can run it with
```
cd BinaryString
dotnet run
```
and enter the binary string manually.
Or run the unit tests with
```
dotnet test -l "console;verbosity=normal"
```
Or, of course, you can run everything from Visual Studio or Rider.