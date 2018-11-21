using System;
using Lab3.DI.Tests.Fakes;
using Xunit;

namespace Lab3.DI.Tests
{
    //Functional tests with fake classes
    public class ResolverTest
    {
        private Container container;
        private Resolver resolver;

        public ResolverTest()
        {
            container = new Container();
            resolver = new Resolver(container);
        }

        [Fact]
        public void Get_ChildClass_ShouldHaveInterfaceType()
        {
            container.Register<IFakeStudent, SuperFakeStudent>();
            var model = resolver.Get<IFakeStudent>();

            var expectedResult = "Hello";
            var actualResult = model.Do(); //SuperFakeStudent returns "World" in Do() function

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Get_WithParameters_ShouldHaveField()
        {
            container.Register<IFakeStudent, FakeStudent>();
            var model = resolver.Get<IFakeStudent>("Bob");

            var expectedResult = "Bob";
            var actualResult = model.FirstName;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Register_ParentClassChildClass_ShouldWork()
        {
            container.Register<FakeStudent, SuperFakeStudent>(); //This DI can register child classes as parent
            var model = resolver.Get<FakeStudent>("Bob");

            var expectedResult = "Bob";
            var actualResult = model.FirstName;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Get_WithWrongParameters_ThrowsException()
        {
            container.Register<IFakeStudent, FakeStudent>();

            Assert.Throws<MissingMethodException>(
                () => resolver.Get<IFakeStudent>("Bob", "Marley"));
        }

        [Fact]
        public void Register_Struct_ThrowsException()
        {
            Assert.Throws<Exception>(
                () => container.Register<IFakeStudent, StructFakeStudent>());
        }

        [Fact]
        public void Get_ChildClassParentClass_ThrowsInvalidCastException()
        {
            container.Register<SuperFakeStudent, FakeStudent>();
            Assert.Throws<InvalidCastException>(
                () => resolver.Get<SuperFakeStudent>());
        }
    }
}
