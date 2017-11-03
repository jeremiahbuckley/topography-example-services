﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvcInterfaces
{
	public class Comment
	{
		public int Id { get; set; }
		public int TopicId { get; set; }
		public int ThreadId { get; set; }
		public int UserId { get; set; }
		public int? ReplyToCommentId { get; set; }
		public string CommentStr { get; set; }
		public DateTime DateTimeAdded { get; set; }

		public Comment ReplyToComment { get; set; }
		public Thread Thread { get; set; }
		public Topic Topic { get; set; }
		public User User { get; set; }
	}

	public class Thread
	{
		public int Id { get; set; }
		public int TopicId { get; set; }
		public string Name { get; set; }
		public bool Enabled { get; set; }
		public bool Pinned { get; set; }
		public int? PinOrder { get; set; }

		public Dictionary<int, Comment> Comments {get; set;}
		public Thread Topic { get; set; }
	}

	public class Topic
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Enabled { get; set; }
		
		public Dictionary<int, Thread> Threads { get; set; }
	}

	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Enabled { get; set; }
		public DateTime DateTimeJoined { get; set; }

		public Dictionary<int, Comment> Comments { get; set; }
	}
}