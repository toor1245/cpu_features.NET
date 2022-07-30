namespace CpuFeaturesDotNet.GoogleDriveDeploy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GoogleDriveClient googleDriveClient = new GoogleDriveClient();
            googleDriveClient.DownloadBuilds();
        }
    }
}