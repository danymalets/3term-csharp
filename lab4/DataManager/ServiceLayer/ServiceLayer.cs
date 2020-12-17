using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace ServiceLayer
{
    public class ServiceLayer
    {
        DataAccessLayer.DataAccessLayer dal;

        public ServiceLayer(string connectionString)
        {
            dal = new DataAccessLayer.DataAccessLayer(connectionString);
        }

        public List<Person> GetListOfPeople()
        {
            List<Person> list = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                dal.GetPerson(list, i);
                dal.GetPassword(list, i);
                dal.GetAddress(list, i);
                dal.GetEmailAddress(list, i);
                dal.GetPhoneNumber(list, i);
            }
            return list;
        } 
    }
}
