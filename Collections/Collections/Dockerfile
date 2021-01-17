#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Collections/Collections.csproj", "Collections/"]
COPY ["Collections.DAL/Collections.DAL.csproj", "Collections.DAL/"]
COPY ["Collections.General/Collections.General.csproj", "Collections.General/"]
RUN dotnet restore "Collections/Collections.csproj"
COPY . .
WORKDIR "/src/Collections"
RUN dotnet build "Collections.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Collections.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Collections.dll"]
