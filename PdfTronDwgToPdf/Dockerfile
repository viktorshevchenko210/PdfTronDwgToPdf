
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base

RUN apt-get -y update
RUN apt-get -y install libgl1-mesa-dev libx11-dev libglu1-mesa-dev
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PdfTronDwgToPdf/PdfTronDwgToPdf.csproj", "PdfTronDwgToPdf/"]
RUN dotnet restore "PdfTronDwgToPdf/PdfTronDwgToPdf.csproj"
COPY . .
WORKDIR "/src/PdfTronDwgToPdf"
RUN dotnet build "PdfTronDwgToPdf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PdfTronDwgToPdf.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PdfTronDwgToPdf.dll"]