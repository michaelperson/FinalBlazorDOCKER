#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DemoAPI_Complete/DemoAPI_Complete.csproj", "DemoAPI_Complete/"]
COPY ["DAL/DAL.csproj", "DAL/"]
RUN dotnet restore "DemoAPI_Complete/DemoAPI_Complete.csproj"
COPY . .
WORKDIR "/src/DemoAPI_Complete"
RUN dotnet build "DemoAPI_Complete.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoAPI_Complete.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoAPI_Complete.dll"]