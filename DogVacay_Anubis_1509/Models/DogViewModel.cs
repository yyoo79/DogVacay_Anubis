using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogVacay_Anubis_1509.Models
{
    public class DogViewModel
    {
        public DogViewModel()
        {
            //AllHumans = new List<SelectListItem>();
        }
        public Dog Dog { get; set; }
        public IEnumerable<SelectListItem> AllStays { get; set; }

        private List<int> _selectedAllStays;
        public List<int> SelectedStays
        {
            get
            {
                if (_selectedAllStays == null)
                {
                    _selectedAllStays = Dog.Stays.Select(s => s.StayId).ToList();
                }
                return _selectedAllStays;
            }
            set { _selectedAllStays = value; }
        }
                
        [Display(Name = "-- Human List --")]
        public IEnumerable<SelectListItem> ListOfHumans { get; set; }
        public int SelectedHumanId { get; set; }
        

    }
}