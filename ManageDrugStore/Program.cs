using Core.Constants;
using Core.Helpers;
using ManageDrugStore.Controllers;
using System;

namespace ManageDrugStore
{
    class Program
    {
        static void Main(string[] args)
        {


            AdminController _adminController = new AdminController();
            OwnerController _ownerController = new OwnerController();
            DrugstoreController _drugstoreController = new DrugstoreController();
            DruggistController _druggistController = new DruggistController();
            DrugController _drugController = new DrugController();



        Authentication: var admin = _adminController.Authenticate();

            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Welcome");
                Console.WriteLine("-----");

            Menu: while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Owner");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Drugstore");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Drug");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Logout");

                    Console.WriteLine("-----");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {

                        switch (selectedNumber)
                        {
                            case 1:
                                while (true)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1 - Create owner");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2 - Update owner");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3 - Delete owner");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4 - Get all owners");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Main menu");

                                    string number2 = Console.ReadLine();

                                    int selectedNumber2;
                                    bool result2 = int.TryParse(number2, out selectedNumber2);

                                    if (result2)
                                    {
                                        if (selectedNumber2 > 0 && selectedNumber2 < 6)
                                        {
                                            switch (selectedNumber2)
                                            {
                                                case (int)Options.CreateOwner:
                                                    _ownerController.CreateOwner();
                                                    break;
                                                case (int)Options.UpdateOwner:
                                                    _ownerController.UpdateOwner();
                                                    break;
                                                case (int)Options.DeleteOwner:
                                                    _ownerController.DeleteOwner();
                                                    break;
                                                case (int)Options.GetAllOwner:
                                                    _ownerController.GetAllOwners();
                                                    break;
                                                case (int)Options.MainMenu:
                                                    goto Menu;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including number doesn't exist");
                                        }
                                    }


                                }
                            case 2:
                                while (true)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Main menu");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6 - Create drugstore");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "7 - Update drugstore");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "8 - Delete drugstore");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "9 - Get all drugstore");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "10 - Get all drugstores by owner");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "11 - Sale");



                                    string number3 = Console.ReadLine();

                                    int selectedNumber3;
                                    bool result3 = int.TryParse(number3, out selectedNumber3);

                                    if (result3)
                                    {
                                        if (selectedNumber3 > 4 && selectedNumber3 < 13)
                                        {
                                            switch (selectedNumber3)
                                            {
                                                case (int)Options.CreateDrugstore:
                                                    _drugstoreController.CreateDrugstore();
                                                    break;
                                                case (int)Options.UpdateDrugstore:
                                                    _drugstoreController.UpdateDrugstore();
                                                    break;
                                                case (int)Options.DeleteDrugstore:
                                                    _drugstoreController.DeleteDrugstore();
                                                    break;
                                                case (int)Options.GetAllDrugstore:
                                                    _drugstoreController.GetAllDrugstore();
                                                    break;
                                                case (int)Options.GetAllDrugstoresByOwner:
                                                    _drugstoreController.GetAllDrugstoresByOwner();
                                                    break;
                                                case (int)Options.DrugstoreSale:
                                                    _drugstoreController.Sale();
                                                    break;
                                                case (int)Options.MainMenu:
                                                    goto Menu;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including number doesn't exist");
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                    }

                                }
                            case 3:
                                while (true)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "12 - Create druggist");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "13 - Update druggist");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "14 - Delete druggist");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "15 - Get all druggist");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "16 - Get all druggist by drugstore");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "17 - Main menu");
                                    string number4 = Console.ReadLine();

                                    int selectedNumber4;
                                    bool result4 = int.TryParse(number4, out selectedNumber4);

                                    if (result4)
                                    {
                                        if (selectedNumber4 > 11 && selectedNumber4 < 18 /*|| selectedNumber4 == 5*/)
                                        {
                                            switch (selectedNumber4)
                                            {
                                                case (int)Options.CreateDruggist:
                                                    _druggistController.CreateDruggist();
                                                    break;
                                                case (int)Options.UpdateDruggist:
                                                    _druggistController.UpdateDruggist();
                                                    break;
                                                case (int)Options.DeleteDruggist:
                                                    _druggistController.DeleteDruggist();
                                                    break;
                                                case (int)Options.GetAllDruggist:
                                                    _druggistController.GetAllDruggist();
                                                    break;
                                                case (int)Options.GetAllDruggistByDrugstore:
                                                    _druggistController.GetAllDruggistByDrugstore();
                                                    break;
                                                case (int)Options.Mainmenu:
                                                    goto Menu;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including number doesn't exist");
                                        }
                                    }

                                }
                            case 4:
                                while (true)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "17 - Main menu");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "18 - Create drug");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "19 - Update drug");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "20 - Delete drug");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "21 - Get all drug");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "22 - Get all drug by drugstore");
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "23 - Filter");

                                    string number5 = Console.ReadLine();

                                    int selectedNumber5;
                                    bool result5 = int.TryParse(number5, out selectedNumber5);

                                    if (result5)
                                    {
                                        if (selectedNumber5 > 16 && selectedNumber5 < 24 )
                                        {
                                            switch (selectedNumber5)
                                            {
                                                case (int)Options.CreateDrug:
                                                    _drugController.CreateDrug();
                                                    break;
                                                case (int)Options.UpdateDrug:
                                                    _drugController.UpdateDrug();
                                                    break;
                                                case (int)Options.DeleteDrug:
                                                    _drugController.DeleteDrug();
                                                    break;
                                                case (int)Options.GetAllDrug:
                                                    _drugController.GetAllDrug();
                                                    break;
                                                case (int)Options.GetAllDrugsByDrugstore:
                                                    _drugController.GetAllDrugsByDrugstore();
                                                    break;
                                                case (int)Options.Filter:
                                                    _drugController.Filter();
                                                    break;
                                                case (int)Options.Mainmenu:
                                                    goto Menu;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including number doesn't exist");
                                        }
                                    }

                                }
                            case 5:
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "You log out");
                                while (true)
                                {
                                    goto Authentication;
                                }
                        }


                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including number doesn't exist");
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including username or password is incorrect");
                goto Authentication;
            }
        }
    }
}
