## 專案啟動需求

- 作業系統 : windows 10
- 套件管理 : npm、nuget
- IDE : vistual studio 2019
- 資料庫 : mysql
- 其他安裝 : 
   -  mysql .net connector8.0.31 : https://dev.mysql.com/downloads/connector/net/

## 設定資料庫

在專案跟目錄下開啟cmd，執行:
```sh
copy Web.example.config Web.config
```

修改 Web.config 中的 connectionStrings中的 ttqs_newEntities 連線內容

在專案跟目錄找到ttqsExport.sql，執行在資料庫

## 編譯Vue

前端的部分放在/ClientApp 下，進入該資料夾cmd執行 :
   ```sh
npm i
```

編譯:
   ```sh
npm run build
```

這裡可能會有版本問題，請下載並使用正確的node版本
