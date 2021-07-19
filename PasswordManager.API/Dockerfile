#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PasswordManager.API/PasswordManager.API.csproj", "PasswordManager.API/"]
RUN dotnet restore "PasswordManager.API/PasswordManager.API.csproj"
COPY . .
WORKDIR "/src/PasswordManager.API"
RUN dotnet build "PasswordManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PasswordManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PasswordManager.API.dll"]