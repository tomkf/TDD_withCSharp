using Microsoft.AspNetCore.Mvc;
using Moq;
using MVC_inclass.Controllers;
using MVC_inclass.Models;
using MVC_inclass.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace MVC_inclass.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IndexViewhas2Items()
        {
            //does it return a view, is the view a list of products, are there two of them
            
            //break points can be set at each test to verify which ones indiividuaklly are failling
            //run with debug all

            var repo = new ProductRepository();

            //now access to home controller
            var controller = new HomeController(repo);

            // the first asssertion, going against the index action method, and seeing if it returns a view
            var viewResult = Assert.IsType<ViewResult>(controller.Index());

            var model = Assert.IsType<List<Product>>(viewResult.Model);

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void ProductDetail1IsNammedApples()
        {
            var repo = new ProductRepository();
            var controller = new HomeController(repo);
            var viewResult = Assert.IsType<ViewResult>(controller.Details(1));

            //is the model a single product
            var model = Assert.IsType<Product>(viewResult.Model);

            //if single product, is name apples....
            Assert.Equal("Apple",
                         model.Name);
        }


        [Fact]
        public void IndexViewhas3Items()
        {
            //will return view, willm return 3, will they be products

            //new mock instance of our repo

            //now no longer using product repo, we must define implementation of the interface
            var mockRepo = new Mock<IProductRepository>();

            //initializing the repo
            //this replaces testing the repo, making it a unit and not an integration test

            mockRepo.Setup(mr => mr.GetProducts())
                .Returns(new List<Product> { new Product(), new Product(), new Product() 
                });

            var controller = new HomeController(mockRepo.Object);

            // the first asssertion, going against the index action method, and seeing if it returns a view
            var viewResult = Assert.IsType<ViewResult>(controller.Index());
            var model = Assert.IsType<List<Product>>(viewResult.Model);

            Assert.Equal(3, model.Count);
        }





        [Fact]
        public void ProductDetail1IsNammedShoe()
        {
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(mr => mr.GetProducts(It.IsAny<int>()))
             .Returns(new Product
             {
                 ID = 1,
                 Name = "Shoe",
                 Price = 99.99m
             });


            //is the model a single product
            var model = Assert.IsType<Product>(viewResult.Model);

            //if single product, is name apples....
            Assert.Equal("Apple",
                         model.Name);
        

        var controller = new HomeController(mockRepo.Object);
        var viewResult = Assert.IsType<ViewResult>(controller.Details(1));
        var model = Assert.IsType<List<Product>>(viewResult.Model);
        Assert.Equal("Shoe", model.Name);
    }
        
}