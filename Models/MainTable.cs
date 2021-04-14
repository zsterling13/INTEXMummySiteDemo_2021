using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace INTEX2Mock.Models
{
    public partial class MainTable
    {
        [Key]
        public int? PrimaryKeyId { get; set; }
        public string BurialId { get; set; }
        public int? C14Id { get; set; }
        public int? SampleId { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }
        public int? LowPairNs { get; set; }
        public int? HighPairNs { get; set; }
        public string LowPairEw { get; set; }
        public int? HighPairEw { get; set; }
        public string BurialSubplot { get; set; }
        public string BurialNumber { get; set; }
        public string BurialDepth { get; set; }
        public string FieldBook { get; set; }
        public string FieldBookPageNum { get; set; }
        public string InitialOfDataExpert { get; set; }
        public string InitialsChecker { get; set; }
        public string BodyAnalyzeYear { get; set; }
        public string SouthToHead { get; set; }
        public string SouthToFeet { get; set; }
        public string EastToHead { get; set; }
        public string EastToFeet { get; set; }
        public string WestToHead { get; set; }
        public string WestToFeet { get; set; }
        public string BurialSituation { get; set; }
        public string LengthOfRemains { get; set; }
        public int? SampleNumber { get; set; }
        public string GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string HowGenderDetermined { get; set; }
        public string BasilarSuture { get; set; }
        public string VentralArc { get; set; }
        public string SubpubicAngle { get; set; }
        public string SciaticNotch { get; set; }
        public string PubicBone { get; set; }
        public string PreaurSulcus { get; set; }
        public string MedialIpRamus { get; set; }
        public string DorsalPitting { get; set; }
        public string ForemanMagnum { get; set; }
        public string FemurHead { get; set; }
        public string HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public string BoneLength { get; set; }
        public string MedialClavicle { get; set; }
        public string IliacCrest { get; set; }
        public string FemurDiameter { get; set; }
        public string Humerus { get; set; }
        public string FemurLength { get; set; }
        public string HumerusLength { get; set; }
        public string TibiaLength { get; set; }
        public string Robust { get; set; }
        public string SupraorbitalRidges { get; set; }
        public string OrbitEdge { get; set; }
        public string ParietalBossing { get; set; }
        public string Gonian { get; set; }
        public string NuchalCrest { get; set; }
        public string ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public string MaximumCranialLength { get; set; }
        public string MaximumCranialBreadth { get; set; }
        public string BasionBregmaHeight { get; set; }
        public string BasionNasion { get; set; }
        public string BasionProsthionLength { get; set; }
        public string BizygomaticDiameter { get; set; }
        public string NasionProsthion { get; set; }
        public string MaximumNasalBreadth { get; set; }
        public string InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool? ArtifactFound { get; set; }
        public string AgeMethod { get; set; }
        public string EstimateAge { get; set; }
        public string AgeClassification { get; set; }
        public string EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public string YearFound { get; set; }
        public string MonthFound { get; set; }
        public string DayFound { get; set; }
        public string HeadDirection { get; set; }
        public string Rack { get; set; }
        public string CribraOrbitala { get; set; }
        public string PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public string MetopicSuture { get; set; }
        public string ButtonOsteoma { get; set; }
        public string PostcraniaTrauma { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public string TemporalMandibularJointOsteoarthritisTmjOa { get; set; }
        public string LinearHypoplasiaEnamel { get; set; }
        public string AreaHillBurials { get; set; }
        public string Tomb { get; set; }
        public string YearOnSkull { get; set; }
        public string MonthOnSkull { get; set; }
        public string DateOnSkull { get; set; }
        public string Cluster { get; set; }
        public string Notes { get; set; }
        public string Shaft { get; set; }
        public string SharedShaft { get; set; }
        public string PreservationIndex2 { get; set; }
        public string BurialMaterials { get; set; }
        public string BurialGoods { get; set; }
        public string Photo { get; set; }
    }
}
