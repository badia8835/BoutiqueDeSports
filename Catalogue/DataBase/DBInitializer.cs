using Catalogue.Models;

namespace Catalogue.DataBase
{
    public static class DBInitializer
    {
        public static void Initialize(CatalogueContext context)
        {
            // Vérifier s’il existe au moins un element d'Hockey.
            if (context.Hockeys.Any())
            {
                return;   // DB déjà populée
            }

            context.Hockeys.Add(new Hockey
            {
                NomProduit = "Jetspeed FT670 Sr - Patins de hockey pour senior",
                DescriptionDetaillee = "Patins de hockeyBotte monocoque pour une tenue plus près du piedDoublure en microfibre HD pour une grande résistance à l’usureLanguette asymétrique en feutre de 7 mm avec protection moulée contre la pression des lacetsAssise plantaire OrtholiteMD moulée pour un confort amélioréIndex de performance de rigidité de 150 pour une coque rigidePorte-lame Speedblade XS avec système de verrouillage de lame BladeLock et lame XS en acier inoxydable",
                Marque = "CCM",
                Taille = "8",
                Categorie = "Hockey",
                QuantiteEnInventaire = 2
            });
            context.Baseballs.Add(new Baseball
            {
                NomProduit = "Softball Series (13 po) - Gant de voltigeur de balle-molle pour adulte",
                DescriptionDetaillee = "Gant de voltigeur de balle-molleCuir souple pour une durabilité accrue et une meilleure rétention de forme du panierDoublure coussinée à la paume et aux doigts pour un confort accruPaume et index rembourrés pour une protection amélioréeDos Neo-FlexMC avec attache autoagrippante pour un ajustement personnaliséPanier Pro H13 po",
                Marque = "RAWLINGS",
                Taille = "13, Main Droite",
                Categorie = "Baseball",
                QuantiteEnInventaire = 20
            });
            context.Soccers.Add(new Soccer
            {
                NomProduit = "X CrazyFast Messi.4 FXG - Chaussures de soccer extérieur pour adulte",
                DescriptionDetaillee = "Améliorez votre jeu avec les chaussures de soccer extérieur pour adulte X CrazyFast Messi.4 FXG de Adidas. Douce et durable, l'empeigne en tissu enduit est conçue pour aider au contrôle du ballon lorsque vous driblez à grande vitesse, tandis que la semelle intercalaire en EVA et la languette perforée vous aident à rester confortable. La semelle d'usure en caoutchouc adhérente, quant à elle, vous permet de rester rapide sur une multitude de surfaces.",
                Marque = "Adidas",
                Taille = "11",
                Categorie = "Soccer",
                QuantiteEnInventaire = 6
            });

            context.Velos.Add(new Velo
            {
                NomProduit = "FDR (20 po) - Vélos BMX",
                DescriptionDetaillee = "Sautez sur ce cheval d’acier qui donne au cycliste la pleine maîtrise de sa conduite avec le vélo BMX FDR (20 po) de Capix. Ajoutez-y un rotor Giro intégré et un pédalier 3 pièces et vous avez un cuirassé qui peut aller partout.",
                Marque = "CAPIX",
                Taille = "20",
                Categorie = "Velo",
                QuantiteEnInventaire = 8
            });

            context.SaveChanges();
        }

        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CatalogueContext>();
                    Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
