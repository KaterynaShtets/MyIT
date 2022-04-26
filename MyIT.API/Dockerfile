FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyIT.API/MyIT.API.csproj", "MyIT.API/"]
COPY ["MyIT.BusinessLogic/MyIT.BusinessLogic.csproj", "MyIT.BusinessLogic/"]
COPY ["MyIT.DataAccess/MyIT.DataAccess.csproj", "MyIT.DataAccess/"]
COPY ["MyIT.Contracts/MyIT.Contracts.csproj", "MyIT.Contracts/"]
RUN dotnet restore "MyIT.API/MyIT.API.csproj"
COPY . .
WORKDIR "/src/MyIT.API"
RUN dotnet build "MyIT.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyIT.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyIT.API.dll"]
