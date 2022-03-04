FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Accelerex/Accelerex.csproj", "Accelerex/"]
RUN dotnet restore "Accelerex/Accelerex.csproj"
COPY . .
WORKDIR "/src/Accelerex"
RUN dotnet build "Accelerex.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Accelerex.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Accelerex.dll"]
