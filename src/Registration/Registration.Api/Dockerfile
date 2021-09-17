#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Registration/Registration.Api/Registration.Api.csproj", "src/Registration/Registration.Api/"]
RUN dotnet restore "src/Registration/Registration.Api/Registration.Api.csproj"
COPY . .
WORKDIR "/src/src/Registration/Registration.Api"
RUN dotnet build "Registration.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Registration.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Registration.Api.dll"]
