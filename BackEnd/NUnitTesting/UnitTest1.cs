using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using WebApplication1.Controllers;

namespace NUnitTesting
{
    public class Tests
    {

        private CatController _controller;
      
        
        
        [SetUp]
        public void Setup()
        {
            _controller = new CatController();
        }

        [Test]
        public void GetCats_ReturnsOk()
        {
            var result = _controller.GetCats();
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetCatYears_ReturnsOk()
        {

            var result = _controller.GetCatYears(1);
            var okResult = result as OkObjectResult;


            Assert.That(okResult.StatusCode, Is.EqualTo(7));
        }



    }
}