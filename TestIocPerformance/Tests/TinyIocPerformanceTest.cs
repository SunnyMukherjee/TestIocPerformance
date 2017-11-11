using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIocPerformance.Interfaces;
using TestIocPerformance.Models;
using TinyIoC;

namespace TestIocPerformance.Tests
{
    public class TinyIocPerformanceTest : IPerformanceTest
    {
        private int _numberOfTests;

        private TinyIoCContainer _container { get; set; }

        public TinyIocPerformanceTest(int numberOfTests)
        {
            _numberOfTests = numberOfTests;
            _container = TinyIoCContainer.Current;
        }

        void IPerformanceTest.RunRegistrationTests()
        {
            Console.WriteLine("TinyIOC: Running {0} registration tests", _numberOfTests);

            for (int x = 0; x < _numberOfTests; x++)
            {
                _container.Register<Test>(String.Format("Class{0}", x));
            }
        }

        void IPerformanceTest.RunResolveTests()
        {
            Console.WriteLine("TinyIOC: Running {0} resolution tests", _numberOfTests);

            for (int x = 0; x < _numberOfTests; x++)
            {
                _container.Resolve<Test>(String.Format("Class{0}", x));
            }
        }
    }
}
