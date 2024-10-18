﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain.Exceptions
{
	public class BaseDomainException : Exception
	{
		public BaseDomainException()
		{

		}

		public BaseDomainException(string message) : base(message)
		{

		}
	}
}
