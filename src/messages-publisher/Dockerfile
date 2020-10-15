FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src/
COPY ./messages-publisher/ ./messages-publisher/
COPY ./messages-contracts/ ./messages-contracts/

RUN dotnet restore "messages-publisher/messages-publisher.csproj"

WORKDIR /src/messages-publisher/
RUN dotnet build "messages-publisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "messages-publisher.csproj" -c Release -o /app/publish

FROM build AS debug
ENV ASPNETCORE_URLS="http://*:5000"
WORKDIR /src/messages-publisher/
RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "messages-publisher.dll" ]