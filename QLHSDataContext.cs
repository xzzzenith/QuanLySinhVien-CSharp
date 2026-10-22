using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Paint
{
    [Table(Name = "dbo.Lop")]
    public class Lop
    {
        [Column(Name = "MaLop", IsPrimaryKey = true, CanBeNull = false, DbType = "varchar(20) NOT NULL")]
        public string MaLop { get; set; }

        [Column(Name = "TenLop", CanBeNull = false, DbType = "nvarchar(100) NOT NULL")]
        public string TenLop { get; set; }

        [Column(Name = "SiSo", DbType = "smallint")]
        public short? SiSo { get; set; }

        private EntitySet<HocSinh> _HocSinhs = new EntitySet<HocSinh>();

        [Association(Name = "FK_HocSinh_Lop", Storage = "_HocSinhs", ThisKey = "MaLop", OtherKey = "MaLop")]
        public EntitySet<HocSinh> HocSinhs
        {
            get { return _HocSinhs; }
            set { _HocSinhs.Assign(value); }
        }
    }

    [Table(Name = "dbo.HocSinh")]
    public class HocSinh
    {
        [Column(Name = "MaHS", IsPrimaryKey = true, CanBeNull = false, DbType = "varchar(20) NOT NULL")]
        public string MaHS { get; set; }

        [Column(Name = "TenHS", CanBeNull = false, DbType = "nvarchar(100) NOT NULL")]
        public string TenHS { get; set; }

        [Column(Name = "NgaySinh", DbType = "datetime")]
        public DateTime? NgaySinh { get; set; }

        [Column(Name = "DiaChi", DbType = "nvarchar(150)")]
        public string DiaChi { get; set; }

        [Column(Name = "DTB", DbType = "real")]
        public float? DTB { get; set; }

        [Column(Name = "MaLop", DbType = "varchar(20)")]
        public string MaLop { get; set; }

        private EntityRef<Lop> _Lop = default(EntityRef<Lop>);

        [Association(Name = "FK_HocSinh_Lop", Storage = "_Lop", ThisKey = "MaLop", OtherKey = "MaLop", IsForeignKey = true)]
        public Lop Lop
        {
            get { return _Lop.Entity; }
            set { _Lop.Entity = value; }
        }
    }

    public class QLHSDataContext : DataContext
    {
        public Table<Lop> Lops
        {
            get { return this.GetTable<Lop>(); }
        }

        public Table<HocSinh> HocSinhs
        {
            get { return this.GetTable<HocSinh>(); }
        }

        public QLHSDataContext() : base(DatabaseConfig.ConnectionString)
        {
        }

        public QLHSDataContext(string connectionString) : base(connectionString)
        {
        }
    }
}
