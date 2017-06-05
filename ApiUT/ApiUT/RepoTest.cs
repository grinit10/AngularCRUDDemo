using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Common.Viewmodels;
using System.Linq;
using System.Data.Entity;
using Moq;
using Common.Interfaces;
using Repository.Repositories;
using Common.Models;

namespace ApiUT
{
    [TestClass]
    public class RepoTest
    {
        List<Property> properties = new List<Property>();
        List<Company> companies = new List<Company>();
        IList<Propertyvm> expectdProperties = new List<Propertyvm>();

        public RepoTest()
        {
            properties.Add(new Property { Id = 1, Name = "First Property", BoundsLatA = 1.2, BoundsLatB = 3.4, BoundsLngA = 5.6, BoundsLngB = 7.8, CompanyId = 1 });
            properties.Add(new Property { Id = 2, Name = "Second Property", BoundsLatA = 3.4, BoundsLatB = 7.8, BoundsLngA = 1.2, BoundsLngB = 5.6, CompanyId = 2 });
            properties.Add(new Property { Id = 3, Name = "Third Property", BoundsLatA = 7.8, BoundsLatB = 3.4, BoundsLngA = 5.6, BoundsLngB = 1.2, CompanyId = 3 });
            properties.Add(new Property { Id = 4, Name = "Fourth Property", BoundsLatA = 7.8, BoundsLatB = 3.4, BoundsLngA = 3.4, BoundsLngB = 7.8, CompanyId = 4 });
            properties.Add(new Property { Id = 5, Name = "Fifth Property", BoundsLatA = 1.2, BoundsLatB = 5.6, BoundsLngA = 5.6, BoundsLngB = 7.8, CompanyId = 5 });
            properties.Add(new Property { Id = 6, Name = "Sixth Property", BoundsLatA = 5.6, BoundsLatB = 3.4, BoundsLngA = 1.2, BoundsLngB = 7.8, CompanyId = 6});

            companies.Add(new Company { Id = 1, Name = "First Company" });
            companies.Add(new Company { Id = 2, Name = "Second Company" });
            companies.Add(new Company { Id = 3, Name = "Third Company" });
            companies.Add(new Company { Id = 4, Name = "Fourth Company" });
            companies.Add(new Company { Id = 5, Name = "Fifth Company" });
            companies.Add(new Company { Id = 6, Name = "Sixth Company" });

            expectdProperties.Add(new Propertyvm { id = 1, Name = "First Property", BoundsLatA = 1.2, BoundsLatB = 3.4, BoundsLngA = 5.6, BoundsLngB = 7.8, CompanyName = "First Company" });
            expectdProperties.Add(new Propertyvm { id = 2, Name = "Second Property", BoundsLatA = 3.4, BoundsLatB = 7.8, BoundsLngA = 1.2, BoundsLngB = 5.6, CompanyName = "Second Company" });
            expectdProperties.Add(new Propertyvm { id = 3, Name = "Third Property", BoundsLatA = 7.8, BoundsLatB = 3.4, BoundsLngA = 5.6, BoundsLngB = 1.2, CompanyName = "Third Company" });
            expectdProperties.Add(new Propertyvm { id = 4, Name = "Fourth Property", BoundsLatA = 7.8, BoundsLatB = 3.4, BoundsLngA = 3.4, BoundsLngB = 7.8, CompanyName = "Fourth Company" });
            expectdProperties.Add(new Propertyvm { id = 5, Name = "Fifth Property", BoundsLatA = 1.2, BoundsLatB = 5.6, BoundsLngA = 5.6, BoundsLngB = 7.8, CompanyName = "Fifth Company" });
            expectdProperties.Add(new Propertyvm { id = 6, Name = "Sixth Property", BoundsLatA = 5.6, BoundsLatB = 3.4, BoundsLngA = 1.2, BoundsLngB = 7.8, CompanyName = "Sixth Company" });
        }

        private PropertyRepository Mockdata()
        {
            var Propertydata = properties.AsQueryable();
            var MockPropertyDBSet = new Mock<IDbSet<Property>>();
            MockPropertyDBSet.Setup(m => m.Provider).Returns(Propertydata.Provider);
            MockPropertyDBSet.Setup(m => m.Expression).Returns(Propertydata.Expression);
            MockPropertyDBSet.Setup(m => m.ElementType).Returns(Propertydata.ElementType);
            MockPropertyDBSet.Setup(m => m.GetEnumerator()).Returns(Propertydata.GetEnumerator());

            var Companydata = companies.AsQueryable();
            var MockCompanyDBSet = new Mock<IDbSet<Company>>();
            MockCompanyDBSet.Setup(m => m.Provider).Returns(Companydata.Provider);
            MockCompanyDBSet.Setup(m => m.Expression).Returns(Companydata.Expression);
            MockCompanyDBSet.Setup(m => m.ElementType).Returns(Companydata.ElementType);
            MockCompanyDBSet.Setup(m => m.GetEnumerator()).Returns(Companydata.GetEnumerator());

            Mock<IPropertyDBContext> customDbContextMock = new Mock<IPropertyDBContext>();
            customDbContextMock
                .Setup(x => x.Properties)
                .Returns(MockPropertyDBSet.Object);
            customDbContextMock
                .Setup(x => x.Companies)
                .Returns(MockCompanyDBSet.Object);

            PropertyRepository repo = new PropertyRepository(customDbContextMock.Object);

            return repo;
        }

        [TestMethod]
        public void TestGetproperties()
        {
            PropertyRepository repo = Mockdata();
            IEnumerable<Propertyvm> rslt = repo.Getproperties();
            IEnumerable<Propertyvm> expectd = new List<Propertyvm>(expectdProperties);

            Assert.AreEqual(expectd.First().Name, rslt.First().Name);
            Assert.AreEqual(expectd.ElementAt(2).CompanyName, rslt.ElementAt(2).CompanyName);
        }

        [TestMethod]
        public void TestGetByID()
        {
            PropertyRepository repo = Mockdata();
            Propertyvm rslt = repo.GetByID(1);
            Propertyvm expectd = expectdProperties[0];

            Assert.AreEqual(expectd.Name, rslt.Name);
        }
    }
}
