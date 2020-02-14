using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace googlecloud
{
    public interface IGcpBucketUtils
    {
       string CreateBucket();
       ICollection GetObjectList();
       
    }
}
