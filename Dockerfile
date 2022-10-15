FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["agrconclude.api/agrconclude.api.csproj", "agrconclude.api/"]
RUN dotnet restore "agrconclude.api/agrconclude.api.csproj"
COPY . .
WORKDIR "/src/agrconclude.api"
RUN dotnet build "agrconclude.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "agrconclude.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD [ "dotnet", "agrconclude.api.dll" ]

