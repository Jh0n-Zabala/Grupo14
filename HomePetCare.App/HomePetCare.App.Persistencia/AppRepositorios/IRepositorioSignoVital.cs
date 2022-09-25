using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;


namespace HomePetCare.App.Persistencia
{
    public interface IRepositorioSignoVital
    {
        SignoVital AddSignoVital(SignoVital signoVital);
    }

}