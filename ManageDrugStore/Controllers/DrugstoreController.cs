using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageDrugStore.Controllers
{
    public class DrugstoreController
    {
        private DrugstoreRepository _drugstoreRepository;
        private OwnerRepository _ownerRepository;
        private DrugRepository _drugRepository;




        public DrugstoreController()
        {
            _drugstoreRepository = new DrugstoreRepository();
            _ownerRepository = new OwnerRepository();
            _drugRepository = new DrugRepository();



        }

        public void CreateDrugstore()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore name:");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore address:");
                string address = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore contactnumber");
                string contactNumber = Console.ReadLine();

            AllOwnersList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{owner.Id}, owner name:{owner.Name}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner Id:");
                string ownerId = Console.ReadLine();
                int Id;
                bool result = int.TryParse(ownerId, out Id);


                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {
                        var drugstore = new Drugstore
                        {
                            Name = name,
                            Address = address,
                            ContactNumber = contactNumber,
                            Owner = owner


                        };
                        owner.Drugstores.Add(drugstore);
                        _drugstoreRepository.Create(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id}, Name:{name}, Address:{address}, Contactnumber:{contactNumber}, Owner:{owner.Name}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including id doesn't exist");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter in correct format");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create an owner before creating drugstore");
            }
        }

        public void UpdateDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            var owners = _ownerRepository.GetAll();

            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{drugstore.Id}, Name:{drugstore.Name}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id:");

                string id = Console.ReadLine();

                int chosenid;
                bool result = int.TryParse(id, out chosenid);
                if (result)
                {

                    var drugstore = _drugstoreRepository.Get(d => d.Id == chosenid);
                    if (drugstore != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore new name:");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore new address");
                        string newAddress = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter drugstore new contactnumber");
                        string newContactnumber = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owners:");
                        foreach (var owner in owners)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{owner.Id}, Full Name:{owner.Name} {owner.Surname}");
                        }
                    owid: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new drugstore owner id:");
                        string newOwnerId = Console.ReadLine();
                        int newId;
                        result = int.TryParse(newOwnerId, out newId);
                        if (result)
                        {
                            var newowner = _ownerRepository.Get(o => o.Id == newId);
                            if (newowner!=null)
                            {
                                var updatedDrugstore = new Drugstore
                                {
                                    Id = drugstore.Id,
                                    Name = newName,
                                    Address = newAddress,
                                    ContactNumber = newContactnumber,
                                    Owner = newowner

                                };
                                newowner.Drugstores.Add(updatedDrugstore);
                                _drugstoreRepository.Update(updatedDrugstore);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drugstore is updated to {newName}, {newAddress}, {newContactnumber}");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner with this id");
                                goto owid;
                            }
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drugstore doesn't exist with id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore");
            }
        }

        public void DeleteDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstores");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{drugstore.Id}, Name:{drugstore.Name}, Drugstore's owner name:{drugstore.Owner.Name}"); 
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id:");
                int drugstoreId;

                string id = Console.ReadLine();
                bool result = int.TryParse(id, out drugstoreId);

                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == drugstoreId);
                    if (drugstore != null)
                    {
                        string name = drugstore.Name;
                        _drugstoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drugstore doesn't exist with this id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore");
            }
        }

        public void GetAllDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();

            if (drugstores.Count > 0)
            {
                var owner = _ownerRepository.Get();
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drugstore Id:{drugstore.Id}, Drugstore Name: {drugstore.Name}, Drugstore's owner name:{drugstore.Owner.Name}");  
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }

        public void GetAllDrugstoresByOwner()
        {
            var owners = _ownerRepository.GetAll();

        OwnerAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All owners");

            foreach (var owner in owners)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{owner.Id}, Full name:{owner.Name} {owner.Surname}");
            }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner id:");
            string ownerId = Console.ReadLine();

            int id;
            bool result = int.TryParse(ownerId, out id);
            if (result)
            {
                if (ownerId != null)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner!=null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores by owner");
                        if (owner.Drugstores.Count > 0)
                        {
                            foreach (var drugstore in owner.Drugstores)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drugstore id:{drugstore.Id}, drugstore name:{drugstore.Name}");
                            }
                            var drugstores = _drugstoreRepository.GetAll();
                        }
                        
                        
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner with this id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner with this id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                goto Id;
            }

        }

        public void Sale()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                //drugstore-un id-sini secmek//
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Drugstore Id-{drugstore.Id}, Drugstore Name:{drugstore.Name}, Drugstore's owner:{drugstore.Owner.Name}");  
                }
            DrugstoreId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id:");
                string id1 = Console.ReadLine();
                int drugstoreId;
                bool result = int.TryParse(id1, out drugstoreId);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == drugstoreId);
                    if (drugstore != null)
                    {
                        var drugs = _drugRepository.GetAll(d=>d.Drugstore.Drugs==drugstore.Drugs);
                        if (drugs.Count > 0)
                        {
                        AllDrugList: foreach (var drug in drugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Drug id:{drug.Id}, Name:{drug.Name}, Price:{drug.Price}, Count:{drug.Count}");
                            }
                        DrugId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug id:");
                            string id2 = Console.ReadLine();
                            int drugId;
                            result = int.TryParse(id2, out drugId);
                            if (result)
                            {
                                var drug = _drugRepository.Get(d => d.Id == drugId && d.Drugstore.Id == drugstore.Id);
                                if (drug != null)
                                {
                                Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the count of drugs you want to buy");
                                    string count = Console.ReadLine();
                                    int drugCount;
                                    result = int.TryParse(count, out drugCount);
                                    if (result)
                                    {
                                        if (drugCount > 0)
                                        {

                                            if (drug.Count >= drugCount)
                                            {
                                                double totalPrice = drugCount * drug.Price;
                                            PRICE: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Total price:{totalPrice}, if you want to buy pay total price");
                                                string total = Console.ReadLine();
                                                int totalP;
                                                result = int.TryParse(total, out totalP);
                                                if (result)
                                                {
                                                    if (totalP == totalPrice)
                                                    {
                                                        drug.Count = drug.Count - drugCount;
                                                        _drugRepository.Update(drug);
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "This drug is sold");
                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You don't have money to buy medicine");
                                                        goto PRICE;
                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter drug price in correct format");
                                                    goto PRICE;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug with this count");
                                                goto AllDrugList;
                                            }
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is not enough drug to sell");
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drug count must be in digit format");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug with this id");
                                    goto DrugId;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter id in correct format:");
                                goto DrugId;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug in drugstore");
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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drugstore id must be in digit format");
                    goto DrugstoreId;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore");
            }
        }

    }
}
