using System;
using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class OrderTransaction : LogableEntity
    {
        public Order Order { get; set; }
        public decimal Value { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ProcessDate { get; set; }
        public TransactionStatus ResultStatus { get; set; }
        public string Errors { get; set; }
        public string Reference { get; set; }
        public string Note { get; set; }
    }
}
