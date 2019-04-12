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
using System.Text;

namespace Acting.Net.CMS.Controllers
{
    public class HomePageController : RenderMvcController
    {
        public ActionResult Index(HomePage model)
        {
            var sb = new StringBuilder();

            //sb.Append("ayo,");
            //sb.Append("olu,");

            //sb.ToString(); ; // = ayo,olu,


            int numberOfSkills = model.Skills.Count();
            int currentSkillNumber = 0;

            foreach (var skill in model.Skills)
            {
                sb.Append("'");
                sb.Append(skill);
                sb.Append("'");
                if (currentSkillNumber != numberOfSkills-1)
                {
                    sb.Append(",");
                }
               

                currentSkillNumber++;

            }

            


            var viewModel = new HomePageVM(model);

           viewModel.Json = sb.ToString();

            viewModel.FullName = model.FullName != null ? model.FullName : null;
            viewModel.Banner = model.Banner != null ? model.Banner : null;
            viewModel.ProfilePicture = model.ProfilePicture != null ? model.ProfilePicture : null;
            viewModel.Skills = model.Skills != null ? model.Skills : null;
            viewModel.AboutTitle = model.AboutTitle != null ? model.AboutTitle : null;
            viewModel.AboutText = model.AboutText != null ? model.AboutText : null;

            

            viewModel.Pictures = model.Children.Where(P => P.DocumentTypeAlias == "portfolioPictures").OfType<PortfolioPictures>().ToList();

            viewModel.Videos = model.Children.Where(v => v.DocumentTypeAlias == "showReelVideo").OfType<ShowReelVideo>().ToList();

           



            return View(viewModel);
        }
    }
}