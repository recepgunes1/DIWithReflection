using Business.Common.LifeTimeMarkers;
using Business.Services.Abstracts;

namespace Business.Services.Concretes;

public sealed class BookingService : IBookingService, ISingletonService
{
    public int CountBooking()
    {
        return 10;
    }
}