namespace Fleet.Vehicles
{
    public class FileUploadOptions
    {
        public const string Name = "FileUpload";

        public string AcceptedFileName { get; set; }
        public string AcceptedFilePath { get; set; }
        public string RejectedFilePath { get; set; }
    }
}
