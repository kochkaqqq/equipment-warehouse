namespace Presentation.Utils.Services.S3Service
{
    public interface IS3Service
    {
        Task<string> SaveMedia(byte[] file);
    }
}
