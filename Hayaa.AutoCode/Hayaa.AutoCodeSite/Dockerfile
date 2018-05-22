FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Hayaa.AutoCodeSite/Hayaa.AutoCodeSite.csproj Hayaa.AutoCodeSite/
RUN dotnet restore Hayaa.AutoCodeSite/Hayaa.AutoCodeSite.csproj
COPY . .
WORKDIR /src/Hayaa.AutoCodeSite
RUN dotnet build Hayaa.AutoCodeSite.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Hayaa.AutoCodeSite.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hayaa.AutoCodeSite.dll"]
