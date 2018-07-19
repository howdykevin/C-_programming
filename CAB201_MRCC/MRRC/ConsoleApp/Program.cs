using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRRCManagement;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            ////Vehicle Ferrari = new Vehicle("Fast", VehicleClass.Luxury, "Ferari", "IDK", 2017, 2, TransmissionType.Manual, FuelType.Diesel, true, true, 200, "red");
            ////// testing the vehicle class
            ////Console.WriteLine(new Vehicle("123ABC", VehicleClass.Economy,"Hyundai", "i30", 2014, 5, TransmissionType.Automatic,FuelType.Diesel,true,false,100,"White"));
            //////should print what I just wrote....
            ////Console.ReadLine();
            ////Console.WriteLine(new Vehicle("246DEF", VehicleClass.Luxury, "Audi", "R8", 2018));
            ////// This should hopefully fill in the blanks......
            ////Console.ReadLine();
            ////Console.WriteLine(Ferrari);
            //////this is just testing what the normal output would be
            ////Console.ReadLine();
            ////Console.WriteLine(Ferrari.ToCSVString());
            ////// This should put the Ferrari atrributes into CVS form.
            ////Console.ReadLine();
            ////Vehicle Mirage = new Vehicle("ugly", VehicleClass.Economy, "Mitsubishi", "Mirage", 2010, 4, TransmissionType.Manual, FuelType.Petrol, false, false, 100, "purple");


            //// Testing Customers



            ////testing fleet class
            //Fleet round = new Fleet();
            //List<Vehicle> test1;
            //test1 = round.GetFleet(true);
            //foreach(var item in test1)
            //{
            //    Console.WriteLine(item);

            //}
            ////foreach (var item in test1)
            ////{
            ////    Console.WriteLine(item.ToCSVString());
            ////}
            ////Console.WriteLine();
            ////Console.ReadLine();
            ////Vehicle Toyota = new Vehicle("1234CS", VehicleClass.Commercial, "Holden", "astra", 2017, 4, TransmissionType.Automatic, FuelType.Diesel, true, false, 50, "blue");


            ////bool add = round.AddVehicle(new Vehicle("1234CS", VehicleClass.Economy, "Holden", "astra", 2017, 4, TransmissionType.Automatic, FuelType.Petrol, true, false, 50, "blue"));
            ////if (add)
            ////{
            ////    round.SaveToFile();
            ////    foreach (var item in test1)
            ////    {
            ////        Console.WriteLine(item.ToCSVString());
            ////    }

            ////}
            ////else
            ////{
            ////    Console.WriteLine("There are duplicate vehicle Rego");
            ////}

            ////Console.WriteLine();
            ////Console.ReadLine();

            ////Console.WriteLine(round.RemoveVehicle(Toyota));
            //////This returns true 
            ////round.SaveToFile();
            ////foreach (var item in test1)
            ////{
            ////    Console.WriteLine(item.ToCSVString());
            ////}
            ////Console.ReadLine();

            ////Console.WriteLine();
            ////Console.ReadLine();

            ////Console.WriteLine(round.IsRented("123HCB"));
            ////Console.ReadLine();
            ////// should return true

            ////Console.WriteLine(round.IsRenting(0));
            ////Console.ReadLine();
            //////should return true

            ////Console.WriteLine(round.RentedBy("123HCB"));
            ////Console.ReadKey();
            ////// should return ID so 0.

            ////Console.WriteLine(round.RentCar("809POI", 2));
            ////Console.ReadLine();
            ////round.SaveToFile();
            ////// should return true

            ////Console.WriteLine(round.ReturnCar("123HCB"));
            ////Console.ReadLine();
            ////// should return ID so 0
            ////Console.WriteLine();
            ////round.SaveToFile();





            ////test1 = round.GetFleet();
            ////foreach (var item in test1)
            ////{
            ////    Console.WriteLine(item.ToCSVString());
            ////}
            ////Console.ReadLine();

            ////foreach (var item in round.andOr("123HCB Or Economy AnD Commerical OR Luxury"))
            ////{
            ////    Console.WriteLine(item);
            ////}
            ////Console.ReadLine();

            ////testing CRM class

            //CRM testing = new CRM();
            //List<Customer> result = testing.GetCustomers();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToCSVString());
            //}
            //Console.WriteLine();
            //bool addition = testing.AddCustomer(new Customer(20, "Mr", "poo", "honey", Gender.Male, "1/11/1500"));
            //if (addition)
            //{
            //    testing.SaveToFile();
            //    List<Customer> result1 = testing.GetCustomers();
            //    foreach (var item in result1)
            //    {
            //        Console.WriteLine(item.ToCSVString());
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("There are duplicated customerID");
            //}
            //// this shouold print there are duplicated customerID.

            //Console.ReadLine();
            //Customer poop = new Customer(20, "Mr", "poo", "honey", Gender.Male, "1/11/1500");
            //Console.WriteLine(testing.RemoveCustomer(poop, round));
            //testing.SaveToFile();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToCSVString());
            //}
            //// should remove last item in list + display result
            //Console.ReadLine();

            //Console.WriteLine(testing.RemoveCustomer(4, round));
            //testing.SaveToFile();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToCSVString());
            //}
            //Console.ReadKey();
            //should remove mrs ami. and say true.

            //Testing Customer
            //Customer test1 = new Customer(2, "Mr", "KEvin", "Gun", Gender.Male, "1/02/1997");
            //Console.WriteLine("Good1");
            //Console.WriteLine(test1.ToCSVString());

            //Testing Vehicles
            //Vehicle test2 = new Vehicle("458vjb", VehicleClass.Commercial, "ggg", "cunt", 2011, 4, TransmissionType.Automatic, FuelType.Diesel, true, true, 100.0, "orange");
            //Console.WriteLine(test2.ToString());
            //Vehicle test3 = new Vehicle("669jbb", VehicleClass.Economy, "ddssd", "mkkfm", 2003);
            //Console.WriteLine(test3.ToCSVString());
            //Vehicle test4 = new Vehicle("334hcc", VehicleClass.Commercial, "dsds", "dhsd", 1998);
            //Console.WriteLine(test4.ToCSVString());
            //Vehicle test5 = new Vehicle("sdsd", VehicleClass.Family, "hdsd", "dhs", 1997);
            //Console.WriteLine(test5.ToCSVString());
            //Vehicle test6 = new Vehicle("sdsd5", VehicleClass.Luxury, "dsd", "hug", 1667);
            //Console.WriteLine(test6.ToString());
            //List<string> result = test5.GetAttributeList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}






        }
    }
}
