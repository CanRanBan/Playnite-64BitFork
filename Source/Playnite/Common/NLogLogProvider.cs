﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using NLog.Config;
using NLog.Targets;
using Playnite.SDK;

namespace Playnite.Common
{
    public class NLogLogger : ILogger
    {
        public static bool IsTraceEnabled { get; set; } = false;
        private NLog.Logger logger;

        public NLogLogger(string loggerName)
        {
            logger = NLog.LogManager.GetLogger(loggerName);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug(Exception exception, string message)
        {
            logger.Debug(exception, message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception exception, string message)
        {
            logger.Error(exception, message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Info(Exception exception, string message)
        {
            logger.Info(exception, message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Warn(Exception exception, string message)
        {
            logger.Warn(exception, message);
        }

        public void Trace(string message)
        {
            if (IsTraceEnabled)
            {
                logger.Trace(message);
            }
        }

        public void Trace(Exception exception, string message)
        {
            if (IsTraceEnabled)
            {
                logger.Trace(exception, message);
            }
        }
    }

    public class NLogLogProvider : ILogProvider
    {
        public NLogLogProvider()
        {
            if (NLog.LogManager.Configuration != null)
            {
                return;
            }

            var config = new LoggingConfiguration();
            config.DefaultCultureInfo = new System.Globalization.CultureInfo("en-US");

#if DEBUG
            var consoleTarget = new ColoredConsoleTarget("FallbackConsoleLog")
            {
                Layout = @"${level:uppercase=true}|${logger}:${message}${exception}"
            };

            config.AddRuleForAllLevels(consoleTarget);
#endif

            var loggerDir = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            var fileTarget = new FileTarget("FallbackPlayniteLog")
            {
                FileName = Path.Combine(loggerDir, "NLog.log"),
                Layout = "${longdate}|${level:uppercase=true}:${message}${exception:format=toString}",
                KeepFileOpen = false,
                ArchiveFileName = Path.Combine(loggerDir, "NLog.{#####}.log"),
                ArchiveAboveSize = 4096000,
                ArchiveNumbering = ArchiveNumberingMode.Sequence,
                MaxArchiveFiles = 2,
                Encoding = Encoding.UTF8
            };

            config.AddRuleForAllLevels(fileTarget);
            NLog.LogManager.Configuration = config;
        }

        public ILogger GetLogger(string loggerName)
        {
            return new NLogLogger(loggerName);
        }
    }
}
