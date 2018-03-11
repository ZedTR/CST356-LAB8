﻿using FakeItEasy;
using Lab8.Data.Entities;
using Lab8.Repository;
using Lab8.Service;
using NUnit.Framework;
using System;

namespace Tests
{
    public class PetServiceTests
    {
        private IPetRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = A.Fake<IPetRepository>();
        }

        [Test]
        public void CheckupAlert_NoAlert()
        {
            // Arrange
            A.CallTo(() => _repository.GetPet(A<int>.Ignored)).Returns(new Pet
            {
                NextCheckup = DateTime.Today.AddDays(150)
            });

            // Act
            var service = new PetService(_repository);
            var view = service.GetPet(1);

            // Assert
            Assert.IsFalse(view.CheckupAlert);
        }

        [Test]
        public void CheckupAlert_YesAlert()
        {
            // Arrange
            A.CallTo(() => _repository.GetPet(A<int>.Ignored)).Returns(new Pet
            {
                NextCheckup = DateTime.Today.AddDays(150)
            });

            // Act
            var service = new PetService(_repository);
            var view = service.GetPet(1);

            // Assert
            Assert.IsTrue(view.CheckupAlert);
        }
    }
}
