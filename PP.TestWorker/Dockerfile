#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PP.TestWorker/PP.TestWorker.csproj", "PP.TestWorker/"]
RUN dotnet restore "PP.TestWorker/PP.TestWorker.csproj"
COPY . .
WORKDIR "/src/PP.TestWorker"
RUN dotnet build "PP.TestWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PP.TestWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PP.TestWorker.dll"]