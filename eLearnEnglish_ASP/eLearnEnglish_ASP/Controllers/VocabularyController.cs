using eLearnEnglish_ASP.Models;
using eLearnEnglish_ASP.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Controllers
{
    public class VocabularyController : Controller
    {
        private readonly IVocabularyRepository _vocabularyRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public VocabularyController(IVocabularyRepository vocabularyRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _vocabularyRepository = vocabularyRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("~/all-words")]
        public async Task<ViewResult> GetAllWords()
        {
            var data = await _vocabularyRepository.GetAllWords(ViewBag.userId);
            return View(data);
        }
        [Route("~/words/{id:int:min(1)}", Name = "wordDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {

            var data = await _vocabularyRepository.GetAllWords(id);

            return View(data);
        }


    }
}
