using System.Collections.Generic;
using System.Linq;
using HouseOfCulture.Models.Entities;
using HouseOfCulture.ViewModels.Base;

namespace HouseOfCulture.ViewModels
{
    public class RequestsTableViewModel : BaseViewModel
    {
        private List<Request> _requests;

        public List<Request> Requests
        {
            get => _requests;
            set => SetField(ref _requests, value);
        }

        public RequestsTableViewModel()
        {
            Requests = HouseOfCultureEntities.GetContext().Requests.ToList();
        }
    }
}