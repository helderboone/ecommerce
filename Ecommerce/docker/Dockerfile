FROM microsoft/dotnet:2.0-runtime

COPY out/ /home/bin
WORKDIR /home/bin

EXPOSE 5000

CMD ["dotnet", "Ecommerce.dll"]