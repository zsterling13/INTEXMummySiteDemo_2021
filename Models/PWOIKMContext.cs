using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace INTEX2Mock.Models
{
    public partial class PWOIKMContext : DbContext
    {
        public PWOIKMContext()
        {
        }

        public PWOIKMContext(DbContextOptions<PWOIKMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BurialTable> BurialTables { get; set; }
        public virtual DbSet<C14Table> C14Tables { get; set; }
        public virtual DbSet<MainTable> MainTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PWOIKM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BurialTable>(entity =>
            {
                entity.HasKey(e => e.BioSampleId);

                entity.ToTable("BurialTable");

                entity.Property(e => e.BioSampleId)
                    .ValueGeneratedNever()
                    .HasColumnName("bio_sample_ID");

                entity.Property(e => e.Area).HasColumnName("AREA");

                entity.Property(e => e.BurialNumber).HasColumnName("Burial_Number");

                entity.Property(e => e.Cluster).IsUnicode(false);

                entity.Property(e => e.Date).IsUnicode(false);

                entity.Property(e => e.Ew).HasColumnName("EW");

                entity.Property(e => e.HighEw)
                    .IsUnicode(false)
                    .HasColumnName("High_EW");

                entity.Property(e => e.HighNs).HasColumnName("High_NS");

                entity.Property(e => e.Initials).IsUnicode(false);

                entity.Property(e => e.LocationConcat).HasColumnName("location_concat");

                entity.Property(e => e.LowEw).HasColumnName("Low_EW");

                entity.Property(e => e.LowNs).HasColumnName("Low_NS");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Notes2)
                    .IsUnicode(false)
                    .HasColumnName("notes2");

                entity.Property(e => e.Ns).HasColumnName("NS");

                entity.Property(e => e.PreviouslySampled)
                    .IsUnicode(false)
                    .HasColumnName("Previously_Sampled");
            });

            modelBuilder.Entity<C14Table>(entity =>
            {
                entity.ToTable("c14Table");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .HasColumnName("AREA");

                entity.Property(e => e.Burial).HasMaxLength(50);

                entity.Property(e => e.BurialLocation)
                    .HasMaxLength(50)
                    .HasColumnName("burial_location");

                entity.Property(e => e.C14Sample2017)
                    .HasMaxLength(50)
                    .HasColumnName("C14_Sample_2017");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasMaxLength(50)
                    .HasColumnName("Calibrated_95_Calendar_Date_AVG");

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("Calibrated_95_Calendar_Date_MAX");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("Calibrated_95_Calendar_Date_MIN");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("Calibrated_95_Calendar_Date_SPAN");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Column19)
                    .HasMaxLength(50)
                    .HasColumnName("column19");

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("Conventional_14C_age_BP");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ew)
                    .HasMaxLength(50)
                    .HasColumnName("EW");

                entity.Property(e => e.EwLowPair)
                    .HasMaxLength(50)
                    .HasColumnName("ew_low_pair");

                entity.Property(e => e.Foci).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Notes).HasMaxLength(50);

                entity.Property(e => e.Ns)
                    .HasMaxLength(50)
                    .HasColumnName("NS");

                entity.Property(e => e.NsLowPar).HasColumnName("ns_low_par");

                entity.Property(e => e.QuestionS)
                    .HasMaxLength(150)
                    .HasColumnName("Question_s");

                entity.Property(e => e.SizeMl).HasColumnName("Size_ml");

                entity.Property(e => e.Square).HasMaxLength(50);

                entity.Property(e => e.Tube)
                    .HasMaxLength(50)
                    .HasColumnName("TUBE");

                entity.Property(e => e._14cCalendarDate).HasColumnName("_14C_Calendar_Date");
            });

            modelBuilder.Entity<MainTable>(entity =>
            {
                entity.HasKey(e => e.PrimaryKeyId);

                entity.ToTable("mainTable");

                entity.Property(e => e.PrimaryKeyId)
                    .ValueGeneratedNever()
                    .HasColumnName("Primary_key_ID");

                entity.Property(e => e.AgeClassification)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("age_classification");

                entity.Property(e => e.AgeMethod)
                    .HasMaxLength(50)
                    .HasColumnName("age_method");

                entity.Property(e => e.AreaHillBurials)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Area_Hill_burials");

                entity.Property(e => e.ArtifactFound).HasColumnName("artifact_found");

                entity.Property(e => e.ArtifactsDescription)
                    .HasMaxLength(150)
                    .HasColumnName("artifacts_description");

                entity.Property(e => e.BasilarSuture)
                    .HasMaxLength(50)
                    .HasColumnName("basilar_suture");

                entity.Property(e => e.BasionBregmaHeight)
                    .HasMaxLength(50)
                    .HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion)
                    .HasMaxLength(50)
                    .HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength)
                    .HasMaxLength(50)
                    .HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasMaxLength(50)
                    .HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BodyAnalyzeYear)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("body_analyze_year");

                entity.Property(e => e.BoneLength)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bone_length");

                entity.Property(e => e.BoneTaken).HasColumnName("bone_taken");

                entity.Property(e => e.BurialDepth)
                    .HasMaxLength(50)
                    .HasColumnName("burial_depth");

                entity.Property(e => e.BurialGoods)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("burial_goods");

                entity.Property(e => e.BurialId)
                    .HasMaxLength(50)
                    .HasColumnName("Burial_ID");

                entity.Property(e => e.BurialLocationEw)
                    .HasMaxLength(50)
                    .HasColumnName("burial_location_EW");

                entity.Property(e => e.BurialLocationNs)
                    .HasMaxLength(50)
                    .HasColumnName("burial_location_NS");

                entity.Property(e => e.BurialMaterials)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("burial_materials");

                entity.Property(e => e.BurialNumber)
                    .HasMaxLength(50)
                    .HasColumnName("burial_number");

                entity.Property(e => e.BurialSituation)
                    .HasMaxLength(1100)
                    .HasColumnName("burial_situation");

                entity.Property(e => e.BurialSubplot)
                    .HasMaxLength(50)
                    .HasColumnName("burial_subplot");

                entity.Property(e => e.ButtonOsteoma)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Button_Osteoma");

                entity.Property(e => e.C14Id).HasColumnName("C14_id");

                entity.Property(e => e.Cluster)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CranialSuture)
                    .HasMaxLength(50)
                    .HasColumnName("cranial_suture");

                entity.Property(e => e.CribraOrbitala)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cribra_Orbitala");

                entity.Property(e => e.DateOnSkull)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Date_on_Skull");

                entity.Property(e => e.DayFound)
                    .HasMaxLength(50)
                    .HasColumnName("day_found");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(100)
                    .HasColumnName("description_of_taken");

                entity.Property(e => e.DorsalPitting)
                    .HasMaxLength(50)
                    .HasColumnName("dorsal_pitting");

                entity.Property(e => e.EastToFeet)
                    .HasMaxLength(50)
                    .HasColumnName("east_to_feet");

                entity.Property(e => e.EastToHead)
                    .HasMaxLength(50)
                    .HasColumnName("east_to_head");

                entity.Property(e => e.EpiphysealUnion)
                    .HasMaxLength(50)
                    .HasColumnName("epiphyseal_union");

                entity.Property(e => e.EstimateAge)
                    .HasMaxLength(50)
                    .HasColumnName("estimate_age");

                entity.Property(e => e.EstimateLivingStature)
                    .HasMaxLength(50)
                    .HasColumnName("estimate_living_stature");

                entity.Property(e => e.FemurDiameter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("femur_diameter");

                entity.Property(e => e.FemurHead)
                    .HasMaxLength(50)
                    .HasColumnName("femur_head");

                entity.Property(e => e.FemurLength)
                    .HasMaxLength(50)
                    .HasColumnName("femur_length");

                entity.Property(e => e.FieldBook)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("field_book");

                entity.Property(e => e.FieldBookPageNum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("field_book_page_num");

                entity.Property(e => e.ForemanMagnum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("foreman_magnum");

                entity.Property(e => e.GeFunctionTotal)
                    .HasMaxLength(50)
                    .HasColumnName("GE_function_total");

                entity.Property(e => e.GenderBodyCol)
                    .HasMaxLength(50)
                    .HasColumnName("gender_body_col");

                entity.Property(e => e.Gonian)
                    .HasMaxLength(50)
                    .HasColumnName("gonian");

                entity.Property(e => e.HairColor)
                    .HasMaxLength(50)
                    .HasColumnName("hair_color");

                entity.Property(e => e.HairTaken).HasColumnName("hair_taken");

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(50)
                    .HasColumnName("head_direction");

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_EW");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_NS");

                entity.Property(e => e.HowGenderDetermined)
                    .HasMaxLength(50)
                    .HasColumnName("how_gender_determined");

                entity.Property(e => e.Humerus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("humerus");

                entity.Property(e => e.HumerusHead)
                    .HasMaxLength(50)
                    .HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength)
                    .HasMaxLength(50)
                    .HasColumnName("humerus_length");

                entity.Property(e => e.IliacCrest)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("iliac_crest");

                entity.Property(e => e.InitialOfDataExpert)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Initial_of_data_expert");

                entity.Property(e => e.InitialsChecker)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("initials_checker");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasMaxLength(50)
                    .HasColumnName("interorbital_breadth");

                entity.Property(e => e.LengthOfRemains)
                    .HasMaxLength(50)
                    .HasColumnName("length_of_remains");

                entity.Property(e => e.LinearHypoplasiaEnamel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Linear_Hypoplasia_Enamel");

                entity.Property(e => e.LowPairEw)
                    .HasMaxLength(50)
                    .HasColumnName("low_pair_EW");

                entity.Property(e => e.LowPairNs).HasColumnName("low_pair_NS");

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasMaxLength(50)
                    .HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength)
                    .HasMaxLength(50)
                    .HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasMaxLength(50)
                    .HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialClavicle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("medial_clavicle");

                entity.Property(e => e.MedialIpRamus)
                    .HasMaxLength(50)
                    .HasColumnName("medial_IP_ramus");

                entity.Property(e => e.MetopicSuture)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Metopic_Suture");

                entity.Property(e => e.MonthFound)
                    .HasMaxLength(50)
                    .HasColumnName("month_found");

                entity.Property(e => e.MonthOnSkull)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Month_on_skull");

                entity.Property(e => e.NasionProsthion)
                    .HasMaxLength(50)
                    .HasColumnName("nasion_prosthion");

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NuchalCrest)
                    .HasMaxLength(50)
                    .HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge)
                    .HasMaxLength(50)
                    .HasColumnName("orbit_edge");

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Osteology_unknown_comment");

                entity.Property(e => e.Osteophytosis)
                    .HasMaxLength(50)
                    .HasColumnName("osteophytosis");

                entity.Property(e => e.ParietalBossing)
                    .HasMaxLength(50)
                    .HasColumnName("parietal_bossing");

                entity.Property(e => e.PathologyAnomalies)
                    .HasMaxLength(200)
                    .HasColumnName("pathology_anomalies");

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.PoroticHyperostosis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Porotic_Hyperostosis");

                entity.Property(e => e.PoroticHyperostosisLocations)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Porotic_Hyperostosis_LOCATIONS");

                entity.Property(e => e.PostcraniaTrauma)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Postcrania_Trauma");

                entity.Property(e => e.PreaurSulcus)
                    .HasMaxLength(50)
                    .HasColumnName("preaur_sulcus");

                entity.Property(e => e.PreservationIndex)
                    .HasMaxLength(50)
                    .HasColumnName("preservation_index");

                entity.Property(e => e.PreservationIndex2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("preservation_index2");

                entity.Property(e => e.PubicBone)
                    .HasMaxLength(50)
                    .HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis)
                    .HasMaxLength(50)
                    .HasColumnName("pubic_symphysis");

                entity.Property(e => e.Rack)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rack");

                entity.Property(e => e.Robust)
                    .HasMaxLength(50)
                    .HasColumnName("robust");

                entity.Property(e => e.SampleId).HasColumnName("sample_id");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.SciaticNotch)
                    .HasMaxLength(50)
                    .HasColumnName("sciatic_notch");

                entity.Property(e => e.Shaft)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shaft");

                entity.Property(e => e.SharedShaft)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shared_shaft");

                entity.Property(e => e.SoftTissueTaken).HasColumnName("soft_tissue_taken");

                entity.Property(e => e.SouthToFeet)
                    .HasMaxLength(50)
                    .HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("south_to_head");

                entity.Property(e => e.SubpubicAngle)
                    .HasMaxLength(50)
                    .HasColumnName("subpubic_angle");

                entity.Property(e => e.SupraorbitalRidges)
                    .HasMaxLength(50)
                    .HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritisTmjOa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Temporal_Mandibular_Joint_Osteoarthritis_TMJ_OA");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.TibiaLength)
                    .HasMaxLength(50)
                    .HasColumnName("tibia_length");

                entity.Property(e => e.Tomb)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToothAttrition)
                    .HasMaxLength(50)
                    .HasColumnName("tooth_attrition");

                entity.Property(e => e.ToothEruption)
                    .HasMaxLength(50)
                    .HasColumnName("tooth_eruption");

                entity.Property(e => e.ToothTaken).HasColumnName("tooth_taken");

                entity.Property(e => e.VentralArc)
                    .HasMaxLength(50)
                    .HasColumnName("ventral_arc");

                entity.Property(e => e.WestToFeet)
                    .HasMaxLength(50)
                    .HasColumnName("west_to_feet");

                entity.Property(e => e.WestToHead)
                    .HasMaxLength(50)
                    .HasColumnName("west_to_head");

                entity.Property(e => e.YearFound)
                    .HasMaxLength(50)
                    .HasColumnName("year_found");

                entity.Property(e => e.YearOnSkull)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Year_on_skull");

                entity.Property(e => e.ZygomaticCrest)
                    .HasMaxLength(50)
                    .HasColumnName("zygomatic_crest");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
