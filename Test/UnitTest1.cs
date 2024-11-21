using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ParkeringshusTester
{
    public class ParkingGarage
    {
        private readonly Dictionary<int, string> _parkeringsplatser = new();

        public bool TilldelaPlats(int platsnummer, string fordonId)
        {
            if (_parkeringsplatser.ContainsKey(platsnummer))
            {
                return false; 
            }

            _parkeringsplatser[platsnummer] = fordonId;
            return true;
        }

        public bool �rPlatsLedig(int platsnummer)
        {
            return !_parkeringsplatser.ContainsKey(platsnummer);
        }

        public string H�mtaFordonP�Plats(int platsnummer)
        {
            return _parkeringsplatser.ContainsKey(platsnummer) ? _parkeringsplatser[platsnummer] : null;
        }
    }

    [TestClass]
    public class ParkeringshusTester
    {
        [TestMethod]
        public void TilldelaPlats_SkaReturneraSant_N�rPlats�rLedig()
        {
            var garage = new ParkingGarage();
            int platsnummer = 1;
            string fordonId = "ABC123";
            bool resultat = garage.TilldelaPlats(platsnummer, fordonId);
            Assert.IsTrue(resultat, "Platsen borde tilldelas korrekt.");
        }

        [TestMethod]
        public void TilldelaPlats_SkaReturneraFalskt_N�rPlats�rUpptagen()
        {
            
            var garage = new ParkingGarage();
            int platsnummer = 1;
            string fordonId1 = "ABC123";
            string fordonId2 = "DEF456";
            garage.TilldelaPlats(platsnummer, fordonId1);
            bool resultat = garage.TilldelaPlats(platsnummer, fordonId2);
            Assert.IsFalse(resultat, "Platsen ska inte kunna tilldelas igen om den �r upptagen.");
        }

        [TestMethod]
        public void �rPlatsLedig_SkaReturneraSant_N�rPlats�rFri()
        {
            
            var garage = new ParkingGarage();
            int platsnummer = 2;          
            bool �rLedig = garage.�rPlatsLedig(platsnummer);          
            Assert.IsTrue(�rLedig, "Platsen borde vara ledig.");
        }

        [TestMethod]
        public void �rPlatsLedig_SkaReturneraFalskt_N�rPlats�rUpptagen()
        {
            
            var garage = new ParkingGarage();
            int platsnummer = 1;
            string fordonId = "ABC123";

            garage.TilldelaPlats(platsnummer, fordonId);

            
            bool �rLedig = garage.�rPlatsLedig(platsnummer);

            
            Assert.IsFalse(�rLedig, "Platsen borde inte vara ledig.");
        }

        [TestMethod]
        public void H�mtaFordonP�Plats_SkaReturneraFordonId_N�rPlats�rUpptagen()
        {
            
            var garage = new ParkingGarage();
            int platsnummer = 1;
            string fordonId = "ABC123";

            garage.TilldelaPlats(platsnummer, fordonId);

           
            string resultat = garage.H�mtaFordonP�Plats(platsnummer);

           
            Assert.AreEqual(fordonId, resultat, "Korrekt fordon-ID borde returneras.");
        }

        [TestMethod]
        public void H�mtaFordonP�Plats_SkaReturneraNull_N�rPlats�rTom()
        {
            
            var garage = new ParkingGarage();
            int platsnummer = 1;

            string resultat = garage.H�mtaFordonP�Plats(platsnummer);

            Assert.IsNull(resultat, "Inget fordon-ID borde returneras f�r en tom plats.");
        }
    }
}
