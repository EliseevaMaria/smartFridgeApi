using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public static class Converting
    {
        public static List<ReceiptDTO> ReceiptsToDto(List<Receipt> receipts)
        {
            List<ReceiptDTO> result = new List<ReceiptDTO>(receipts.Count);
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = new ReceiptDTO
                {
                    Name = receipts[i].Name,
                    IsPrivate = receipts[i].IsPrivate,
                    Type = receipts[i].Type
                };
            }
            return result;
        }
    }
}
