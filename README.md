# The PZ Cheeseria

This sample web application is made of a front end (Vue based webapp) and the associated backend (.Net Core API) that provides the necessary CRUD operations for handling the Cheese operations.

The API can be consumed by the web application and in this sample application, the Vue based web app fetches the various details from the backend using these api operations.

## Solution Structure

The WebAPI part is made of the following projects:

- Cheeseria.Api
    ``` Contains the implementation for the various HTTP CRUD operations ```
- Cheeseria.Api.Tests
    ``` Project is responsible for hosting the automated tests ```

The frontend is a Vue based web app and uses Axios to connect to the Web API to fetch data as required.

### Frontend - getting it working locally

To run this application locally, follow the steps below:

Frontend
1. Clone the repo (Master branch) available at:
    ``` https://github.com/chitransachin/pzcheeseria.git ```
2. Navigate to the frontend folder - open in VSCode as it helps to get a better view of the folder structure
3. Run the following commands:
```
cd frontend
npm run serve
```

### Backend API

Navigate to the folder ```Cheeseria.Api```

Run the following commands

```json
dotnet build
dotnet test

dotnet run -p ./Cheeseria.Api/Cheeseria.Api.csproj

```
## General notes

I have tried to bring in some structure around the Visual Studio solution projects. The general approach is to have the APIs exposed through the specific Controller actions. Handlers are then responsible for processing the respective request and the pattern allows to create newer implementations by keeping the Controller lean.

Dependency Injection allows for the various dependencies to be constructor injected and this also makes it easier to test those dependencies in isolation.
