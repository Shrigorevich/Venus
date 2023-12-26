FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Venus/Venus.csproj", "Venus/"]
COPY ["Venus.Database/Venus.Database.csproj", "Venus.Database/"]
COPY ["Venus.Database.Contracts/Venus.Database.Contracts.csproj", "Venus.Database.Contracts/"]
COPY ["Venus.Database.Models/Venus.Database.Models.csproj", "Venus.Database.Models/"]
COPY ["Venus.Dto/Venus.Dto.csproj", "Venus.Dto/"]
COPY ["Venus.Common/Venus.Common.csproj", "Venus.Common/"]
COPY ["Venus.Domain/Venus.Domain.csproj", "Venus.Domain/"]
COPY ["Venus.Domain.Mapping/Venus.Domain.Mapping.csproj", "Venus.Domain.Mapping/"]
RUN dotnet restore "Venus/Venus.csproj"
COPY . .
WORKDIR "/src/Venus"
RUN dotnet build "Venus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Venus.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Venus.dll"]
