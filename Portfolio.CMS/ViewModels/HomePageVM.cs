using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedContentModels;

namespace Portfolio.CMS.ViewModels
{
    public class HomePageVM : RenderModel
    {
        public HomePageVM(IPublishedContent content) : base(content)
        {
        }

        public string FullName { get; set; }
        public IPublishedContent ProfilePicture { get; set; }
        public IPublishedContent Banner { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public string AboutText { get; set; }
        public string AboutTitle { get; set; }
        public string Json { get; set; }

        public IEnumerable<PortfolioPictures> Pictures { get; set; }
        public IEnumerable<ShowReelVideo> Videos { get; set; }

    }
}