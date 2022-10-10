FROM mcr.microsoft.com/dotnet/sdk as runtime
WORKDIR /app
COPY . /app
RUN dotnet publish API/ -c Release -o published
ENV PORT 8000
EXPOSE $PORT
CMD ["dotnet",  "published/API.dll"]