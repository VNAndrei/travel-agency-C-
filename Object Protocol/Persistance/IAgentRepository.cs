﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorC
{
	public interface IAgentRepository
	{
		Agent findByUser(string user);
	}
}