using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain.Exceptions
{
	public class SlugIsDuplicateException : BaseDomainException
	{
		public SlugIsDuplicateException() : base("اساگ تکراری است.") { }
		public SlugIsDuplicateException(string message) : base(message) { }


	}
}
