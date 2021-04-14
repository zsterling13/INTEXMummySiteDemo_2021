using Microsoft.EntityFrameworkCore.Migrations;

namespace INTEX2Mock.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BurialTable",
                columns: table => new
                {
                    bio_sample_ID = table.Column<int>(type: "int", nullable: false),
                    location_concat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Low_NS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    High_NS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Low_EW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    High_EW = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    EW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Burial_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cluster = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Date = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Previously_Sampled = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Notes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Initials = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    notes2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialTable", x => x.bio_sample_ID);
                });

            migrationBuilder.CreateTable(
                name: "c14Table",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    burial_location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rack = table.Column<int>(type: "int", nullable: true),
                    ns_low_par = table.Column<int>(type: "int", nullable: true),
                    NS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ew_low_pair = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EW = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Square = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Burial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rack2 = table.Column<int>(type: "int", nullable: true),
                    TUBE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size_ml = table.Column<int>(type: "int", nullable: true),
                    Foci = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    C14_Sample_2017 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Question_s = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    column19 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Conventional_14C_age_BP = table.Column<int>(type: "int", nullable: true),
                    _14C_Calendar_Date = table.Column<int>(type: "int", nullable: true),
                    Calibrated_95_Calendar_Date_MAX = table.Column<int>(type: "int", nullable: true),
                    Calibrated_95_Calendar_Date_MIN = table.Column<int>(type: "int", nullable: true),
                    Calibrated_95_Calendar_Date_SPAN = table.Column<int>(type: "int", nullable: true),
                    Calibrated_95_Calendar_Date_AVG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_c14Table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mainTable",
                columns: table => new
                {
                    Primary_key_ID = table.Column<int>(type: "int", nullable: false),
                    Burial_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    C14_id = table.Column<int>(type: "int", nullable: true),
                    sample_id = table.Column<int>(type: "int", nullable: true),
                    burial_location_NS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    burial_location_EW = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    low_pair_NS = table.Column<int>(type: "int", nullable: true),
                    high_pair_NS = table.Column<int>(type: "int", nullable: true),
                    low_pair_EW = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    high_pair_EW = table.Column<int>(type: "int", nullable: true),
                    burial_subplot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    burial_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    burial_depth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    field_book = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    field_book_page_num = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Initial_of_data_expert = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    initials_checker = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    body_analyze_year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    south_to_head = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    south_to_feet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    east_to_head = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    east_to_feet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    west_to_head = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    west_to_feet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    burial_situation = table.Column<string>(type: "nvarchar(1100)", maxLength: 1100, nullable: true),
                    length_of_remains = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sample_number = table.Column<int>(type: "int", nullable: true),
                    GE_function_total = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gender_body_col = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    how_gender_determined = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    basilar_suture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ventral_arc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    subpubic_angle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sciatic_notch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pubic_bone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    preaur_sulcus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    medial_IP_ramus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dorsal_pitting = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    foreman_magnum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    femur_head = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    humerus_head = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    osteophytosis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pubic_symphysis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bone_length = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    medial_clavicle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    iliac_crest = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    femur_diameter = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    humerus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    femur_length = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    humerus_length = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tibia_length = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    robust = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    supraorbital_ridges = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    orbit_edge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    parietal_bossing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gonian = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nuchal_crest = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    zygomatic_crest = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cranial_suture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maximum_cranial_length = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maximum_cranial_breadth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    basion_bregma_height = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    basion_nasion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    basion_prosthion_length = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bizygomatic_diameter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nasion_prosthion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maximum_nasal_breadth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    interorbital_breadth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    artifacts_description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    hair_color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    preservation_index = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    hair_taken = table.Column<bool>(type: "bit", nullable: true),
                    soft_tissue_taken = table.Column<bool>(type: "bit", nullable: true),
                    bone_taken = table.Column<bool>(type: "bit", nullable: true),
                    tooth_taken = table.Column<bool>(type: "bit", nullable: true),
                    textile_taken = table.Column<bool>(type: "bit", nullable: true),
                    description_of_taken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    artifact_found = table.Column<bool>(type: "bit", nullable: true),
                    age_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    estimate_age = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    age_classification = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    estimate_living_stature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tooth_attrition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tooth_eruption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pathology_anomalies = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    epiphyseal_union = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    year_found = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    month_found = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    day_found = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    head_direction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rack = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cribra_Orbitala = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Porotic_Hyperostosis = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Porotic_Hyperostosis_LOCATIONS = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Metopic_Suture = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Button_Osteoma = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Postcrania_Trauma = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Osteology_unknown_comment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Temporal_Mandibular_Joint_Osteoarthritis_TMJ_OA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Linear_Hypoplasia_Enamel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Area_Hill_burials = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Tomb = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Year_on_skull = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Month_on_skull = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_on_Skull = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cluster = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    shaft = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    shared_shaft = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    preservation_index2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    burial_materials = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    burial_goods = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    photo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainTable", x => x.Primary_key_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurialTable");

            migrationBuilder.DropTable(
                name: "c14Table");

            migrationBuilder.DropTable(
                name: "mainTable");
        }
    }
}
