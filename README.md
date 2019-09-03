# .NET Core 3 的 Linux systemd 範例

透過 .NET Core 3.0，我們可以快速的開發出 Linux systemd。

## 專案的執行環境

* SDK 3.0.100-preview8-013656
* VSCode 1.37
* CentOS 7

## 安裝為 Services

#### 發佈專案

或是建置(build)，兩者輸出路徑不同，到時要建立 Services 時，指的路徑也不同。
```
sudo dotnet publish -o /usr/sbin/testapp
```

#### 建立 .service 檔
要建立 Linux 的 service，需要在 /etc/systemd/system/ 目錄下提供一個 .service 檔做配置 service 之用。將服務命名為 testapp 時，檔名為 testapp.service，基本內容如下
```
[Unit]
Description=my test app

[Service]
Type=notify
ExecStart=/usr/sbin/testapp/net-core-3-linux-systemd

[Install]
WantedBy=multi-user.target
```
ExecStart 指到發佈路徑下的主程式

#### 重載服務
```
sudo systemctl daemon-reload
```

#### 啟用 Services
```
sudo systemctl enable testapp.service
```

#### 執行 Services
```
sudo systemctl enable testapp.service
```

#### 觀察 /var/log/netcoreservice.log 的內容。
```
tail -f /var/log/netcoreservice.log
```

## 參考

[以 .NET Core 快速開發 Windows Services 或 Linux systemd 服務](http://yingclin.github.io/2019/windows-services-or-linux-systemd-in-netcore.html)

