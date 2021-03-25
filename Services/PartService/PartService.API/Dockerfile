#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/PartService/PartService.API/PartService.API.csproj", "Services/PartService/PartService.API/"]
COPY ["Services/PartService/PartService.DataLayer/PartService.DataLayer.csproj", "Services/PartService/PartService.DataLayer/"]
RUN dotnet restore "Services/PartService/PartService.API/PartService.API.csproj"
COPY . .
WORKDIR "/src/Services/PartService/PartService.API"
RUN dotnet build "PartService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartService.API.dll"]