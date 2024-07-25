using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database.Configuration;

namespace SimpleCliniq.Module.Core.Infrastructure.Database;

public partial class SimpleCliniqCoreContext : DbContext
{

    public SimpleCliniqCoreContext(DbContextOptions<SimpleCliniqCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MAntrianCounter> MAntrianCounter { get; set; }

    public virtual DbSet<MAntrianCounterAudio> MAntrianCounterAudio { get; set; }

    public virtual DbSet<MAntrianLayanan> MAntrianLayanan { get; set; }

    public virtual DbSet<MAntrianLokasi> MAntrianLokasi { get; set; }

    public virtual DbSet<MAsal> MAsal { get; set; }

    public virtual DbSet<MAsalGroup> MAsalGroup { get; set; }

    public virtual DbSet<MAturanPakai> MAturanPakai { get; set; }

    public virtual DbSet<MBank> MBank { get; set; }

    public virtual DbSet<MBarang> MBarang { get; set; }

    public virtual DbSet<MBarangAturanpakai> MBarangAturanpakai { get; set; }

    public virtual DbSet<MCoa> MCoa { get; set; }

    public virtual DbSet<MCoaGolongan> MCoaGolongan { get; set; }

    public virtual DbSet<MCoaKlasifikasi> MCoaKlasifikasi { get; set; }

    public virtual DbSet<MCoaSubKlasifikasi> MCoaSubKlasifikasi { get; set; }

    public virtual DbSet<MCountTraffic> MCountTraffic { get; set; }

    public virtual DbSet<MDepartment> MDepartment { get; set; }

    public virtual DbSet<MDiagnosa> MDiagnosa { get; set; }

    public virtual DbSet<MDiagnosaMatrix> MDiagnosaMatrix { get; set; }

    public virtual DbSet<MDokter> MDokter { get; set; }

    public virtual DbSet<MDokterHonor> MDokterHonor { get; set; }

    public virtual DbSet<MDokterNote> MDokterNote { get; set; }

    public virtual DbSet<MDtd> MDtd { get; set; }

    public virtual DbSet<MFarmakoterapi> MFarmakoterapi { get; set; }

    public virtual DbSet<MFarmakoterapiSub> MFarmakoterapiSub { get; set; }

    public virtual DbSet<MGizi> MGizi { get; set; }

    public virtual DbSet<MGudang> MGudang { get; set; }

    public virtual DbSet<MHargaBarang> MHargaBarang { get; set; }

    public virtual DbSet<MHargaRekanan> MHargaRekanan { get; set; }

    public virtual DbSet<MHargakamar> MHargakamar { get; set; }

    public virtual DbSet<MJadwalDokter> MJadwalDokter { get; set; }

    public virtual DbSet<MKamarinap> MKamarinap { get; set; }

    public virtual DbSet<MKamarinapHarga> MKamarinapHarga { get; set; }

    public virtual DbSet<MKamarinapRekanan> MKamarinapRekanan { get; set; }

    public virtual DbSet<MKelompokBarang> MKelompokBarang { get; set; }

    public virtual DbSet<MKodepos> MKodepos { get; set; }

    public virtual DbSet<MLaboratorium> MLaboratorium { get; set; }

    public virtual DbSet<MLaboratoriumGroup> MLaboratoriumGroup { get; set; }

    public virtual DbSet<MLaboratoriumHarga> MLaboratoriumHarga { get; set; }

    public virtual DbSet<MLaboratoriumRekanan> MLaboratoriumRekanan { get; set; }

    public virtual DbSet<MMap> MMap { get; set; }

    public virtual DbSet<MMasterPaketH> MMasterPaketH { get; set; }

    public virtual DbSet<MMasterTnd> MMasterTnd { get; set; }

    public virtual DbSet<MModule> MModule { get; set; }

    public virtual DbSet<MModuleDetail> MModuleDetail { get; set; }

    public virtual DbSet<MMorfologi> MMorfologi { get; set; }

    public virtual DbSet<MObatUnit> MObatUnit { get; set; }

    public virtual DbSet<MPaketDetail> MPaketDetail { get; set; }

    public virtual DbSet<MPaketHarga> MPaketHarga { get; set; }

    public virtual DbSet<MPaketHargaBaru> MPaketHargaBaru { get; set; }

    public virtual DbSet<MPaketMatrix> MPaketMatrix { get; set; }

    public virtual DbSet<MPaketRekanan> MPaketRekanan { get; set; }

    public virtual DbSet<MPasien> MPasien { get; set; }

    public virtual DbSet<MPemeriksaanPenunjang> MPemeriksaanPenunjang { get; set; }

    public virtual DbSet<MPemeriksaanPenunjangDetail> MPemeriksaanPenunjangDetail { get; set; }

    public virtual DbSet<MRadiologi> MRadiologi { get; set; }

    public virtual DbSet<MRadiologiGroup> MRadiologiGroup { get; set; }

    public virtual DbSet<MRadiologiHarga> MRadiologiHarga { get; set; }

    public virtual DbSet<MRadiologiRekanan> MRadiologiRekanan { get; set; }

    public virtual DbSet<MRekanan> MRekanan { get; set; }

    public virtual DbSet<MRuang> MRuang { get; set; }

    public virtual DbSet<MSettingAdm> MSettingAdm { get; set; }

    public virtual DbSet<MSettingBayar> MSettingBayar { get; set; }

    public virtual DbSet<MSettingDaftar> MSettingDaftar { get; set; }

    public virtual DbSet<MSettingKomputerAntrian> MSettingKomputerAntrian { get; set; }

    public virtual DbSet<MSettingPemeriksaan> MSettingPemeriksaan { get; set; }

    public virtual DbSet<MSmf> MSmf { get; set; }

    public virtual DbSet<MStandartfield> MStandartfield { get; set; }

    public virtual DbSet<MStandartfieldGroup> MStandartfieldGroup { get; set; }

    public virtual DbSet<MStatus> MStatus { get; set; }

    public virtual DbSet<MSupplier> MSupplier { get; set; }

    public virtual DbSet<MTarifDetail> MTarifDetail { get; set; }

    public virtual DbSet<MTarifGroup> MTarifGroup { get; set; }

    public virtual DbSet<MTarifHarga> MTarifHarga { get; set; }

    public virtual DbSet<MTarifMatrix> MTarifMatrix { get; set; }

    public virtual DbSet<MTarifNonMedis> MTarifNonMedis { get; set; }

    public virtual DbSet<MTarifPelayanan> MTarifPelayanan { get; set; }

    public virtual DbSet<MTarifRekanan> MTarifRekanan { get; set; }

    public virtual DbSet<MTarifRekananSub> MTarifRekananSub { get; set; }

    public virtual DbSet<MTarifnonmedisGroup> MTarifnonmedisGroup { get; set; }

    public virtual DbSet<MTarifnonmedisHarga> MTarifnonmedisHarga { get; set; }

    public virtual DbSet<MTarifnonmedisMatrix> MTarifnonmedisMatrix { get; set; }

    public virtual DbSet<MTarifnonmedisRekanan> MTarifnonmedisRekanan { get; set; }

    public virtual DbSet<MTennant> MTennant { get; set; }

    public virtual DbSet<MTindakan> MTindakan { get; set; }

    public virtual DbSet<MUser> MUser { get; set; }

    public virtual DbSet<MUserGroup> MUserGroup { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        builder.ModelConfiguration(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}