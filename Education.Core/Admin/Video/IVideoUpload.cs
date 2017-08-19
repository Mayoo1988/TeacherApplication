using Education.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin
{
   public interface IVideoUpload
    {
        VideoUploaddetails CreateVideoDetails(VideoUploaddetails studentDetails);

        List<VideoUploaddetails> GetVideoUploaddetails();
        List<VideoUploaddetails> GetVideoUploaddetails(VideoUploaddetails objvideoDetails);

        List<VideoUploaddetails> GetFileName(int FileID);
    }
}
