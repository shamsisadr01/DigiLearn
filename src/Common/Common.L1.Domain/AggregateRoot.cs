using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain
{
	public class AggregateRoot : BaseEntity
	{
		private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

		[NotMapped]
		public List<BaseDomainEvent> DomainEvents => _domainEvents;

		public void AddDomainEvent(BaseDomainEvent domainEvent)
		{
			_domainEvents.Add(domainEvent);
		}

		public void RemoveDomainEvent(BaseDomainEvent domainEvent)
		{
			_domainEvents?.Remove(domainEvent);
		}
	}
}
