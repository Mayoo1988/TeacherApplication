using Education.DB;
using Education.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin
{
    public class VideoUpload : IVideoUpload
    {
        public EducationDBEntities dbEntities = new EducationDBEntities();

        public VideoUploaddetails CreateVideoDetails(VideoUploaddetails objvideoDetails)
        {
            try
            {
                TBL_GN_DIGITALDOC_DETAILS videodetails = new TBL_GN_DIGITALDOC_DETAILS();
                videodetails.DIGITALDOCTYPEID = objvideoDetails.DIGITALDOCTYPEID;
                videodetails.DOCUMENTNAME = objvideoDetails.DOCUMENTNAME;
                videodetails.SUBJECTID = objvideoDetails.SUBJECTID;
                
                videodetails.CREATEDBY = objvideoDetails.CREATEDBY;
                videodetails.CREATEDDATE = objvideoDetails.CREATEDDATE;
                videodetails.MODIFIEDBY = objvideoDetails.MODIFIEDBY;
                videodetails.MODIFIEDDATE = objvideoDetails.MODIFIEDDATE;
                videodetails.STATUS = objvideoDetails.STATUS;
                videodetails.ALLOWANONYMOUS = objvideoDetails.ALLOWANONYMOUS;
                videodetails.DOWNLOADCOUNT = objvideoDetails.DOWNLOADCOUNT;
                videodetails.VIEWCOUNT = objvideoDetails.VIEWCOUNT;

                dbEntities.TBL_GN_DIGITALDOC_DETAILS.Add(videodetails);
                dbEntities.SaveChanges();
                return objvideoDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoUploaddetails> GetFileName(int FileID)
        {
            try
            {
                return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Where(X => X.DIGITALDOCTYPEID == FileID).Select(X =>
           new VideoUploaddetails()
           {
               DOCUMENTNAME = X.DOCUMENTNAME,
               
              
           }

               ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoUploaddetails> GetVideoUploaddetails()
        {
           try
            {
                //return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Select(X =>

                // new VideoUploaddetails()
                // {
                //     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                //     DOCUMENTNAME = X.DOCUMENTNAME,
                //     SUBJECTID = X.SUBJECTID,

                // }

                //).ToList();
                return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Select(X => new VideoUploaddetails() { DIGITALDOCTYPEID = X.DIGITALDOCTYPEID, DOCUMENTNAME = X.DOCUMENTNAME }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoUploaddetails> GetVideoUploaddetails(VideoUploaddetails objvideoDetails)
        {
            try
            {
                return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Select(X =>

                 new VideoUploaddetails()
                 {
                     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                     DOCUMENTNAME = X.DOCUMENTNAME,
                     SUBJECTID = X.SUBJECTID,
                   
                 }

                ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
