using TourPackageApp.Interfaces;
using TourPackageApp.Models;
using TourPackageApp.Models.DTO;

namespace TourPackageApp.Services
{
    public class TourServices : IServices
    {

        private IRepo<int, Tours> _tourRepo;
        private IRepo<int, Inclusion> _inclusionRepo;
        private IRepo<int, TotalDaysDescription> _totalDaysDetailsRepo;


        public TourServices(IRepo<int, Tours> tourRepo, IRepo<int, Inclusion> inclusionRepo,

          IRepo<int, TotalDaysDescription> totalDaysDetailsRepo)
        {

            _tourRepo = tourRepo;
            _inclusionRepo = inclusionRepo;
            _totalDaysDetailsRepo = totalDaysDetailsRepo;


        }
        public async Task<Tours?> AddNewTour(Tours tours)
        {
            if (tours != null)
            {
                // Add the tour details to the database
                var addedTour = await _tourRepo.Add(tours);
                return addedTour;
            }

            throw new Exception("Unable to add at this moment");
        }

        public async Task<ICollection<TourNameDTO>> GetAllTourNameBySpeciality(string tourSpecialty)
        {
            if (tourSpecialty != null)
            {
                var allTours = await _tourRepo.GetAll();
                if (allTours.Count > 0)
                {
                    var tourNames = allTours.Where(a => a.TourSpecialty == tourSpecialty).Select(a => new TourNameDTO { TourName = a.TourName }).ToList();
                    return tourNames;
                }
            }
            throw new Exception("unable to find");
        }

        public async Task<CountDTO?> GetCountOfToursBySpecailty(string specailty)
        {
            if (specailty != null)
            {
                var tours = await _tourRepo.GetAll();
                var SpecailtyCount = tours.Where(t => t.TourSpecialty == specailty).Count();
                var Count = new CountDTO
                {
                    Count = SpecailtyCount
                };
                return Count;

            }
            throw new Exception("unable to get at this moment");
        }

        public async Task<TourDetailsDTO?> GetTourDetailsByTourId(int tourId)
        {
            if (tourId > 0)
            {
                var tours = await _tourRepo.GetAll();
                var particularTour = tours.FirstOrDefault(t => t.TourId == tourId);
                var tourInclusions = await _inclusionRepo.GetAll();
                var particularTourInclusions = tourInclusions.FirstOrDefault(i => i.InclusionId == particularTour.TourId);
                var totalDaysDescription = await _totalDaysDetailsRepo.GetAll();
                var particularTotalDaysDescription = totalDaysDescription
                                             .Where(t => t.InclusionId == particularTour.TourId)
                                             .Select(t => new TotalDaysDescription
                                             {
                                                 TourSpotName = t.TourSpotName,
                                                 DayDescription = t.DayDescription
                                             }).ToList();
                var tourDetailsDTO = new TourDetailsDTO
                {
                    TourId = particularTour.TourId,
                    TourName = particularTour.TourName,
                    TourLocationCountry = particularTour.TourLocationCountry,
                    TourLocationState = particularTour.TourLocationState,
                    Inclusion = particularTourInclusions,
                    TourPrice = particularTour.TourPrice,
                    MaxCount = particularTour.MaxCount

                };
                return tourDetailsDTO;

            }
            return null;

        }

        public async Task<ICollection<TourDetailsDTO?>> GetTourDetailsByTourName(string tourName)
        {
            if (tourName != null)
            {
                var tours = await _tourRepo.GetAll();
                var particularTours = tours.Where(t => t.TourName == tourName).ToList();

                if (particularTours.Any())
                {
                    var tourDetailsList = new List<TourDetailsDTO>();

                    foreach (var particularTour in particularTours)
                    {
                        var tourInclusions = await _inclusionRepo.GetAll();
                        var particularTourInclusions = tourInclusions.FirstOrDefault(i => i.InclusionId == particularTour.TourId);

                        var totalDaysDescription = await _totalDaysDetailsRepo.GetAll();
                        var particularTotalDaysDescription = totalDaysDescription
                               .Where(t => t.InclusionId == particularTour.TourId)
                               .Select(t => new TotalDaysDescription
                               {
                                   TourSpotName = t.TourSpotName,
                                   DayDescription = t.DayDescription
                               }).ToList();

                        var tourDetailsDTO = new TourDetailsDTO
                        {

                            TourId = particularTour.TourId,
                            TourName = particularTour.TourName,
                            TourLocationCountry = particularTour.TourLocationCountry,
                            TourLocationState = particularTour.TourLocationState,
                            TourPrice = particularTour.TourPrice,
                            Inclusion = particularTourInclusions,
                            MaxCount = particularTour.MaxCount
                        };

                        tourDetailsList.Add(tourDetailsDTO);
                    }

                    return tourDetailsList;
                }
            }

            throw new Exception("Unable to retrieve tour details at this moment");
        }
    }
}
