using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Entity.Models.InsuranceModels;

namespace App.Test.MockData
{
    public class PriceDataMock
    {
        public static InsurancePrice GetPrice()
        {
            return new InsurancePrice()
            {
                ProgramId = Guid.NewGuid(),
                PolicyId = Guid.NewGuid(),
                Price = 2000
            };
        }

        public static List<InsurancePrice> GetPrices()
        {
            return new EditableList<InsurancePrice>
            {
                GetPrice(),
                GetPrice(),
                GetPrice(),
            };
        }
    }
}
