FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore && dotnet build --configuration Release
RUN dotnet test

RUN dotnet publish "VY-Hackathon-Team6-back.sln" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime 

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Distrubuted.WebAPI.dll"]