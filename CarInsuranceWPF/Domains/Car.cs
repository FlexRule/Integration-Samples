namespace FlexRule.Samples.CarInsuranceApplication
{
    internal class Car
    {
        public string Model { get; set; }

        public decimal Price { get; set; }

        public decimal BasePremium { get; set; }

        public decimal AutoPremium { get; set; }

        public CarStyle Style { get; set; }

        public int ModelYear { get; set; }

        public bool HasRollBar { get; set; }

        public bool Convertible { get; set; }

        public int Age { get; set; }

        public bool HasMedicalCoverage { get; set; }

        public bool UninsuredMotoristCoverage { get; set; }

        public PotentialOccupantInjuryCategoy OccupantInjuryCategory { get; set; }

        public PotentialTheftCategory TheftCategory { get; set; }

        public AirbagType Airbags { get; set; }

        public string Made { get; set; }
    }
}