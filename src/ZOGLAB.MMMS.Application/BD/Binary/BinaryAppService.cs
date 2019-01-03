using Abp.UI;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZOGLAB.MMMS.Storage;
using ZOGLAB.MMMS.Timing;

namespace ZOGLAB.MMMS.BD
{
    public class BinaryAppService : MMMSAppServiceBase, IBinaryAppService
    {
        private readonly IAppFolders _appFolders;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private readonly ITimeZoneService _timeZoneService;

        #region 注入服务
        public BinaryAppService(
            IAppFolders appFolders,
            IBinaryObjectManager binaryObjectManager,
            ITimeZoneService timezoneService)
        {
            _appFolders = appFolders;
            _binaryObjectManager = binaryObjectManager;
            _timeZoneService = timezoneService;
        }
        #endregion

        public string GetBinaryForTest()
        {

            return "hello Binary world!";
        }

        public async Task<string> SaveImages()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files["file02"];//接收

            byte[] byteArray;
            //Save new picture
            var fileInfo = new FileInfo(file.FileName);
            var tempFileName = "androidImage_" + file.FileName ; /*+fileInfo.Extension*/
            var tempFilePath = Path.Combine(_appFolders.TempFileDownloadFolder, tempFileName);
            file.SaveAs(tempFilePath);

            //if (!File.Exists(tempFilePath))//判断文件是否存在
            //{//若不存在
            //    Directory.CreateDirectory(tempFilePath);//这个方法创建文件夹的时候如果文件夹存在的话就不会创建了，所以不管文件有没有都调用一下，省得写那么多判断
            //    file.SaveAs(tempFilePath); //保存文件
            //}

            using (var fsTempProfilePicture = new FileStream(tempFilePath, FileMode.Open))
            {
                using (var bmpImage = new Bitmap(fsTempProfilePicture))
                {
                    //var width = input.Width == 0 ? bmpImage.Width : input.Width;
                    //var height = input.Height == 0 ? bmpImage.Height : input.Height;
                    //var bmCrop = bmpImage.Clone(new Rectangle(input.X, input.Y, width, height), bmpImage.PixelFormat);

                    using (var stream = new MemoryStream())
                    {
                        bmpImage.Save(stream, bmpImage.RawFormat);
                        stream.Close();
                        byteArray = stream.ToArray();
                    }
                }
            }

            //if (byteArray.LongLength > 102400) //100 KB
            //{
            //    throw new UserFriendlyException(L("ResizedProfilePicture_Warn_SizeLimit"));
            //}
            var storedFile = new BinaryObject(AbpSession.TenantId, byteArray);
            await _binaryObjectManager.SaveAsync(storedFile);

            return tempFilePath; //返回MD5码，用于后面保存在数据库
        }

        #region 注释备用
        //string ext = Path.GetExtension(file.FileName);//文件后缀名
        //Stream s = file.InputStream;//文件流
        //MD5 md5 = new MD5CryptoServiceProvider();
        //byte[] retVal = md5.ComputeHash(s);
        //StringBuilder sb = new StringBuilder();
        //for (int i = 0; i < retVal.Length; i++)
        //{
        //    sb.Append(retVal[i].ToString("x2"));
        //}

        //string Md5res = sb.ToString();//上面的代码是为了生成文件唯一的MD5码
        //string path = Md5res.Substring(0, 2);
        //string path1 = Md5res.Substring(Md5res.Length - 2, 2); //取MD5的前两位和后两位生成文件夹，把图片存在后两位的文件夹内
        //string fileSaveLocation = "E:\\CoolSchoolImages\\{path}\\{path1}\\{Md5res}.jpg";//文件最终保存路径

        //public ImgOutput SaveImges() {
        //    var result = new ImgOutput ();

        //    try
        //    {
        //        //Check input
        //        if (HttpRequest.Files.Count <= 0 || Request.Files[0] == null)
        //        {
        //            throw new UserFriendlyException(L("ProfilePicture_Change_Error"));
        //        }

        //        var file = Request.Files[0];

        //        if (file.ContentLength > 1048576) //1MB.
        //        {
        //            throw new UserFriendlyException(L("ProfilePicture_Warn_SizeLimit"));
        //        }

        //        //Check file type & format
        //        var fileImage = Image.FromStream(file.InputStream);
        //        var acceptedFormats = new List<ImageFormat>
        //        {
        //            ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif
        //        };

        //        if (!acceptedFormats.Contains(fileImage.RawFormat))
        //        {
        //            throw new ApplicationException("Uploaded file is not an accepted image file !");
        //        }

        //        //Delete old temp profile pictures
        //        AppFileHelper.DeleteFilesInFolderIfExists(_appFolders.TempFileDownloadFolder, "userProfileImage_" + AbpSession.GetUserId());

        //        //Save new picture
        //        var fileInfo = new FileInfo(file.FileName);
        //        var tempFileName = "userProfileImage_" + AbpSession.GetUserId() + fileInfo.Extension;
        //        var tempFilePath = Path.Combine(_appFolders.TempFileDownloadFolder, tempFileName);
        //        file.SaveAs(tempFilePath);

        //        using (var bmpImage = new Bitmap(tempFilePath))
        //        {
        //            return Json(new AjaxResponse(new { fileName = tempFileName, width = bmpImage.Width, height = bmpImage.Height }));
        //        }
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //    return result;
        //}
        #endregion
    }
}
