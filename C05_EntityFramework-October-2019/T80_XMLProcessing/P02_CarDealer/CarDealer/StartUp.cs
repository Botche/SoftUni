using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
//using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            using (var db = new CarDealerContext())
            {
                // db.Database.EnsureCreated();

                // var file = File.ReadAllText(@".\..\..\..\Datasets\sales.xml");

                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }
        }
        #region input
        //public static string ImportSuppliers(CarDealerContext context, string inputXml)
        //{
        //    var xmlSerialize = new XmlSerializer(typeof(Dtos.Import.SupplierDTO[]), new XmlRootAttribute("Suppliers"));
        //    var suppliersFromXML = (Dtos.Import.SupplierDTO[])xmlSerialize.Deserialize(new StringReader(inputXml));

        //    var suppliers = new List<Supplier>();

        //    foreach (var item in suppliersFromXML)
        //    {
        //        var supplier = Mapper.Map<Supplier>(item);
        //        suppliers.Add(supplier);
        //    }

        //    context.Suppliers.AddRange(suppliers);
        //    context.SaveChanges();

        //    return $"Successfully imported {suppliers.Count}";
        //}

        //public static string ImportParts(CarDealerContext context, string inputXml)
        //{
        //    var xmlSerialize = new XmlSerializer(typeof(PartDTO[]), new XmlRootAttribute("Parts"));
        //    var partsFromXML = (PartDTO[])xmlSerialize.Deserialize(new StringReader(inputXml));

        //    var parts = new List<Part>();

        //    foreach (var item in partsFromXML)
        //    {
        //        if (context.Suppliers.FirstOrDefault(p => p.Id == item.SupplierId) != null)
        //        {
        //            var part = Mapper.Map<Part>(item);
        //            parts.Add(part);
        //        }
        //    }

        //    context.Parts.AddRange(parts);
        //    context.SaveChanges();

        //    return $"Successfully imported {parts.Count}";
        //}

        //public static string ImportCars(CarDealerContext context, string inputXml)
        //{
        //    var xmlSerialize = new XmlSerializer(typeof(CarDTO[]), new XmlRootAttribute("Cars"));
        //    var carsFromXML = (CarDTO[])xmlSerialize.Deserialize(new StringReader(inputXml));

        //    var cars = new List<Car>();

        //    foreach (var carDto in carsFromXML)
        //    {
        //        var car = Mapper.Map<Car>(carDto);

        //        context.Cars.Add(car);

        //        foreach (var part in carDto.Parts.PartsId)
        //        {
        //            if (car.PartCars
        //                .FirstOrDefault(p => p.PartId == part.PartId) == null &&
        //                context.Parts.Find(part.PartId) != null)
        //            {
        //                var partCar = new PartCar
        //                {
        //                    CarId = car.Id,
        //                    PartId = part.PartId
        //                };

        //                car.PartCars.Add(partCar);
        //            }
        //        }

        //        cars.Add(car);
        //    }

        //    context.SaveChanges();

        //    return $"Successfully imported {cars.Count}";
        //}

        //public static string ImportCustomers(CarDealerContext context, string inputXml)
        //{
        //    var xmlSerialize = new XmlSerializer(typeof(CustomerDTO[]), new XmlRootAttribute("Customers"));
        //    var customersFromXML = (CustomerDTO[])xmlSerialize.Deserialize(new StringReader(inputXml));

        //    var customers = new List<Customer>();

        //    foreach (var item in customersFromXML)
        //    {
        //        var customer = Mapper.Map<Customer>(item);
        //        customers.Add(customer);
        //    }

        //    context.Customers.AddRange(customers);
        //    context.SaveChanges();

        //    return $"Successfully imported {customers.Count}";
        //}

        //public static string ImportSales(CarDealerContext context, string inputXml)
        //{
        //    var xmlSerialize = new XmlSerializer(typeof(SaleDTO[]), new XmlRootAttribute("Sales"));
        //    var salesFromXML = (SaleDTO[])xmlSerialize.Deserialize(new StringReader(inputXml));

        //    var sales = new List<Sale>();

        //    foreach (var item in salesFromXML)
        //    {
        //        var sale = Mapper.Map<Sale>(item);
        //        if (context.Cars.Find(item.CarId) != null)
        //        {
        //            sales.Add(sale);
        //        }
        //    }

        //    context.Sales.AddRange(sales);
        //    context.SaveChanges();

        //    return $"Successfully imported {sales.Count}";
        //}
        #endregion
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new CarWithDistanceDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarWithDistanceDTO[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarWithAttrDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarWithAttrDTO[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new SupplierDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(SupplierDTO[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), suppliers, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                 .Select(c => new CarPartsDTO
                 {
                     Make = c.Make,
                     Model = c.Model,
                     TravelledDistance = c.TravelledDistance,
                     Parts = c.PartCars
                                .Select(p => new PartsDTO
                                {
                                    Name = p.Part.Name,
                                    Price = p.Part.Price
                                })
                                .OrderByDescending(p => p.Price)
                                .ToArray()
                 })
                 .OrderByDescending(c => c.TravelledDistance)
                 .ThenBy(c => c.Model)
                 .Take(5)
                 .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarPartsDTO[]), new XmlRootAttribute("cars"));

            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count() >= 1)
                .Select(c => new CustomerDTO
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(cp => cp.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CustomerDTO[]), new XmlRootAttribute("customers"));

            serializer.Serialize(new StringWriter(sb), customers, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(c => new SalesDTO
                {
                    Car = new CarWithDistanceDTO
                    {
                        Make = c.Car.Make,
                        Model = c.Car.Model,
                        TravelledDistance = c.Car.TravelledDistance
                    },
                    Discount = c.Discount,
                    CustomerName = c.Customer.Name,
                    Price = c.Car.PartCars.Sum(p => p.Part.Price),
                    PriceDiscount = c.Car.PartCars.Sum(p => p.Part.Price) -
                        c.Car.PartCars.Sum(p => p.Part.Price) * c.Discount / 100
                })
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(SalesDTO[]), new XmlRootAttribute("sales"));

            serializer.Serialize(new StringWriter(sb), sales, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}