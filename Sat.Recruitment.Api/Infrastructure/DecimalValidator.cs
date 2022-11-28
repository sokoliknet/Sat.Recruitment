using System;

namespace Sat.Recruitment.Api.Infrastructure
{
    public static class DecimalValidator
    {
        public static bool IsDecimal(string value)
        {
            try
            {
                Decimal.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
