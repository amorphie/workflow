FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

RUN adduser -u 5679 --disabled-password --gecos "" amorphie-workflowuser && chown -R amorphie-workflowuser:amorphie-workflowuser /app
USER amorphie-workflowuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./amorphie.workflow/amorphie.workflow.csproj", "."]
RUN dotnet restore "./amorphie.workflow.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./amorphie.workflow/amorphie.workflow.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./amorphie.workflow/amorphie.workflow.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "amorphie.workflow.dll"]
