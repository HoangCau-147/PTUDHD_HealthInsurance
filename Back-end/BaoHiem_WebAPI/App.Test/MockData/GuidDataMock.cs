using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test.MockData
{
    public class GuidDataMock
    {
        public static Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
