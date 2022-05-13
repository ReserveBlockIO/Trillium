#!/bin/bash

dotnet build ./src/Trillium.sln /nologo
dotnet test ./src/Trillium.Test/Trillium.Test.csproj