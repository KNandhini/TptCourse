using System.Data;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using TptCourse.Domain.Entities;
using TptCourse.Infrastructure.Interfaces;
using TptCourse.Infrastructure.DatabaseConnection;
using Dapper;

namespace TptCourse.Infrastructure.Repositories
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly IDataBaseConnection _db;

        public ApplicationFormRepository(IDataBaseConnection db)
        {
            _db = db;
        }

        /// <inheritdoc/>
        public async Task<List<Application>> GetApplicationFormDetails(int? id)
        {
            //var list = new List<Application>();

            //using var conn = (SqlConnection)_db.Connection;
            //using var cmd = new SqlCommand(
            //    id.HasValue ? "sp_GetAllApplicationForms" : "sp_GetAllApplicationForms",
            //    conn
            //)
            //{ CommandType = CommandType.StoredProcedure };

            //if (id.HasValue)
            //    cmd.Parameters.AddWithValue("@ApplicationID", id.Value);

            //await conn.OpenAsync();
            //using var reader = await cmd.ExecuteReaderAsync();

            //while (await reader.ReadAsync())
            //{
            //    list.Add(MapApplication(reader));
            //}

            //return list;
            var spName = "sp_GetAllApplicationForms";
            return await Task.Factory.StartNew(() => _db.Connection.Query<Application>(spName, new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        /// <inheritdoc/>
        public async Task<Application> InsertApplicationForm(Application formDetails)
        {
            using var conn = (SqlConnection)_db.Connection;
            using var cmd = new SqlCommand("sp_InsertApplicationForm", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            string educationJson = JsonSerializer.Serialize(formDetails.ListEducationDetails);

            cmd.Parameters.AddWithValue("@CandidateName", formDetails.CandidateName);
            cmd.Parameters.AddWithValue("@Sex", formDetails.Sex);
            cmd.Parameters.AddWithValue("@FatherOrHusbandName", formDetails.FatherOrHusbandName);
            cmd.Parameters.AddWithValue("@ContactAddress", formDetails.ContactAddress);
            cmd.Parameters.AddWithValue("@MobileNumber", formDetails.MobileNumber);
            cmd.Parameters.AddWithValue("@Age", formDetails.Age);
            cmd.Parameters.AddWithValue("@DateOfBirth", formDetails.DateOfBirth);
            cmd.Parameters.AddWithValue("@AadharNumber", formDetails.AadharNumber);
            cmd.Parameters.AddWithValue("@Email", formDetails.Email);
            cmd.Parameters.AddWithValue("@EducationDetails", educationJson);
            cmd.Parameters.AddWithValue("@ModeOfAdmission", formDetails.ModeOfAdmission);
            cmd.Parameters.AddWithValue("@CandidateStatus", formDetails.CandidateStatus);
            cmd.Parameters.AddWithValue("@IfEmployed_WorkingAt", formDetails.IfEmployed_WorkingAt);
            cmd.Parameters.AddWithValue("@Declaration", formDetails.Declaration);
            cmd.Parameters.AddWithValue("@Place", formDetails.Place);
            cmd.Parameters.AddWithValue("@ApplicationDate", formDetails.ApplicationDate);
            cmd.Parameters.AddWithValue("@CreatedBy", formDetails.CreatedBy);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();

            formDetails.ApplicationID = Convert.ToInt32(result);
            return formDetails;
        }

        /// <inheritdoc/>
        public async Task UpdateApplicationForm(Application formDetails)
        {
            using var conn = (SqlConnection)_db.Connection;
            using var cmd = new SqlCommand("sp_UpdateApplicationForm", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            string educationJson = JsonSerializer.Serialize(formDetails.ListEducationDetails ?? new List<Education>());

            cmd.Parameters.AddWithValue("@ApplicationID", formDetails.ApplicationID);
            cmd.Parameters.AddWithValue("@CandidateName", formDetails.CandidateName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Sex", formDetails.Sex ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@FatherOrHusbandName", formDetails.FatherOrHusbandName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ContactAddress", formDetails.ContactAddress ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MobileNumber", formDetails.MobileNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Age", formDetails.Age);
            cmd.Parameters.AddWithValue("@DateOfBirth", formDetails.DateOfBirth);
            cmd.Parameters.AddWithValue("@AadharNumber", formDetails.AadharNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", formDetails.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@EducationDetails", educationJson);
            cmd.Parameters.AddWithValue("@ModeOfAdmission", formDetails.ModeOfAdmission ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CandidateStatus", formDetails.CandidateStatus ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IfEmployed_WorkingAt", formDetails.IfEmployed_WorkingAt ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Declaration", formDetails.Declaration);
            cmd.Parameters.AddWithValue("@Place", formDetails.Place ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ApplicationDate", formDetails.ApplicationDate);
            cmd.Parameters.AddWithValue("@ModifiedBy", formDetails.ModifiedBy ?? (object)DBNull.Value);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }


        private Application MapApplication(SqlDataReader reader)
        {
            return new Application
            {
                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                CandidateName = reader["CandidateName"].ToString() ?? string.Empty,
                Sex = reader["Sex"].ToString() ?? string.Empty,
                FatherOrHusbandName = reader["FatherOrHusbandName"].ToString() ?? string.Empty,
                ContactAddress = reader["ContactAddress"].ToString() ?? string.Empty,
                MobileNumber = reader["MobileNumber"].ToString() ?? string.Empty,
                Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : DateTime.MinValue,
                AadharNumber = reader["AadharNumber"].ToString() ?? string.Empty,
                Email = reader["Email"].ToString() ?? string.Empty,
                ListEducationDetails = string.IsNullOrEmpty(reader["EducationDetails"]?.ToString())
                    ? new List<Education>()
                    : JsonSerializer.Deserialize<List<Education>>(reader["EducationDetails"].ToString() ?? "[]") ?? new List<Education>(),
                ModeOfAdmission = reader["ModeOfAdmission"].ToString() ?? string.Empty,
                CandidateStatus = reader["CandidateStatus"].ToString() ?? string.Empty,
                IfEmployed_WorkingAt = reader["IfEmployed_WorkingAt"].ToString() ?? string.Empty,
                Declaration = reader["Declaration"] != DBNull.Value && Convert.ToBoolean(reader["Declaration"]),
                Place = reader["Place"].ToString() ?? string.Empty,
                ApplicationDate = reader["ApplicationDate"] != DBNull.Value ? Convert.ToDateTime(reader["ApplicationDate"]) : DateTime.MinValue,
                FilePath = reader["FilePath"].ToString() ?? string.Empty,
                FileNames = reader["FileNames"].ToString() ?? string.Empty,
                CreatedBy = reader["CreatedBy"].ToString() ?? string.Empty,
                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.MinValue,
                ModifiedBy = reader["ModifiedBy"].ToString(),
                ModifiedDate = reader["ModifiedDate"] != DBNull.Value ? Convert.ToDateTime(reader["ModifiedDate"]) : null
            };
        }
    }
}
