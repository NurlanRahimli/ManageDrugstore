using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageDrugStore
{
    public class OwnerController
    {
        private OwnerRepository _ownerRepository;
        /*private DrugstoreRepository _drugstoreRepository;*/

        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
            /*_drugstoreRepository = new DrugstoreRepository();*/
        }

        public void CreateOwner()
        {
            
            Name: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner name:");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner surname:");
                string surname = Console.ReadLine();

                var owner = new Owner
                {
                    Name = name,
                    Surname = surname
                };
                _ownerRepository.Create(owner);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name: {name}, Surname: {surname}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must add a number");
                goto Name;
            }
            

        }

        public void DeleteOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count>0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{owner.Id}, Full name-{owner.Name} {owner.Surname}");
                }


            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner id:");
                int ownerId;

                string id = Console.ReadLine();
                bool result = int.TryParse(id, out ownerId);

                if (result)
                {
                    var owner = _ownerRepository.Get(d => d.Id == ownerId);
                    if (owner!=null)
                    {
                        string name = owner.Name;
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner doesn't exist with this id");
                    goto Id;
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no owner");
            }
        }

        public void UpdateOwner()
        {
            var owners = _ownerRepository.GetAll();

            if (owners.Count>0)
            {
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id-{owner.Id}, Full name:{owner.Name} {owner.Surname}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner id:");

                string id = Console.ReadLine();

                int chosenid;
                bool result = int.TryParse(id, out chosenid);

                if (result)
                {
                    var ownerId = _ownerRepository.Get(d => d.Id == chosenid);
                    if (ownerId!=null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter owner new name:");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter owner new surname:");
                        string newSurname = Console.ReadLine();

                        var updatedOwner = new Owner
                        {
                            Id = ownerId.Id,
                            Name = newName,
                            Surname = newSurname
                            
                        };

                        _ownerRepository.Update(updatedOwner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Owner is updated to {newName} {newSurname}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner doesn't exist with this id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner");
            }
        }

        public void GetAllOwners()
        {
            var owners = _ownerRepository.GetAll();

            if (owners.Count > 0)
            {
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{owner.Id}, full name: {owner.Name} {owner.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }


    }
}
