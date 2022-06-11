FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
COPY published/ ./
ENTRYPOINT ["dotnet", "SpeedControl.API.dll"]