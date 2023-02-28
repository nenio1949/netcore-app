#netcore-app
## codefirst数据库更新
### 1.若未安装ef则执行 dotnet tool install --global dotnet-ef
### 2.生成构建数据库结构文件 dotnet ef migrations add InitialCreate
### 3.更新到数据库 dotnet ef database update