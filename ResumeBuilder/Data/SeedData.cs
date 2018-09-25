using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ResumeBuilderContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderContext.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                if (!context.Applicant.Any())
                {

                    //if (context.Applicant.Any())
                    //{
                    //    foreach (var current in context.Applicant)
                    //    {
                    //        context.Applicant.Remove(current);
                    //    }
                    //    context.SaveChanges();
                    //}


                    var applicant = new Applicant[]
                        {

                    new Applicant {FirstName = "Dustin", LastName = " Fleming", StreedAddress = "11409 Haines Ave Ne", City = "Albuqeruqe", State = "New Mexico",
                    ZipCode = "87112", PhoneNumber = "(505)234-2913", EmailAddress = "dfle688@gmail.com", Summary = "This is my summary"},

                    new Applicant {FirstName = "Becca", LastName = "Elbrecht", StreedAddress = " 3305 Calle Cuervo NW", City = " Albuquerque", State = "New Mexico",
                    ZipCode = "87114", PhoneNumber = " (505)730-3639", EmailAddress = "beccaelbrecht@gmail.com", Summary = "This is my summary"},

                    new Applicant {FirstName = "Diane", LastName = "Fleming", StreedAddress = "1711 Elsie St", City = "Moriarty", State = " New Mexico",
                    ZipCode = "87035", PhoneNumber = "(505)225-0338", EmailAddress = "seabiscuit58@gmail.com", Summary = "This is my summary" },

                    new Applicant {FirstName ="Delmar", LastName = "Fleming", StreedAddress = " 1711 Else St", City = "Moriarty", State = " New Mexico",
                    ZipCode = "87035", PhoneNumber = " (505)304-9415", EmailAddress = "mr59@gmail.com", Summary = "This is my summary"}

                    };
                    foreach (Applicant a in applicant)
                    {
                        context.Applicant.Add(a);
                    }
                    context.SaveChanges();
                }
                if (!context.JobHistory.Any())
                {

                    var jobhistory = new JobHistory[]
                {

                    new JobHistory {Employer = "Garcia Auto Group", City = "Albuquerque", State = "New Mexico",
                    StartMonth = "09",StartYear = "2014", CurrentlyEmployed = true,
                    Applicant = context.Applicant.Single(y => y.FirstName == "Dustin")},

                    new JobHistory {Employer = "Swiss Alps Bakery", City = "Albuquerque", State = "New Mexico",
                    StartMonth = "05", StartYear = "2016", CurrentlyEmployed = true,
                    Applicant = context.Applicant.Single(y => y.FirstName =="Becca")},

                    new JobHistory {Employer = "Self Employed", City = "Moriarty", State = "New Mexico",
                    StartMonth = "01", StartYear = "2014", CurrentlyEmployed = true,
                    Applicant = context.Applicant.Single(y => y.FirstName == "Diane")},

                    new JobHistory {Employer = "Carmax", City = "Moriarty", State = "New Mexico",
                    StartMonth = "03", StartYear = "2005", CurrentlyEmployed = false,
                    Applicant = context.Applicant.Single(y => y.FirstName == "Delmar")}

                };
                    foreach (JobHistory j in jobhistory)
                    {
                        context.JobHistory.Add(j);
                    }
                    context.SaveChanges();
                }

                if (!context.Position.Any())
                {

                    var position = new Position[]
                {
                    new Position {Title = "Sales Consultant", StartYear = ("2014"), EndYear = ("2017"),
                    JobHistories = context.JobHistory.Single(y => y.Employer == "Garcia Auto Group"), CurrentPosition = false},

                    new Position {Title = "Service Advisor", StartYear = ("2017"), CurrentPosition = true,
                    JobHistories = context.JobHistory.Single(y => y.Employer == "Garcia Auto Group")},

                    new Position {Title = "Barista", StartYear = ("2015"),
                    JobHistories = context.JobHistory.Single(y => y.Employer == "Swiss Alps Bakery")},

                    new Position {Title = "Care Taker", StartYear =("2014"),
                    JobHistories = context.JobHistory.Single(y => y.Employer == "Self Employed")},

                    new Position {Title = "Technician", StartYear = ("2005"),
                    JobHistories = context.JobHistory.Single(y => y.Employer == "Carmax")}

                };
                    foreach (Position p in position)
                    {
                        context.Position.Add(p);
                    }
                    context.SaveChanges();
                }

                if (!context.Duties.Any())
                {

                    var duty = new Duties[]
                {
                    new Duties {Description = "Sales, and follow up",
                    Position = context.Position.Single(y => y.Title == "Sales Consultant")}
                    ,

                    new Duties {Description = " Greet clients and address service concerns.",
                    Position = context.Position.Single(y => y.Title == "Service Advisor")},

                    new Duties {Description = " Greet customers, manage tranactions, prepare drinks",
                    Position = context.Position.Single(y => y.Title == "Barista")},

                    new Duties {Description = "Provide assistance to persons unable",
                    Position = context.Position.Single(y => y.Title == "Care Taker")},

                    new Duties {Description = "Diagnose and repair vehicle's",
                    Position = context.Position.Single(y => y.Title == "Technician")}

                };
                    foreach (Duties d in duty)
                    {
                        context.Duties.Add(d);
                    }
                    context.SaveChanges();
                }

                if (!context.Skills.Any())
                {

                    var skill = new Skills[]
                {

                    new Skills {Skill = "Working Knowledge of C#, and .NET",
                   Applicant = context.Applicant.Single(y => y.FirstName == "Dustin")},

                    new Skills {Skill = "This is my skill!",
                    Applicant = context.Applicant.Single(y => y.FirstName == "Becca")},

                    new Skills {Skill = "This is my skill!",
                    Applicant = context.Applicant.Single(y => y.FirstName == "Delmar")}

                };
                    foreach (Skills s in skill)
                    {
                        context.Skills.Add(s);
                    }
                    context.SaveChanges();
                }

                if (!context.Education.Any())
                {

                    var education = new Education[]
                {
                    new Education {School = "Sandia High School", Location = "Albuqueruqe New Mexcio", Degree = "GED", FieldOfStudy = "General Studies", gradYear = "2012",
                    Applicant = context.Applicant.Single(y => y.FirstName == "Dustin")}
                    ,

                    new Education {School = "Deep Dive Coding", Location = "Albuquerque New Mexico", FieldOfStudy = ".NET/C#", gradYear ="2018",
                     Applicant = context.Applicant.Single(y => y.FirstName == "Dustin")}
                    ,

                    new Education {School = "Del Norte High School", Location = "Albuquerque New Mexico", Degree = "High School Diploma", FieldOfStudy = "General Studies",
                        gradYear = "1970",
                    Applicant = context.Applicant.Single(y => y.FirstName == "Delmar")}

                };
                    foreach (Education e in education)
                    {
                        context.Education.Add(e);
                    }
                    context.SaveChanges();
                }

                if (!context.References.Any())
                {

                    var references = new References[]
                {

                   new References {RefferenceName = "John Holcomb", Title = "Service Director", CompanyName = "Garcia Auto Group", PhoneNumber = "505-555-5555",
                       EmailAddress = "jholcomb@garciacars.com", Relation = "Supervisor",
                   Applicant = context.Applicant.Single(y => y.FirstName == "Dustin")},

                   new References { RefferenceName = "Jessica", Title = "Owner", CompanyName = "Swiss Alps Bakery", PhoneNumber = "505-222-2222",
                       EmailAddress = "something@gmail.com", Relation = "Supervisor",
                   Applicant = context.Applicant.Single(y => y.FirstName == "Becca")},

                   new References {RefferenceName = "Karole Covnot", Title = "Reception", CompanyName = "Bug Lady", PhoneNumber = "505-333-3333",
                   EmailAddress = "philkarole@comcast.net", Relation = "Sister",
                   Applicant = context.Applicant.Single(y => y.FirstName == "Diane")},

                   new References {RefferenceName = "Clint Robin", Title = "CDL Driver", CompanyName = "Western Refinery", PhoneNumber = "505-444-4444",
                   EmailAddress = "idontknow@gmail.com", Relation = "Friend",
                   Applicant = context.Applicant.Single(y => y.FirstName == "Delmar")}

                };
                    foreach (References r in references)
                    {
                        context.References.Add(r);
                    }
                    context.SaveChanges();
                }

                if (!context.Portfolio.Any())
                {

                    var portfolios = new Portfolio[]
                {

                    new Portfolio { Link1 = "www.websit.com",Link2 = "www.net.com", Link3 = "www.org.com",
                    Applicant = context.Applicant.Single(y => y.FirstName == "Dustin")}

                };
                    foreach (Portfolio p in portfolios)
                    {
                        context.Portfolio.Add(p);
                    }
                    context.SaveChanges();
                }

            }



        }
    }
}
