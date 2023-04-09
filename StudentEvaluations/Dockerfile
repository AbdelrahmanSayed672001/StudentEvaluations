#Load BaseImage --> first stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

#set working dir from OS
WORKDIR /source

#copy csproj file and restore dependencies
COPY *.csproj .
RUN dotnet restore

#copy and publish the project
COPY . .
RUN dotnet publish -c release -o /app

#second stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet","StudentEvaluations.dll" ]