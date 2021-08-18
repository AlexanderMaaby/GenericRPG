using System;
using Xunit;

namespace GenericRPGTests
{
    public class HeroTests
    {
        [Fact]
        public void Mage_CharacterCreated_ShouldBeLevelOne()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            int expected = 1;
            //Act
            int actual = hero.Level;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_CharacterLevelUp_ShouldBeLevelTwo()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            int expected = 2;
            //Act
            hero.LevelUp(1);
            int actual = hero.Level;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MageLevelUp_LevelUpZero_ShouldThrowArgumentException()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();

            //Act and Assert
            Assert.Throws<ArgumentException>(() => hero.LevelUp(0));
        }
        [Fact]
        public void MageBasePrimaryAttributes_DefaultValueAdded_ShouldBeAtLevelOneValues()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            int[] expected = new int[] { 1, 1, 8, 5 };
            //Act
            GenericRPG.BasePrimaryAttributes temp = new GenericRPG.BasePrimaryAttributes()
            {
                Dexterity = hero.totalPrimaryAttributes.Dexterity,
                Strength = hero.totalPrimaryAttributes.Strength,
                Intelligence = hero.totalPrimaryAttributes.Intelligence,
                Vitality = hero.totalPrimaryAttributes.Vitality
            };
            int[] actual = new int[] 
            { (int)temp.Dexterity, (int)temp.Strength, (int)temp.Intelligence, (int)temp.Vitality };
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void WarriorBasePrimaryAttributes_DefaultValueAdded_ShouldBeAtLevelOneValues()
        {
            //Arrange
            GenericRPG.Warrior hero = new GenericRPG.Warrior();
            int[] expected = new int[] { 2, 5, 1, 10 };
            //Act
            GenericRPG.BasePrimaryAttributes temp = new GenericRPG.BasePrimaryAttributes()
            {
                Dexterity = hero.totalPrimaryAttributes.Dexterity,
                Strength = hero.totalPrimaryAttributes.Strength,
                Intelligence = hero.totalPrimaryAttributes.Intelligence,
                Vitality = hero.totalPrimaryAttributes.Vitality
            };
            int[] actual = new int[]
            { (int)temp.Dexterity, (int)temp.Strength, (int)temp.Intelligence, (int)temp.Vitality };
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BasePrimaryAttributes_LevelUpValue_ShouldBeAtLevelTwoValues()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            int[] expected = new int[] { 2, 2, 13, 8 };
            int levelsToGain = 1;
            //Act
            hero.LevelUp(levelsToGain);
            GenericRPG.BasePrimaryAttributes temp = new GenericRPG.BasePrimaryAttributes()
            {
                Dexterity = hero.totalPrimaryAttributes.Dexterity,
                Strength = hero.totalPrimaryAttributes.Strength,
                Intelligence = hero.totalPrimaryAttributes.Intelligence,
                Vitality = hero.totalPrimaryAttributes.Vitality
            };
            int[] actual = new int[]
            { (int)temp.Dexterity, (int)temp.Strength, (int)temp.Intelligence, (int)temp.Vitality };
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
