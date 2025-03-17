using CommonDLL.DTO;
using DatabaseDLL.DatabaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicDLL.BusinessRepo
{
    public class PersonsLogic
    {
        readonly PersonsRepo acc = new PersonsRepo();

        public List<Persons> ListAllPersons()
        {
            return acc.ListAllPersons();

        }

        public Persons GetPersonsById(int Id)
        {
            return acc.GetPersonsById(Id);

        }
            
        public string AddNewPersons(string name, string surname, string idNumber)
        {
            return acc.AddNewPersons(name, surname, idNumber);

        }

        public string EditPersons(int code, string name, string surname, string idNumber)
        {
            return acc.EditPersons(code, name, surname, idNumber);

        }

        public List<Persons> ListAllPersonNames()
        {
            return acc.ListAllPersonNames();

        }
        public string DeletePerson(int Code)
        {
            return acc.DeletePerson(Code);

        }
        public List<Persons> GetPersonDetails(int id)
        {
            return acc.GetPersonDetails(id);

        }
    }
}
