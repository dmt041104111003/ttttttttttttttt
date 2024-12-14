using System;
using System.Collections.Generic;

namespace DaoManhTung_N05_221231041.Models;

public partial class PhanLoai
{
    public string MaPhanLoai { get; set; } = null!;

    public string? PhanLoaiChinh { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
