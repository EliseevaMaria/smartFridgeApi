using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using BusinessLayer;
using Models;
using DAL;

namespace API.Controllers
{
    public class IngredientController : ApiController
    {
        public List<IngredientDTO> Get(int receiptId)
        {
            List<Ingredient> ingrs = IngredientDataAccess.GetIngredients(receiptId);

            List<int> prodIds = new List<int>();
            foreach(Ingredient ingr in ingrs)
                prodIds.Add(ingr.ProductId);

            return Converting.IngredientToDto(ingrs);
        }

        public HttpResponseMessage Post(List<IngredientDTO> ingrs)
        {
                IngredientDataAccess.RefreshIngredients(ingrs);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
