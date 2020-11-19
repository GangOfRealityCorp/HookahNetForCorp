#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HookahNet/HookahNet.csproj", "HookahNet.csproj"]
RUN dotnet restore "HookahNet.csproj"
COPY . .
WORKDIR "/src/HookahNet"
RUN dotnet build "HookahNet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HookahNet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HookahNet.dll"]


#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["HookahNet/HookahNet.csproj", "HookahNet.csproj"]
#RUN dotnet restore "HookahNet.csproj"
#COPY . .
#WORKDIR "/src/HookahNet"
#RUN dotnet build "HookahNet.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "HookahNet.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "HookahNet.dll"]