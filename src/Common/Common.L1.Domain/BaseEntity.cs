using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain
{
	public class BaseEntity
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get;  set; }

		public DateTime CreationDate { get;  set; }

		public BaseEntity()
		{
			Id = Guid.NewGuid();
			CreationDate = DateTime.Now;
		}
	}
}
