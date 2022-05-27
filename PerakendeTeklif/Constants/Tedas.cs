namespace PerakendeTeklif.Constants
{
    public static class Tedas
    {
        public enum Gerilim
        {
            OGCift = 0,
            OGTek = 1,
            AGTek =2

        }


        public enum Mesken
        {
            Sanayi,
            Ticarethane
        }

        public static double BirimFiyatAl(string gerilim,string mesken)
        {
          
            switch ((gerilim,mesken))
            {
                case ("OGCift", "Sanayi"):
                    return 0.490737;
                case ("OGCift","Ticarethane"):
                    return 0.534213;
                case ("OGTek", "Sanayi"):
                    return 0.489238;
                case ("OGTek", "Ticarethane"):
                    return 0.536809;
                case ("AGTek","Sanayi"):
                    return 0.498371;
                case ("AGTek", "Ticarethane"):
                    return 0.54212;
                default:
                    return 0;
            }       
        }


    }



}
