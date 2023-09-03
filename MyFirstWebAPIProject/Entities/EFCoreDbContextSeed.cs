using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebAPIProject.Entities
{
    public class EFCoreDbContextSeed
    {
        public static void Seed(EFCoreDbContext context)
        {
            Random random = new Random(); 
                if(!context.Students.Any())
                {
                    try
                    {
                        for(int i=0; i<10; i++)
                        {
                            var nameValue = random.Next(100, 500);
                            var heightValue = random.Next(400, 500);
                            var weightValue = random.Next(100, 200);
                            
                            //Create a New Student Object
                            var student = new Student()
                            {
                                FirstName = "First " + nameValue.ToString(),
                                LastName = "Last " + nameValue.ToString(),
                                Height = (decimal)(heightValue * .01),
                                Weight = (float)(weightValue)
                            };
                            context.Students.Add(student);
                            context.SaveChanges();

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}"); ;
                    }
                }
                if(!context.Standards.Any())
                {
                                        try
                    {
                        for(int i=0; i<10; i++)
                        {
                            var nameValue = random.Next(100, 500);

                            
                            //Create a New Student Object
                            var standard = new Standard()
                            {
                                StandardName = "Standard Name " + nameValue.ToString(),
                                Description = "Description " + nameValue.ToString()
                            };
                            context.Standards.Add(standard);
                            context.SaveChanges();

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}"); ;
                    }
                }
                //if(context.ChangeTracker.HasChanges()) context.SaveChanges();
        }
    }
}