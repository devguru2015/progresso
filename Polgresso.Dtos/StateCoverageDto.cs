namespace Polgresso.Dtos
{
    public class StateCoverageDto
    {
        public int Id { get; set; }

        public int CoverageId { get; set; }

        public string StateAbbreviation { get; set; }

        public string CoverageName { get; set; }

        public decimal? PerPersonLimit { get; set; }

        public decimal? PerAccidentLimit { get; set; }

        public decimal? Deductible { get; set; }

        public bool IsRequired { get; set; }
    }
}