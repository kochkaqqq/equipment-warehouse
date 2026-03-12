namespace Presentation.Utils.Services.S3Service
{
    public class S3Settings
    {
        public string StorageUrl { get; set; } = null!;
        public string AccessKey { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
        public string BucketName { get; set; } = null!;
    }
}
