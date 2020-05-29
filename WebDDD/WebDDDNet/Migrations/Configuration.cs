namespace WebDDDNet.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WebDDDNet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; // CAMBIAR ESTO a false
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebDDDNet.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //InicializarIdentity(context);
        }

        /// <summary>
        /// Iniciamos la base de datos si no tenemos usuarios creados:        /// 
        /// Creamos el usuario admin/IoT@123 por defecto para la aplicación.
        /// Creamos el role SuperAdministrador y asignamos al usuario admin.
        /// Creamos el resto de roles y datos.
        /// </summary>
        /// <param name="db">Contexto de la BBDD</param>
        //public static void InicializarIdentity(ApplicationDbContext db)
        //{
        //    var userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    if (userManager.Users.Count() == 0)
        //    {
        //        // var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

        //        const string userName = "admin";
        //        // const string userRealName = "Website super administrator";
        //        const string userMail = "antoniocasas7@gmail.com";
        //        const string userPassword = "IoT@123";
        //        const string userPhoneNumber = "957123335";
        //        const string roleName = "SuperAdministrador";
        //        // const string roleDescription = "Superadministrator of Web Platform";

        //        // Creamos los roles si no existen
        //        //var roles = new List<ApplicationRole>
        //        //    {
        //        //        new ApplicationRole { Id = "1", Name = roleName, Descripcion = roleDescription },
        //        //        new ApplicationRole { Id = "3", Name = "Administrador", Descripcion = "Manage a company." },
        //        //        new ApplicationRole { Id = "4", Name = "Usuario", Descripcion = "User of a company." }
        //        //    };
        //        //// Creamos cada uno de ellos si no existe
        //        //foreach (ApplicationRole role in roles)
        //        //    if (roleManager.FindByName(role.Name) == null)
        //        //        roleManager.Create(role);

        //        //Creamos los idiomas si no existen
        //        if (db.Idiomas.Count() == 0)
        //        {
        //            var idiomas = new List<Idioma>
        //                {
        //                    new Idioma { Id = 1, Nombre = "Espanol", Cultura = "es-ES", Icono = "Spain.png", FechaCreacion = DateTime.Now, UsuarioIdCreacion = "0" },
        //                    new Idioma { Id = 2, Nombre = "Ingles", Cultura = "en-GB", Icono = "United-Kingdom.png", FechaCreacion = DateTime.Now, UsuarioIdCreacion = "0" },
        //                    new Idioma { Id = 3, Nombre = "Aleman", Cultura = "de-DE", Icono = "Aleman.png", FechaCreacion = DateTime.Now, UsuarioIdCreacion = "0" },
        //                    new Idioma { Id = 4, Nombre = "Frances", Cultura = "fr-FR", Icono = "France.png", FechaCreacion = DateTime.Now, UsuarioIdCreacion = "0" }
        //                };
        //            db.Idiomas.AddRange(idiomas);
        //            db.SaveChanges();
        //        }

        //        // Creamos el usuario admin si no existe
        //        var user = userManager.FindByName(userName);
        //        if (user == null)
        //        {
        //            user = new ApplicationUser { UserName = userName, Email = userMail, PhoneNumber = userPhoneNumber, EmailConfirmed = true, LockoutEnabled = false };
        //            var result = userManager.Create(user, userPassword);
        //            result = userManager.SetLockoutEnabled(user.Id, false);
        //        }

        //        // Añadimos el rol SuperAdministrador al usuario admin, si no lo tiene ya
        //        //var rolesForUser = userManager.GetRoles(user.Id);
        //        //if (!rolesForUser.Contains(roleName))
        //        //    userManager.AddToRole(user.Id, roleName);

        //        //var fechaCreacion = DateTime.Now;

        //        db.SaveChanges();

        //    }
        //}
    }
}
