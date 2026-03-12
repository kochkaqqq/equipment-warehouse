
using Amazon.S3;
using Amazon.S3.Model;

namespace Presentation.Utils.Services.S3Service
{
    public class S3Service : IS3Service
    {
        private readonly S3Settings _settings;
        private readonly IAmazonS3 _client;

        public S3Service(S3Settings settings)
        {
            _settings = settings;

            var s3Config = new AmazonS3Config()
            {
                ServiceURL = _settings.StorageUrl,
                ForcePathStyle = true
            };

            _client = new AmazonS3Client(_settings.AccessKey, _settings.SecretKey, s3Config);
        }

        public async Task<string> SaveMedia(byte[] file)
        {
            var key = $"{Guid.NewGuid()}.jpg";

            using var stream = new MemoryStream(file);

            var request = new PutObjectRequest
            {
                BucketName = _settings.BucketName,
                Key = key,
                InputStream = stream,
                ContentType = "application/octet-stream",
                CannedACL = S3CannedACL.PublicRead
            };

            try
            {
                await _client.PutObjectAsync(request);
                return $"{_settings.StorageUrl}/{_settings.BucketName}/{key}";
            }
            catch
            {
                return string.Empty;
            }
            
        }
    }
}
