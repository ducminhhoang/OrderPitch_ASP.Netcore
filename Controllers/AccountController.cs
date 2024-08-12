using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PitchOrderMVC.Models;
using System.Text;
namespace PitchOrderMVC.Controllers
{
    public class AccountController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7074/api");
        private readonly HttpClient _httpClient;
        public AccountController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<AccountViewModel> accountList = new List<AccountViewModel>();
            HttpResponseMessage respone = _httpClient.GetAsync(_httpClient.BaseAddress + "/Account/GetAccounts/GetAccounts").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                accountList = JsonConvert.DeserializeObject<List<AccountViewModel>>(data);
            }
            return View(accountList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AccountViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Account/AddAccount/AddAccount",content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Account Created";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMesssage"] = ex.Message;
            }
            return View(model);
        }
        
    }
}
