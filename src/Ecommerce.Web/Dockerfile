FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base

WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build

# Setup NodeJs
RUN apt-get update -qq && \
    apt-get install -qq -y wget && \
    apt-get install -qq -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
    apt-get install -qq -y build-essential nodejs && \
    apt-get install -qq -y nginx
# End setup

WORKDIR /src
COPY ["src/Ecommerce.Web/Ecommerce.Web.csproj", "src/Ecommerce.Web/"]
COPY ["src/Ecommerce.App/Ecommerce.App.csproj", "src/Ecommerce.App/"]
COPY ["src/Ecommerce.Infra/Ecommerce.Infra.csproj", "src/Ecommerce.Infra/"]
COPY ["src/Ecommerce.Domain/Ecommerce.Domain.csproj", "src/Ecommerce.Domain/"]

RUN cd src/Ecommerce.Web/ \
    && npm i --silent

COPY . .
WORKDIR "/src/src/Ecommerce.Web"
RUN dotnet build "Ecommerce.Web.csproj" -c Release -o /app

FROM build AS publish

RUN dotnet publish "Ecommerce.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ecommerce.Web.dll"]
