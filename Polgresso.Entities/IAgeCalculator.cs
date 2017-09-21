using System;

namespace Polgresso.Entities
{
    public interface IAgeCalculator
    {
        int Calculate(DateTime startDate);
    }
}