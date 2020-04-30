FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS debug

ENV ASPNETCORE_URLS="http://*:5000"

WORKDIR /src/
COPY ./messages-publisher/ ./messages-publisher/
COPY ./messages-contracts/ ./messages-contracts/

WORKDIR /src/messages-publisher/
RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]