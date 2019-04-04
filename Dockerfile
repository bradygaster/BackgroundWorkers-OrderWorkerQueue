FROM microsoft/dotnet:3.0-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:3.0-sdk AS build
WORKDIR /src
COPY ["OrderQueueWorker.csproj", "./"]
RUN dotnet restore "./OrderQueueWorker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "OrderQueueWorker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OrderQueueWorker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OrderQueueWorker.dll"]
