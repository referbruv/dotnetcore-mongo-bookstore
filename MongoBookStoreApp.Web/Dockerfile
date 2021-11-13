FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
RUN apt install -y nodejs

WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./MongoBookStoreApp.Contracts/MongoBookStoreApp.Contracts.csproj", "src/MongoBookStoreApp.Contracts/"]
COPY ["./MongoBookStoreApp.Core/MongoBookStoreApp.Core.csproj", "src/MongoBookStoreApp.Core/"]
COPY ["./MongoBookStoreApp.Web/MongoBookStoreApp.Web.csproj", "src/MongoBookStoreApp.Web/"]

# run restore over web project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/MongoBookStoreApp.Web/MongoBookStoreApp.Web.csproj"

COPY . .

# run build over the web project
WORKDIR "/src/MongoBookStoreApp.Web/"
RUN dotnet build -c Release -o /app/build

# run publish over the web project
# this also generates the dist folder for the ClientApp
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "MongoBookStoreApp.Web.dll" ]