using BlogAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BlogAspNet.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<IActionResult> Index()
        {
            var requests = await _requestRepository.GetRequests();

            return View(requests);
        }
    }
}
