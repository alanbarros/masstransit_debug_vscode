FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS debug

WORKDIR /src/
COPY ./messages-listener/ ./messages-listener/
COPY ./messages-contracts/ ./messages-contracts/

WORKDIR /src/messages-listener/
RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]