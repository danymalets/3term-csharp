using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;
using ConfigurationManager;
using System.Xml.Linq;
using System.IO;

namespace DataManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config;
            try
            {
                var configurationManager = new ConfigurationManager.ConfigurationManager(@"‪C:\Users\daniel\Desktop\config.json");
                config = configurationManager.GetConfiguration();
            }
            catch
            {
                config = new Configuration();
            }
            ServiceLayer.ServiceLayer sl = new ServiceLayer.ServiceLayer($"Server={config.server};Database={config.dataBase};Trusted_Connection={config.trustedConnection};");
            List<Person> list = sl.GetListOfPeople();

            XDocument xDoc = ListToXDoc(list);
            xDoc.Save(Path.Combine(config.ftpServer, "persons.xml"));
        }
        
        static XDocument ListToXDoc(List<Person> list)
        {
            XDocument xDoc = new XDocument();
            XElement persons = new XElement("Persons");

            foreach (Person person in list)
            {
                XElement human = new XElement("Person");
                XElement firstName = new XElement("FirstName", person.FirstName);
                XElement lastName = new XElement("LastName", person.LastName);
                human.Add(firstName);
                human.Add(lastName);

                XElement password = new XElement("Password");
                XElement passwordHash = new XElement("PasswordHash", person.password.passwordHash);
                password.Add(passwordHash);

                XElement address = new XElement("Address");
                XElement addressLine = new XElement("AddressLine", person.address.AddressLine);
                XElement city = new XElement("City", person.address.City);
                XElement postalCode = new XElement("PostalCode", person.address.PostalCode);
                address.Add(addressLine);
                address.Add(city);
                address.Add(postalCode);

                XElement emailAddress = new XElement("EmailAddress");
                XElement email = new XElement("Email", person.emailAdress.Email);
                emailAddress.Add(email);

                XElement phoneNumber = new XElement("PhoneNumber");
                XElement number = new XElement("Number", person.phoneNumber.Number);
                XElement type = new XElement("Code", person.phoneNumber.Type);
                phoneNumber.Add(number);
                phoneNumber.Add(type);

                human.Add(password);
                human.Add(address);
                human.Add(emailAddress);
                human.Add(phoneNumber);

                persons.Add(human);
            }

            xDoc.Add(persons);
            return xDoc;
        }
    }
}
