using System;                                                                                                                                       
using System.Collections.Generic;                                                                                                                   
using System.Linq;                                                                                                                                  
using System.Web;                                                                                                                                   

namespace UzenetKuldoWCF.Models                                                                                                                     
{
    public class Uzenet : Tablazat                                                                                                                  
    {
        public string Szoveg { get; set; }                                                                                                          

        public DateTime KüldesiIdo { get; set; }                                                                                                    

        public string UzenetTipus { get; set; }                                                                                                     
        public string Telefon { get; set; }                                                                                                         
        public string Email { get; set; }                                                                                                           

        public override string ToString()                                                                                                           
        {
            return $"Id:{Id},Szoveg:{Szoveg},KüldesiIdo:{KüldesiIdo},UzenetTipus:{UzenetTipus},Telefon:{Telefon},Email:{Email}";                    
        }
    }
}