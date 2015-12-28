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
    public class ReceiptController : ApiController
    {
        public List<ReceiptDTO> GetFridges(string email)
        {

            List<ReceiptDTO> receipts = Converting.ReceiptsToDto(ReceiptDataAccess.GetReceipts(email));
            return receipts;
        }
    }
}
