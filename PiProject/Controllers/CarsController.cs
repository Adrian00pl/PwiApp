using Microsoft.AspNetCore.Mvc;
using PiProject.Models;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using PIApi.Models;

namespace PiProject.Controllers;
public class CarsController : Controller
{
    private readonly HttpClient _client;

    public CarsController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://localhost:7254/api/");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Car> carsList = new();
        List<Model> modelsList = new();

        HttpResponseMessage response = await _client.GetAsync("Car");
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            carsList = JsonConvert.DeserializeObject<List<Car>>(data) ?? new List<Car>();
        }
        HttpResponseMessage response1 = await _client.GetAsync("Model");
        if (response1.IsSuccessStatusCode)
        {
            string data = await response1.Content.ReadAsStringAsync();
            modelsList = JsonConvert.DeserializeObject<List<Model>>(data) ?? new List<Model>();
        }

            // Przekazanie obu list do widoku
        ViewBag.CarsList = carsList;
        ViewBag.ModelsList = modelsList;

        return View();
        


    }
    
    // Akcja do dodawania nowego samochodu
    [HttpPost]
    public async Task<IActionResult> AddCar(CarDto car)
    {
        if (ModelState.IsValid)
        {
            var response = await _client.PostAsJsonAsync("Car", car);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Po dodaniu przekierowujemy na stronę główną
            }
        }
        return View("Index"); // W przypadku błędu pozostajemy na tej samej stronie
    }

    // Akcja do usuwania samochodu
    [HttpPost]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var response = await _client.DeleteAsync($"Car/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Po usunięciu przekierowujemy na stronę główną
        }
        return View("Index"); // W przypadku błędu pozostajemy na tej samej stronie
    }
}
