namespace SRS_Game.Models.Srs
{
    public class SRS
    {
        public required string ProjectName { get; set; }
        public string? TeamNumber { get; set; } = string.Empty;
        public required int Version { get; set; }
        public string? Owner { get; set; }
        public required string Author { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Chapter 1. Introduction
        /// </summary>
        public string? Introduction { get; set; }
        
        /// <summary>
        /// Chapter 2. Requirements sources
        /// </summary>
        public List<Stakeholder> Stakeholders { get; set; } = [];
        public List<Personless> Personlesses { get; set; } = [];
        
        /// <summary>
        /// Chapter 3 - System purposes
        /// </summary>
        public List<BusinesPurpose> BusinesPurposes { get; set; } = [];
        public List<FunctionalityPurpose> FunctionalityPurposes { get; set; } = [];
        
        /// <summary>
        /// Chapter 4. System environment
        /// </summary>
        public List<SystemUser> SystemUsers { get; set; } = [];
        public List<ExternalSystem> ExternalSystems { get; set; } = [];
        
        /// <summary>
        /// Chapter 5. System components
        /// </summary>
        public List<SubSystem> SubSystems { get; set; } = [];
        public List<HardwareComponent> HardwareComponents { get; set; } = [];
        public List<SoftwareComponent> SoftwareComponents { get; set; } = [];

        /// <summary>
        /// Chapter 6. Funcionality requirements
        /// </summary>
        public List<FuncionalityRequirement> FuncionalityRequirements { get; set; } = [];
        
        /// <summary>
        /// Chapter 7. Data requirements
        /// </summary>
        public List<DataRequirement> DataRequirements { get; set; } = [];
        
        /// <summary>
        /// Chapter 8. Quality requirements
        /// </summary>
        public List<CredibilityRequirement> CredibilityRequirements { get; set; } = [];
        public List<PerformanceRequirement> PerformanceRequirements { get; set; } = [];
        public List<FlexibilityRequirement> FlexibilityRequirements { get; set; } = [];
        public List<UsabilityRequirement> UsabilityRequirements { get; set; } = [];
    
        /// <summary>
        /// Chapter 9. Emergancy situations
        /// </summary>
        public List<ExceptionScenario> Exceptions { get; set; } = [];
        public List<CriticalSituation> CriticalSituations  { get; set; } = [];
        public List<EmergancySituation> EmergancySituations  { get; set; } = [];

        /// <summary>
        /// Chapter 10. Additional requirements
        /// </summary>
        public List<HardwareRequirement> HardwareRequirements { get; set; } = [];
        public List<SoftwareRequirement> SoftwareRequirements { get; set; } = [];
        public List<OtherRequirement> OtherRequirements { get; set; } = [];

        /// <summary>
        /// Chapter 11. Acceptance criteria
        /// </summary>
        public List<AcceptanceCriteria> AcceptanceCriteria { get; set; } = [];

        /// <summary>
        /// Chapter 12. Dictionary
        /// </summary>
        public string? Dictionary { get; set; }

        /// <summary>
        /// Chapter 13. Attachements
        /// </summary>
        public List<SrsAttachement> Attachements { get; set; } = [];
    }
}
