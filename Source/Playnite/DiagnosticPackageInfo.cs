namespace Playnite
{
    public class DiagnosticPackageInfo
    {
        public static readonly string PackageInfoFileName = "packageInfo.txt";

        public string PlayniteVersion { get; set; }
        public bool IsCrashPackage { get; set; } = false;
    }
}
