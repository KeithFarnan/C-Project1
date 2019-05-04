using System;

namespace Assignment7
{
    // contract variables with getter and setter methods
    public class Contract
    {
        public int ContractId { get; set; }
        public int ClientId { get; set; }
        // the value of the Contract
        public double Contract_Value { get; set; }
        // the remaining amount that the client owes
        public double AmountOwed { get; set; }
        // the date the Contract was taken out
        public DateTime StartDate { get; set; }
        // the date the Contact was fully paid off. it is nullable because it may not have still be open
        public DateTime? EndDate { get; set; }
    }
}