#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LetsMeet.WebApi/LetsMeet.WebApi.csproj", "LetsMeet.WebApi/"]
COPY ["LetsMeet.Abstractions/LetsMeet.Abstractions.csproj", "LetsMeet.Abstractions/"]
COPY ["LetsMeet.Business/LetsMeet.Business.csproj", "LetsMeet.Business/"]
COPY ["LetsMeet.Store/LetsMeet.Store.csproj", "LetsMeet.Store/"]
RUN dotnet restore "LetsMeet.WebApi/LetsMeet.WebApi.csproj"
COPY . .
WORKDIR "/src/LetsMeet.WebApi"
RUN dotnet build "LetsMeet.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LetsMeet.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LetsMeet.WebApi.dll"]