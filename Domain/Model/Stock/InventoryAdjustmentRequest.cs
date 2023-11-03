using Domain.Enum;

namespace Domain.Model.Stock
{
    public class InventoryAdjustmentRequest
    {
        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public EReleaseFlow Flow { get; set; }
        
        public Guid ProductUuid { get; set; }
                
        public Guid StockLocationUuid { get; set; }

        
    }
}
