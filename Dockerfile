FROM microsoft/dotnet:2.0.0-sdk as build-environment

MAINTAINER Thorsten Hans <thorsten.hans@gmail.com>

COPY ./src/Demo.IdentityServer.csproj /app/
WORKDIR /app
RUN dotnet restore
CMD ["ls" "-al"]
COPY ./src/ /app/

RUN dotnet publish -c Release -o out

FROM microsoft/aspnetcore:2.0.0
WORKDIR /app
COPY --from=build-environment /app/out/ ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "Demo.IdentityServer.dll"]