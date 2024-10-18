using Common.L1.Domain.Exceptions;
using Common.L1.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; set; }

        public PhoneNumber(string value) 
        {
			if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
				throw new InvalidDomainDataException("شماره تلفن نامعتبر است");
			Value = value;
        }
    }
}
