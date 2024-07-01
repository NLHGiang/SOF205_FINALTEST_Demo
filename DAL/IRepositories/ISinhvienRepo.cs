using DAL.Models;
using DAL.ViewModels;

namespace DAL.IRepositories;

public interface ISinhvienRepo
{
    public List<SinhvienVM> GetAll(string searchText, string searchType);
    public Sinhvien GetById(int id);
    public bool Add(Sinhvien sinhvien);
    public bool Update(int id, Sinhvien sinhvien);
    public bool Remove(int id);
}