using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.OpenServices.OpenStorageService;
using System.Collections;
using System.IO;

namespace BIMT.Util.Oss
{
    public class OssHelper
    {
        private static OssClient ossClient = OssManager.GetInstance();
        InitItemInvoke mi;

        public InitItemInvoke Mi
        {
            get { return mi; }
            //set { mi = value; }
        }
        IViewCallback view;

        public OssHelper(IViewCallback view)
        {
            this.view = view;
            mi = new InitItemInvoke(view.SetView);
        }
        public IEnumerable GetBucketsList()
        {
            return ossClient.ListBuckets();
        }

        public string CreateBucket(string bucketName)
        {
            try
            {
                ossClient.CreateBucket(bucketName);
                return ("创建成功！Bucket: " + bucketName);
            }
            catch (OssException ex)
            {
                if (ex.ErrorCode == OssErrorCode.BucketAlreadyExists)
                {
                    // 这里示例处理一种特定的ErrorCode。 
                    return (string.Format("Bucket '{0}' 已经存在，请更改名称后再创建。", bucketName));
                }
                else if (ex.ErrorCode == OssErrorCode.BucketNotEmtpy)
                {
                    return string.Format("Bucket:{0}中存有数据，拒绝删除");
                }
                else
                {
                    // RequestID和HostID可以在有问题时用于联系客服诊断异常。 
                    return (string.Format("创建失败。错误代码：{0}; 错误消息：{1}。\nRequestID:{2}\tHostID:{3}",
                                                    ex.ErrorCode,
                                                    ex.Message,
                                                    ex.RequestId,
                                                    ex.HostId));
                }
            }
        }

        public string UploadFile(string bucketName, Stream stream, string key)
        {
            try
            {
                using (stream)
                {
                    ObjectMetadata metadata = new ObjectMetadata();
                    PutObjectResult res = ossClient.PutObject(bucketName, key, stream, metadata);
                    return string.Format("上传成功{0} {1}", key, res.ETag);
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void mutiPartUpload(string bucketName, string key,string path,int M)
        {
            
            InitiateMultipartUploadRequest initRequest =  new InitiateMultipartUploadRequest(bucketName, key);
            InitiateMultipartUploadResult initResult = ossClient.InitiateMultipartUpload(initRequest);
            // 设置每块为 5M   
            int partSize = 1024 * 1024 * M;
            FileInfo partFile = new FileInfo(path);
            // 计算分块数目   
            int partCount = (int)(partFile.Length / partSize);
            if (partFile.Length % partSize != 0)
            {
                partCount++;
            }
            // 新建一个List保存每个分块上传后的ETag和PartNumber   
            List<PartETag> partETags = new List<PartETag>();
            view.MyInvoke(Mi, new object[] { partCount, null });
            for (int i = 0; i < partCount; i++)
            {
                view.MyInvoke(Mi, new object[] { i, string.Format("uploading blocks of {2} [{0}/{1}] ", string.Format("{0,-1:D2}",i + 1), partCount, partFile.Name) });
                // 获取文件流   
                FileStream fis = new FileStream(partFile.FullName, FileMode.Open);
                // 跳到每个分块的开头   
                long skipBytes = partSize * i;
                fis.Position = skipBytes;
                //fis.skip(skipBytes);   
                // 计算每个分块的大小   
                long size = partSize < partFile.Length - skipBytes ?
                        partSize : partFile.Length - skipBytes;
                // 创建UploadPartRequest，上传分块   
                UploadPartRequest uploadPartRequest = new UploadPartRequest(bucketName, key, initResult.UploadId);
                uploadPartRequest.InputStream = fis;
                uploadPartRequest.PartSize = size;
                uploadPartRequest.PartNumber = (i + 1);
                UploadPartResult uploadPartResult = ossClient.UploadPart(uploadPartRequest);
                // 将返回的PartETag保存到List中。   
                partETags.Add(uploadPartResult.PartETag);
                // 关闭文件   
                fis.Close();
            }
            CompleteMultipartUploadRequest completeReq = new CompleteMultipartUploadRequest(bucketName, key, initResult.UploadId);
            foreach (PartETag partETag in partETags)
            {
                completeReq.PartETags.Add(partETag);
            }
            //完成分块上传   
            CompleteMultipartUploadResult completeResult = ossClient.CompleteMultipartUpload(completeReq);   
            view.MyInvoke(Mi, new object[] { 999999, string.Format("big file {0} upload finished...",partFile.Name) });
        } 

        public IEnumerable<OssObjectSummary> GetObjectlist(string bucketName)
        {
            ObjectListing list = ossClient.ListObjects(bucketName);
            return list.ObjectSummaries;
        }

        private string GetSize(long size)
        {
            if (size > 1024 * 1024)
                return size / (1024 * 1024) + "." + (size % (1024 * 1024)) / 1024 + "MB";
            else if (size > 1024)
                return size / 1024 + "." + (size % 1024) / 10 + "KB";
            else
                return size + "字节";
        }

        public string DeleteObject(string bucketName, string obj)
        {
            try
            {
                ossClient.DeleteObject(bucketName, obj);
                return string.Format("删除成功!文件：" + obj); 
            }
            catch (Exception ex)
            {
                return string.Format("删除失败!文件：" + obj+ex.ToString()); 
            }
            
        } 

    }
}
