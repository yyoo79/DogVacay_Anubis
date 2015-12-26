using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogVacay_Anubis_1509.Models
{
    public class CalEventModel
    {        
        public string id { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string url { get; set; }
        public string color { get; set; }
        
        //public string color {
        //    get {
        //        if (String.IsNullOrEmpty(_color))
        //        {
        //            _color = colorArray[new Random().Next(0,colorArray.Length)];
        //        }
        //        return _color; 
        //    }
        //    set { _color = value; }
        //}

        public bool allDay { get; set; }        
    }
}