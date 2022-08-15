using System.Text.RegularExpressions;

namespace ShopAPI.Validation
{
    public class FullBuyValidation
    {
       public bool IsValid(string phone)
        {
            Regex regex = new(@"^(\+7|8){1}\s\d{3}\s\d{3}\-\d{2}\-\d{2}$");
            return regex.IsMatch(phone.ToString());
        }
    }
}
