using System;

namespace Common.L2.Application.Validation
{
	public class InvalidCommandException : Exception
	{
		public string Details { get; }
		public InvalidCommandException()
		{

		}
		public InvalidCommandException(string message) : base(message)
		{

		}
		public InvalidCommandException(string message, string details) : base(message)
		{
			Details = details;
		}
	}
}