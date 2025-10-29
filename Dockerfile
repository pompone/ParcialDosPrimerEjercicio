# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos TODO el repo (evita problemas de rutas)
COPY . .

# (Paso de diagnóstico opcional: ver que el csproj esté)
RUN find . -maxdepth 2 -name "*.csproj" -print

# Restaurar y publicar sin especificar path (detecta el único .csproj)
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PrimerEjercicio.dll"]
