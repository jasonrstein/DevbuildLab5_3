using System;
using System.Collections.Generic;

namespace DevBuildLab5_3
{
    class NewCar
    {
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public decimal price { get; set; }

        public NewCar(string pMake, string pModel, int pYear, decimal pPrice)
        {
            this.make = pMake;
            this.model = pModel;
            this.year = pYear;
            this.price = pPrice;
        }

        public override string ToString()
        {
            return $"{this.make},{this.model},{this.year},{this.price}";
        }
    }

    class UsedCar : NewCar
    {
        public string condition { get; set; }
        public decimal mileage { get; set; }
        
        public UsedCar(string pMake, string pModel, int pYear, decimal pPrice, string pCondition, decimal pMileage) : base(pMake, pModel, pYear, pPrice)
        {
            condition = pCondition;
            mileage = pMileage;
        }

        public override string ToString()
        {
            return $"{this.make},{this.model},{this.year},{this.price},{this.condition},{this.mileage}";
        }
    }

    class CarLotApp
    {
        private List<string> Cars;

        CarLotApp(List<UsedCar> usedCar, List<NewCar> newCar)
        {
            foreach (var car in usedCar)
            {
                this.Cars.Add(car.ToString());
            }

            foreach (var car in newCar)
            {
                this.Cars.Add(car.ToString());
            }
        }



        public void ListCars()
        {

        }

        public void BuyCar()
        {

        }

        public void AddCar()
        {

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            bool continueYN = true;

            int userCarPur;
            int userAddedYear;
            int count;
            
            decimal userAddedPrice;
            decimal userAddedMileage;

            string userAddedCar;
            string continueWithPurchase;
            string userAddedMake;
            string userAddedModel;


            List<NewCar> ListOfNewCars = new List<NewCar>();
            List<UsedCar> ListOfUsedCars = new List<UsedCar>();

            ListOfNewCars.Add(new NewCar("Ford", "Mustang", 2021, 35000));
            ListOfNewCars.Add(new NewCar("Ford", "Explorer", 2022, 42000));
            ListOfNewCars.Add(new NewCar("Ford", "Bronco  ", 2022, 56000));

            ListOfUsedCars.Add(new UsedCar("Mercedes", "3.5L", 2019, 18500, "used", 100500));
            ListOfUsedCars.Add(new UsedCar("Chevrolet", "Blazer", 2004, 9800, "used", 97000));
            ListOfUsedCars.Add(new UsedCar("Dodge    ", "Ram   ", 2015, 12000, "used", 115000));

            Console.WriteLine("Welcome to Grant Chirpus’ Used Car Emporium!");

            do
            {
                count = 1;

                foreach (NewCar car in ListOfNewCars)
                { 
                        Console.WriteLine($"{count}.{car.make}\t\t {car.model}\t ${car.price}\t");
                        count++;
                }

                foreach (UsedCar car in ListOfUsedCars)
                {
                    Console.WriteLine($"{count} {car.make}\t {car.model}\t\t ${car.price}\t ({car.condition})\t {car.mileage}\t");
                    count++;
                }

                Console.WriteLine($"{count}. Add a car");
                count++;
                Console.WriteLine($"{count}. Quit");

                Console.WriteLine("Which car would you like?");
                userCarPur = Convert.ToInt32(Console.ReadLine());
                bool isNew = false;
                int num;

                if (userCarPur <= (ListOfNewCars.Count + ListOfUsedCars.Count))
                {
                    if (userCarPur <= ListOfNewCars.Count)
                    {
                        isNew = true;
                        num = userCarPur - 1;
                        Console.WriteLine($" {ListOfNewCars[num].make}\t\t {ListOfNewCars[num].model}\t ${ListOfNewCars[num].price}\t");
                    }

                    else
                    {
                        num = userCarPur - ListOfNewCars.Count - 1;
                        Console.WriteLine($" {ListOfUsedCars[num].make}\t\t {ListOfUsedCars[num].model}\t {ListOfUsedCars[num].price}\t {ListOfUsedCars[num].condition}\t {ListOfUsedCars[num].mileage} ");
                    }


                    Console.WriteLine("Would like to buy this car? (y/n)");
                    continueWithPurchase = Console.ReadLine();

                    if (continueWithPurchase == "y")
                    {
                        Console.WriteLine("Excellent! Our finance department will be in touch shortly.");
                        if (isNew)
                        {
                            ListOfNewCars.RemoveAt(num);
                        }
                        else
                        {
                            ListOfUsedCars.RemoveAt(num);

                        }
                    }
                }

                else if (userCarPur == ListOfUsedCars.Count + ListOfNewCars.Count + 1)
                {
                    Console.WriteLine("Is this a new or used car? (new/used)");
                    userAddedCar = Console.ReadLine();

                    Console.WriteLine("Please add the vehicle information");
                    Console.Write("Please enter the make: ");
                    userAddedMake = Console.ReadLine();
                    Console.Write("Please enter the model: ");
                    userAddedModel = Console.ReadLine();
                    Console.Write("Please enter the year: ");
                    userAddedYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter the price: ");
                    userAddedPrice = Convert.ToDecimal(Console.ReadLine());

                    if (userAddedCar == "new")
                    {
                        ListOfNewCars.Add(new NewCar(userAddedMake, userAddedModel, userAddedYear, userAddedPrice));
                    }
                    else
                    {
                        Console.Write("Please add the vehicle mileage: ");

                        userAddedMileage = Convert.ToDecimal(Console.ReadLine());

                        ListOfUsedCars.Add(new UsedCar(userAddedMake, userAddedModel, userAddedYear, userAddedPrice, "used", userAddedMileage));

                    }
                }
                else
                    continueYN = false;
                

            } while (continueYN);

        }
    }
}
