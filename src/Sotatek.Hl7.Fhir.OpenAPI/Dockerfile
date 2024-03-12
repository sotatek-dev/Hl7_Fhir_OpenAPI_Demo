#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Sotatek.Hl7.Fhir.OpenAPI/Sotatek.Hl7.Fhir.OpenAPI.csproj", "src/Sotatek.Hl7.Fhir.OpenAPI/"]
COPY ["src/Sotatek.Hl7.Fhir.Common.Contracts/Sotatek.Hl7.Fhir.Common.Contracts.csproj", "src/Sotatek.Hl7.Fhir.Common.Contracts/"]
COPY ["src/Sotatek.Hl7.Fhir.Common.Core/Sotatek.Hl7.Fhir.Common.Core.csproj", "src/Sotatek.Hl7.Fhir.Common.Core/"]
RUN dotnet restore "src/Sotatek.Hl7.Fhir.OpenAPI/Sotatek.Hl7.Fhir.OpenAPI.csproj"
COPY . .
WORKDIR "/src/src/Sotatek.Hl7.Fhir.OpenAPI"
RUN dotnet build "Sotatek.Hl7.Fhir.OpenAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sotatek.Hl7.Fhir.OpenAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sotatek.Hl7.Fhir.OpenAPI.dll"]