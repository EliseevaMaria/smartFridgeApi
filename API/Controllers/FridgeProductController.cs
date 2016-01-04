using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using Models;
using DAL;

namespace API.Controllers
{
    public class FridgeProductController : ApiController
    {
        public List<FridgeProductDTO> Get(string email)
        {
            List<FridgeProductDTO> result = Converting.FridgeProductToDto(ProductDataAccess.GetFridgeProducts(email));
            return result;
        }

        public HttpResponseMessage Post(FridgeProductDTO newProduct)
        {
            ProductDataAccess.AddFridgeProduct(newProduct);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
