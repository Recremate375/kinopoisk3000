#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Rating/Rating.WebApi/Rating.WebApi.csproj", "src/Services/Rating/Rating.WebApi/"]
COPY ["src/Services/Rating/Rating.Application/Rating.Application.csproj", "src/Services/Rating/Rating.Application/"]
COPY ["src/Services/Rating/Rating.Domain/Rating.Domain.csproj", "src/Services/Rating/Rating.Domain"]
COPY ["src/Services/Rating/Rating.Infrastructure/Rating.Infrastructure.csproj", "src/Services/Rating/Rating.Infrasctructure"]
COPY ["src/Services/Rating/Rating.Tests/Rating.Tests.csproj", "src/Services/Rating/Rating.Tests"]
RUN dotnet restore "src/Services/Rating/Rating.WebApi/Rating.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Services/Rating/Rating.WebApi"
RUN dotnet build "Rating.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rating.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rating.WebApi.dll"]