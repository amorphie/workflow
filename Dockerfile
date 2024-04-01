FROM mcr.microsoft.com/dotnet/aspnet:8.0.2 AS base
WORKDIR /app

RUN adduser amorphie-workflowuser --disabled-password --gecos "" && chown -R amorphie-workflowuser:amorphie-workflowuser /app
USER amorphie-workflowuser

FROM mcr.microsoft.com/dotnet/sdk:8.0.200 AS build
WORKDIR /src
ENV DOTNET_NUGET_SIGNATURE_VERIFICATION=false
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
