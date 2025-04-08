### Folder Structure
```
src/
├── Abstraction/            # base classes and interfaces that models inherit from to keep consistency
├── Endpoints/              # where static Endpoint classes are              
│   ├── Endpoints.Enums/    # folder for holding Endpoint based enums; still in the Endpoints namespace
├── Models/                 # Json response deserialization models
│   ├── Models.Internal/    # folder for Internals Models that exist for specific requests; still in the Models namespace 
│   ├── JsonConverters/     # Json converter models
│   ├── v1/                 # Models for v1 endpoints
│   ├── v2/                 # Models for v2 endpoints
│   ├── v3/                 # Models for v3 endpoints
```