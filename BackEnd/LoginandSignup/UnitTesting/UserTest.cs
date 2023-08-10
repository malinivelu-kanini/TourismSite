using LoginandSignup.Models;
using LoginandSignup.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class UserTest
    {
        private DbContextOptions<UserContext> GetDbContextOptions()
        {
            var contextOptions = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "userInMemory")
                .Options;
            return contextOptions;

        }
        [TestMethod]

        public async Task AddAsync()
        {
            using (var userContext = new UserContext(GetDbContextOptions()))
            {

                userContext.Traveller.Add(new Traveller
                {
                    Username = "Sam",
                    PhoneNumber = "8877665544",


                    Users = new User
                        {
                            PasswordHash = new byte[] {},
                            PasswordKey = new byte[] {},
                            Role ="traveller",
                            Email = "sam@gmail.com"

                        },
                });
                await userContext.SaveChangesAsync();
            }
        }
        [TestMethod]

        public async Task GetTaskAsync()
        {
            //Arrange
            using (var userContext = new UserContext(GetDbContextOptions()))
            {
                var travellers = new List<Traveller>
                {
                    new Traveller
                    {
                        Username="Sam",
                        PhoneNumber = "8877665544",
                        Users = new User
                        {
                            PasswordHash= new byte[] {},
                            PasswordKey= new byte[] {},
                            Role="traveller",
                            Email = "sam@gmail.com"
                        },
                    },

                };
                userContext.Traveller.AddRange(travellers);
                await userContext.SaveChangesAsync();
            }

            //Act

            List<Traveller> retrievedTravellers;
            using (var userContext = new UserContext(GetDbContextOptions()))
            {
                retrievedTravellers = await userContext.Traveller.ToListAsync();
            }

            //Assert

        Assert.IsNotNull(retrievedTravellers);
        }

        
    }
}
