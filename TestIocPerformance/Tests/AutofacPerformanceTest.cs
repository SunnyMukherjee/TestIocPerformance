using Autofac;
using System;
using TestIocPerformance.Interfaces;
using TestIocPerformance.Models;

namespace TestIocPerformance.Tests
{
    public class AutofacPerformanceTest : IPerformanceTest
    {
        private int _numberOfTests;
        private static ContainerBuilder Builder { get; set; }
        private static IContainer Container { get; set; }

        public AutofacPerformanceTest(int numberOfTests)
        {
            _numberOfTests = numberOfTests;

            Builder = new ContainerBuilder();            
        }

        public void RunRegistrationTests()
        {
            Console.WriteLine("Autofac: Running {0} registration tests", _numberOfTests);
            
            for (int x = 0; x < _numberOfTests; x++)
            {
                Builder.RegisterType<Test>().As<ITest>().Named<Test>(String.Format("Class{0}", x));
            }

            Container = Builder.Build();
        }

        public void RunResolveTests()
        {
            Console.WriteLine("Autofac: Running {0} resolution tests", _numberOfTests);

            using (var scope = Container.BeginLifetimeScope())
            {
                for (int x = 0; x < _numberOfTests; x++)
                {
                    scope.ResolveNamed<Test>(String.Format("Class{0}", x));
                }
            }
        }
    }
}
