using System;
using System.Collections.Generic;
using System.Linq;
using CSharpIs.Domain.Data.Model;
using CSharpIs.Domain.DAL;
using Microsoft.EntityFrameworkCore;

namespace CSharpIs.Api.Seeder
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CSharpIs-API;Trusted_Connection=True;MultipleActiveResultSets=true");

            using (var context = new EntityContext(options.Options))
            {
                var tags = new List<Tag>
                {
                    new Tag
                    {
                        Value = "JSON"
                    },
                    new Tag
                    {
                        Value = "Serialization"
                    },
                    new Tag
                    {
                        Value = "Database"
                    },
                    new Tag
                    {
                        Value = "ORM"
                    },
                };

                context.Authors.Add(new Author
                {
                    DateAdded = DateTime.Now,
                    ExploreUrl = "https://github.com/JamesNK",
                    Name = "James Newton-King",
                    Projects = new List<Project>
                    {
                        new Project
                        {
                            Name = "Newtonsoft.JSON",
                            Description = "Json.NET is a popular high-performance JSON framework for .NET",
                            DateAdded = DateTime.Now,
                            DateLastUpdated = DateTime.Now,
                            ImageUrl = "https://via.placeholder.com/250x250",
                            Url = "https://github.com/JamesNK/Newtonsoft.Json",
                            Tags = new List<ProjectTag>
                            {
                                new ProjectTag
                                {
                                    Tag = tags.Single(x => x.Value == "JSON"),
                                },
                                new ProjectTag
                                {
                                    Tag = tags.Single(x => x.Value == "Serialization"),
                                },
                            }
                        }
                    }
                });

                context.Authors.Add(new Author
                {
                    DateAdded = DateTime.Now,
                    ExploreUrl = "https://github.com/aspnet",
                    Name = "ASP.NET",
                    Projects = new List<Project>
                    {
                        new Project
                        {
                            Name = "EntityFrameworkCore",
                            Description = "Entity Framework Core is a lightweight and extensible version of the popular Entity Framework data access technology",
                            DateAdded = DateTime.Now,
                            DateLastUpdated = DateTime.Now,
                            ImageUrl = "https://via.placeholder.com/250x250",
                            Url = "https://github.com/aspnet/EntityFrameworkCore",
                            Tags = new List<ProjectTag>
                            {
                                new ProjectTag
                                {
                                    Tag = tags.Single(x => x.Value == "Database"),
                                },
                                new ProjectTag
                                {
                                    Tag = tags.Single(x => x.Value == "ORM"),
                                },
                            }
                        },
                        new Project
                        {
                            Name = "EntityFramework6",
                            Description = "This is the codebase for Entity Framework 6 (previously maintained at https://entityframework.codeplex.com). Entity Framework Core is maintained at https://github.com/aspnet/EntityFrameworkCore",
                            DateAdded = DateTime.Now,
                            DateLastUpdated = DateTime.Now,
                            ImageUrl = "https://via.placeholder.com/250x250",
                            Url = "https://github.com/aspnet/EntityFramework6",
                            Tags = new List<ProjectTag>
                            {
                                new ProjectTag
                                {
                                    Tag = tags.Single(x => x.Value == "Database"),
                                },
                                new ProjectTag
                                {
                                    Tag = tags.Single(x => x.Value == "ORM"),
                                },
                            }
                        },
                    }
                });

                context.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
