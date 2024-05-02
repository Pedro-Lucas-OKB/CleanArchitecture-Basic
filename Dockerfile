# Create a stage for building the application.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY ./*.sln .

COPY ./CleanArch/CleanArch.Application/*.csproj ./CleanArch/CleanArch.Application/
COPY ./CleanArch/CleanArch.Domain/*.csproj ./CleanArch/CleanArch.Domain/
COPY ./CleanArch/CleanArch.Infra.Data/*.csproj ./CleanArch/CleanArch.Infra.Data/
COPY ./CleanArch/CleanArch.Infra.IoC/*.csproj ./CleanArch/CleanArch.Infra.IoC/
COPY ./CleanArch/CleanArch.MVC/*.csproj ./CleanArch/CleanArch.MVC/

RUN dotnet restore

# Copying the remaining files
RUN dotnet dev-certs https --trust

COPY . .

RUN dotnet build --no-restore

RUN dotnet publish --no-restore -c Release --property:PublishDir=out

# Create a new stage for running the application.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

# Copying publish files
COPY --from=build /app/*/*/out/ ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "CleanArch.MVC.dll"]