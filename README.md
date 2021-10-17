# Weather Forecast demo with Dependency Injection

This is the Weather Forecast demo service from the ASP.NET Core Web API template. The service itself just returns some demo weather data. I used it to implement an example of Dependency Injection using Autofac. You can check it out to have a sample how Autofac could be implemented in a Web API environment. As an example I added a save data function that stores all the weather data. There're two implementations under `Services` which can store the returned data in a CSV file or a SQLite database. The AutofacModule which contains all the registrations is under `Infrastructure/Autofac`.

For further details, see https://medium.com/@nicolaswa/get-started-with-dependency-injection-582b4b683da6
