FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Presentations/Rasot.Web/Rasot.Web.csproj", "src/Presentations/Rasot.Web/"]
COPY ["src/Library/Rasot.Data/Rasot.Data.csproj", "src/Library/Rasot.Data/"]
COPY ["src/Library/Rasot.Core/Rasot.Core.csproj", "src/Library/Rasot.Core/"]
COPY ["src/Library/Rasot.Service/Rasot.Service.csproj", "src/Library/Rasot.Service/"]
RUN dotnet restore "src/Presentations/Rasot.Web/Rasot.Web.csproj"
COPY . .
WORKDIR "/src/src/Presentations/Rasot.Web"
RUN dotnet build "Rasot.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Rasot.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Rasot.Web.dll"]