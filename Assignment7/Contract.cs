using System;

namespace Assignment7
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int ClientId { get; set; }
        // the value of the loan
        public double Contract_Value { get; set; }
        // the remaining amount that the client owes you
        public double AmountOwed { get; set; }
        // the date the loan was taken out
        public DateTime StartDate { get; set; }
        // the date the loan was fully paid off. it is nullable because it may not have still be open
        public DateTime? EndDate { get; set; }
    }
}