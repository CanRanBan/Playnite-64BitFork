﻿using System;
using System.ComponentModel;

namespace Playnite.SDK.Models
{
    /// <summary>
    ///
    /// </summary>
    public enum AppSoftwareType
    {
        /// <summary>
        ///
        /// </summary>
        [Description("LOCDefault")]
        Standard,
        /// <summary>
        ///
        /// </summary>
        [Description("LOCGameActionTypeScript")]
        Script
    }

    /// <summary>
    /// Represents general application software.
    /// </summary>
    public class AppSoftware : DatabaseObject
    {
        private string icon;
        /// <summary>
        /// Gets or sets application icon.
        /// </summary>
        public string Icon
        {
            get => icon;
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }

        private string arguments;
        /// <summary>
        /// Gets or sets application arguments.
        /// </summary>
        public string Arguments
        {
            get => arguments;
            set
            {
                arguments = value;
                OnPropertyChanged();
            }
        }

        private string path;
        /// <summary>
        /// Gets or sets application path.
        /// </summary>
        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged();
            }
        }

        private string workingDir;
        /// <summary>
        /// Gets or sets application working directory.
        /// </summary>
        public string WorkingDir
        {
            get => workingDir;
            set
            {
                workingDir = value;
                OnPropertyChanged();
            }
        }

        private bool showOnSidebar;
        /// <summary>
        ///
        /// </summary>
        public bool ShowOnSidebar
        {
            get => showOnSidebar;
            set
            {
                showOnSidebar = value;
                OnPropertyChanged();
            }
        }

        private AppSoftwareType appType = AppSoftwareType.Standard;
        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public AppSoftwareType AppType
        {
            get => appType;
            set
            {
                appType = value;
                OnPropertyChanged();
            }
        }

        private string script;
        /// <summary>
        /// Gets or sets script to execute if type is set to script type.
        /// </summary>
        public string Script
        {
            get => script;
            set
            {
                script = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Creates new instance of <see cref="AppSoftware"/>.
        /// </summary>
        public AppSoftware() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="AppSoftware"/>.
        /// </summary>
        /// <param name="name"></param>
        public AppSoftware(string name) : base()
        {
            Name = name;
        }

        /// <inheritdoc/>
        public override void CopyDiffTo(object target)
        {
            base.CopyDiffTo(target);

            if (target is AppSoftware tro)
            {
                if (!string.Equals(Icon, tro.Icon, StringComparison.Ordinal))
                {
                    tro.Icon = Icon;
                }

                if (!string.Equals(Arguments, tro.Arguments, StringComparison.Ordinal))
                {
                    tro.Arguments = Arguments;
                }

                if (!string.Equals(Path, tro.Path, StringComparison.Ordinal))
                {
                    tro.Path = Path;
                }

                if (!string.Equals(WorkingDir, tro.WorkingDir, StringComparison.Ordinal))
                {
                    tro.WorkingDir = WorkingDir;
                }

                if (ShowOnSidebar != tro.ShowOnSidebar)
                {
                    tro.ShowOnSidebar = ShowOnSidebar;
                }

                if (AppType != tro.AppType)
                {
                    tro.AppType = AppType;
                }

                if (!string.Equals(Script, tro.Script, StringComparison.Ordinal))
                {
                    tro.Script = Script;
                }
            }
            else
            {
                throw new ArgumentException($"Target object has to be of type {GetType().Name}");
            }
        }
    }
}
