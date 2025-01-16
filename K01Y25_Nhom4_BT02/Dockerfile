# Sử dụng hình ảnh cơ bản của .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Sao chép tệp dự án và khôi phục các gói phụ thuộc
COPY *.csproj ./
RUN dotnet restore

# Sao chép toàn bộ mã nguồn và xây dựng ứng dụng
COPY . ./
RUN dotnet publish -c Release -o /out

# Giai đoạn chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /out .
EXPOSE 80
ENTRYPOINT ["dotnet", "K01Y25_Nhom4_BT02.dll"]
