namespace SimpleCliniq.Module.Core.Infrastructure.Database.Configuration;

using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Models;

/// <summary>
/// Defines the <see cref="builder" />
/// </summary>
internal static class builder
{
    /// <summary>
    /// The ModelConfiguration
    /// </summary>
    /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>

    public static void ModelConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MAntrianCounter>(entity =>
        {
            entity.HasKey(e => e.IdCounter);

            entity.ToTable("M_AntrianCounter");

            entity.HasIndex(e => e.IdCounter, "IX_M_AntrianCounter_idcounter");

            entity.HasIndex(e => e.IsAktif, "IX_M_AntrianCounter_isaktif");

            entity.HasIndex(e => e.Kdcounter, "IX_M_AntrianCounter_vkdcounter");

            entity.HasIndex(e => e.Counter, "IX_M_AntrianCounter_vnmcounter");

            entity.Property(e => e.Counter)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kdcounter)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Kdlayanan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Kdlokasi)
                .IsRequired()
                .HasMaxLength(5);
        });

        modelBuilder.Entity<MAntrianCounterAudio>(entity =>
        {
            entity.HasKey(e => e.IdCounterAudio);

            entity.ToTable("M_AntrianCounterAudio");

            entity.HasIndex(e => e.KdLayanan, "IX_M_AntrianCounterAudio__kdlayanan");

            entity.HasIndex(e => e.KdLokasi, "IX_M_AntrianCounterAudio__kdlokasi");

            entity.HasIndex(e => e.Counter, "IX_M_AntrianCounterAudio_counter");

            entity.HasIndex(e => e.File, "IX_M_AntrianCounterAudio_file");

            entity.HasIndex(e => e.IdCounterAudio, "IX_M_AntrianCounterAudio_idcounteraudio");

            entity.HasIndex(e => e.IsAktif, "IX_M_AntrianCounterAudio_isaktif");

            entity.HasIndex(e => e.KdCounter, "IX_M_AntrianCounterAudio_kdcounter");

            entity.HasIndex(e => e.Nomor, "IX_M_AntrianCounterAudio_nomor");

            entity.Property(e => e.Counter)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.File)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.KdCounter)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KdLayanan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KdLokasi)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Nomor)
                .IsRequired()
                .HasMaxLength(4);
        });

        modelBuilder.Entity<MAntrianLayanan>(entity =>
        {
            entity.HasKey(e => e.IdLayanan);

            entity.ToTable("M_AntrianLayanan");

            entity.HasIndex(e => e.IdLayanan, "IX_M_AntrianLayanan_idlayanan");

            entity.HasIndex(e => e.Inisial, "IX_M_AntrianLayanan_inisial");

            entity.HasIndex(e => e.IsAktif, "IX_M_AntrianLayanan_isaktif");

            entity.HasIndex(e => e.KdLayanan, "IX_M_AntrianLayanan_vkdlayan");

            entity.HasIndex(e => e.Layanan, "IX_M_AntrianLayanan_vlayanan");

            entity.Property(e => e.Inisial)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.KdLayanan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KdLokasi)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Layanan)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MAntrianLokasi>(entity =>
        {
            entity.HasKey(e => e.Kdlokasi);

            entity.ToTable("M_AntrianLokasi");

            entity.HasIndex(e => e.Action, "IX_M_AntrianLokasi_action");

            entity.HasIndex(e => e.IdLokasi, "IX_M_AntrianLokasi_idlokasi");

            entity.HasIndex(e => e.IsAktif, "IX_M_AntrianLokasi_isaktif");

            entity.HasIndex(e => e.Kdlokasi, "IX_M_AntrianLokasi_vkdlokasi");

            entity.HasIndex(e => e.Lokasi, "IX_M_AntrianLokasi_vlokasi");

            entity.Property(e => e.Kdlokasi).HasMaxLength(5);
            entity.Property(e => e.Action)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.IdLokasi).ValueGeneratedOnAdd();
            entity.Property(e => e.Lokasi)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MAsal>(entity =>
        {
            entity.HasKey(e => e.IdAsal);

            entity.ToTable("M_Asal");

            entity.HasIndex(e => e.IdAsal, "IX_M_Asal_IdAsal");

            entity.HasIndex(e => e.IdAsalGroup, "IX_M_Asal_IdAsalgroup");

            entity.HasIndex(e => e.IsAktif, "IX_M_Asal_IsAktif");

            entity.HasIndex(e => e.Kdasal, "IX_M_Asal_Kdasal");

            entity.HasIndex(e => e.NmAsal, "IX_M_Asal_Nmasal");

            entity.Property(e => e.Kdasal)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.NmAsal)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdAsalGroupNavigation).WithMany(p => p.MAsal)
                .HasForeignKey(d => d.IdAsalGroup)
                .HasConstraintName("FK_M_ASAL_M_ASAL_GROUP");
        });

        modelBuilder.Entity<MAsalGroup>(entity =>
        {
            entity.HasKey(e => e.IdAsalGroup);

            entity.ToTable("M_AsalGroup");

            entity.HasIndex(e => e.IsAktif, "IX_M_AsalGroup_IS_Aktif");

            entity.HasIndex(e => e.IdAsalGroup, "IX_M_AsalGroup_IdAsalGroup");

            entity.HasIndex(e => e.NamaGroupAsal, "IX_M_AsalGroup_NamaGroupAsal");

            entity.Property(e => e.NamaGroupAsal)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MAturanPakai>(entity =>
        {
            entity.HasKey(e => e.IdAturanpakai);

            entity.ToTable("M_AturanPakai");

            entity.HasIndex(e => e.IdAturanpakai, "IX_M_AturanPakai_IdAturanPakai");

            entity.HasIndex(e => e.IsAktif, "IX_M_AturanPakai_IsAktif");

            entity.HasIndex(e => e.KdAturanPakai, "IX_M_AturanPakai_KdAturanPakai");

            entity.HasIndex(e => e.KetAturanpakai, "IX_M_AturanPakai_KetAturanPakai");

            entity.HasIndex(e => e.NamaAturanpakai, "IX_M_AturanPakai_NmAturanPakai");

            entity.Property(e => e.IdAturanpakai).HasPrecision(18);
            entity.Property(e => e.KdAturanPakai)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.KetAturanpakai)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NamaAturanpakai)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MBank>(entity =>
        {
            entity.HasKey(e => e.IdBank);

            entity.ToTable("M_Bank");

            entity.Property(e => e.IdBank).HasMaxLength(26);
            entity.Property(e => e.Alamat)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Cabang)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.KdAkun)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.Kdbank)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Kota)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmBank)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NomorRekening)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.OldIdBank).HasPrecision(18);
            entity.Property(e => e.Telepon)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MBarang>(entity =>
        {
            entity.HasKey(e => e.BarangId);

            entity.ToTable("M_Barang");

            entity.HasIndex(e => e.Etiket, "IX_M_Barang_Etiket");

            entity.HasIndex(e => e.Farmakoterapi, "IX_M_Barang_Farmakoterapi");

            entity.HasIndex(e => e.BarangId, "IX_M_Barang_IdBarang");

            entity.HasIndex(e => e.IdFarmakoterapi, "IX_M_Barang_IdFarmakoterapi");

            entity.HasIndex(e => e.IdSubFarmakoterapi, "IX_M_Barang_IdSubFarmakoterapi");

            entity.HasIndex(e => e.IsAktif, "IX_M_Barang_IsAktif");

            entity.HasIndex(e => e.Isi, "IX_M_Barang_Isi");

            entity.HasIndex(e => e.Jenis, "IX_M_Barang_Jenis");

            entity.HasIndex(e => e.Kandungan, "IX_M_Barang_Kandungan");

            entity.HasIndex(e => e.Kemasan, "IX_M_Barang_Kemasan");

            entity.HasIndex(e => e.Kode, "IX_M_Barang_Kode");

            entity.HasIndex(e => e.Merk, "IX_M_Barang_Merk");

            entity.HasIndex(e => e.Nama, "IX_M_Barang_Nama");

            entity.HasIndex(e => e.Pabrik, "IX_M_Barang_Pabrik");

            entity.HasIndex(e => e.Satuan, "IX_M_Barang_Satuan");

            entity.HasIndex(e => e.SubFarmakoterapi, "IX_M_Barang_SubFarmakoterapi");

            entity.HasIndex(e => e.TipeBarang, "IX_M_Barang_TipeBarang");

            entity.HasIndex(e => e.Ukuran, "IX_M_Barang_Ukuran");

            entity.HasIndex(e => e.KelompokId, "IX_M_Barang_kelompokId");

            entity.Property(e => e.BarangId)
                .HasMaxLength(26)
                .HasColumnName("barangId");
            entity.Property(e => e.DiskonOff).HasPrecision(18, 2);
            entity.Property(e => e.DiskonOn).HasPrecision(18, 2);
            entity.Property(e => e.Etiket)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ExpiredDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Farmakoterapi)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.HargaBeli).HasPrecision(18, 2);
            entity.Property(e => e.HargaJual).HasPrecision(18, 2);
            entity.Property(e => e.Isi).HasPrecision(18);
            entity.Property(e => e.Jenis)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kandungan)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.KelompokId).HasPrecision(18);
            entity.Property(e => e.Kemasan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("kode");
            entity.Property(e => e.Merk)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Nama)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.NoBatch)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.OldBarangId).HasPrecision(18);
            entity.Property(e => e.Pabrik)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Satuan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.StokMax).HasPrecision(18, 2);
            entity.Property(e => e.StokMin).HasPrecision(18, 2);
            entity.Property(e => e.StokNow).HasPrecision(18, 2);
            entity.Property(e => e.SubFarmakoterapi)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.TipeBarang).HasMaxLength(1);
            entity.Property(e => e.Ukuran).HasMaxLength(50);

            entity.HasOne(d => d.IdFarmakoterapiNavigation).WithMany(p => p.MBarang)
                .HasForeignKey(d => d.IdFarmakoterapi)
                .HasConstraintName("FK_M_BARANG_M_FARMAKOTERAPI");

            entity.HasOne(d => d.IdSubFarmakoterapiNavigation).WithMany(p => p.MBarang)
                .HasForeignKey(d => d.IdSubFarmakoterapi)
                .HasConstraintName("FK_M_BARANG_M_FARMAKOTERAPI_SUB");

            entity.HasOne(d => d.Kelompok).WithMany(p => p.MBarang)
                .HasForeignKey(d => d.KelompokId)
                .HasConstraintName("FK_M_BARANG_M_KELOMPOKBARANG2");
        });

        modelBuilder.Entity<MBarangAturanpakai>(entity =>
        {
            entity.HasKey(e => e.IdAturanpakai);

            entity.ToTable("M_BarangAturanpakai");

            entity.Property(e => e.IdAturanpakai).HasPrecision(18);
            entity.Property(e => e.KdAturanPakai)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.KetAturanPakai)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmAturanPakai)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MCoa>(entity =>
        {
            entity.HasKey(e => e.IdCoa);

            entity.ToTable("M_Coa");

            entity.HasIndex(e => e.IsAktif, "IX_M_Coa_ISAKTIF");

            entity.HasIndex(e => e.SaldoAwal, "IX_M_Coa_SALDO");

            entity.HasIndex(e => e.Subklasifikasi, "IX_M_Coa_Subklasifikasi");

            entity.HasIndex(e => e.Dc, "IX_M_Coa_VDC");

            entity.HasIndex(e => e.Kdakun, "IX_M_Coa_VKDAKUN");

            entity.HasIndex(e => e.NmAkun, "IX_M_Coa_VNMAKUN");

            entity.Property(e => e.IdCoa).HasMaxLength(26);
            entity.Property(e => e.Dc)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("DC");
            entity.Property(e => e.Kdakun)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.NmAkun)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.NmAkunAlias)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.OldIdCoa).HasPrecision(18);
            entity.Property(e => e.OldSubklasifikasi).HasPrecision(18);
            entity.Property(e => e.SaldoAwal).HasPrecision(18);
            entity.Property(e => e.Subklasifikasi).HasMaxLength(26);
            entity.Property(e => e.TglSaldoAwal).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.SubklasifikasiNavigation).WithMany(p => p.MCoa)
                .HasForeignKey(d => d.Subklasifikasi)
                .HasConstraintName("FK_M_COA_M_COA_SUBKLASIFIKASI");
        });

        modelBuilder.Entity<MCoaGolongan>(entity =>
        {
            entity.HasKey(e => e.IdGolongan);

            entity.ToTable("M_CoaGolongan");

            entity.HasIndex(e => e.IsAktif, "IX_M_CoaGolongan_IsAktif");

            entity.HasIndex(e => e.NmGolongan, "IX_M_CoaGolongan_NmGolo");

            entity.Property(e => e.IdGolongan).HasPrecision(18);
            entity.Property(e => e.NmGolongan)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MCoaKlasifikasi>(entity =>
        {
            entity.HasKey(e => e.IdKlasifikasi);

            entity.ToTable("M_CoaKlasifikasi");

            entity.HasIndex(e => e.IdGolongan, "IX_M_CoaKlasifikasi_IdGolongan");

            entity.HasIndex(e => e.IsAktif, "IX_M_CoaKlasifikasi_IsAktif");

            entity.HasIndex(e => e.NmKlasifikasi, "IX_M_CoaKlasifikasi_NmKlasifikasi");

            entity.Property(e => e.IdKlasifikasi).HasPrecision(18);
            entity.Property(e => e.IdGolongan).HasPrecision(18);
            entity.Property(e => e.NmKlasifikasi)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Urut).HasPrecision(18);

            entity.HasOne(d => d.IdGolonganNavigation).WithMany(p => p.MCoaKlasifikasi)
                .HasForeignKey(d => d.IdGolongan)
                .HasConstraintName("FK_M_COA_KLASIFIKASI_M_COA_GOLONGAN");
        });

        modelBuilder.Entity<MCoaSubKlasifikasi>(entity =>
        {
            entity.HasKey(e => e.IdSubKlasifikasi);

            entity.ToTable("M_CoaSubKlasifikasi");

            entity.HasIndex(e => e.Dc, "IX_M_CoaSubKlasifikasi_DC");

            entity.HasIndex(e => e.IsAktif, "IX_M_CoaSubKlasifikasi_ISAKTIF");

            entity.HasIndex(e => e.IdKlasifikasi, "IX_M_CoaSubKlasifikasi_IdKlasifikasi");

            entity.HasIndex(e => e.KdSubKlasifikasi, "IX_M_CoaSubKlasifikasi_Kdsub");

            entity.HasIndex(e => e.NmSubKlasifikasi, "IX_M_CoaSubKlasifikasi_Nmsub");

            entity.Property(e => e.IdSubKlasifikasi).HasMaxLength(26);
            entity.Property(e => e.Dc)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("DC");
            entity.Property(e => e.IdKlasifikasi).HasPrecision(18);
            entity.Property(e => e.KdSubKlasifikasi)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmSubKlasifikasi)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.OldIdSubKlasifikasi).HasPrecision(18);
            entity.Property(e => e.Urut).HasPrecision(18);

            entity.HasOne(d => d.IdKlasifikasiNavigation).WithMany(p => p.MCoaSubKlasifikasi)
                .HasForeignKey(d => d.IdKlasifikasi)
                .HasConstraintName("FK_M_COA_SUBKLASIFIKASI_M_COA_KLASIFIKASI");
        });

        modelBuilder.Entity<MCountTraffic>(entity =>
        {
            entity.HasKey(e => e.IdCountTraffic);

            entity.ToTable("M_CountTraffic");

            entity.Property(e => e.IdCountTraffic).HasMaxLength(26);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Jam)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("jam");
            entity.Property(e => e.Menu)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SubMenu)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Tanggal).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MDepartment>(entity =>
        {
            entity.HasKey(e => e.IdDepartment);

            entity.ToTable("M_Department");

            entity.Property(e => e.IdDepartment).HasPrecision(18);
            entity.Property(e => e.NamaDepartemen)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<MDiagnosa>(entity =>
        {
            entity.HasKey(e => e.IdDiagnosa);

            entity.ToTable("M_Diagnosa");

            entity.HasIndex(e => e.KdDiagnosa, "IX_M_Diagnosa_KdDiagnosa");

            entity.HasIndex(e => e.NmDiagnosa, "IX_M_Diagnosa_NmDiagnosa");

            entity.HasIndex(e => e.IdDtd, "IX_M_Diagnosa_IdDtd");

            entity.Property(e => e.KdDiagnosa)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.KdDtd)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("kdDTD");
            entity.Property(e => e.NmDiagnosa)
                .IsRequired()
                .HasMaxLength(300);
            entity.Property(e => e.IdDtd)
                .HasColumnName("IdDTD");

            entity.HasOne(d => d.MDtdNavigation).WithMany()
               .HasForeignKey(d => d.IdDtd)
               .HasConstraintName("FK_M_DIAGNOSA_M_DTD");
        });

        modelBuilder.Entity<MDiagnosaMatrix>(entity =>
        {
            entity.HasKey(e => e.IdMatrixDiagnosa);

            entity.ToTable("M_DiagnosaMatrix");

            entity.Property(e => e.KdDiagnosa)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.KodeRuangan)
                .IsRequired()
                .HasMaxLength(8);

            entity.HasIndex(e => e.IdDiagnosa, "IX_M_DiagnosaMatrix_IdDiagnosa");

            entity.HasIndex(e => e.IdRuangan, "IX_M_DiagnosaMatrix_IdRuangan");

            entity.HasOne(d => d.MDiagnosaNavigation).WithMany()
                .HasForeignKey(d => d.IdDiagnosa)
                .HasConstraintName("FK_M_DIAGNOSAMATRIX_M_DIAGNOSA");

            entity.HasOne(d => d.MRuangNavigation).WithMany()
                .HasForeignKey(d => d.IdRuangan)
                .HasConstraintName("FK_M_DIAGNOSAMATRIX_M_RUANG");
        });

        modelBuilder.Entity<MDokter>(entity =>
        {
            entity.HasKey(e => e.IdDokter);

            entity.ToTable("M_Dokter");

            entity.HasIndex(e => e.IdCoa, "IX_M_Dokter_IdCoa");

            entity.HasIndex(e => e.KdDokter, "IX_M_Dokter_KdDokter");

            entity.HasIndex(e => e.NmDokter, "IX_M_Dokter_NmDokter");

            entity.Property(e => e.AlamatDokter)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.AlamatPraktek)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.IdCoa).HasMaxLength(26);
            entity.Property(e => e.ImgFotodokter)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.IsTtd).IsRequired();
            entity.Property(e => e.KdAkun)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.KdDokter)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.KodeTarif)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.NmDokter)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.NoSip)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Pin).HasPrecision(18, 2);
            entity.Property(e => e.SpesialisasiDokter)
                .IsRequired()
                .HasMaxLength(60);
            entity.Property(e => e.TelpDokter)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Telppraktek)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdCoaNavigation).WithMany(p => p.MDokter)
                .HasForeignKey(d => d.IdCoa)
                .HasConstraintName("FK_M_DOKTER_M_COA");
        });

        modelBuilder.Entity<MDokterHonor>(entity =>
        {
            entity.ToTable("M_DokterHonor");

            entity.Property(e => e.JasaMedis).HasPrecision(18);
            entity.Property(e => e.JasaRs)
                .HasPrecision(18)
                .HasColumnName("JasaRS");
            entity.Property(e => e.KdDokter)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.Ket)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmDokter)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Tarif).HasPrecision(18);
        });

        modelBuilder.Entity<MDokterNote>(entity =>
        {
            entity.HasKey(e => e.IdDokterNote);

            entity.ToTable("M_DokterNote");

            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.IdDokter).HasPrecision(18);
            entity.Property(e => e.KdDokter)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.Keterangan)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TglInput).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MDtd>(entity =>
        {
            entity.HasKey(e => e.IdDtd);

            entity.ToTable("M_DTD");

            entity.Property(e => e.IdDtd).HasColumnName("IdDTD");
            entity.Property(e => e.KdDtd)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("KdDTD");
            entity.Property(e => e.NmDtd)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("NmDTD");
            entity.Property(e => e.IsAktif).HasColumnName("IsAktif");
        });

        modelBuilder.Entity<MFarmakoterapi>(entity =>
        {
            entity.HasKey(e => e.IdFarmakoterapi);

            entity.ToTable("M_Farmakoterapi");

            entity.Property(e => e.Nmfarmakoterapi)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<MFarmakoterapiSub>(entity =>
        {
            entity.HasKey(e => e.IdSubFarmakoterapi);

            entity.ToTable("M_FarmakoterapiSub");

            entity.HasIndex(e => e.IdFarmakoterapi, "IX_M_FarmakoterapiSub_IdFarmakoterapi");

            entity.Property(e => e.NmSubFarmakoterapi)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.IdFarmakoterapiNavigation).WithMany(p => p.MFarmakoterapiSub)
                .HasForeignKey(d => d.IdFarmakoterapi)
                .HasConstraintName("FK_M_FARMAKOTERAPI_SUB_M_FARMAKOTERAPI");
        });

        modelBuilder.Entity<MGizi>(entity =>
        {
            entity.HasKey(e => e.IdGizi);

            entity.ToTable("M_Gizi");

            entity.Property(e => e.Air).HasPrecision(18);
            entity.Property(e => e.Bdd).HasPrecision(18);
            entity.Property(e => e.Calsium).HasPrecision(18);
            entity.Property(e => e.Energi).HasPrecision(18);
            entity.Property(e => e.Fe).HasPrecision(18);
            entity.Property(e => e.Fosfor).HasPrecision(18);
            entity.Property(e => e.Group)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kandungan)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Kdmakanan)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Kh).HasPrecision(18);
            entity.Property(e => e.Lemak).HasPrecision(18);
            entity.Property(e => e.Nmmakanan)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.OldIdGizi).HasPrecision(18);
            entity.Property(e => e.Protein).HasPrecision(18);
            entity.Property(e => e.Vita).HasPrecision(18);
            entity.Property(e => e.Vitb1).HasPrecision(18);
            entity.Property(e => e.Vitc).HasPrecision(18);
        });

        modelBuilder.Entity<MGudang>(entity =>
        {
            entity.HasKey(e => e.IdGudangObat);

            entity.ToTable("M_Gudang");

            entity.HasIndex(e => e.KodeInventory, "IX_M_GudangKdinv");

            entity.HasIndex(e => e.IsListropp, "IX_M_GudangLisrop");

            entity.HasIndex(e => e.NamaGudangObat, "IX_M_GudangNamagudang");

            entity.HasIndex(e => e.IsAktif, "IX_M_Gudang_IsAktif");

            entity.HasIndex(e => e.IsRequest, "IX_M_Gudang_Isrequest");

            entity.Property(e => e.IsTipebarang)
                .IsRequired()
                .HasMaxLength(1);
            entity.Property(e => e.KodeInventory)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.NamaGudangObat)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MHargaBarang>(entity =>
        {
            entity.HasKey(e => e.IdHargaBeli);

            entity.ToTable("M_HargaBarang");

            entity.HasIndex(e => e.IsAktif, "IX_M_HargaBarang_IsAktif");

            entity.HasIndex(e => e.BarangId, "IX_M_HargaBarang_barangId");

            entity.HasIndex(e => e.DiskonOff, "IX_M_HargaBarang_diskonOff");

            entity.HasIndex(e => e.DiskonOn, "IX_M_HargaBarang_diskonOn");

            entity.HasIndex(e => e.Harga, "IX_M_HargaBarang_harga");

            entity.HasIndex(e => e.LastUpdate, "IX_M_HargaBarang_lastupdate");

            entity.HasIndex(e => e.Ppn, "IX_M_HargaBarang_ppn");

            entity.HasIndex(e => e.SupplierId, "IX_M_HargaBarang_supplierId");

            entity.Property(e => e.IdHargaBeli).HasMaxLength(26);
            entity.Property(e => e.BarangId).HasMaxLength(26);
            entity.Property(e => e.DiskonOff).HasPrecision(18, 2);
            entity.Property(e => e.DiskonOn).HasPrecision(18, 2);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.InputBy)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastUpdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OldBarangId).HasPrecision(18);
            entity.Property(e => e.OldIdHargaBeli).HasPrecision(18);
            entity.Property(e => e.Ppn)
                .HasPrecision(18)
                .HasColumnName("PPN");

            entity.HasOne(d => d.Barang).WithMany(p => p.MHargaBarang)
                .HasForeignKey(d => d.BarangId)
                .HasConstraintName("FK_M_HARGABARANG_M_BARANG");

            entity.HasOne(d => d.Supplier).WithMany(p => p.MHargaBarang)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_M_HARGABARANG_M_SUPPLIER");
        });

        modelBuilder.Entity<MHargaRekanan>(entity =>
        {
            entity.HasKey(e => e.IdHargaRekanan);

            entity.ToTable("M_HargaRekanan");

            entity.HasIndex(e => e.BarangId, "IX_M_HargaRekanan_barangId");

            entity.HasIndex(e => e.Harga, "IX_M_HargaRekanan_harga");

            entity.HasIndex(e => e.Hargajual, "IX_M_HargaRekanan_hargaJual");

            entity.HasIndex(e => e.IdHargaRekanan, "IX_M_HargaRekanan_idHargaRekanan");

            entity.HasIndex(e => e.IsAktif, "IX_M_HargaRekanan_isAktif");

            entity.HasIndex(e => e.LastUpdate, "IX_M_HargaRekanan_lastUpdate");

            entity.HasIndex(e => e.RekananId, "IX_M_HargaRekanan_rekananId");

            entity.Property(e => e.BarangId).HasMaxLength(26);
            entity.Property(e => e.Diskon).HasPrecision(18);
            entity.Property(e => e.Harga).HasPrecision(19, 2);
            entity.Property(e => e.Hargajual).HasPrecision(18);
            entity.Property(e => e.InpuBy)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastUpdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Margin).HasPrecision(18);
            entity.Property(e => e.OldBarangId).HasPrecision(18);
            entity.Property(e => e.OldIdHargaRekanan).HasPrecision(18);
            entity.Property(e => e.Ppn).HasPrecision(18);

            entity.HasOne(d => d.Barang).WithMany(p => p.MHargaRekanan)
                .HasForeignKey(d => d.BarangId)
                .HasConstraintName("FK_M_HARGAREKANAN_M_BARANG");

            entity.HasOne(d => d.Rekanan).WithMany(p => p.MHargaRekanan)
                .HasForeignKey(d => d.RekananId)
                .HasConstraintName("FK_M_HARGAREKANAN_M_REKANAN");
        });

        modelBuilder.Entity<MHargakamar>(entity =>
        {
            entity.HasKey(e => e.IdHargakamar);

            entity.ToTable("M_Hargakamar");

            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MJadwalDokter>(entity =>
        {
            entity.HasKey(e => e.IdJadwal);

            entity.ToTable("M_JadwalDokter");

            entity.HasIndex(e => e.Hari, "IX_M_JadwalDokter_Hari");

            entity.HasIndex(e => e.IdDokter, "IX_M_JadwalDokter_IdDokter");

            entity.HasIndex(e => e.IdJadwal, "IX_M_JadwalDokter_IdJadwal");

            entity.HasIndex(e => e.IdRuangan, "IX_M_JadwalDokter_IdRuangan");

            entity.HasIndex(e => e.IsAktif, "IX_M_JadwalDokter_IsAktif");

            entity.HasIndex(e => e.JamFinish, "IX_M_JadwalDokter_JamFinish");

            entity.HasIndex(e => e.JamStart, "IX_M_JadwalDokter_JamStart");

            entity.HasIndex(e => e.KdDokter, "IX_M_JadwalDokter_KdDokter");

            entity.HasIndex(e => e.KodeRuangan, "IX_M_JadwalDokter_KdRuangan");

            entity.HasIndex(e => e.NamaKlinik, "IX_M_JadwalDokter_NamaKlinik");

            entity.Property(e => e.Hari)
                .IsRequired()
                .HasMaxLength(30);
            entity.Property(e => e.IdDokter).HasPrecision(18);
            entity.Property(e => e.JamFinish)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.JamStart)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KdDokter)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.KodeRuangan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.NamaKlinik)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdDokterNavigation).WithMany(p => p.MJadwalDokter)
                .HasForeignKey(d => d.IdDokter)
                .HasConstraintName("FK_M_JADWALDOKTER_M_DOKTER_(kddokter)");

            entity.HasOne(d => d.IdRuanganNavigation).WithMany(p => p.MJadwalDokter)
                .HasForeignKey(d => d.IdRuangan)
                .HasConstraintName("FK_M_JADWALDOKTER_M_RUANG_(kdruangan)");
        });

        modelBuilder.Entity<MKamarinap>(entity =>
        {
            entity.HasKey(e => e.IdKamarInap);

            entity.ToTable("M_Kamarinap");

            entity.HasIndex(e => e.IdHargakamar, "IX_M_Kamarinap_IdHargakamar");

            entity.HasIndex(e => e.IdMapid, "IX_M_Kamarinap_IdMapid");

            entity.HasIndex(e => e.KdTmpTidur, "IX_TM_KAMARINAP_kdtmptidur");

            entity.HasIndex(e => e.Lantai, "IX_TM_KAMARINAP_lantai");

            entity.Property(e => e.Isi).HasMaxLength(1);
            entity.Property(e => e.Ix).HasColumnName("IX");
            entity.Property(e => e.Iy).HasColumnName("IY");
            entity.Property(e => e.KdTmpTidur)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.KodeRuangan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KodeTarif)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.Lantai)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.Nokamar)
                .IsRequired()
                .HasMaxLength(6);

            entity.HasOne(d => d.IdHargakamarNavigation).WithMany(p => p.MKamarinap)
                .HasForeignKey(d => d.IdHargakamar)
                .HasConstraintName("FK_M_KAMARINAP_M_HARGAKAMAR");

            entity.HasOne(d => d.IdMap).WithMany(p => p.MKamarinap)
                .HasForeignKey(d => d.IdMapid)
                .HasConstraintName("FK_M_KAMARINAP_M_MAP");
        });

        modelBuilder.Entity<MKamarinapHarga>(entity =>
        {
            entity.HasKey(e => e.IdKamarInapHarga);

            entity.ToTable("M_KamarinapHarga");

            entity.HasIndex(e => e.IdKamarInap, "IX_M_KamarinapHarga_IdKamarInap");

            entity.Property(e => e.Adm).HasPrecision(18);
            entity.Property(e => e.Bahanalkes).HasPrecision(18);
            entity.Property(e => e.BeaPasien).HasPrecision(18);
            entity.Property(e => e.BeaRekanan).HasPrecision(18);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Dcito)
                .HasPrecision(18)
                .HasColumnName("DCito");
            entity.Property(e => e.Diskon).HasPrecision(18);
            entity.Property(e => e.Dpenyulit)
                .HasPrecision(18)
                .HasColumnName("DPenyulit");
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.JasaMedis).HasPrecision(18);
            entity.Property(e => e.JasaRs)
                .HasPrecision(18)
                .HasColumnName("JasaRS");
            entity.Property(e => e.KdTmpTidur)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.RekananId).HasPrecision(18);
            entity.Property(e => e.SecondTnd).HasPrecision(18);
            entity.Property(e => e.Tglakhir).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Tglawal).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.IdKamarInapNavigation).WithMany(p => p.MKamarinapHarga)
                .HasForeignKey(d => d.IdKamarInap)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_M_KAMARINAP_HARGA_M_KAMARINAP");
        });

        modelBuilder.Entity<MKamarinapRekanan>(entity =>
        {
            entity.HasKey(e => e.IdKamarinaprek);

            entity.ToTable("M_KamarinapRekanan");

            entity.Property(e => e.IdKamarinaprek).HasPrecision(18);
            entity.Property(e => e.KdTmpTidur)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.OldRekananId).HasPrecision(18);
            entity.Property(e => e.RekananId)
                .IsRequired()
                .HasMaxLength(26);
        });

        modelBuilder.Entity<MKelompokBarang>(entity =>
        {
            entity.HasKey(e => e.KelompokId);

            entity.ToTable("M_KelompokBarang");

            entity.HasIndex(e => e.IdGroupTarif, "IX_M_KelompokBarang_IDGROUP");

            entity.HasIndex(e => e.IsAktif, "IX_M_KelompokBarang_ISAKTIF");

            entity.HasIndex(e => e.KelompokId, "IX_M_KelompokBarang_KELOMPOKID");

            entity.HasIndex(e => e.Kode, "IX_M_KelompokBarang_KODE");

            entity.HasIndex(e => e.Nama, "IX_M_KelompokBarang_NAMA");

            entity.Property(e => e.KelompokId).HasPrecision(18);
            entity.Property(e => e.IdGroupTarif).HasPrecision(18);
            entity.Property(e => e.Kode)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Margin).HasPrecision(18, 2);
            entity.Property(e => e.Nama)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(500);
        });

        modelBuilder.Entity<MKodepos>(entity =>
        {
            entity.HasKey(e => e.IdKodepos);

            entity.ToTable("M_Kodepos");

            entity.Property(e => e.IsAktif).HasColumnName("IS_AKTIF");
            entity.Property(e => e.Kabupaten)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.KdKodePos)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Kecamatan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kelurahan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Provinsi)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MLaboratorium>(entity =>
        {
            entity.HasKey(e => e.IdPemeriksaanLab);

            entity.ToTable("M_Laboratorium");

            entity.HasIndex(e => e.IdGroup, "IX_M_Laboratorium_IdGroup");

            entity.Property(e => e.KdPemeriksaanLab)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.NmPemeriksaanLab)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.MLaboratorium)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK_M_LABORATORIUM_M_LABORATORIUM_GROUP");
        });

        modelBuilder.Entity<MLaboratoriumGroup>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.ToTable("M_LaboratoriumGroup");

            entity.Property(e => e.IdGrouptarif).HasPrecision(18);
            entity.Property(e => e.Nmgroup)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<MLaboratoriumHarga>(entity =>
        {
            entity.HasKey(e => e.IdLabharga);

            entity.ToTable("M_LaboratoriumHarga");

            entity.HasIndex(e => e.IdHargakamar, "IX_M_LaboratoriumHarga_IdHargakamar");

            entity.HasIndex(e => e.IdPemeriksaanLab, "IX_M_LaboratoriumHarga_IdPemeriksaanLab");

            entity.HasIndex(e => e.RekananId, "IX_M_LaboratoriumHarga_RekananId");

            entity.Property(e => e.IdLabharga).HasPrecision(18);
            entity.Property(e => e.Adm).HasPrecision(18);
            entity.Property(e => e.Bahanalkes).HasPrecision(18);
            entity.Property(e => e.Beapasien).HasPrecision(18);
            entity.Property(e => e.Bearekanan).HasPrecision(18);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Cito).HasPrecision(18);
            entity.Property(e => e.Diskon).HasPrecision(18);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.Jasamedis).HasPrecision(18);
            entity.Property(e => e.Jasars).HasPrecision(18);
            entity.Property(e => e.KdPemeriksaanLab)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.LastUpdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Penyulit).HasPrecision(18);
            entity.Property(e => e.SecondTnd).HasPrecision(18);
            entity.Property(e => e.Tglakhir).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Tglawal).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.IdHargakamarNavigation).WithMany(p => p.MLaboratoriumHarga)
                .HasForeignKey(d => d.IdHargakamar)
                .HasConstraintName("FK_M_LABORATORIUM_HARGA_M_HARGAKAMAR");

            entity.HasOne(d => d.IdPemeriksaanLabNavigation).WithMany(p => p.MLaboratoriumHarga)
                .HasForeignKey(d => d.IdPemeriksaanLab)
                .HasConstraintName("FK_M_LABORATORIUM_HARGA_M_LABORATORIUM");

            entity.HasOne(d => d.Rekanan).WithMany(p => p.MLaboratoriumHarga)
                .HasForeignKey(d => d.RekananId)
                .HasConstraintName("FK_M_LABORATORIUM_HARGA_M_REKANAN");
        });

        modelBuilder.Entity<MLaboratoriumRekanan>(entity =>
        {
            entity.HasKey(e => e.IdLabrekanan);

            entity.ToTable("M_LaboratoriumRekanan");

            entity.HasIndex(e => e.IdPemeriksaanLab, "IX_M_LaboratoriumRekanan_IdPemeriksaanLab");

            entity.HasIndex(e => e.RekananId, "IX_M_LaboratoriumRekanan_RekananId");

            entity.Property(e => e.KdPemeriksaanLab)
                .IsRequired()
                .HasMaxLength(8);

            entity.HasOne(d => d.IdPemeriksaanLabNavigation).WithMany(p => p.MLaboratoriumRekanan)
                .HasForeignKey(d => d.IdPemeriksaanLab)
                .HasConstraintName("FK_M_LABORATORIUM_REKANAN_M_LABORATORIUM");

            entity.HasOne(d => d.Rekanan).WithMany(p => p.MLaboratoriumRekanan)
                .HasForeignKey(d => d.RekananId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M_LABORATORIUM_REKANAN_M_REKANAN");
        });

        modelBuilder.Entity<MMap>(entity =>
        {
            entity.HasKey(e => e.IdMapid);

            entity.ToTable("M_Map");

            entity.HasIndex(e => e.IdRuang, "IX_M_Map_IdRuang");

            entity.Property(e => e.Image).IsRequired();
            entity.Property(e => e.KodeRuangan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.NmMap)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.IdRuangNavigation).WithMany(p => p.MMap)
                .HasForeignKey(d => d.IdRuang)
                .HasConstraintName("FK_M_MAP_M_RUANG");
        });

        modelBuilder.Entity<MMasterPaketH>(entity =>
        {
            entity.ToTable("M_MasterPaketH");

            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.IdGroupTarif).HasPrecision(18);
            entity.Property(e => e.KdPemeriksaan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmPemeriksaan)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Penunjang)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MMasterTnd>(entity =>
        {
            entity.HasKey(e => e.IdGroupTarif);

            entity.ToTable("M_MasterTnd");

            entity.Property(e => e.KdTarifDetail)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.NmTarifDetail)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.NmgroupTarif)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<MModule>(entity =>
        {
            entity.HasKey(e => e.IdModule);

            entity.ToTable("M_Module");

            entity.Property(e => e.Nmmodule)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MModuleDetail>(entity =>
        {
            entity.HasKey(e => e.IdModuleDetail);

            entity.ToTable("M_ModuleDetail");

            entity.HasIndex(e => e.IdModule, "IX_M_ModuleDetail_IdModule");

            entity.Property(e => e.NmModulDetail)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmModuleDetailSub)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Urut).HasPrecision(18);

            entity.HasOne(d => d.IdModuleNavigation).WithMany(p => p.MModuleDetail)
                .HasForeignKey(d => d.IdModule)
                .HasConstraintName("FK_M_MODULE_DETAIL_M_MODULE");
        });

        modelBuilder.Entity<MMorfologi>(entity =>
        {
            entity.HasKey(e => e.IdMorfologi);

            entity.ToTable("M_Morfologi");

            entity.HasIndex(e => e.IdDiagnosa, "IX_M_Morfologi_IdDiagnosa");

            entity.Property(e => e.KdDiagnosa)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.KdMorfologi)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.NmMorfologi)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdDiagnosaNavigation).WithMany(p => p.MMorfologi)
                .HasForeignKey(d => d.IdDiagnosa)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_M_MORFOLOGI_M_DIAGNOSA");
        });

        modelBuilder.Entity<MObatUnit>(entity =>
        {
            entity.HasKey(e => e.IdObatUnit);

            entity.ToTable("M_ObatUnit");

            entity.HasIndex(e => e.BarangId, "IX_M_ObatUnit_barangid");

            entity.HasIndex(e => e.ExpiredDate, "IX_M_ObatUnit_d_expireddate");

            entity.HasIndex(e => e.StokMax, "IX_M_ObatUnit_d_stokmax");

            entity.HasIndex(e => e.StokMin, "IX_M_ObatUnit_d_stokmin");

            entity.HasIndex(e => e.StokNow, "IX_M_ObatUnit_d_stoknow");

            entity.HasIndex(e => e.IdObatUnit, "IX_M_ObatUnit_id_obatunit");

            entity.HasIndex(e => e.IsAktif, "IX_M_ObatUnit_is_aktif");

            entity.HasIndex(e => e.KodeInventory, "IX_M_ObatUnit_v_kdinventory");

            entity.HasIndex(e => e.KdObat, "IX_M_ObatUnit_v_kdobat");

            entity.HasIndex(e => e.Rod, "IX_M_ObatUnit_v_rod");

            entity.HasIndex(e => e.NmObat, "IX_M_ObatUnit_vnmobat");

            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ExpiredDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.KdObat)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.KodeInventory)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.NmObat)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.OldBarangId).HasPrecision(18);
            entity.Property(e => e.StokMax).HasPrecision(18);
            entity.Property(e => e.StokMin).HasPrecision(18);
            entity.Property(e => e.StokNow).HasPrecision(18);
        });

        modelBuilder.Entity<MPaketDetail>(entity =>
        {
            entity.HasKey(e => e.IdPaketdetail);

            entity.ToTable("M_PaketDetail");

            entity.Property(e => e.Group)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.KdPaketDetail)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmPaketDetail)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Rekanan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Tipe)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MPaketHarga>(entity =>
        {
            entity.HasKey(e => e.IdPaketkelas);

            entity.ToTable("M_PaketHarga");

            entity.Property(e => e.Adm).HasPrecision(18);
            entity.Property(e => e.BahanAlkes).HasPrecision(18);
            entity.Property(e => e.Beapasien).HasPrecision(18);
            entity.Property(e => e.Bearekanan).HasPrecision(18);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Cito).HasPrecision(18);
            entity.Property(e => e.Diskon).HasPrecision(18);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.IdMasterPemeriksaanPenunjang)
                .IsRequired()
                .HasMaxLength(26);
            entity.Property(e => e.JasaRs)
                .HasPrecision(18)
                .HasColumnName("JasaRS");
            entity.Property(e => e.Jasamedis).HasPrecision(18);
            entity.Property(e => e.Jasamedis2).HasPrecision(18);
            entity.Property(e => e.Jasamedis3).HasPrecision(18);
            entity.Property(e => e.Jasamedis4).HasPrecision(18);
            entity.Property(e => e.Jasamedis5).HasPrecision(18);
            entity.Property(e => e.Jumlah).HasPrecision(18);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastUpdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OldIdMasterPemeriksaanPenunjang).HasPrecision(18);
            entity.Property(e => e.OldIdPaketkelas).HasPrecision(18);
            entity.Property(e => e.OldIdPenunjangDetail).HasPrecision(18);
            entity.Property(e => e.OldRekananid).HasPrecision(18);
            entity.Property(e => e.Penyulit).HasPrecision(18);
            entity.Property(e => e.SecondTnd).HasPrecision(18);
            entity.Property(e => e.Subtotal).HasPrecision(18);
            entity.Property(e => e.TglAkhir).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TglAwal).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MPaketHargaBaru>(entity =>
        {
            entity.HasKey(e => e.IdPaketkelas);

            entity.ToTable("M_PaketHargaBaru");

            entity.Property(e => e.Adm).HasPrecision(18);
            entity.Property(e => e.Bahanalkes).HasPrecision(18);
            entity.Property(e => e.Beapasien).HasPrecision(18);
            entity.Property(e => e.Bearekanan).HasPrecision(18);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Cito).HasPrecision(18);
            entity.Property(e => e.Diskon).HasPrecision(18);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.JasaRs)
                .HasPrecision(18)
                .HasColumnName("JasaRS");
            entity.Property(e => e.Jasamedis).HasPrecision(18);
            entity.Property(e => e.Jasamedis2).HasPrecision(18);
            entity.Property(e => e.Jasamedis3).HasPrecision(18);
            entity.Property(e => e.Jasamedis4).HasPrecision(18);
            entity.Property(e => e.Jasamedis5).HasPrecision(18);
            entity.Property(e => e.Jumlah).HasPrecision(18);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Lastupdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OldIdMasterPemeriksaanPenunjang).HasPrecision(18);
            entity.Property(e => e.OldIdPenunjangDetail).HasPrecision(18);
            entity.Property(e => e.OldRekananId).HasPrecision(18);
            entity.Property(e => e.Penyulit).HasPrecision(18);
            entity.Property(e => e.SecondTnd).HasPrecision(18);
            entity.Property(e => e.Subtotal).HasPrecision(18);
            entity.Property(e => e.Tglakhir).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Tglawal).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MPaketMatrix>(entity =>
        {
            entity.HasKey(e => e.IdPaketMatrix);

            entity.ToTable("M_PaketMatrix");

            entity.Property(e => e.IdPaketMatrix).HasMaxLength(26);
            entity.Property(e => e.Koderuangan)
                .IsRequired()
                .HasMaxLength(5);
        });

        modelBuilder.Entity<MPaketRekanan>(entity =>
        {
            entity.HasKey(e => e.IdPaketRekanan);

            entity.ToTable("M_PaketRekanan");

            entity.Property(e => e.IdMasterPemeriksaanPenunjang)
                .IsRequired()
                .HasMaxLength(26);
            entity.Property(e => e.OldIdPaketRekanan).HasPrecision(18);
            entity.Property(e => e.RekananId)
                .IsRequired()
                .HasMaxLength(26);
        });

        modelBuilder.Entity<MPasien>(entity =>
        {
            entity.HasKey(e => e.IdPasien);

            entity.ToTable("M_Pasien");

            entity.HasIndex(e => e.RekananId, "IX_M_Pasien_RekananId");

            entity.HasIndex(e => e.AgamaPasien, "IX_M_Pasien_agama");

            entity.HasIndex(e => e.AlamatPasien, "IX_M_Pasien_alamat");

            entity.HasIndex(e => e.IsBlacklist, "IX_M_Pasien_blacklist");

            entity.HasIndex(e => e.HpPasien, "IX_M_Pasien_hp");

            entity.HasIndex(e => e.IdPasien, "IX_M_Pasien_idpasien");

            entity.HasIndex(e => e.IsAktif, "IX_M_Pasien_isaktif");

            entity.HasIndex(e => e.Kelaminpasien, "IX_M_Pasien_kelamin");

            entity.HasIndex(e => e.KotaPasien, "IX_M_Pasien_kota");

            entity.HasIndex(e => e.NamaPasien, "IX_M_Pasien_namapasien");

            entity.HasIndex(e => e.Noktpsimpasien, "IX_M_Pasien_noktp");

            entity.HasIndex(e => e.NoPenjamin, "IX_M_Pasien_nopenjamin");

            entity.HasIndex(e => e.PekerjaanPasien, "IX_M_Pasien_pekerjaan");

            entity.HasIndex(e => e.StatusKwnpasien, "IX_M_Pasien_statuskawin");

            entity.HasIndex(e => e.TelpPasien, "IX_M_Pasien_telp");

            entity.HasIndex(e => e.Tmptlahirpasien, "IX_M_Pasien_tempatlahir");

            entity.HasIndex(e => e.Tgllahirpasien, "IX_M_Pasien_tgllahir");

            entity.Property(e => e.IdPasien).HasMaxLength(26);
            entity.Property(e => e.AgamaPasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.AlamatPasien)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.AlamatPekerjaan)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.AlamatPenanggung)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.AlergiPasien)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.AyahPasien)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CatKhusPasien)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Goldarah)
                .IsRequired()
                .HasMaxLength(3);
            entity.Property(e => e.HpPasien)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.IbuPasien)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Iscetakkartu);
            entity.Property(e => e.JenisIdentitas)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Jenispasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kelaminpasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kodepos)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KotaPasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NamaKelPasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NamaPasien)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.NamaPenanggung)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.NoPenjamin)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Noktpsimpasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.OldIdPasien).HasPrecision(18);
            entity.Property(e => e.PasanganPasien)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.PasienNo)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.PekerjaanPasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PendidikanPasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Perusahaan)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Petugas)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Provinsi)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Rhesus)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.StatusKwnpasien)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("StatusKWNPasien");
            entity.Property(e => e.Suku)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.TelpPasien)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TelpPekerjaan)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TelpPenanggung)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Tgldaftar).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Tgllahirpasien).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Tmptlahirpasien)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Warganegara)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Rekanan).WithMany(p => p.MPasien)
                .HasForeignKey(d => d.RekananId)
                .HasConstraintName("FK_M_PASIEN_M_REKANAN_(rekananid)");
        });

        modelBuilder.Entity<MPemeriksaanPenunjang>(entity =>
        {
            entity.HasKey(e => e.IdMasterPemeriksaanPenunjang);

            entity.ToTable("M_PemeriksaanPenunjang");

            entity.Property(e => e.BeaPasien).HasPrecision(18);
            entity.Property(e => e.BeaRekanan).HasPrecision(18);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.IdGroupTarif)
                .IsRequired()
                .HasMaxLength(26);
            entity.Property(e => e.KdPemeriksaan)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.NmPemeriksaan)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.OldIdGroupTarif).HasPrecision(18);
            entity.Property(e => e.OldRekananId).HasPrecision(18);
            entity.Property(e => e.Penunjang)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.RekananId)
                .IsRequired()
                .HasMaxLength(26);
        });

        modelBuilder.Entity<MPemeriksaanPenunjangDetail>(entity =>
        {
            entity.HasKey(e => e.IdPenunjangDetail);

            entity.ToTable("M_PemeriksaanPenunjangDetail");

            entity.HasIndex(e => e.IdMasterPemeriksaanPenunjang, "IX_M_PemeriksaanPenunjangDetail_IdMasterPemeriksaanPenunjang");

            entity.Property(e => e.BeaPasien).HasPrecision(18);
            entity.Property(e => e.BeaRekanan).HasPrecision(18);
            entity.Property(e => e.Group)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.Jumlah).HasPrecision(18);
            entity.Property(e => e.KdDetail)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.KdPemeriksaan)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.KodeTarif)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.NmDetail)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Tipe)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.IdMasterPemeriksaanPenunjangNavigation).WithMany(p => p.MPemeriksaanPenunjangDetail)
                .HasForeignKey(d => d.IdMasterPemeriksaanPenunjang)
                .HasConstraintName("FK_M_PEMERIKSAANPENUNJANGDETAIL_M_PEMERIKSAANPENUNJANG");
        });

        modelBuilder.Entity<MRadiologi>(entity =>
        {
            entity.HasKey(e => e.IdPemeriksaanRad);

            entity.ToTable("M_Radiologi");

            entity.HasIndex(e => e.IdGroup, "IX_M_Radiologi_IdGroup");

            entity.Property(e => e.KdPemeriksaanRad)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.NmPemeriksaanRad)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.MRadiologi)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK_M_RADIOLOGI_M_RADIOLOGI_GROUP");
        });

        modelBuilder.Entity<MRadiologiGroup>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.ToTable("M_RadiologiGroup");

            entity.Property(e => e.Nmgroup)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<MRadiologiHarga>(entity =>
        {
            entity.HasKey(e => e.IdRadHarga);

            entity.ToTable("M_RadiologiHarga");

            entity.HasIndex(e => e.IdHargakamar, "IX_M_RadiologiHarga_IdHargakamar");

            entity.HasIndex(e => e.IdPemeriksaanRad, "IX_M_RadiologiHarga_IdPemeriksaanRad");

            entity.HasIndex(e => e.RekananId, "IX_M_RadiologiHarga_RekananId");

            entity.Property(e => e.Adm).HasPrecision(18);
            entity.Property(e => e.BahanAlkes).HasPrecision(18);
            entity.Property(e => e.BeaPasien).HasPrecision(18);
            entity.Property(e => e.BeaRekanan).HasPrecision(18);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Cito).HasPrecision(18);
            entity.Property(e => e.Diskon).HasPrecision(18);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.JasaMedis).HasPrecision(18);
            entity.Property(e => e.JasaRs)
                .HasPrecision(18)
                .HasColumnName("JasaRS");
            entity.Property(e => e.KdPemeriksaanRad)
                .IsRequired()
                .HasMaxLength(6);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Lastupdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Penyulit).HasPrecision(18);
            entity.Property(e => e.SecondTnd).HasPrecision(18);
            entity.Property(e => e.Tglakhir).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Tglawal).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.IdHargakamarNavigation).WithMany(p => p.MRadiologiHarga)
                .HasForeignKey(d => d.IdHargakamar)
                .HasConstraintName("FK_M_RADIOLOGI_HARGA_M_HARGAKAMAR");

            entity.HasOne(d => d.IdPemeriksaanRadNavigation).WithMany(p => p.MRadiologiHarga)
                .HasForeignKey(d => d.IdPemeriksaanRad)
                .HasConstraintName("FK_M_RADIOLOGI_HARGA_M_RADIOLOGI");

            entity.HasOne(d => d.Rekanan).WithMany(p => p.MRadiologiHarga)
                .HasForeignKey(d => d.RekananId)
                .HasConstraintName("FK_M_RADIOLOGI_HARGA_M_REKANAN");
        });

        modelBuilder.Entity<MRadiologiRekanan>(entity =>
        {
            entity.HasKey(e => e.IdRadrekanan);

            entity.ToTable("M_RadiologiRekanan");

            entity.HasIndex(e => e.IdPemeriksaanRad, "IX_M_RadiologiRekanan_IdPemeriksaanRad");

            entity.HasIndex(e => e.RekananId, "IX_M_RadiologiRekanan_RekananId");

            entity.Property(e => e.KdPemeriksaanRad)
                .IsRequired()
                .HasMaxLength(6);

            entity.HasOne(d => d.IdPemeriksaanRadNavigation).WithMany(p => p.MRadiologiRekanan)
                .HasForeignKey(d => d.IdPemeriksaanRad)
                .HasConstraintName("FK_M_RADIOLOGI_REKANAN_M_RADIOLOGI");

            entity.HasOne(d => d.Rekanan).WithMany(p => p.MRadiologiRekanan)
                .HasForeignKey(d => d.RekananId)
                .HasConstraintName("FK_M_RADIOLOGI_REKANAN_M_REKANAN");
        });

        modelBuilder.Entity<MRekanan>(entity =>
        {
            entity.HasKey(e => e.IdRekanan);

            entity.ToTable("M_Rekanan");

            entity.HasIndex(e => e.Alias, "IX_M_Rekanan_Alias");

            entity.HasIndex(e => e.IdRekanan, "IX_M_Rekanan_IdRekanan");

            entity.HasIndex(e => e.IsAktif, "IX_M_Rekanan_IsAktif");

            entity.HasIndex(e => e.NmRekanan, "IX_M_Rekanan_NmRekanan");

            entity.Property(e => e.Alamat)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Alias)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.IsCob).HasDefaultValue(false);
            entity.Property(e => e.IsPaketBhp).HasColumnName("IsPaketBHP");
            entity.Property(e => e.KdAkun)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.Kota)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NmRekanan)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Telp)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<MRuang>(entity =>
        {
            entity.HasKey(e => e.IdRuang);

            entity.ToTable("M_Ruang");

            entity.HasIndex(e => e.KodeRuangan, "IX_M_Ruang");

            entity.HasIndex(e => e.Nama, "IX_M_Ruang_1");

            entity.HasIndex(e => e.Kamar, "IX_M_Ruang_2");

            entity.HasIndex(e => e.KodeInventoryGudangObat, "IX_M_Ruang_3");

            entity.HasIndex(e => e.KodeRequestGudangObat, "IX_M_Ruang_4");

            entity.HasIndex(e => e.KodeTarif, "IX_M_Ruang_5");

            entity.HasIndex(e => e.IsAktif, "IX_M_Ruang_6");

            entity.HasIndex(e => e.IdRuang, "IX_M_Ruang_7");

            entity.HasIndex(e => e.KdInhealth, "IX_V_KDINHEALTH");

            entity.HasIndex(e => e.LynInhealth, "IX_V_LYNINHEALTH");

            entity.Property(e => e.GdgPaket)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.GdgPenerimaan)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.GdgRetur)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.Kamar)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.KdInhealth)
                .IsRequired()
                .HasMaxLength(3);
            entity.Property(e => e.Kelompok).HasMaxLength(1);
            entity.Property(e => e.KodeInventory)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.KodeRequestObat)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.KodeRuangan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KodeTarif)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.LynInhealth)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Nama)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NoRuang)
                .IsRequired()
                .HasMaxLength(10);

            entity.HasOne(d => d.KodeInventoryGudangObatNavigation).WithMany(p => p.MRuangKodeInventoryGudangObatNavigation)
                .HasForeignKey(d => d.KodeInventoryGudangObat)
                .HasConstraintName("FK_M_RUANG_M_GUDANG_(kdinventory)");

            entity.HasOne(d => d.KodeRequestGudangObatNavigation).WithMany(p => p.MRuangKodeRequestGudangObatNavigation)
                .HasForeignKey(d => d.KodeRequestGudangObat)
                .HasConstraintName("FK_M_RUANG_M_GUDANG2_(requestobat)");
        });

        modelBuilder.Entity<MSettingAdm>(entity =>
        {
            entity.HasKey(e => e.IdSettingAdm);

            entity.ToTable("M_SettingAdm");

            entity.Property(e => e.IdSettingAdm).HasPrecision(18);
            entity.Property(e => e.Biaya).HasPrecision(18);
            entity.Property(e => e.Kategori)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.OldRekananId).HasPrecision(18);
            entity.Property(e => e.Percent).HasPrecision(18, 2);
            entity.Property(e => e.RekananId)
                .IsRequired()
                .HasMaxLength(26);
        });

        modelBuilder.Entity<MSettingBayar>(entity =>
        {
            entity.HasKey(e => e.IdSettingBayar);

            entity.ToTable("M_SettingBayar");

            entity.Property(e => e.CaraBayar)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.KdAkun)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MSettingDaftar>(entity =>
        {
            entity.HasKey(e => e.IdSettingdaftar);

            entity.ToTable("M_SettingDaftar");

            entity.Property(e => e.Koderuangan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.NmUnitDaftar)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Tujuan)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MSettingKomputerAntrian>(entity =>
        {
            entity.HasKey(e => e.IdSettingKomp);

            entity.ToTable("M_SettingKomputerAntrian");

            entity.HasIndex(e => e.IdSettingKomp, "IX_M_SettingKomputerAntrian_idsettingkomp");

            entity.HasIndex(e => e.KdCounter, "IX_M_SettingKomputerAntrian_vkdcounter");

            entity.HasIndex(e => e.KdJenisLayanan, "IX_M_SettingKomputerAntrian_vkdlayanan");

            entity.HasIndex(e => e.KdLokasi, "IX_M_SettingKomputerAntrian_vkdlokasi");

            entity.HasIndex(e => e.NmKomputer, "IX_M_SettingKomputerAntrian_vnmkomp");

            entity.Property(e => e.KdCounter)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KdJenisLayanan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.KdLokasi)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.NmKomputer)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Tanggal).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MSettingPemeriksaan>(entity =>
        {
            entity.HasKey(e => e.IdSettingPeriksaan);

            entity.ToTable("M_SettingPemeriksaan");

            entity.Property(e => e.Group)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.NmPemeriksaan)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MSmf>(entity =>
        {
            entity.HasKey(e => e.IdSmf);

            entity.ToTable("M_Smf");

            entity.Property(e => e.Kdsmf)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.Nmsmf)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MStandartfield>(entity =>
        {
            entity.HasKey(e => e.IdField);

            entity.ToTable("M_Standartfield");

            entity.HasIndex(e => e.IdFieldgroup, "IX_M_Standartfield_IdFieldgroup");

            entity.Property(e => e.IdField).HasPrecision(18);
            entity.Property(e => e.IdFieldgroup).HasPrecision(18);
            entity.Property(e => e.Keterangan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.KodeField)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Vdeskfield)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("VDeskfield");

            entity.HasOne(d => d.IdFieldgroupNavigation).WithMany(p => p.MStandartfield)
                .HasForeignKey(d => d.IdFieldgroup)
                .HasConstraintName("FK_M_STANDARTFIELD_M_STANDARTFIELD_GROUP");
        });

        modelBuilder.Entity<MStandartfieldGroup>(entity =>
        {
            entity.HasKey(e => e.IdFieldgroup);

            entity.ToTable("M_StandartfieldGroup");

            entity.Property(e => e.IdFieldgroup).HasPrecision(18);
            entity.Property(e => e.Dtanggal)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("DTanggal");
            entity.Property(e => e.Nmfieldgroup)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Vketerangan)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("VKeterangan");
        });

        modelBuilder.Entity<MStatus>(entity =>
        {
            entity.HasKey(e => e.IdStatus);

            entity.ToTable("M_Status");

            entity.HasIndex(e => e.Vstatus, "IX_M_Status");

            entity.HasIndex(e => e.IdStatus, "IX_M_Status_1");

            entity.Property(e => e.Vstatus)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("VStatus");
        });

        modelBuilder.Entity<MSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId);

            entity.ToTable("M_Supplier");

            entity.HasIndex(e => e.Alamat, "IX_M_Supplier_ALAMAT");

            entity.HasIndex(e => e.IsAktif, "IX_M_Supplier_ISAKTIF");

            entity.HasIndex(e => e.NamaSupplier, "IX_M_Supplier_NAMA");

            entity.HasIndex(e => e.SupplierId, "IX_M_Supplier_SUPPLIERID");

            entity.HasIndex(e => e.KdAkun, "IX_M_Supplier_V_KDAKUN");

            entity.Property(e => e.Alamat)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.Cp)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Fax)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.KdAkun)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Kota)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NamaSupplier)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.Telpon)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MTarifDetail>(entity =>
        {
            entity.HasKey(e => e.IdTarifdetail);

            entity.ToTable("M_TarifDetail");

            entity.HasIndex(e => e.IdGroupTarif, "IX_M_TarifDetail_IdGroupTarif");

            entity.HasIndex(e => e.Kodetariflayan1, "IX_M_TarifDetail_Kodetariflayan");

            entity.Property(e => e.IdTarifdetail).HasMaxLength(26);
            entity.Property(e => e.KdTarifDetail)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.KodeTarifLayan)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.Kodetariflayan1).HasColumnName("Kodetariflayan");
            entity.Property(e => e.NmTarifDetail)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.OldIdTarifdetail).HasPrecision(18);

            entity.HasOne(d => d.IdGroupTarifNavigation).WithMany(p => p.MTarifDetail)
                .HasForeignKey(d => d.IdGroupTarif)
                .HasConstraintName("FK_M_TARIFDETAIL_M_TARIF_GROUP");

            entity.HasOne(d => d.Kodetariflayan1Navigation).WithMany(p => p.MTarifDetail)
                .HasForeignKey(d => d.Kodetariflayan1)
                .HasConstraintName("FK_M_TARIFDETAIL_M_TARIF_PELAYANAN");
        });

        modelBuilder.Entity<MTarifGroup>(entity =>
        {
            entity.HasKey(e => e.IdGroupTarif);

            entity.ToTable("M_TarifGroup");

            entity.Property(e => e.Aliasgroup)
                .IsRequired()
                .HasMaxLength(3);
            entity.Property(e => e.KdAkun)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.NmGroupTarif)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<MTarifHarga>(entity =>
        {
            entity.HasKey(e => e.IdTarifkelas);

            entity.ToTable("M_TarifHarga");

            entity.Property(e => e.IdTarifkelas).HasMaxLength(26);
            entity.Property(e => e.Adm).HasPrecision(18);
            entity.Property(e => e.Bahanalkes).HasPrecision(18);
            entity.Property(e => e.Beapasien).HasPrecision(18);
            entity.Property(e => e.Bearekanan).HasPrecision(18);
            entity.Property(e => e.By)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Cito).HasPrecision(18);
            entity.Property(e => e.Diskon).HasPrecision(18);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.Jasamedis).HasPrecision(18);
            entity.Property(e => e.Jasamedis2).HasPrecision(18);
            entity.Property(e => e.Jasamedis3).HasPrecision(18);
            entity.Property(e => e.Jasamedis4).HasPrecision(18);
            entity.Property(e => e.Jasamedis5).HasPrecision(18);
            entity.Property(e => e.Jasars).HasPrecision(18);
            entity.Property(e => e.Kdtarifdetail)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Kelas)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Lastupdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OldIdTarifkelas).HasPrecision(18);
            entity.Property(e => e.OldRekananId).HasPrecision(18);
            entity.Property(e => e.Penyulit).HasPrecision(18);
            entity.Property(e => e.RekananId).HasMaxLength(26);
            entity.Property(e => e.SecondTnd).HasPrecision(18);
            entity.Property(e => e.Tglakhir).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Tglawal).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MTarifMatrix>(entity =>
        {
            entity.HasKey(e => e.IdTarifmatrix);

            entity.ToTable("M_TarifMatrix");

            entity.Property(e => e.IdTarifmatrix).HasMaxLength(26);
            entity.Property(e => e.IdRuang)
                .IsRequired()
                .HasMaxLength(26);
            entity.Property(e => e.IdTarifdetail)
                .IsRequired()
                .HasMaxLength(26);
            entity.Property(e => e.Kdtarifdetail)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Koderuangan)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.OldIdTarifmatrix).HasPrecision(18);
        });

        modelBuilder.Entity<MTarifNonMedis>(entity =>
        {
            entity.HasKey(e => e.IdNonMedis);

            entity.ToTable("M_TarifNonMedis");

            entity.HasIndex(e => e.IdGroupNonMedis, "IX_M_TarifNonMedis_IdGroupNonMedis");

            entity.HasIndex(e => e.KdTarif, "IX_TmTarifNonMedis_KdTarif").IsUnique();

            entity.Property(e => e.IdNonMedis).HasPrecision(18);
            entity.Property(e => e.KdTarif)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Nmtarif)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdGroupNonMedisNavigation).WithMany(p => p.MTarifNonMedis).HasForeignKey(d => d.IdGroupNonMedis);
        });

        modelBuilder.Entity<MTarifPelayanan>(entity =>
        {
            entity.HasKey(e => e.IdTariflayan);

            entity.ToTable("M_TarifPelayanan");

            entity.HasIndex(e => e.KodeTarifLayan, "IX_M_SettingKomputerAntrian_vnmkomp1").IsUnique();

            entity.Property(e => e.KodeTarifLayan)
                .IsRequired()
                .HasMaxLength(2);
            entity.Property(e => e.NamaTarifLayan)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MTarifRekanan>(entity =>
        {
            entity.HasKey(e => e.IdTarifRekanan);

            entity.ToTable("M_TarifRekanan");

            entity.Property(e => e.IdTarifRekanan).HasMaxLength(26);
            entity.Property(e => e.KdTarifDetail)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.OldIdTarifRekanan).HasPrecision(18);
            entity.Property(e => e.OldRekananId).HasPrecision(18);
            entity.Property(e => e.RekananId)
                .IsRequired()
                .HasMaxLength(26);
        });

        modelBuilder.Entity<MTarifRekananSub>(entity =>
        {
            entity.HasKey(e => e.IdTarifrekanansub);

            entity.ToTable("M_TarifRekananSub");

            entity.Property(e => e.IdTarifrekanansub).HasMaxLength(26);
            entity.Property(e => e.IdTarifRekananSub1)
                .HasPrecision(18)
                .HasColumnName("IdTarifRekananSub");
            entity.Property(e => e.RekananIdHd).HasPrecision(18);
            entity.Property(e => e.RekananidDt).HasPrecision(18);
        });

        modelBuilder.Entity<MTarifnonmedisGroup>(entity =>
        {
            entity.HasKey(e => e.IdGroupNonMedis);

            entity.ToTable("M_TarifnonmedisGroup");

            entity.Property(e => e.Kdakun)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.Nmgroupnonmedis)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MTarifnonmedisHarga>(entity =>
        {
            entity.HasKey(e => e.IdNonmedishrg);

            entity.ToTable("M_TarifnonmedisHarga");

            entity.HasIndex(e => e.IdTarifNon, "IX_M_TarifnonmedisHarga_IdTarifNon");

            entity.Property(e => e.Beapasien).HasPrecision(18);
            entity.Property(e => e.Bearekanan).HasPrecision(18);
            entity.Property(e => e.Harga).HasPrecision(18);
            entity.Property(e => e.IdTarifNon).HasPrecision(18);
            entity.Property(e => e.Kdtarif)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.OldRekananId).HasPrecision(18);
            entity.Property(e => e.RekananId).HasMaxLength(26);

            entity.HasOne(d => d.IdTarifNonNavigation).WithMany(p => p.MTarifnonmedisHarga)
                .HasForeignKey(d => d.IdTarifNon)
                .HasConstraintName("FK_M_TARIFNONMEDIS_HARGA_M_TARIFNONMEDIS");
        });

        modelBuilder.Entity<MTarifnonmedisMatrix>(entity =>
        {
            entity.HasKey(e => e.IdNonMedisMatrix);

            entity.ToTable("M_TarifnonmedisMatrix");

            entity.HasIndex(e => e.IdNonMedis, "IX_M_TarifnonmedisMatrix_IdNonMedis");

            entity.Property(e => e.IdNonMedisMatrix).HasPrecision(18);
            entity.Property(e => e.IdNonMedis).HasPrecision(18);
            entity.Property(e => e.KdTarif)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.KodeRuangan)
                .IsRequired()
                .HasMaxLength(8);

            entity.HasOne(d => d.IdNonMedisNavigation).WithMany(p => p.MTarifnonmedisMatrix)
                .HasForeignKey(d => d.IdNonMedis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M_TARIFNONMEDIS_MATRIX_M_TARIFNONMEDIS");
        });

        modelBuilder.Entity<MTarifnonmedisRekanan>(entity =>
        {
            entity.HasKey(e => e.IdNonMedRek);

            entity.ToTable("M_TarifnonmedisRekanan");

            entity.HasIndex(e => e.IdTarifNon, "IX_M_TarifnonmedisRekanan_IdTarifNon");

            entity.Property(e => e.IdRekanan)
                .IsRequired()
                .HasMaxLength(26);
            entity.Property(e => e.IdTarifNon).HasPrecision(18);
            entity.Property(e => e.KdTarif)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.OldIdRekanan).HasPrecision(18);

            entity.HasOne(d => d.IdTarifNonNavigation).WithMany(p => p.MTarifnonmedisRekanan)
                .HasForeignKey(d => d.IdTarifNon)
                .HasConstraintName("FK_M_TARIFNONMEDIS_REKANAN_M_TARIFNONMEDIS");
        });

        modelBuilder.Entity<MTennant>(entity =>
        {
            entity.HasKey(e => e.IdTenant);

            entity.ToTable("M_Tennant");

            entity.Property(e => e.IdTenant).HasMaxLength(26);
            entity.Property(e => e.CodeLogo).IsRequired();
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Logo)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.OldIdTenant).HasPrecision(18);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SubscriptionCode)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TenantAddress)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.TenantCode)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.TenantName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Website)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<MTindakan>(entity =>
        {
            entity.HasKey(e => e.IdTindakan);

            entity.ToTable("M_Tindakan");

            entity.Property(e => e.IdTindakan).HasColumnName("IdTindakan").HasPrecision(18);
            entity.Property(e => e.IsAktif).HasColumnName("IS_AKTIF");
            entity.Property(e => e.KdTindakan).HasColumnName("KdTindakan")
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.NmPendek).HasColumnName("NmPendek")
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.NmTindakan).HasColumnName("NmTindakan")
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<MUser>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("M_User");

            entity.HasIndex(e => e.IdDokter, "IX_M_User_IdDokter");

            entity.HasIndex(e => e.IdGroupUser, "IX_M_User_IdGroupUser");

            entity.HasIndex(e => e.IdRuang, "IX_M_User_IdRuang");

            entity.Property(e => e.IdUser).HasMaxLength(26);
            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.IdDokter).HasPrecision(18);
            entity.Property(e => e.IdGroupUser).HasPrecision(18);
            entity.Property(e => e.IdKaryawan).HasMaxLength(50);
            entity.Property(e => e.KdDokter).HasMaxLength(6);
            entity.Property(e => e.KodeRuangan)
                .IsRequired()
                .HasMaxLength(5);
            entity.Property(e => e.Namalengkap).HasMaxLength(50);
            entity.Property(e => e.Nmuser).HasMaxLength(50);
            entity.Property(e => e.OldIdUser).HasPrecision(18);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Pin)
                .HasPrecision(10, 2)
                .HasColumnName("PIN");

            entity.HasOne(d => d.IdDokterNavigation).WithMany(p => p.MUser)
                .HasForeignKey(d => d.IdDokter)
                .HasConstraintName("FK_M_USER_M_DOKTER");

            entity.HasOne(d => d.IdGroupUserNavigation).WithMany(p => p.MUser)
                .HasForeignKey(d => d.IdGroupUser)
                .HasConstraintName("FK_M_USER_M_USER_GROUP");

            entity.HasOne(d => d.IdRuangNavigation).WithMany(p => p.MUser)
                .HasForeignKey(d => d.IdRuang)
                .HasConstraintName("FK_M_USER_M_RUANG");
        });

        modelBuilder.Entity<MUserGroup>(entity =>
        {
            entity.HasKey(e => e.IdGroupUser);

            entity.ToTable("M_UserGroup");

            entity.Property(e => e.IdGroupUser).HasPrecision(18);
            entity.Property(e => e.NmGroupUser)
                .IsRequired()
                .HasMaxLength(50);
        });
    }
}

