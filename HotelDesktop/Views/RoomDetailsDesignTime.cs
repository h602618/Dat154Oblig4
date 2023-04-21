using Lib.Models;

namespace HotelDesktop;

public class RoomDetailsDesignTime : RoomDetails
{
    public RoomDetailsDesignTime() : base(new() { nr = 1, beds = 2, quality = 1 })
    {
    }
}
