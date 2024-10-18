using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.L1.Domain
{
	public class BaseDomainEvent : INotification
	{
		public DateTime CreationDate { get; protected set; }

		public BaseDomainEvent()
		{
			CreationDate = DateTime.Now;
		}
	}
}
