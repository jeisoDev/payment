# Use a imagem base do SDK do .NET para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie os arquivos de projeto e restaure as dependências
COPY ["paymentAPI/*.csproj", "./"]
RUN dotnet restore

# Copie o restante dos arquivos e construa a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Use a imagem base do runtime do .NET para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Exponha a porta que a aplicação vai rodar
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "paymentAPI.dll"]