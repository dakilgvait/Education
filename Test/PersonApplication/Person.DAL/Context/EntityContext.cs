using Microsoft.EntityFrameworkCore;
using Person.DAL.Entity;
using randomuser;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.DAL.Context
{
    public class EntityContext : ConfigContext
    {
        public DbSet<PersonEntity> PersonEntities { get; set; }
        public DbSet<GenderEntity> GenderEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonEntity>()
                .HasIndex(b => b.PersonNumber).IsUnique();

            var genders = this.InitializeGenders(modelBuilder);
            this.InitializePersons(modelBuilder, genders);
        }

        private Dictionary<GenderType, int> InitializeGenders(ModelBuilder modelBuilder)
        {
            var genders = new Dictionary<GenderType, int>() {
                { GenderType.MALE, 1 },
                { GenderType.FEMALE, 2 }
            };
            modelBuilder.Entity<GenderEntity>().HasData(
                new GenderEntity() { Id = genders[GenderType.MALE], Code = GenderType.MALE, Name = "Male" },
                new GenderEntity() { Id = genders[GenderType.FEMALE], Code = GenderType.FEMALE, Name = "Female" });

            return genders;
        }

        private void InitializePersons(ModelBuilder modelBuilder, Dictionary<GenderType, int> genders)
        {
            var client = new RestClient("https://randomuser.me/api/?results=25&nat=us");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Rootobject json = fastJSON.JSON.ToObject<Rootobject>(response.Content);
            Random generator = new Random();
            int id = 0;
            var entities = json.results.Select(i => new PersonEntity() {
                Birthdate = i.dob.date,
                FirstName = i.name.first,
                LastName = i.name.last,
                PersonNumber = generator.Next(0, 10000000).ToString("D11"),
                Salary = generator.Next(0, 10000000),
                GenderId = genders[Enum.Parse<GenderType>(i.gender, true)],
                Id = ++id
            }).ToArray();
            modelBuilder.Entity<PersonEntity>().HasData(entities);
        }
    }
}