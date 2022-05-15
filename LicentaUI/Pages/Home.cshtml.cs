using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicentaUI.HttpClients;
using LicentaUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LicentaUI.Pages
{
    public class HomeModel : PageModel
    {
        public List<BookModel> Books { get; set; }
        public List<FilmModel> Films { get; set; }
        public List<SeriesModel> Series { get; set; }
        public List<AppointmentModel> Appointments { get; set; }
        public List<ReviewBookModel> ReviewBooks { get; set; }
        public List<ReviewBookModel> ReviewBooksO { get; set; }
        public List<ReviewFilmModel> ReviewFilms { get; set; }
        public List<ReviewFilmModel> ReviewFilmsO { get; set; }
        public List<ReviewSeriesModel> ReviewSeries { get; set; }
        public List<ReviewSeriesModel> ReviewSeriesO { get; set; }

        private LicentaApiHttpClient _licentaApiHttpClient;

        public HomeModel(LicentaApiHttpClient licentaApiHttpClient)
        {
            _licentaApiHttpClient = licentaApiHttpClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"] ?? "";

            Books = (await _licentaApiHttpClient.GetAllBooksAsync(cookie)).ToList();
            Films = (await _licentaApiHttpClient.GetAllFilmsAsync(cookie)).ToList();
            Series = (await _licentaApiHttpClient.GetAllSeriesAsync(cookie)).ToList();
            Appointments = (await _licentaApiHttpClient.GetAllApointmentForUser(cookie)).ToList();
            ReviewBooks = (await _licentaApiHttpClient.GetReviewBookByStatus(Status.Planning, cookie)).ToList();
            ReviewFilms = (await _licentaApiHttpClient.GetReviewFilmByStatus(Status.Planning, cookie)).ToList();
            ReviewSeries = (await _licentaApiHttpClient.GetReviewSeriesByStatus(Status.Planning, cookie)).ToList();
            ReviewBooksO = (await _licentaApiHttpClient.GetReviewBookByStatus(Status.Ongoing, cookie)).ToList();
            ReviewFilmsO = (await _licentaApiHttpClient.GetReviewFilmByStatus(Status.Ongoing, cookie)).ToList();
            ReviewSeriesO = (await _licentaApiHttpClient.GetReviewSeriesByStatus(Status.Ongoing, cookie)).ToList();

            return Page();
        }
    }
}