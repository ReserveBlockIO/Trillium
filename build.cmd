@echo off

dotnet build .\src\Trillium.sln /nologo
dotnet test .\src\Trillium.Tests\Trillium.Tests.csproj