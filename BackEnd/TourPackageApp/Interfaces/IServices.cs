using TourPackageApp.Models.DTO;
using TourPackageApp.Models;

namespace TourPackageApp.Interfaces
{
    public interface IServices
    {

        public Task<ICollection<TourDetailsDTO?>> GetTourDetailsByTourName(string tourName);

        public Task<CountDTO?> GetCountOfToursBySpecailty(string specailty);

        public Task<Tours?> AddNewTour(Tours tours);

        public Task<TourDetailsDTO?> GetTourDetailsByTourId(int TourId);

        public Task<ICollection<TourNameDTO>> GetAllTourNameBySpeciality(string tourSpecialty);
    }
}
