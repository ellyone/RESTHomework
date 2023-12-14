using System;
using System.Text.Json.Serialization;

namespace WebClient
{
    public class Customer
    {
        public long? ID { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public Customer()
        {
            
        }
        
        public Customer(long? id, string firstname, string lastname)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public override string ToString()
        {
            if (this.ID is null)
            {
                return "Empty customer";
            }
            else
            {
                return string.Format("Id {0}, First name {1}, Last name {2}", ID, FirstName, LastName);
            }
        }
    }
    
}