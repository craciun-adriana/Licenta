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
        public List<ReviewFilmModel> ReviewFilms { get; set; }
        public List<ReviewSeriesModel> ReviewSeries { get; set; }

        private LicentaApiHttpClient _licentaApiHttpClient;

        public HomeModel(LicentaApiHttpClient licentaApiHttpClient)
        {
            _licentaApiHttpClient = licentaApiHttpClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Books = (await _licentaApiHttpClient.GetAllBooksAsync()).ToList();
            Films = (await _licentaApiHttpClient.GetAllFilmsAsync()).ToList();
            Series = (await _licentaApiHttpClient.GetAllSeriesAsync()).ToList();
            Appointments = (await _licentaApiHttpClient.GetAllApointmentForUser()).ToList();
            ReviewBooks = (await _licentaApiHttpClient.GetReviewBookByStatus(Status.Planning)).ToList();
            ReviewFilms = (await _licentaApiHttpClient.GetReviewFilmByStatus(Status.Planning)).ToList();
            ReviewSeries = (await _licentaApiHttpClient.GetReviewSeriesByStatus(Status.Planning)).ToList();

            return Page();
        }
    }
}