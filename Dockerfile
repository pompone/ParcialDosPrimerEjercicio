# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj y restaurar
COPY PrimerEjercicio.csproj ./
RUN dotnet restore

# Copiar el resto y publicar
COPY . .
RUN dotnet publish -c Release -o /app/out

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Render inyecta PORT; exponemos el puerto para local
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
EXPOSE 8080

# Si usás disco en Render, montará /var/data; tu app debe apuntar ahí por ENV
# ConnectionStrings__DefaultConnection=Data Source=/var/data/app.db

ENTRYPOINT ["dotnet", "PrimerEjercicio.dll"]
