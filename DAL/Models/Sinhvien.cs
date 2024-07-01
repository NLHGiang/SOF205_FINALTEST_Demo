namespace DAL.Models;

public class Sinhvien
{
    public int Id { get; set; }

    public string Ten { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Diachi { get; set; }

    public int? IdPh { get; set; }

    public virtual Phuhuynh? IdPhNavigation { get; set; }
}