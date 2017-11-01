using SvcInterfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSvc
{
	public class DataLayer
	{
		private SqlDatabase db;

		public DataLayer()
		{
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var csSection = config.ConnectionStrings;
			var connStr = csSection.ConnectionStrings["DevConnecton"].ToString();
			db = new SqlDatabase(connStr);
		}

		public int TopicCreate(string name, bool enabled)
		{
			var cmd = db.GetStoredProcCommand("Topic_Insert");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@name"].Value = name;
			cmd.Parameters["@enabled"].Value = enabled;

			var id = (int)db.ExecuteScalar(cmd);

			return id;
		}

		public IList<Topic> TopicRead(int? id)
		{
			var cmd = db.GetStoredProcCommand("Topic_Select");
			db.DiscoverParameters(cmd);
			if (id.HasValue)
			{
				cmd.Parameters["@id"].Value = id.Value;
			}

			var topics = new List<Topic>();
			using (var reader = db.ExecuteReader(cmd))
			{
				while (reader.Read())
				{
					Topic t = new Topic();
					t.Id = reader.GetInt32(reader.GetOrdinal("Id"));
					t.Name = reader.GetString(reader.GetOrdinal("Name"));
					t.Enabled = reader.GetBoolean(reader.GetOrdinal("Enabled"));
					topics.Add(t);
				}
			}

			return topics;
		}

		public IList<Topic> TopicReadAll()
		{
			return TopicRead(null);
		}

		public int TopicUpdate(int id, string name, bool enabled)
		{
			var cmd = db.GetStoredProcCommand("Topic_Update");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			cmd.Parameters["@name"].Value = name;
			cmd.Parameters["@enabled"].Value = enabled;

			int updateId = -1;
			using (var reader = db.ExecuteReader(cmd))
			{
				while (reader.Read())
				{
					id = reader.GetInt32(reader.GetOrdinal("Id"));
				}
			}

			return updateId;
		}

		public void TopicDelete(int id)
		{
			var cmd = db.GetStoredProcCommand("Topic_Delete");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			db.ExecuteNonQuery(cmd);
		}

	}
}
