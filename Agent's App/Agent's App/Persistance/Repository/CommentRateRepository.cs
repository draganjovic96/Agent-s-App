﻿using Agent_s_App.Core.Model;
using Agent_s_App.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Persistance.Repository
{
	public class CommentRateRepository : Repository<CommentRate>, ICommentRateRepository
	{
		public CommentRateRepository(AgentsAppContext context) : base(context)
		{
		}

		public AgentsAppContext AgentsAppContext
		{
			get { return Context as AgentsAppContext; }
		}
	}
}
