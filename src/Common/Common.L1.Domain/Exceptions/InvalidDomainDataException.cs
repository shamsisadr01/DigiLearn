﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain.Exceptions
{
	public class InvalidDomainDataException : BaseDomainException
	{
		public InvalidDomainDataException()
		{

		}

		public InvalidDomainDataException(string message) : base(message)
		{

		}
	}
}