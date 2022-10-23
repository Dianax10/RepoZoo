using Microsoft.Extensions.Hosting;

namespace ZooApi.Models
{
    public class AreaModel
    {
        public int AreaId { get; set; }
        public int CapienzaMaxAnimali { get; set; }
        public Animal Animale { get; set;}

        public string Specie { get; set; }  

    }
}


//*Area {

//    Id

//    CapienzaMaxAnimali


//    Specie

//    Animali

//}

//*POST Area

//* InsertAnimaleInArea 

//*RicercaAreaTramiteAnimale 
