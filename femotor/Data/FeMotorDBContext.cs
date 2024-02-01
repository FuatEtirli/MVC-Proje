
using femotor.Models;
using Microsoft.EntityFrameworkCore;

namespace femotor.Data
{
    public class FeMotorDBContext : DbContext
    {
        public FeMotorDBContext(DbContextOptions<FeMotorDBContext> options) : base(options) { }

        public DbSet<Rolee> Rolees { get; set; }
        public DbSet<Userr> Userrs { get; set; }


        public DbSet<Motor> Motors { get; set; }
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<GearType> GearTypes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
       

      
        




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rolee>().HasData(

                new Rolee { RoleeID = 1, RoleeName = "Aday" },
                new Rolee { RoleeID = 2, RoleeName = "Uye" },
                new Rolee { RoleeID = 3, RoleeName = "Admin" },
                new Rolee { RoleeID = 4, RoleeName = "Supervisor" }
                );

            modelBuilder.Entity<Userr>().HasData(

                new Userr { UserrID = 1, Emaill = "aday@hotmail.com", Passwordd = "123456", RoleeID = 1 },
                new Userr { UserrID = 2, Emaill = "uye@hotmail.com", Passwordd = "123456", RoleeID = 2 },
                new Userr { UserrID = 3, Emaill = "admin@hotmail.com", Passwordd = "123456", RoleeID = 3 },
                new Userr { UserrID = 4, Emaill = "supervisor@hotmail.com", Passwordd = "123456", RoleeID = 4 },
                new Userr { UserrID = 5, Emaill = "uye2@hotmail.com", Passwordd = "123456", RoleeID = 2 }
                );
            modelBuilder.Entity<BodyType>().HasData(
                new BodyType { BodyTypeID = 1, BodyTypeName = "SuperSport" },
                new BodyType { BodyTypeID = 2, BodyTypeName = "Naked" },
                new BodyType { BodyTypeID = 3, BodyTypeName = "Scooter" },
                new BodyType { BodyTypeID = 4, BodyTypeName = "Touring" }
            );

            modelBuilder.Entity<GearType>().HasData(
                new GearType { GearTypeID = 1, GearTypeName = "Otomatik" },
                new GearType { GearTypeID = 2, GearTypeName = "Manuel" }
               
            );
           
            modelBuilder.Entity<Color>().HasData(
                new Color { ColorID = 1, ColorName = "Beyaz" },
                new Color { ColorID = 2, ColorName = "Siyah" },
                new Color { ColorID = 3, ColorName = "Gri" },
                new Color { ColorID = 4, ColorName = "Mavi" },
                new Color { ColorID = 5, ColorName = "Kırmızı" }
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandID = 1, BrandName = "Yamaha" },
                new Brand { BrandID = 2, BrandName = "Kawasaki" },
                new Brand { BrandID = 3, BrandName = "BMW" },
                new Brand { BrandID = 4, BrandName = "Suzuki" },
                new Brand { BrandID = 5, BrandName = "Honda" },
                new Brand { BrandID = 6, BrandName = "Ducati" }
               
            );

            modelBuilder.Entity<Motor>().HasData(
                new Motor { MotorID = 1,BodyTypeID = 1,BodyTypeName="SuperSport",BodyType = "SuperSport" ,Brand = "Ducati", Color = "Siyah", GearType = "Otomatik", MotorModel = "V4S", EngineVolume = 600, ModelYear = 2022, Price = Convert.ToDecimal(500000) },
                new Motor { MotorID = 2,BodyTypeID = 2,BodyTypeName="Naked",BodyType = "Naked" ,Brand = "BMW", Color = "Siyah", GearType = "Otamatik", MotorModel = "S1000RR", EngineVolume = 990, ModelYear = 2022, Price = Convert.ToDecimal(5000000) },
                new Motor { MotorID = 3,BodyTypeID = 4,BodyTypeName="Turing",BodyType = "Turing" ,Brand = "BMW", Color = "Siyah", GearType = "Manuel", MotorModel = "GS1000", EngineVolume = 990, ModelYear = 2022, Price = Convert.ToDecimal(5000000) },
                new Motor { MotorID = 4,BodyTypeID = 3,BodyTypeName="Scooter",BodyType = "Scooter", Brand = "Yamaha", Color = "Gri", GearType = "Manuel", MotorModel = "R1", EngineVolume = 1100, ModelYear = 2022, Price = Convert.ToDecimal(450000) }
              );
            


            
        }   
    }
}