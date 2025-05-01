using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Common.Logging
{
    public static class SeriLogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
           (context, configuration) =>
           {
               var connectionstring = context.Configuration.GetConnectionString("SeriLogConnectionString");

               configuration
                    //.WriteTo.Debug()
                    //.WriteTo.Console()
                    //.WriteTo.MySQL(
                    //   connectionString: connectionstring,
                    //   tableName: "Log"
                    // )
              .ReadFrom.Configuration(context.Configuration).CreateLogger();
           };
    }
}
