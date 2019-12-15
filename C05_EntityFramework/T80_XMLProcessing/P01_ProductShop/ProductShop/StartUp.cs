using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            using (var db = new ProductShopContext())
            {
                // db.Database.EnsureCreated();
                // var file = File.ReadAllText(@".\..\..\..\Datasets\categories-products.xml");

                Console.WriteLine(GetUsersWithProducts(db));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserDTO[]), new XmlRootAttribute("Users"));
            var usersFromXML = (UserDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userFromXML in usersFromXML)
            {
                var user = Mapper.Map<User>(userFromXML);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductDTO[]), new XmlRootAttribute("Products"));
            var productsFromXML = (ProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productFromXML in productsFromXML)
            {
                var product = Mapper.Map<Product>(productFromXML);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryDTO[]), new XmlRootAttribute("Categories"));
            var categoriesFromXML = (CategoryDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryFromXML in categoriesFromXML)
            {
                var category = Mapper.Map<Category>(categoryFromXML);

                if (category.Name != null)
                {
                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductsDTO[]), new XmlRootAttribute("CategoryProducts"));
            var categoryProductsFromXML = (CategoryProductsDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductFromXML in categoryProductsFromXML)
            {
                if (categoryProductFromXML.CategoryId != null || categoryProductFromXML.ProductId != null)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(categoryProductFromXML);

                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductInRangeDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProductInRangeDTO[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserWithSoldProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                        .Select(ps => new SoldProductDTO
                                        {
                                            Name = ps.Name,
                                            Price = ps.Price
                                        })
                                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(UserWithSoldProductsDTO[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), usersWithSoldProducts, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(p => new CategoryByCountDTO
                {
                    Name = p.Name,
                    Count = p.CategoryProducts.Count(),
                    AveragePrice = p.CategoryProducts
                                        .Average(cp => cp.Product.Price),
                    TotalRevenue = p.CategoryProducts
                                        .Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CategoryByCountDTO[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new UserWithProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDTO
                    {
                        Count = u.ProductsSold.Count(),
                        SoldProducts = u.ProductsSold
                                            .Select(ps => new SoldProductDTO
                                            {
                                                Name = ps.Name,
                                                Price = ps.Price
                                            })
                                            .OrderByDescending(ps => ps.Price)
                                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            var users = new UsersDTO
            {
                Count = usersWithProducts.Count(),
                Users = usersWithProducts
                            .Take(10)
                            .ToArray()
            };

            var xmlSerializer = new XmlSerializer(typeof(UsersDTO), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}