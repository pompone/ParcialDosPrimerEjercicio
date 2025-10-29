# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos TODO el repo (evita problemas de ruta)
COPY . .

# Restaura y publica apuntando explícitamente al csproj
RUN dotnet restore "./PrimerEjercicio.csproj"
RUN dotnet publish "./PrimerEjercicio.csproj" -c Release -o /app/out

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Render inyecta PORT; setealo en env vars del servicio
ENTRYPOINT ["dotnet", "PrimerEjercicio.dll"]
