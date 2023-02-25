FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["agrconclude.API/agrconclude.API.csproj", "agrconclude.API/"]
RUN dotnet restore "agrconclude.API/agrconclude.API.csproj"
COPY . .
WORKDIR "/src/agrconclude.API"
RUN dotnet build "agrconclude.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "agrconclude.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD [ "dotnet", "agrconclude.API.dll" ]

