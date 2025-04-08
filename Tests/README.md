### Folder Structure
```
Tests/	
├── Integration/            # Tests the Endpoint functions for both success and fail case       
├── Model /                 # Model based tests
│   ├── Json/               # Model Json serialization and deserialization Tests
│   ├── Polymorphism/       # Model Inheritance based tests; Tests that certain models can be used in the same context (example: User based models all have UserId and Username)
```
