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
                    Id = receipts[i].Id,
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
                    ReceiptId = ingredients[i].RecieptId,
                    Product = prod,
                    Amount = ingredients[i].Amount,
                    Measure = prod.Measure.Trim()
                });
            }
            return result;
        }

        public static List<FridgeProductDTO> FridgeProductToDto(List<FridgeProduct> prods)
        {
            List<FridgeProductDTO> result = new List<FridgeProductDTO>();
            for (int i = 0; i < prods.Count; i++)
            {
                Product prod = ProductDataAccess.GetProduct(prods[i].ProductId);
                result.Add(new FridgeProductDTO
                {
                    Id = prods[i].Id,
                    Product = prod,
                    Amount = prods[i].Amount,
                    DateMade = prods[i].DateMade,
                    MinAmount = prods[i].MinAmount
                });
            }
            return result;
        }

        public static List<Ingredient> DtoToIngredient(List<IngredientDTO> ingrs)
        {
            return null;
        }

        public static void DtoToReceipt(List<ReceiptDTO> receipt)
        {

        }


        public static bool UseReceipt(int id)
        {
            List<Ingredient> ingrs = IngredientDataAccess.GetIngredients(id);
            string user = ReceiptDataAccess.GetUser(id);
            List<FridgeProduct> prods = ProductDataAccess.GetFridgeProducts(user);
            float[] amounts = new float[ingrs.Count];
            int[] ids = new int[ingrs.Count];

            for (int i = 0; i < ingrs.Count; i++)
            {
                int index = prods.FindIndex(x => x.ProductId == ingrs[i].ProductId);
                if (index > 0)
                {
                    if (ingrs[i].Amount > prods[index].Amount)
                    {
                        return false;
                    }
                    else
                    {
                        ids[i] = index;
                        amounts[i] = ingrs[i].Amount - prods[index].Amount;
                    }
                }
                else
                    return false;
            }

            ProductDataAccess.SetAmounts(ids, amounts);

            return true;
        }
    }
}
