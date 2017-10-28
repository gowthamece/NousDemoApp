using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;

namespace NousDemoApp.Utility
{
    public class BlobConnection
    {
        public static CloudStorageAccount GetBlobConnection()
        {

            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName=nousdemo;AccountKey=/szGZzBqymeIKWY+X2NwrhS6o9RPhgfTZjSX7MKfcS8yNqa6gxVS3dTQMkx83DAyYJ7UdKbAI5C/qtV0+RdkaA==;EndpointSuffix=core.windows.net");
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}