using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TptCourse.Infrastructure.Constants
{
    public static class SPNames
    {
        
        public const string SP_INSERTAPPLICATIONFORM = "sp_InsertApplicationForm";
        public const string SP_GETAPPLICATIONFORMBYID = "sp_GetApplicationFormByID";
        public const string SP_GETALLAPPLICATIONFORMS = "sp_GetAllApplicationForms";
        public const string SP_UPDATEAPPLICATIONFORM = "sp_UpdateApplicationForm";

        public const string SP_INSERTBATCHDETAILS = "sp_InsertBatchDetails";
        public const string SP_UPDATEBATCHDETAILS = "sp_UpdateBatchDetails";
        public const string SP_GETBATCHBYID = "sp_GetBatchDetailsById";
        public const string SP_GETALLBATCHES = "sp_GetAllBatchDetails";
        public const string SP_DELETEBATCHDETAILS = "sp_DeleteBatchDetails";

        public const string SP_GETALLCOURSES = "sp_GetAllCourseDetails";
        public const string SP_GETCOURSEBYID = "sp_GetCourseDetailsById";
        public const string SP_INSERTCOURSEDETAILS = "sp_InsertCourseDetails";
        public const string SP_UPDATECOURSEDETAILS = "sp_UpdateCourseDetails";
        public const string SP_DELETECOURSEDETAILS = "sp_DeleteCourseDetails";


    }


}



