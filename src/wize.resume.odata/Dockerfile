FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ./ ./

RUN dotnet restore "src/wize.resume.odata/wize.resume.odata.csproj"
COPY . .
WORKDIR "src/wize.resume.odata"
RUN dotnet build "wize.resume.odata.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "wize.resume.odata.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wize.resume.odata.dll"]
