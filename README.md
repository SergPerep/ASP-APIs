# API

Collection of skeleton APIs.

Minimal API

- In Memory Entity Framework DB
- Endpoints simply grouped

Minimal Modular API:
- In Memory Entity Framework DB
- Custom module per endpoint group
- `ServiceCollection` and `WebApplication` extensions

Minimal Modular API with Carter:
- In Memory Entity Framework DB
- **Carter Modules for Endpoints**. `app.MapCarter()` - searches for classes that implement `ICarterModule` and executes `.AddRoutes()` on them. `.AddRoutes()` adds endpoints to the app.
- `ServiceCollection` extension
