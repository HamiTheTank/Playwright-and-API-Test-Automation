# UI-Playwright-and-API-Test-Automation
Test Automation Assessment Project 2024

## UI Test Automation
Implements an automated UI testing suite which is run against the https://www.saucedemo.com/ website. Three single scenarios were developed in C#, using Playwright and NUnit libraries. This is a standalone test framework which runs on its own and can be further expanded. The project is implemented in Page Object Model design pattern, resources and common methods are organized in separate classes.
## API Test Automation
Implements an automated API testing suite which runs against https://reqres.in/ endpoints. Three single scenarios were developed in C#, using NUnit for organizing and executing tests, RestSharp for API requests and NewtonSoft.Json to parse JSON content. This is a standalone test framework which runs on its own and can be further extended.

## Command Line
To run the tests from command line, use the following commands for each project respectively:
  dotnet test "UI Tests"
  dotnet test "API Tests"
