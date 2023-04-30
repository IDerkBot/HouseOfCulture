using System.Collections.Generic;
using System.Linq;
using HouseOfCulture.Models.Entities;
using HouseOfCulture.ViewModels.Base;

namespace HouseOfCulture.ViewModels
{
    public class GroupsTableViewModel : BaseViewModel
    {
        private List<Group> _groups;

        public List<Group> Groups
        {
            get => _groups;
            set => SetField(ref _groups, value);
        }

        public GroupsTableViewModel()
        {
            Groups = HouseOfCultureEntities.GetContext().Groups.ToList();
        }
    }
}