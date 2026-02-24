FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Transparity.Api/Transparity.Api.csproj", "Transparity.Api/"]
COPY ["Transparity.Application/Transparity.Application.csproj", "Transparity.Application/"]
COPY ["Transparity.Data/Transparity.Data.csproj", "Transparity.Data/"]
COPY ["Transparity.Infrastructure/Transparity.Infrastructure.csproj", "Transparity.Infrastructure/"]
COPY ["Transparity.Shared/Transparity.Shared.csproj", "Transparity.Shared/"]

RUN dotnet restore "./Transparity.Api/Transparity.Api.csproj"
COPY . .

WORKDIR "/src/Transparity.Api"
RUN dotnet build "./Transparity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Transparity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish \
    --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8443
EXPOSE 8443

RUN apt-get update && apt-get install -y adduser \
    && rm -rf /var/lib/apt/lists/*

RUN addgroup --system --gid 10001 transparity_server_group \
    && adduser --system --uid 10001 --ingroup transparity_server_group transparity_server_user \
    --disabled-password --home /app

USER transparity_server_user

COPY --from=publish --chown=transparity_server_user:transparity_server_group /app/publish .

ENTRYPOINT ["dotnet", "Transparity.Api.dll"]