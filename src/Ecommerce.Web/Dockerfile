FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base

WORKDIR /app

FROM microsoft/dotnet:2.2-sdk-alpine AS build

WORKDIR /src
COPY ["src/Ecommerce.Web/Ecommerce.Web.csproj", "src/Ecommerce.Web/"]
COPY ["src/Ecommerce.App/Ecommerce.App.csproj", "src/Ecommerce.App/"]
COPY ["src/Ecommerce.Infra/Ecommerce.Infra.csproj", "src/Ecommerce.Infra/"]
COPY ["src/Ecommerce.Domain/Ecommerce.Domain.csproj", "src/Ecommerce.Domain/"]

COPY . .
WORKDIR "/src/src/Ecommerce.Web"
RUN dotnet build "Ecommerce.Web.csproj" -c Release -o /app

FROM build AS publish

RUN dotnet publish "Ecommerce.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ecommerce.Web.dll"]
