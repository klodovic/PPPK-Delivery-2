using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Dal;
using Zadatak.Models;

namespace Zadatak.ViewModels
{
    public class ShoesViewModel
    {
        public ObservableCollection<Shoes> ShoeCollection { get; }
        public int PersonId { get; set; }

        public ShoesViewModel(int personId)
        {
            PersonId = personId;
            ShoeCollection = new ObservableCollection<Shoes>(RepositoryFactory.GetRepository().GetAllShoesForSinglePerson(personId));
            ShoeCollection.CollectionChanged += ShoeCollection_CollectionChanged;
        }

        private void ShoeCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddShoes(ShoeCollection[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteShoes(e.OldItems.OfType<Shoes>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateShoes(e.NewItems.OfType<Shoes>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Shoes shoes) => ShoeCollection[ShoeCollection.IndexOf(shoes)] = shoes;

    }
}
