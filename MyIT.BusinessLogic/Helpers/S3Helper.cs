using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;

namespace MyIT.BusinessLogic.Helpers;

public static class S3Helper
{
    private const string BucketName = "myit-artifacts-s3";
    private const string AccessKey = "AKIA3FVVKCT2QSM5TCP3";
    private const string SecretKey = "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";
    public static async Task<string> UploadFile(IFormFile file)
    {
        using (var client = new AmazonS3Client(AccessKey, SecretKey, RegionEndpoint.EUWest1))
        {
            using (var newMemoryStream = new MemoryStream())
            {
                file.CopyTo(newMemoryStream);

                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = file.FileName, // filename
                    BucketName = BucketName // bucket name of S3
                };

                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
            }
        }
        return $"http://{BucketName}.s3.amazonaws.com/{file.FileName}";
    }
}