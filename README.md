# Demo Shop Clean Architecture
Clean Architecture's implementation in 3 layers (Data Access, Business Logic and User Interface)

To build this project
```
dotnet restore 
```

Configure the database settings in src\Shop.Api\appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DemoShop;User ID=sa;Password=coronadoserver2018;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "JwtOptions": {
    "Key": "LJB8l9kbwbr0tWcaRuO7wcJnMsfkgvA5",
    "Issuer": "musc.com",
    "ValidForMinutes" :  1440
  }
}
```

Go to src\Shop.Infrastructure
```
update-database -Context ApplicationDbContext
update-database -Context DemoShopContext
```

To run go to src\Shop.Api
```
dotnet run
```
