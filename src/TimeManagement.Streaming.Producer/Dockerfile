FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/TimeManagement.Streaming.Producer/TimeManagement.Streaming.Producer.csproj", "src/TimeManagement.Streaming.Producer/"]
RUN dotnet restore "src/TimeManagement.Streaming.Producer/TimeManagement.Streaming.Producer.csproj"
COPY . .
WORKDIR "/src/src/TimeManagement.Streaming.Producer"
RUN dotnet build "TimeManagement.Streaming.Producer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TimeManagement.Streaming.Producer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TimeManagement.Streaming.Producer.dll"]
