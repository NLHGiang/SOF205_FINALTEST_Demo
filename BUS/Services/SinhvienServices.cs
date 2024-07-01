using BUS.IServices;
using DAL.Models;
using DAL.Repositories;
using DAL.ViewModels;

namespace BUS.Services;

public class SinhvienServices : ISinhvienServices
{
    private readonly SinhvienRepo _sinhvienRepo;

    public SinhvienServices()
    {
        _sinhvienRepo = new SinhvienRepo();
    }

    public bool Add(Sinhvien sinhvien)
    {
        return _sinhvienRepo.Add(sinhvien);
    }

    public List<SinhvienVM> GetAll(string searchText, string searchType)
    {
        return _sinhvienRepo.GetAll(searchText, searchType);
    }

    public Sinhvien GetById(int id)
    {
        return _sinhvienRepo.GetById(id);
    }

    public bool Remove(int id)
    {
        return _sinhvienRepo.Remove(id);
    }

    public bool Update(int id, Sinhvien sinhvien)
    {
        return _sinhvienRepo.Update(id, sinhvien);
    }
}