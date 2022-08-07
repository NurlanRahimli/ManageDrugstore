using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageDrugStore.Controllers
{
    public class DruggistController
    {
        private DrugstoreRepository _drugstoreRepository;
        private DruggistRepository _druggistRepository;



        public DruggistController()
        {
            _drugstoreRepository = new DrugstoreRepository();
            _druggistRepository = new DruggistRepository();
        }

        public void CreateDruggist()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist name:");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist surname:");
                string surname = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist age:");
                string age = Console.ReadLine();
                byte druggistAge;
                bool result = byte.TryParse(age, out druggistAge);
                if (result)
                {
                AllDrugstoreList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstores");
                    foreach (var drugstore in drugstores)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id}, drugstore name:{drugstore.Name}, Drugstore's owner name:{drugstore.Owner.Name}");
                    }

                Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore id:");
                    string drugstoreId = Console.ReadLine();
                    int Id;
                    result = int.TryParse(drugstoreId, out Id);
                    if (result)
                    {
                        var drugstore = _drugstoreRepository.Get(d => d.Id == Id);
                        if (drugstore != null)
                        {
                        Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist experience");
                            string experience = Console.ReadLine();
                            byte druggistExperience;
                            result = byte.TryParse(experience, out druggistExperience);
                            if (result)
                            {
                                if (druggistAge > druggistExperience)
                                {
                                    var druggist = new Druggist
                                    {
                                        Name = name,
                                        Surname = surname,
                                        Age = druggistAge,
                                        Experience = druggistExperience,
                                        Drugstore = drugstore
                                       
                                    };
                                    drugstore.Druggists.Add(druggist);
                                    _druggistRepository.Create(druggist);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Druggist id: {drugstoreId}, Full Name: {druggist.Name} {druggist.Surname}");
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Druggist experience cannot be bigger than druggist age");
                                    goto Experience;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including id doesn't exist");
                            goto Id;
                        }
                    }


                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create a drugstore before creating a druggist");
            }
        }

        public void DeleteDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All druggists");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{druggist.Id}, Name:{druggist.Name}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist id:");
                int druggistId;

                string id = Console.ReadLine();
                bool result = int.TryParse(id, out druggistId);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == druggistId);
                    if (druggist != null)
                    {
                        string name = druggist.Name;
                        _drugstoreRepository.Delete(druggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{druggist.Name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This druggist doesn't exist");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Druggist doesn't exist with this id");
                    goto Id;
                }
            }
        }

        public void UpdateDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{druggist.Id}, Full name:{druggist.Name} {druggist.Surname}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist id:");

                string id = Console.ReadLine();

                int chosenid;
                bool result = int.TryParse(id, out chosenid);
                if (result)
                {
                    var druggistId = _druggistRepository.Get(d => d.Id == chosenid);
                    if (druggistId != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist new name:");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist new surname:");
                        string newSurname = Console.ReadLine();

                        Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist new age");
                        string newAge = Console.ReadLine();
                        byte Age;
                        result = byte.TryParse(newAge, out Age);
                        if (result)
                        {
                        Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter druggist new experience");
                            string newExperience = Console.ReadLine();
                            byte Experience;
                            result = byte.TryParse(newExperience, out Experience);
                            if (result)
                            {
                                var drugstores = _drugstoreRepository.GetAll();
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstores");
                                foreach (var drugstore in drugstores)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drugstore id:{drugstore.Id}, Drugstore name:{drugstore.Name}");
                                }
                                DrId: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new drugstore id:"); 
                                string newDrugstoreId = Console.ReadLine();
                                int newId;
                                result = int.TryParse(newDrugstoreId, out newId);
                                if (result)
                                {
                                    var newDrugstore = _drugstoreRepository.Get(d => d.Id == newId);
                                    if (newDrugstore!=null)
                                    {
                                        
                                        if (Age > Experience)
                                        {
                                            var updatedDruggist = new Druggist
                                            {
                                                Id = chosenid,
                                                Name = newName,
                                                Surname = newSurname,
                                                Age = Age,
                                                Experience = Experience,
                                                Drugstore = newDrugstore

                                            };
                                            newDrugstore.Druggists.Add(updatedDruggist);
                                            _druggistRepository.Update(updatedDruggist);
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Druggist is updated to Full name: {newName} {newSurname}, new Age:{Age}, new Experience:{Experience}, new Drugstore:{newDrugstore}");
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Druggist experience cannot be bigger than druggist age");
                                            goto Experience;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct id");
                                        goto DrId;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                                    goto DrId;
                                }
                                
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");
                            }

                            
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter age in correct format");
                            goto Age;
                        }
                        
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Druggist doesn't exist with this id");
                        goto Id;
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no druggist");

            }
        }

        public void GetAllDruggist()
        {
            var druggists = _druggistRepository.GetAll();

            if (druggists.Count > 0)
            {
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{druggist.Id}, full name: {druggist.Name} {druggist.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }

        public void GetAllDruggistByDrugstore()
        {
            var drugstrores = _drugstoreRepository.GetAll();
            if (drugstrores.Count>0)
            {
            drugstroreAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores");

                foreach (var drugstore in drugstrores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id}, drugstore name:{drugstore.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore id:");
                string drugstoreId = Console.ReadLine();

                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {

                    if (drugstoreId != null)
                    {
                        var druggists = _druggistRepository.GetAll(d => d.Drugstore.Id == id);
                        if (druggists.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All druggist by drugstore");
                            foreach (var druggist in druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Druggist id:{druggist.Id}, Druggist Full name:{druggist.Name} {druggist.Surname}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore with this id");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore with this id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");
                    goto Id;
                }
            }
        }



    }
}

