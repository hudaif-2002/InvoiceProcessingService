FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["InvoiceProcessingService.csproj", "."]
RUN dotnet restore "./InvoiceProcessingService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "InvoiceProcessingService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvoiceProcessingService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvoiceProcessingService.dll"]