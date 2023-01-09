using System.Collections.Generic;
using Zadatak.Models;

namespace Zadatak.Dal
{
    public interface IRepository
    {
        void AddPerson(Person person);
        void DeletePerson(Person person);
        IList<Person> GetPeople();
        Person GetPerson(int idPerson);
        void UpdatePerson(Person person);


        //project
        void AddShoes(Shoes shoes);
        void DeleteShoes(Shoes shoesn);
        IList<Shoes> GetAllShoesForSinglePerson(int personId);
        Shoes GetPairOfShoes(int idPerson);
        void UpdateShoes(Shoes shoes);
    }
}