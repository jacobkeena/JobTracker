using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace JobSearchLibrary
{
    public static class JobInfo
    {
        public static string CompanyName { get; set; }
        public static string Position { get; set; }
        public static string Location { get; set; }
        public static string SalaryRange { get; set; }
        public static int Rating { get; set; }
        public static string CEOName { get; set; }
        public static string MissionStatement { get; set; }
        public static string Benefits { get; set; }
        public static string Comments { get; set; }
        public static string Recruiter { get; set; }
        public static string JobLink { get; set; }
    }
    

}
