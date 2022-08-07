using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageDrugStore.Controllers
{
    public class DrugController
    {
        private DrugstoreRepository _drugstoreRepository;
        private DrugRepository _drugRepository;



        public DrugController()
        {
            _drugstoreRepository = new DrugstoreRepository();
            _drugRepository = new DrugRepository();
        }

        public void CreateDrug()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drug name:");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drug price");
                string price = Console.ReadLine();
                double drugPrice;
                bool result = double.TryParse(price, out drugPrice);

                if (result)
                {
                Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drug count");
                    string count = Console.ReadLine();
                    int drugCount;
                    result = int.TryParse(count, out drugCount);
                    if (result)
                    {
                        if (drugCount > 0)
                        {

                            foreach (var drugstore in drugstores)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id}, Name:{drugstore.Name}");
                            }
                        id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore id:");
                            string id = Console.ReadLine();
                            int chosenid;
                            result = int.TryParse(id, out chosenid);
                            if (result)
                            {
                                var drugstore = _drugstoreRepository.Get(d => d.Id == chosenid);
                                if (drugstore != null)
                                {
                                    var drug = new Drug
                                    {
                                        Name = name,
                                        Price = drugPrice,
                                        Count = drugCount,
                                        Drugstore = drugstore
                                    };
                                    drugstore.Drugs.Add(drug);
                                    _drugRepository.Create(drug);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drug.Id}, Name:{name}, Price:{drugPrice}, Count:{drugCount}, Drugstore:{drugstore.Name} ");
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore with this id");
                                    goto id;
                                }
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Count cannot be negative");
                            goto Count;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");
                    }
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create a drugstore, before creating a drug");
            }
        }

        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                var drugstore = _drugstoreRepository.Get();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugs");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{drug.Id}, Name:{drug.Name}, Drugtsore name:{drugstore.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug id:");
                int drugId;

                string id = Console.ReadLine();
                bool result = int.TryParse(id, out drugId);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == drugId);
                    if (drug != null)
                    {
                        string name = drug.Name;
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{drug.Name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
                        goto Id;
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug");
            }
        }

        public void UpdateDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                var drugstore = _drugstoreRepository.Get();
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{drug.Id}, Full name:{drug.Name}, Drugtsore name:{drugstore.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug id:");

                string id = Console.ReadLine();

                int chosenid;
                bool result = int.TryParse(id, out chosenid);
                if (result)
                {
                    var drugId = _drugRepository.Get(d => d.Id == chosenid);
                    if (drugId != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drug new name:");
                        string newName = Console.ReadLine();

                    Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drug new price");
                        string newPrice = Console.ReadLine();
                        double drugPrice;
                        result = double.TryParse(newPrice, out drugPrice);
                        if (result)
                        {

                        Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drug new count");
                            string newCount = Console.ReadLine();
                            int drugCount;
                            result = int.TryParse(newCount, out drugCount);
                            if (result)
                            {
                                if (drugCount > 0)
                                {
                                    var updatedDrug = new Drug
                                    {
                                        Id = chosenid,
                                        Name = newName,
                                        Count = drugCount

                                    };
                                    _drugRepository.Update(updatedDrug);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drug is updated succesfully. Drug id:{chosenid}, Drug new name:{newName}, Drug new price:{newPrice}, Drug new count:{newCount}");
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Count cannot be negative");
                                    goto Count;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");
                                goto Count;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");
                            goto Price;
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drug doesn't exist with this id");
                        goto Id;
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug");
            }
        }

        public void GetAllDrug()
        {
            var drugs = _drugRepository.GetAll();

            if (drugs.Count > 0)
            {
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drug.Id}, drug name: {drug.Name}, drugstore name:{drug.Drugstore.Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }

        public void GetAllDrugsByDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            drugstroreAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores");

                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id}, drugstore name:{drugstore.Name}");
                }
            DrugstoreId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore id:");
                string drugstoreId = Console.ReadLine();

                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    if (drugstoreId != null)
                    {
                        var drugs = _drugRepository.GetAll(d => d.Drugstore.Id == id);
                        if (drugs.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugs by drugstore");
                            foreach (var drug in drugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drug id:{drug.Id}, Drug name:{drug.Name}, Drug price:{drug.Price}, Drug count:{drug.Count}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore with this id");
                            goto DrugstoreId;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore with this id");
                        goto DrugstoreId;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                    goto DrugstoreId;
                }
            }

        }

        public void Filter()
        {
        Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter drug filter price");
            string price = Console.ReadLine();
            double drugPrice;
            var result = double.TryParse(price, out drugPrice);
            if (result)
            {
                var drugs = _drugRepository.GetAll(d => d.Price <= drugPrice);
                if (drugPrice > 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugs that are less than the price of the filter");
                    foreach (var drug in drugs)
                    {
                        if (drug.Price < drugPrice)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Drug Id:{drug.Id}, Name:{drug.Name}, Price:{drug.Price}, Count:{drug.Count}");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug that smaller than filter price");
                            //goto eliyim?//
                        }
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct price filter");
                    goto Price;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");

            }
        }



    }
}
