using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule03
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialiserDatas();

            /*var auteurs = ListeAuteurs;
            var livres = ListeLivres;*/
            Console.WriteLine("Liste de tous les auteurs : ");
            foreach (var auteur in ListeAuteurs)
            {
                Console.WriteLine(auteur.Nom);
            }

            var auteursNomG = ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Select(a => a.Prenom);
            foreach (var auteur in auteursNomG)
            {
                Console.WriteLine($"Liste de tous les auteurs dont le nom commence par G : {auteur} \n");
            }

            // Afficher l auteur ayant écrit le plus de livres
            Console.WriteLine("L'auteur ayant écrit le plus de livres : ");
            var autMaxLivre = ListeLivres.Select(a => a.Auteur).First();
            Console.WriteLine(autMaxLivre.Nom);


            var auteurMaxLivres = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(n => n.Count()).First().Key;

            Console.WriteLine("L'auteur ayant écrit le plus de livres : " + auteurMaxLivres.Nom);

            //Afficher le nombre moyen de pages par livre par auteur
            var pageMoyenLivres = ListeLivres.GroupBy(l => l.Auteur);

            foreach (var element in pageMoyenLivres)
            {
                Console.WriteLine($"{element.Key.Prenom} {element.Key.Nom} écrit en moyenne {element.Average(e => e.NbPages)} pages");
            }

            //Afficher le titre du livre avec le plus de pages
            var livreMaxPAge = ListeLivres.OrderByDescending(p => p.NbPages).First();
            Console.WriteLine($"Le livre ayant le max de pages est : {livreMaxPAge.Titre}");


            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
            var gagnerAuteur = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));

            Console.WriteLine($"En moyenne les autteurs ont gangé {gagnerAuteur} €");


            //Afficher les auteurs et la liste de leurs livres
            var auteurs = ListeAuteurs;
            var livres = ListeLivres;

/*            foreach (var auth in ListeAuteurs)
            {
                Console.WriteLine("Auteur : " + auth.Nom);

                foreach (var livreParAuth in ListeLivres)
                {
                    Console.WriteLine(livreParAuth.Titre);
                }
            }*/

            //Afficher les titres de tous les livres triés par ordre alphabétique
            var listeLivreCroissant = ListeLivres.OrderBy(l => l.Titre).Select(t => t.Titre);

            Console.WriteLine("Liste des livres par ordre alphabétique");
            foreach (var livreAlph in listeLivreCroissant)
            {
                Console.WriteLine(livreAlph);
            }


            //Afficher la liste des livres dont le nombre de page s est supérieur à la moyenne
            var moyennePage = ListeLivres.Average(p => p.NbPages);
            var livresSupMoyenne = ListeLivres.Where(p => p.NbPages > moyennePage);

            Console.WriteLine($"Liste des livres dont le nombre de page est sup a {moyennePage} :");
            foreach (var livreSup in livresSupMoyenne)
            {
                Console.WriteLine( livreSup.Titre);
            }


            //Afficher l'auteur ayant écrit le moins de livres
            Console.WriteLine("L'auteur ayant écrit le moins de livres : ");
            var authMoinsLivre = ListeLivres.Select(a => a.Auteur).Last();
            Console.WriteLine(authMoinsLivre.Nom); 


            Console.ReadKey();
        }

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).AddFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).AddFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).AddFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).AddFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).AddFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
