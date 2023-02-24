#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SchoolApi/SchoolApi.csproj", "SchoolApi/"]
COPY ["Dal/Dal.csproj", "Dal/"]
COPY ["DomainModel/DomainModel.csproj", "DomainModel/"]
RUN dotnet restore "SchoolApi/SchoolApi.csproj"
COPY . .
WORKDIR "/src/SchoolApi"
RUN dotnet build "SchoolApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolApi.dll"]