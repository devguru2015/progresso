namespace Polgresso.Dtos
{
    public class ApplicationDto
    {
        public ApplicationStage ApplicationStage { get; set; }

        public int Id { get; set; }

        public string StateAbbreviation { get; set; }

        public NamedInsuredDto NameInsured { get; set; }


    }

    public enum ApplicationStage
    {
        NamedInsured,
        Drivers,
        Vehicles,
        Coverages,
        Preview
    }
}