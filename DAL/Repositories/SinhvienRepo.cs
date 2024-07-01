using DAL.IRepositories;
using DAL.Models;
using DAL.ViewModels;

namespace DAL.Repositories;

public class SinhvienRepo : ISinhvienRepo
{
    private readonly Sof205FinalTestContext _dbContext;

    public SinhvienRepo()
    {
        _dbContext = new Sof205FinalTestContext();
    }

    public List<SinhvienVM> GetAll(string searchText, string searchType)
    {
        if (string.Equals(searchType, SearchType.Sdt))
            return _dbContext.Sinhviens.Where(c => c.Sdt.Contains(searchText))
                .Select(c => new SinhvienVM
                {
                    Sinhvien = c,
                    TenPH = c.IdPh == null ? "N/A" : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Ten,
                    NgheNghiepPH = c.IdPh == null
                        ? "N/A"
                        : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Nghenghiep
                }).ToList();

        if (string.Equals(searchType, SearchType.Diachi))
            return _dbContext.Sinhviens.Where(c => c.Diachi.Contains(searchText))
                .Select(c => new SinhvienVM
                {
                    Sinhvien = c,
                    TenPH = c.IdPh == null ? "N/A" : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Ten,
                    NgheNghiepPH = c.IdPh == null
                        ? "N/A"
                        : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Nghenghiep
                }).ToList();

        if (string.Equals(searchType, SearchType.TenPH))
            return _dbContext.Sinhviens
                .Select(c => new SinhvienVM
                {
                    Sinhvien = c,
                    TenPH = c.IdPh == null ? "N/A" : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Ten,
                    NgheNghiepPH = c.IdPh == null
                        ? "N/A"
                        : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Nghenghiep
                })
                .ToList();

        if (string.Equals(searchType, SearchType.NgheNghiepPH))
            return _dbContext.Sinhviens
                .Select(c => new SinhvienVM
                {
                    Sinhvien = c,
                    TenPH = c.IdPh == null ? "N/A" : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Ten,
                    NgheNghiepPH = c.IdPh == null
                        ? "N/A"
                        : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Nghenghiep
                })
                .Where(c => c.NgheNghiepPH.Contains(searchText)).ToList();

        if (string.Equals(searchType, SearchType.All))
            return _dbContext.Sinhviens
                .Select(c => new SinhvienVM
                {
                    Sinhvien = c,
                    TenPH = c.IdPh == null ? "N/A" : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Ten,
                    NgheNghiepPH = c.IdPh == null
                        ? "N/A"
                        : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Nghenghiep
                })
                .Where(c => c.Sinhvien.Sdt.Contains(searchText) || c.Sinhvien.Diachi.Contains(searchText) ||
                            c.TenPH.Contains(searchText) || c.NgheNghiepPH.Contains(searchText)).ToList();

        return _dbContext.Sinhviens
            .Select(c => new SinhvienVM
            {
                Sinhvien = c,
                TenPH = c.IdPh == null ? "N/A" : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Ten,
                NgheNghiepPH = c.IdPh == null
                    ? "N/A"
                    : _dbContext.Phuhuynhs.FirstOrDefault(ph => ph.Id == c.IdPh)!.Nghenghiep
            }).ToList();
    }

    public Sinhvien GetById(int id)
    {
        return _dbContext.Sinhviens.FirstOrDefault(c => c.Id == id);
    }

    public bool Add(Sinhvien sinhvien)
    {
        try
        {
            _dbContext.Sinhviens.Add(sinhvien);
            _dbContext.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(int id, Sinhvien sinhvien)
    {
        try
        {
            var existedObj = _dbContext.Sinhviens.FirstOrDefault(c => c.Id == id);

            if (existedObj == null) return false;

            existedObj.Ten = sinhvien.Ten;
            existedObj.Email = sinhvien.Email;
            existedObj.Sdt = sinhvien.Sdt;
            existedObj.Diachi = sinhvien.Diachi;

            _dbContext.Sinhviens.Update(existedObj);
            _dbContext.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Remove(int id)
    {
        try
        {
            var existedObj = _dbContext.Sinhviens.FirstOrDefault(c => c.Id == id);

            if (existedObj == null) return false;

            _dbContext.Sinhviens.Remove(existedObj);
            _dbContext.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }
}