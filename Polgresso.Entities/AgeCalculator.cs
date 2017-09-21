using System;

namespace Polgresso.Entities
{
    public class AgeCalculator : IAgeCalculator
    {
        public int Calculate(DateTime startDate)
        {
            if (startDate == DateTime.MinValue)
            {
                throw new ArgumentException("A valid startDate is required.", "startDate");
            }

            int startMonth = startDate.Date.Month;
            int startDay = startDate.Date.Day;
            int startYear = startDate.Date.Year;

            DateTime todaysDate = DateTime.Now.Date;
            int currentMonth = todaysDate.Month;
            int currentDay = todaysDate.Day;
            int currentYear = todaysDate.Year;

            int age = todaysDate.Year - startDate.Year;

            if (currentMonth < startMonth || (currentMonth == startMonth && currentDay < startDay))
            {
                age = currentYear - (startYear + 1);
            }

            return age;
        }
    }
}