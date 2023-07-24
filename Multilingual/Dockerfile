FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Multilingual/Multilingual.csproj", "Multilingual/"]
RUN dotnet restore "Multilingual/Multilingual.csproj"
COPY . .
WORKDIR "/src/Multilingual"
RUN dotnet build "Multilingual.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Multilingual.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Multilingual.dll"]
