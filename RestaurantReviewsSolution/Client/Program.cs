using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsModels;
using BusinessLogic;
using NLog;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger _logger = LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget() { FileName = "logfile.txt", Name = "logfile" };

            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logfile));

            LogManager.Configuration = config;
            
            _logger.Log(LogLevel.Info,_logger); //logger exists only to log information about itself whenever program is run
        }
    }
}

