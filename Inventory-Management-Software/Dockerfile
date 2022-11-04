FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Inventory-Management-Software/Inventory-Management-Software.csproj", "Inventory-Management-Software/"]
RUN dotnet restore "Inventory-Management-Software/Inventory-Management-Software.csproj"
COPY . .
WORKDIR "/src/Inventory-Management-Software"
RUN dotnet build "Inventory-Management-Software.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory-Management-Software.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory-Management-Software.dll"]
