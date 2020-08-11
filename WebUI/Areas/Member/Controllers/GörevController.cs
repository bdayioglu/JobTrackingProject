using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using DTO.DTOs.GorevDtos;
using Entities.Concrete;
using WebUI.BaseControllers;
using WebUI.StringInfo;

namespace WebUI.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class GörevController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
      
        private readonly IMapper _mapper;
        public GörevController(IGorevService gorevService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;            
            _gorevService = gorevService;
        }

        public async Task<IActionResult> Index(int aktifSayfa = 1)
        {
            TempData["Active"] = TempdataInfo.Görev;
            var user = await GetirGirisYapanKullanici();
            var gorevler = _mapper.Map<List<GorevListAllDto>>(_gorevService.GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, user.Id, aktifSayfa));
            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.AktifSayfa = aktifSayfa;

            return View(gorevler);
        }
    }
}