FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["ProductApi/ProductApi.sln", "./"]

COPY ["ProductApi/ProductApi/ProductApi.csproj", "ProductApi/"]
COPY ["ProductApi/ProductApi.BusinessLayer/ProductApi.BusinessLayer.csproj", "ProductApi.BusinessLayer/"]
COPY ["ProductApi/ProductApi.DataAccessLayer/ProductApi.DataAccessLayer.csproj", "ProductApi.DataAccessLayer/"]
COPY ["ProductApi/ProductApi.EntityLayer/ProductApi.EntityLayer.csproj", "ProductApi.EntityLayer/"]

RUN dotnet restore "ProductApi/ProductApi.csproj"

COPY ProductApi/ ./

WORKDIR "/src/ProductApi"
RUN dotnet build "ProductApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductApi.dll"]