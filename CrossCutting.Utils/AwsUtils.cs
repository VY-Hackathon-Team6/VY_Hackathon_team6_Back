using Amazon.S3;
using Amazon.S3.Model;

namespace CrossCutting.Utils
{
    public static class AwsUtils
    {
        public static async Task<string> GetLastFileInFolderAsync(string bucketName, string folderName)
        {
            using (var s3Client = new AmazonS3Client())
            {
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = bucketName,
                    Prefix = folderName + "/"
                };

                ListObjectsV2Response response;
                do
                {
                    response = await s3Client.ListObjectsV2Async(request);

                    var files = response.S3Objects
                        .OrderByDescending(obj => obj.LastModified)
                        .Where(obj => !obj.Key.EndsWith("/")) // excluye las carpetas
                        .Select(obj => obj.Key);

                    if (files.Any())
                    {
                        return files.First();
                    }

                    request.ContinuationToken = response.NextContinuationToken;
                } while (response.IsTruncated);

                return null;
            }
        }
    }
}
