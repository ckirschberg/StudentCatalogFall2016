namespace StudentCatalogFall2016.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentCatalogFall2016.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentCatalogFall2016.Models.ApplicationDbContext";
        }

        protected override void Seed(StudentCatalogFall2016.Models.ApplicationDbContext context)
        {
            //first param used to check if exists already: http://blogs.msdn.com/b/rickandy/archive/2013/02/12/seeding-and-debugging-entity-framework-ef-dbs.aspx
            context.Students.AddOrUpdate(s => s.Email, new StudentModel[]
            {
                new StudentModel
                {
                    Firstname = "Christian",
                    Lastname =  "Kirschberg",
                    Email = "ckirschberg@gmail.com",
                    MobilePhone = "61690509"
                },
                new StudentModel
                {
                    Firstname = "Hans",
                    Lastname = "Hansen",
                    Email = "hans@hans.dk",
                    MobilePhone = "12345678",
                },
                new StudentModel
                {
                    Firstname = "Jens",
                    Lastname = "Jensen",
                    Email = "jens@jens.dk",
                    MobilePhone = "12345638",
                },
                new StudentModel
                {
                    Firstname = "Helle",
                    Lastname = "Hellesen",
                    Email = "helle@helle.dk",
                    MobilePhone = "12345632",
                },
                new StudentModel
                {
                    Firstname = "Berit",
                    Lastname = "Beritsen",
                    Email = "berit@berit.dk",
                    MobilePhone = "12345631",
                },
                new StudentModel
                {
                    Firstname = "Allan",
                    Lastname = "Allansen",
                    Email = "allan@allan.dk",
                    MobilePhone = "12345632",
                },
                new StudentModel
                {
                    Firstname = "Jesper",
                    Lastname = "Jespersen",
                    Email = "jesper@jesper.dk",
                    MobilePhone = "12315631",
                }
            });



            //get a ref. to the UserManager
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("admin"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //create an object of the ApplicationUser and provide a username
            var client1 = new ApplicationUser { UserName = "chrk@kea.dk" };

            //Add the client1 object to the database through the usermanager (and suply password).
            var result1 = userManager.Create(client1, "P_assw0rd1");

            //If that does not go well (username could already exist), look up the user instead.
            if (result1.Succeeded == false)
            {
                client1 = userManager.FindByName("chrk@kea.dk");
            }

            //save this change to the database to get the GUID that is used as an Id.
            context.SaveChanges();

            //Now when creating new users you can use this value.

            //Add the following to Student
            //UserId = client.Id

            userManager.AddToRole(client1.Id, "admin");

        }
    }
}
