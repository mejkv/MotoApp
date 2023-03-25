using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Data.Entities
{
    public class Car : EntityBase
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public decimal StandartCost { get; set; }

        public decimal ListPrice { get; set; }

        public string Type { get; set; }

        public int? NameLength { get; set; }

        public decimal? TotalSales { get; set; }

        #region ToString Override
        public override string ToString()
        {
            StringBuilder sb = new(1024);
            sb.AppendLine($"{Name}  ID: {Id}");
            sb.AppendLine($"   Color: {Color}   Type: {Type ?? "n/a"}");
            sb.AppendLine($"   Cost: {StandartCost:c}   Price: {ListPrice:c}");
            if (NameLength.HasValue)
            {
                sb.AppendLine($"    Name Length: {NameLength}");
            }
            if (TotalSales.HasValue)
            {
                sb.AppendLine($"    Total sales: {TotalSales}");
            }
            return sb.ToString();
        }
        #endregion
    }
}
