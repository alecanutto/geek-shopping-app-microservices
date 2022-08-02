using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GeekShooping.Product.API.Model.Context
{
    public class ProductDbContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.Development.json")
                   .Build();

                optionsBuilder.UseLoggerFactory(_logger).EnableSensitiveDataLogging()
                    .UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                     p => p.MigrationsHistoryTable("ProductDbContext")
                    .EnableRetryOnFailure(
                         maxRetryCount: 2,
                         maxRetryDelay: TimeSpan.FromSeconds(5),
                         errorCodesToAdd: null));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            FixForgotProperties(modelBuilder);

            modelBuilder.Entity<Category>().HasData(ListCategory());
            modelBuilder.Entity<Product>().HasData(ListProduct());
        }

        private static void FixForgotProperties(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
             .SelectMany(t => t.GetProperties())
             .Where(p => p.ClrType == typeof(string)))
            {
                if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                {
                    property.SetMaxLength(150);
                }
            }
        }

        private static List<Product> ListProduct()
        {
            var products = new List<Product>()
            {
                new Product() {
                    Id = 1,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567048-13938600-aa33-11e9-9cfd-712191013192.jpeg",
                    Name = "The Quantified Cactus = An Easy Plant Soil Moisture Sensor",
                    Description = " This project is a good learning project to get comfortable with soldering and programming an Arduino.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                    },
                new Product() {
                    Id = 2,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567049-13938600-aa33-11e9-9c69-a4184bf8e524.jpeg",
                    Name = "A beautiful switch-on book light",
                    Description = " Use craft items you have around the house, plus two LEDs and a LilyPad battery holder, to create a useful book light for reading in the dark.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                    },
                new Product() {
                    Id = 3,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567053-13938600-aa33-11e9-9780-104fe4019659.png",
                    Name = "Bling your Laptop with an Internet-Connected Light Show",
                    Description = " Create a web-connected light-strip API controllable from your website, using the Particle.io.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 4,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567051-13938600-aa33-11e9-8ae7-0b5c19aafab4.jpeg",
                    Name = "Create a Compact Survival Kit with LED Track Lighting",
                    Description = " Use an Altoids tin with Chibitronics sticker LEDs to create a light-up compact that doubles as a survival kit for the young hipster",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 5,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567054-13938600-aa33-11e9-9163-eec98e239b7a.png",
                    Name = "Bubblesort Visualization",
                    Description = " Visualization of sailor scouts sorted by bubblesort algorithm by their planet's distance from the sun",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 6,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567055-142c1c80-aa33-11e9-96ff-9fbac6413625.png",
                    Name = "Light-up Corsage",
                    Description = " Light-up corsage I made with my summer intern.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 7,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567056-142c1c80-aa33-11e9-8682-10065d338145.png",
                    Name = "Pastel hardware kit",
                    Description = " Pastel hardware kits complete with custom manufactured pastel alligator clips.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 8,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567052-13938600-aa33-11e9-9a88-cd842073ba44.jpg",
                    Name = "Heart-shaped LED",
                    Description = " custom molded heart shaped LED with sprinkles.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 9,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567060-142c1c80-aa33-11e9-8188-5a4803844a9e.png",
                    Name = "Black Sweatshirt",
                    Description = " Black sweatshirt hoody with the Sick of the Internet logo.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 10,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567059-142c1c80-aa33-11e9-939b-2ecf4492786d.png",
                    Name = "Sick of the Internet Pins",
                    Description = " Still some time to enter the pin/sticker giveaway! ",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 11,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567061-14c4b300-aa33-11e9-9fee-63ff2c0c9823.png",
                    Name = "Hipster Dev",
                    Description = " Hipster Dev is busy coding away while styled in a camo jacket and orange beanie.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 12,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567062-14c4b300-aa33-11e9-9dcd-8bfed4ece810.png",
                    Name = "Pretty Girls Code Tee",
                    Description = " Everyone’s favorite design is finally here on a tee! The Pretty Girls Code crew-neck tee is available in a soft pink with red writing.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 13,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567063-14c4b300-aa33-11e9-8515-bcb866da9ea3.png",
                    Name = "Ruby Sis",
                    Description = " Styled in a dashiki, Ruby Sis is listening to music while coding in her favorite language, Ruby!",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 14,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567057-142c1c80-aa33-11e9-9781-9e442418eaab.png",
                    Name = "Holographic Dark Moon Necklace",
                    Description = " Not sure if I'll be making more, get it while I have it in the store.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                },
                new Product() {
                    Id = 15,
                    CategoryId = 1,
                    ImageUrl = "https://user-images.githubusercontent.com/41929050/61567058-142c1c80-aa33-11e9-89fb-b4f30d84d69d.png",
                    Name = "Floppy Crop",
                    Description = " Used up the Diskette fabric today to make 2 of these crops.",
                    Price = new decimal(19.90),
                    ProductType = Enum.ProductType.Resale
                }
            };

            return products;
        }


        private static List<Category> ListCategory()
        {
            var categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "General" },
                new Category() { Id = 2, Name = "Geek" }
            };

            return categories;
        }
    }
}
