using Microsoft.VisualStudio.TestTools.UnitTesting;
using STM32_AllTimers_BL.Model;
using System;

namespace STM32_AllTimers_Test {
    [TestClass]
    public class BasicTimerTest {
        [TestMethod]
        public void BasicTimerRightValue_Test() {
            IBasicTimer bt = new BasicTimer {
                InputFrequency = 72000000,
                Prescaler = 719,
                CounterPeriod = 50000
            };

            Assert.AreEqual(500, bt.CalculatePeriodMs());
        }

        [TestMethod]
        public void BasicTimerWrongParameters_Test() {
            IBasicTimer bt = new BasicTimer();                   
            Assert.ThrowsException<ArgumentException>(()=>bt.InputFrequency = 0);
            Assert.ThrowsException<ArgumentException>(() => bt.Prescaler = 0);
            Assert.ThrowsException<ArgumentException>(() => bt.CounterPeriod = 0);
        }
    }
}
