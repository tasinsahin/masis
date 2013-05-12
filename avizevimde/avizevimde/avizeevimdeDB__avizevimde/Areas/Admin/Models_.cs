using System.Data.Entity;
using avizevimde.Areas.Admin.Models;
using avizevimde.Areas.Uretici.Models;
using avizevimde.Areas.Montajci.Models;
using avizevimde.Areas.Tuketici.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using avizevimde.Models;
using avizevimde.Areas.KisitliAdmin.Models;

namespace avizevimde.avizeevimdeDB__avizevimde.Areas.Admin
{
    public class Models_ : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 

        public Models_() : base("name=Models_")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<muzayedeTeklif> muzayedeTeklifs { get; set; } 
        public DbSet<muzayede> muzayedes { get; set; }
        public DbSet<UserProfileAdmin> UserProfiles { get; set; }

        public DbSet<kisitliAdminLog> kisitliAdminLogs { get; set; }

        public DbSet<adminLog> adminLogs {get;set;}

        public DbSet<logo> logos { get; set; }

        public DbSet<sehir> sehirs { get; set; }

        public DbSet<ilce> ilces { get; set; }

        public DbSet<mahalle> mahalles { get; set; }

        public DbSet<marka> markas { get; set; }

        public DbSet<banka> bankas { get; set; }

        public DbSet<bankaSube> bankaSubes { get; set; }

        public DbSet<kategori> kategoris { get; set; }

        public DbSet<blog> blogs { get; set; }

        public DbSet<banner> banners { get; set; }

        public DbSet<taksit> taksits { get; set; }

        public DbSet<carousel> carousels { get; set; }

        public DbSet<vergiDairesi> vergiDairesis { get; set; }

        public DbSet<ureticiLog> ureticiLogs { get; set; }

        public DbSet<uretici> ureticis { get; set; }

        public DbSet<montajciLog> montajciLogs { get; set; }

        public DbSet<montajci> montajcis { get; set; }

        public DbSet<tuketici> tuketicis { get; set; }

        public DbSet<tuketiciFatura> tuketiciFaturas { get; set; }

        public DbSet<tuketiciAdres> tuketiciAdres { get; set; }
        
        public DbSet<tuketiciBanka> tuketiciBankas { get; set; }

        public DbSet<ureticiBanka> ureticiBankas { get; set; }

        public DbSet<ureticiFatura> ureticiFaturas { get; set; }

        public DbSet<ureticiAdres> ureticiAress { get; set; }

        public DbSet<renk> renks { get; set; }

        public DbSet<vergi> vergis { get; set; }

        public DbSet<urun> uruns { get; set; }

        public DbSet<urun2> urun2s { get; set; }

        public DbSet<siparis> sipariss { get; set; }

        public DbSet<siparisListesi> siparisListesi { get; set; }

        public DbSet<sepet> sepets { get; set; }

        public DbSet<oda> odas { get; set; }

        public DbSet<tasimaSarti> tasimaSartis { get; set; }

        public DbSet<smsTuketici> smsTuketicis { get; set; }

        public DbSet<tasiyiciSube> tasiyiciSubes { get; set; }
         
        public DbSet<semt> semts { get; set; }

        public DbSet<MontajciBanka> MontajciBankas { get; set; }

        public DbSet<MontajciFatura> MontajciFaturas { get; set; }

        public DbSet<MontajciAdres> MontajciAdres { get; set; }

        public DbSet<altKategori> altKategoris { get; set; }

        public DbSet<smsUretici> smsUreticis { get; set; }

        public DbSet<smsMontajci> smsMontajcis { get; set; }

        //public DbSet<avizevimde.Areas.Admin.Models.UserProfile> UserProfiles { get; set; }

        public DbSet<avizevimde.Areas.Montajci.Models.UserProfileMontajci> UserProfilesMontajci { get; set; }

        public DbSet<avizevimde.Areas.Tuketici.Models.UserProfileTuketici> UserProfilesTuketici { get; set; }

        public DbSet<avizevimde.Areas.Uretici.Models.UserProfileUretici> UserProfilesUretici { get; set; }

        public DbSet<oneri> oneris { get; set; }

        public DbSet<yardim> yardims { get; set; }

        public DbSet<fiyatDuserse> fiyatDuserses { get; set; }

        public DbSet<stoktaOlursa> stoktaOlursas { get; set; }

        public DbSet<adminTuketiciyeIleti> adminTuketiciyeIletis { get; set; }

        public DbSet<adminUreticiyeIleti> adminUreticiyeIletis { get; set; }

        public DbSet<adminMontajciyaIleti> adminMontajciyaIletis { get; set; }

        public DbSet<montajciTuketiciyeIleti> montajciTuketiciyeIletis { get; set; }

        public DbSet<montajciAdmineIleti> montajciAdmineIletis { get; set; }

        public DbSet<ureticiTuketiciyeIleti> ureticiTuketiciyeIleti { get; set; }

        public DbSet<ureticiAdmineIleti> ureticiAdmineIletis { get; set; }

        public DbSet<tuketiciAdmineIleti> tuketiciAdmineIletis { get; set; }

        public DbSet<tuketiciMontajciyaIleti> tuketiciMontajciyaIletis { get; set; }

        public DbSet<tuketiciUreticiyeIleti> tuketiciUreticiyeIletis { get; set; }

        public DbSet<UserProfileKisitliAdmin> UserProfileKisitliAdmin { get; set; }

        public DbSet<soru> sorus { get; set; }
    } 
}
