using Newtonsoft.Json;
using Portfolio.CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedContentModels;
using System.Web.Script.Serialization;

namespace Acting.Net.CMS.Controllers
{
    public class HomePageController : RenderMvcController
    {
        public ActionResult Index(HomePage model)

        {
            var ViewModel = new HomePageVM(model);

            ViewModel.FullName = model.FullName != null ? model.FullName : null;
            ViewModel.Banner = model.Banner != null ? model.Banner : null;
            ViewModel.ProfilePicture = model.ProfilePicture != null ? model.ProfilePicture : null;
            ViewModel.Skills = model.Skills != null ? model.Skills : null;
            ViewModel.AboutTitle = model.AboutTitle != null ? model.AboutTitle : null;
            ViewModel.AboutText = model.AboutText != null ? model.AboutText : null;

            

            ViewModel.Pictures = model.Children.Where(P => P.DocumentTypeAlias == "portfolioPictures").OfType<PortfolioPictures>().ToList();

            ViewModel.Videos = model.Children.Where(v => v.DocumentTypeAlias == "showReelVideo").OfType<ShowReelVideo>().ToList();

            ViewModel.Json = JsonConvert.SerializeObject(model.Skills);



            return View(ViewModel);
        }
    }
}