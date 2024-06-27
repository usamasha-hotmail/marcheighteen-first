FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY . /app

RUN dotnet publish --configuration Release --output out

FROM mcr.microsoft.com/dotnet/runtime:6.0

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet", "Contoso.Spaces.Console.dll" ]