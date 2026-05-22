FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY DiceRoller/DiceRoller.csproj DiceRoller/
COPY DiceRoller.Api/DiceRoller.Api.csproj DiceRoller.Api/

RUN dotnet restore DiceRoller.Api/DiceRoller.Api.csproj

COPY DiceRoller/ DiceRoller/
COPY DiceRoller.Api/ DiceRoller.Api/
WORKDIR /src/DiceRoller.Api
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "DiceRoller.Api.dll"]
