using Lib.Context;
using Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApp.Controllers;

public class CustomerController : Controller
{
    readonly MyDbContext ctx = new();

    public IActionResult Index()
    {
        if (LoginUtil.isLoggedIn(HttpContext.Session))
        {
            ViewData["User"] = LoginUtil.getUser(HttpContext.Session);

            return View();
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult FindRoom(DateTime? start, DateTime? end, int? beds, int? quality, double? size)
    {
        if (LoginUtil.isLoggedIn(HttpContext.Session))
        {
            IQueryable<room> rooms = ctx.room;

            if (start.HasValue && end.HasValue)
            {
                rooms = rooms.Where(room =>
                    !room.reservations.Any(r =>
                        (r.start < end && r.end > start) || r.status == ReservationStatus.CheckedIn.ToString()));

                if (beds != null)
                {
                    rooms = rooms.Where(r => r.beds == beds);
                }
                if (quality != null)
                {
                    rooms = rooms.Where(r => r.quality.Equals(quality));
                }
                if (size != null)
                {
                    rooms = rooms.Where(r => r.size.Equals(size));
                }
            }
            else
            {
                rooms = new List<room>().AsQueryable();

                start = DateTime.Now;
                end = DateTime.Now.AddDays(1);
            }

            ViewData["StartDate"] = start.GetValueOrDefault().ToString("yyyy-MM-dd");
            ViewData["EndDate"] = end.GetValueOrDefault().ToString("yyyy-MM-dd");

            return View(rooms.ToList());
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult BookRoom(DateTime start, DateTime end, int roomId)
    {
        if (LoginUtil.isLoggedIn(HttpContext.Session))
        {
            string? username = LoginUtil.getUser(HttpContext.Session);
            if (username != null)
            {
                customer? user = ctx.customer.FirstOrDefault(c => c.name == username);
                room? room = ctx.room.FirstOrDefault(r => r.nr == roomId);
                if (user != null && room != null)
                {
                    reservations r = new() {
                        customer = user,
                        roomNrNavigation = room,
                        start = start,
                        end = end
                    };

                    user.reservations.Add(r);
                    ctx.SaveChanges();

                    return RedirectToAction("ShowReservations");
                }
            }

        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult ShowReservations()
    {
        if (LoginUtil.isLoggedIn(HttpContext.Session))
        {
            string? username = LoginUtil.getUser(HttpContext.Session);
            if (username != null)
            {
                var user = ctx.customer.FirstOrDefault(c => c.name == username);
                if (user != null)
                {
                    ctx.reservations.Load();
                    ctx.room.Load();

                    return View(user.reservations.ToList());
                }
            }
        }

        return RedirectToAction("Index", "Home");
    }
}
