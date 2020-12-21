ARG runtime=docker-registry.cdweb.biz/dotnet/dotnet-aspnetcore-runtime:3.1.2
ARG builder=docker-registry.cdweb.biz/dotnet/dotnet-sdk:3.1.102

FROM $builder AS publish
WORKDIR /src
COPY --chown=dotnet:dotnet . .
RUN dotnet publish src/Api/Cds.TestFormationDotnetcore.Api.csproj -c Release -o /app

FROM $runtime AS final

LABEL maintainer=my.team.name \
      com.cdiscount.perimeter=CDS \
      com.cdiscount.contact=my.team@cdiscount.com \
      com.cdiscount.description="My sample API description" \
      com.cdiscount.repository=http://tfs.cdbdx.biz:8080/tfs/DefaultCollection/DotNet-Foundation/_git/TestFormationDotnetcores \
      com.cdiscount.imageName=docker-registry.cdweb.biz/my.team/testformationdotnetcore.api

WORKDIR /app
COPY --from=publish /app .

COPY src/Api/Dockerfile /root/

ENTRYPOINT ["dotnet", "Cds.TestFormationDotnetcore.Api.dll"]
