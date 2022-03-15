using DAL;
using DTO;
using NUnit.Framework;
using System;

namespace Unit_Tests
{
    public class IngredientDB_Test
    {

        [Test]
        public void GetAllIngredients_Test()
        {            
            Assert.IsNotEmpty(IngredientDB.GetAllIngredients());
        }

        [Test]
        public void GetAllCategories_Test()
        {
            Assert.IsNotEmpty(IngredientDB.GetAllCategories());
        }

        [Test]
        public void Insert_Ingredient_Fail_Test()
        {
            Ingredient i = new Ingredient()
            {
                Id = 1 // aldready exists
            };

            Assert.Throws<Exception>(() => IngredientDB.Insert(i));          
        }

        [Test]
        public void Insert_Category_Fail_Test()
        {
            IngredientCategory c = new IngredientCategory()
            {
                Id = 1 // aldready exists
            };

            Assert.Throws<Exception>(() => IngredientDB.Insert(c));
        }

    }
}