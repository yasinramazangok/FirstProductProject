FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["ProductApi/ProductApi.API.sln", "./"]

COPY ["ProductApi/ProductApi/ProductApi.API.csproj", "ProductApi/"]
COPY ["ProductApi/ProductApi.BusinessLayer/ProductApi.BusinessLayer.csproj", "ProductApi.BusinessLayer/"]
COPY ["ProductApi/ProductApi.DataAccessLayer/ProductApi.DataAccessLayer.csproj", "ProductApi.DataAccessLayer/"]
COPY ["ProductApi/ProductApi.EntityLayer/ProductApi.EntityLayer.csproj", "ProductApi.EntityLayer/"]

RUN dotnet restore "ProductApi/ProductApi.API.csproj"

COPY ProductApi/ ./

WORKDIR "/src/ProductApi"
RUN dotnet build "ProductApi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductApi.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductApi.API.dll"]
