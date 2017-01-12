using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helper;
using WebApi.Infrastructure;

namespace WebApi.Tests
{
    [TestFixture]
    public class AssessmentTests
    {
        [OneTimeSetUp]
        public void Setup()
        {           
        }

        [TestCase(" ")]
        [TestCase(null)]
        public void reverse_words_input_value_test(string input)
        {
            // arrange
            var helper = new ReverseWordHelpter();

            // act
            var ex = Assert.Catch<ArgumentNullException>(() => helper.ReverseWords(input));

            // assert
            Assert.That(ex.Message, Does.Contain(Constants.ReverseWords.InvalidInput));
        }

        
        [TestCase("A", ExpectedResult = "A")]
        [TestCase("cat and dog", ExpectedResult = "tac dna god")]
        [TestCase("bluefin test", ExpectedResult = "nifeulb tset")]
        [TestCase("bluefin", ExpectedResult = "nifeulb")]
        [TestCase("This is the    test", ExpectedResult = "sihT si eht    tset")]
        [TestCase("123 456 789", ExpectedResult = "321 654 987")]
        public string reverse_result_test(string input)
        {
            // arrange
            var helper = new ReverseWordHelpter();

            // act
            var result =  helper.ReverseWords(input);

            // assert
            return result;
        }
        

        [TestCase(-1, -2, -3, ExpectedResult = TriangleType.Error)]
        [TestCase(5, 5, 12, ExpectedResult = TriangleType.Error)]
        [TestCase(12, 5, 5, ExpectedResult = TriangleType.Error)]
        [TestCase(5, 12, 5, ExpectedResult = TriangleType.Error)]
        [TestCase(10, 10, 10, ExpectedResult = TriangleType.Equilateral)]
        [TestCase(5, 6, 7, ExpectedResult = TriangleType.Scalene)]
        [TestCase(10, 10, 18, ExpectedResult = TriangleType.Isosceles)]
        public TriangleType triangle_test(int a, int b, int c)
        {
            // arrange
            var helper = new TriangleHelper();

            // act
            var resut = helper.ClassifyTriangleType(a,b,c);

            return resut;
        }
        

        [Test]       
        public void linked_list_test()
        {
            // arrange
            var helper = new LinkedListHelper();

            // act
            var resut = helper.FifithElement();

            // arrange
            Assert.AreEqual(resut.Value,7);
        }
    }
}
