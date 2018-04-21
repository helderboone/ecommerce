# Dockerize And Deploy ASP.NET Core 2.0 + Postgres + nginx with Docker-Compose
This is an example web application to show how to use ASP.Net Core with Postgres database and use Nginx as reverse proxy, and deploy using Docker-Compose.

# How to use?
1. `git clone https://github.com/helderboone/Ecommerce.git`
2. `cd Ecommerce`
3. `docker-compose up -d`

# Second option - Running in production
1. `git clone https://github.com/helderboone/Ecommerce.git`
2. `cd Ecommerce/Ecommerce/`
3. `dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"`
4. `Copy Dockerfile inside docker folder to root directory and replace the actual one`
5. `docker-compose up -d`



