using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Entities.Concrete;
using WebUI.BaseControllers;
using WebUI.StringInfo;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
        private readonly IBildirimService _bildirimService;
        private readonly IRaporService _raporService;
        public HomeController(IGorevService gorevService, IBildirimService bildirimService, UserManager<AppUser> userManager, IRaporService raporService) : base(userManager)
        {
            _raporService = raporService;
            _bildirimService = bildirimService;
            _gorevService = gorevService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetirGirisYapanKullanici();
            TempData["Active"] = TempdataInfo.Anasayfa;
            ViewBag.AtanmayiBekleyenGorevSayisi = _gorevService.GetirGorevSayisiAtanmayiBekleyen();

            ViewBag.TamamlanmisGorevSayisi = _gorevService.GetirGorevTamamlanmis();

            ViewBag.OkunmamisBildirimSayisi = _bildirimService.GetirOkunmayanSayisiileAppUserId(user.Id);

            ViewBag.ToplamRaporSayisi = _raporService.GetirRaporSayisi();
            return View();
        }
    }
}