# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app
COPY . .
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet publish -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:80
USER $APP_UID
ENTRYPOINT ["dotnet", "AspNetMvcCSP.dll"]
