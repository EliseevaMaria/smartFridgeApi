using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using DAL;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        public List<Product> GetAll()
        {
            List<Product> result = ProductDataAccess.GetProducts();
            return result;
        }

        public HttpResponseMessage Post(Product newProduct)
        {
            ProductDataAccess.AddProduct(newProduct);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
