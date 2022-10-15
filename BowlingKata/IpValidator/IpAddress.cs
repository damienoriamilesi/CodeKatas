using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.IpValidator
{
    public class IpAddress
    {
        public bool ValidateIpv4Address(string IpAddress)
        {
            var groupsOfBytes = IpAddress.Split(".");
            if (groupsOfBytes.Length != 4) return false;

            if (new[] { "0", "255" }.Contains(groupsOfBytes.Last())) return false;

            return true;
        }
    }

    public class Sunday
    {
        public List<DateTime> GetAllItemsYearly(int year)
        {
            var daysCountInCurrentYear = DateTime.IsLeapYear(year);
            return null;
        }
    }
}
