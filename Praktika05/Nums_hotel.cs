//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Praktika05
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nums_hotel
    {
        public int id_num_hotel { get; set; }
        public string class_comfort { get; set; }
        public string num_hotel { get; set; }
        public string etage { get; set; }
        public string kolichestvo_people { get; set; }
        public string stoimost_ryb_za_1night { get; set; }

        public string ImPath
        {
            get
            {
                return "/Resources/" + this.class_comfort + ".jpg";
            }
        }
        public string FullViewPrice
        {
            get
            {
                return Convert.ToString(this.stoimost_ryb_za_1night) + "руб.";
            }
        }

        public string FullKolvoPeople
        {
            get
            {
                return "Вместимость: " + this.kolichestvo_people + " чел.";
            }
        }
    }
}