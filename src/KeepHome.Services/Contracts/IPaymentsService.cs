﻿namespace KeepHome.Services.Contracts
{
    public interface IPaymentsService
    {
        string Encoded { get; set; }
        string GetEncodedData(decimal amount, string description, string expDate, string invoice);
        string GetDencodedData(string encoded, string checksum);
    }
}