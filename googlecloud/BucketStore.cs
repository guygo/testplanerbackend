using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace googlecloud
{
    class BucketStore
    {
        private StorageClient client;
        private IGcpBucketUtils bucketUtils;
        public BucketStore(IGcpBucketUtils _bucketUtils) { 
         client= StorageClient.Create();
         this.bucketUtils = _bucketUtils;
        }
        public async void BucketUploadAsync() {
           

        } 


    }
}
