using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.Controllers
{
    public class ListMediaDataController : ApiController
    {
        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("AllMedia")]
        public IEnumerable<Media> GetAllMediaItems()
        {
            return CatalogueService.GetMediaItems(0, Int32.MaxValue).AsEnumerable();
        }
    }
}
