using System;
using System.Collections.Generic;

namespace WebClient;

public static class CustomerRandomizer
{
    public static List<string> FirstNames = new List<string>() { "Alex", "Andrew", "Ivan", "Vlad", "Oleg", "Jack", "Stephan", "Dmitriy" };
    
    public static List<string> LastNames = new List<string>() { "Ivanov", "Smirnov", "Sidorov", "Petrov", "Bulkin", "Kuprin", "Stepanov", "Romanov" };

    public static Customer CustomerRandom()
    {
        Random rnd = new Random();
        
        int firstNameNum = rnd.Next(FirstNames.Count - 1);
        int lastNameNum = rnd.Next(LastNames.Count - 1);

        return new Customer(null, FirstNames[firstNameNum], LastNames[lastNameNum]);
    }
}