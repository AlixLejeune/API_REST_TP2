using Microsoft.VisualStudio.TestTools.UnitTesting;
using API_REST_TP2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_REST_TP2.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace API_REST_TP2.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests
    {
        SeriesDBContext _context = new SeriesDBContext(new DbContextOptionsBuilder<SeriesDBContext>().UseNpgsql("Server=localhost; port=5432; Database=SeriesDB; uid=postgres; password=postgres;").Options);

        [TestMethod()]
        public void SeriesControllerTest()
        {
            SeriesController controller = new SeriesController(_context);
            Assert.IsNotNull(controller);
        }

        [TestMethod()]
        public void GetSeriesTest()
        {
            SeriesController controller = new SeriesController(_context);
            IEnumerable<Serie> listeSeriesRecuperees = controller.GetSeries().Result.Value;
            Assert.IsNotNull(listeSeriesRecuperees);
            List<Serie> series = listeSeriesRecuperees.Where(s => s.Serieid <= 3).ToList();
            List<Serie> testSample = new List<Serie> { new Serie { Serieid = 1, Titre = "Scrubs", Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !"
            , Nbsaisons = 9, Nbepisodes = 184, Anneecreation = 2001, Network = "ABC (US)"}, new Serie { Serieid = 2, Titre = "James May's 20th Century",
            Resume = "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now.",
            Nbsaisons = 1, Nbepisodes = 6, Anneecreation = 2007, Network = "BBC Two"}, new Serie{ Serieid = 3, Titre = "True Blood",Resume = "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...",
            Nbsaisons = 7, Nbepisodes = 81, Anneecreation = 2008, Network = "HBO"} };
            CollectionAssert.AreEqual(testSample, series);
        }

        [TestMethod()]
        public void GetSeriesTestFail()
        {
            SeriesDBContext contextFail = new SeriesDBContext(new DbContextOptionsBuilder<SeriesDBContext>().UseNpgsql("Server=localhost; port=5432; Database=SeriesDB; uid=postgres; password=postgres;").Options);
            contextFail.Series = null;
            SeriesController controllerFail = new SeriesController(contextFail);
            
        }

        [TestMethod()]
        public void GetSerieTest()
        {
            SeriesController controller = new SeriesController(_context);
            Serie importSerie = controller.GetSerie(3).Result.Value;
            Serie testSample = new Serie
            {
                Serieid = 3,
                Titre = "True Blood",
                Resume = "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...",
                Nbsaisons = 7,
                Nbepisodes = 81,
                Anneecreation = 2008,
                Network = "HBO"
            };
            Assert.AreEqual(testSample, importSerie);
        }

        [TestMethod()]
        public void PutSerieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostSerieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteSerieTest()
        {
            Assert.Fail();
        }
    }
}