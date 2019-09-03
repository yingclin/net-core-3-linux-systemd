using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace net_core_3_linux_systemd
{
    public class Worker : BackgroundService
    {
        public Worker()
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                File.AppendAllText("/var/log/netcoreservice.log",
                    $"Worker running at: {DateTimeOffset.Now}{Environment.NewLine}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
