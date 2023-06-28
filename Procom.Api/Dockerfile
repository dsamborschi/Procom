#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Procom.Api.csproj", "."]
RUN dotnet restore "./Procom.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Procom.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Procom.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Procom.Api.dll"]

#docker build -t procomapi:v1 .