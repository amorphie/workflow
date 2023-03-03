FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000
WORKDIR /app


RUN adduser -u 5679 --disabled-password --gecos "" workflowuser && chown -R workflowuser:workflowuser /app
USER workflowuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src

COPY ["amorphie.workflow.csproj", "amorphie.workflow/"]
RUN dotnet restore "amorphie.workflow.csproj"
COPY . .
WORKDIR "amorphie.workflow"
RUN dotnet build "amorphie.workflow.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "amorphie.workflow.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "amorphie.workflow.dll"]
