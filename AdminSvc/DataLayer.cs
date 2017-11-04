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

		#region Topic
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

			var results = new List<Topic>();
			using (var reader = db.ExecuteReader(cmd))
			{
				while (reader.Read())
				{
					var result = new Topic();
					result.Id = reader.GetInt32(reader.GetOrdinal("Id"));
					result.Name = reader.GetString(reader.GetOrdinal("Name"));
					result.Enabled = reader.GetBoolean(reader.GetOrdinal("Enabled"));
					result.Version = (byte[])reader.GetValue(reader.GetOrdinal("Version"));
					results.Add(result);
				}
			}

			return results;
		}

		public IList<Topic> TopicReadAll()
		{
			return TopicRead(null);
		}

		public int TopicUpdate(int id, byte[] version, string name, bool enabled)
		{
			var cmd = db.GetStoredProcCommand("Topic_Update");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			cmd.Parameters["@version"].Value = version;
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
		#endregion

		#region Thread
		public int ThreadCreate(string name, int topicId, bool enabled, bool pinned, int? pinOrder)
		{
			var cmd = db.GetStoredProcCommand("Thread_Insert");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@name"].Value = name;
			cmd.Parameters["@pinned"].Value = pinned;
			cmd.Parameters["@topicid"].Value = topicId;
			cmd.Parameters["@enabled"].Value = enabled;
			
			if (pinOrder.HasValue)
			{
				cmd.Parameters["@pinorder"].Value = pinOrder;
			}

			var id = (int)db.ExecuteScalar(cmd);

			return id;
		}

		public IList<Thread> ThreadRead(int? id)
		{
			var cmd = db.GetStoredProcCommand("Thread_Select");
			db.DiscoverParameters(cmd);
			if (id.HasValue)
			{
				cmd.Parameters["@id"].Value = id.Value;
			}

			var results = new List<Thread>();
			using (var reader = db.ExecuteReader(cmd))
			{
				while (reader.Read())
				{
					var result = new Thread();
					result.Id = reader.GetInt32(reader.GetOrdinal("Id"));
					result.Name = reader.GetString(reader.GetOrdinal("Name"));
					result.Enabled = reader.GetBoolean(reader.GetOrdinal("Enabled"));
					result.Pinned = reader.GetBoolean(reader.GetOrdinal("Pinned"));
					if (!reader.IsDBNull(reader.GetOrdinal("PinOrder")))
					{
						result.PinOrder = reader.GetInt32(reader.GetOrdinal("PinOrder"));
					}
					result.Version = (byte[])reader.GetValue(reader.GetOrdinal("Version"));
					results.Add(result);
				}
			}

			return results;
		}

		public IList<Thread> ThreadReadAll()
		{
			return ThreadRead(null);
		}

		public int ThreadUpdate(int id, byte[] version, string name, int topicId, bool enabled, bool pinned, int? pinOrder)
		{
			var cmd = db.GetStoredProcCommand("Thread_Update");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			cmd.Parameters["@version"].Value = version;
			cmd.Parameters["@name"].Value = name;
			cmd.Parameters["@pinned"].Value = pinned;
			cmd.Parameters["@topicid"].Value = topicId;
			cmd.Parameters["@enabled"].Value = enabled;
			if (pinOrder.HasValue)
			{
				cmd.Parameters["@pinorder"].Value = pinOrder;
			}

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

		public void ThreadDelete(int id)
		{
			var cmd = db.GetStoredProcCommand("Thread_Delete");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			db.ExecuteNonQuery(cmd);
		}
		#endregion

		#region User
		public int UserCreate(string name, bool enabled)
		{
			var cmd = db.GetStoredProcCommand("User_Insert");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@name"].Value = name;
			cmd.Parameters["@enabled"].Value = enabled;

			var id = (int)db.ExecuteScalar(cmd);

			return id;
		}

		public IList<User> UserRead(int? id)
		{
			var cmd = db.GetStoredProcCommand("User_Select");
			db.DiscoverParameters(cmd);
			if (id.HasValue)
			{
				cmd.Parameters["@id"].Value = id.Value;
			}

			var results = new List<User>();
			using (var reader = db.ExecuteReader(cmd))
			{
				while (reader.Read())
				{
					var result = new User();
					result.Id = reader.GetInt32(reader.GetOrdinal("Id"));
					result.Name = reader.GetString(reader.GetOrdinal("Name"));
					result.Enabled = reader.GetBoolean(reader.GetOrdinal("Enabled"));
					result.DateTimeJoined = reader.GetDateTime(reader.GetOrdinal("DateTimeJoined"));
					result.Version = (byte[])reader.GetValue(reader.GetOrdinal("Version"));
					results.Add(result);
				}
			}

			return results;
		}

		public IList<User> UserReadAll()
		{
			return UserRead(null);
		}

		public int UserUpdate(int id, byte[] version, string name, bool enabled)
		{
			var cmd = db.GetStoredProcCommand("User_Update");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			cmd.Parameters["@version"].Value = version;
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

		public void UserDelete(int id)
		{
			var cmd = db.GetStoredProcCommand("User_Delete");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			db.ExecuteNonQuery(cmd);
		}
		#endregion

		#region Comment
		public int CommentCreate(int topicId, int threadId, int userId, string comment, int? replyToCommentId)
		{
			var cmd = db.GetStoredProcCommand("Comment_Insert");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@topicid"].Value = topicId;
			cmd.Parameters["@threadid"].Value = threadId;
			cmd.Parameters["@userid"].Value = userId;
			cmd.Parameters["@comment"].Value = comment;
			if (replyToCommentId.HasValue)
			{
				cmd.Parameters["@replytocommentid"].Value = replyToCommentId;
			}

			var id = (int)db.ExecuteScalar(cmd);

			return id;
		}

		public IList<Comment> CommentRead(int? id)
		{
			var cmd = db.GetStoredProcCommand("Comment_Select");
			db.DiscoverParameters(cmd);
			if (id.HasValue)
			{
				cmd.Parameters["@id"].Value = id.Value;
			}

			var results = new List<Comment>();
			using (var reader = db.ExecuteReader(cmd))
			{
				while (reader.Read())
				{
					var result = new Comment();
					result.Id = reader.GetInt32(reader.GetOrdinal("Id"));
					result.TopicId = reader.GetInt32(reader.GetOrdinal("TopicId"));
					result.ThreadId = reader.GetInt32(reader.GetOrdinal("ThreadId"));
					result.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
					if (!reader.IsDBNull(reader.GetOrdinal("ReplyToCommentId")))
					{
						result.ReplyToCommentId = reader.GetInt32(reader.GetOrdinal("ReplyToCommentId"));
					}
					result.CommentStr = reader.GetString(reader.GetOrdinal("Comment"));
					result.DateTimeAdded = reader.GetDateTime(reader.GetOrdinal("DateTimeAdded"));
					result.Version = (byte[])reader.GetValue(reader.GetOrdinal("Version"));
					results.Add(result);
				}
			}

			return results;
		}

		public IList<Comment> CommentReadAll()
		{
			return CommentRead(null);
		}

		public int CommentUpdate(int id, byte[] version, int topicId, int threadId, int userId, string comment, int? replyToCommentId)
		{
			var cmd = db.GetStoredProcCommand("Comment_Update");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			cmd.Parameters["@version"].Value = version;
			cmd.Parameters["@topicid"].Value = topicId;
			cmd.Parameters["@threadid"].Value = threadId;
			cmd.Parameters["@userid"].Value = userId;
			cmd.Parameters["@comment"].Value = comment;
			if (replyToCommentId.HasValue)
			{
				cmd.Parameters["@replytocommentid"].Value = replyToCommentId;
			}

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

		public void CommentDelete(int id)
		{
			var cmd = db.GetStoredProcCommand("Comment_Delete");
			db.DiscoverParameters(cmd);
			cmd.Parameters["@id"].Value = id;
			db.ExecuteNonQuery(cmd);
		}
		#endregion
	}
}
