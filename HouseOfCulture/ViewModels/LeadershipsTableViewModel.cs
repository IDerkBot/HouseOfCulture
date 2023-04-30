using System.Collections.Generic;
using System.Linq;
using HouseOfCulture.Models.Entities;
using HouseOfCulture.ViewModels.Base;

namespace HouseOfCulture.ViewModels
{
    public class LeadershipsTableViewModel : BaseViewModel
    {
        private List<Leadership> _leaderships;

        public List<Leadership> Leaderships
        {
            get => _leaderships;
            set => SetField(ref _leaderships, value);
        }

        public LeadershipsTableViewModel()
        {
            Leaderships = HouseOfCultureEntities.GetContext().Leaderships.ToList();
        }
    }
}