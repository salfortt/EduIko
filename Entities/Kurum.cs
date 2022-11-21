using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Kurum
    {
        public ObjectId id { get; set; }
        public KurumTicariBilgi KurumTicaraiBilgi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public List<KurumSube> Subeleri { get; set; }
        public List<ObjectId> KurumIlgilileri { get; set; }
        public List<IletisimBilgi> KurumIletisim { get; set; }
        public List<Yetki> KurumYetkiSinirlari { get; set; }
        public bool AktifMi { get; set; }
    }

    public class KurumSube
    {
        public ObjectId id { get; set; }
        public string SubeAdi { get; set; }
        public List<User> KurumIlgilileri { get; set; }
        public KurumuSubeTipi KurumuSubeTipi { get; set; }
        public EgitimKurumuTipi KurumTipi { get; set; }
        public List<IletisimBilgi> SubeIletisim { get; set; }
        public Yetki EgitimKurumYetkiSinirlari { get; set; }//Erişilebilecek yetki seviye belirleme, Müdür,Admin görebilir gibi
        public bool AktifMi { get; set; }

    }
    public class KurumTicariBilgi
    {
        public string KurumAdi { get; set; }
        public int KurumTicariId { get; set; }
        public string KurumVergiDairesi { get; set; }
        public Int64 KurumVergiNosu { get; set; }

    }
    public enum EgitimKurumuTipi
    {
        AnaOkulu = 1,
        IlkOkul = 2,
        OrtaOkulu = 3,
        Lise = 4,
        Universite = 5,
        Kurs = 6,
        OzelDersBurosu = 7,
        BireyselOgretmen = 8,
        YayinFirmasi=9


    }
    public enum KurumuSubeTipi
    {
        Merkez = 1,
        Sube = 2,
        Ofis = 3,
        Franchise = 4

    }
}