using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BusinessLayer
{
    public static class Converting
    {
        public static List<ReceiptDTO> ReceiptsToDto(List<Receipt> receipts)
        {
            List<ReceiptDTO> result = new List<ReceiptDTO>(receipts.Count);
            for (int i = 0; i < receipts.Count; i++)
            {
                result.Add(new ReceiptDTO
                {
                    Name = receipts[i].Name,
                    IsPrivate = receipts[i].IsPrivate,
                    Type = receipts[i].Type
                });
            }
            return result;
        }

        public static List<IngredientDTO> IngredientToDto(List<Ingredient> ingredients)
        {
            List<IngredientDTO> result = new List<IngredientDTO>();
            for (int i = 0; i < ingredients.Count; i++)
            {
                Product prod = ProductDataAccess.GetProduct(ingredients[i].ProductId);
                result.Add(new IngredientDTO
                {
                    Name = prod.Name.Trim(),
                    Amount = ingredients[i].Amount,
                    Measure = prod.Measure.Trim()
                });
            }
            return result;
        }
    }
}
