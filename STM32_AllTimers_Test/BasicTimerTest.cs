using Microsoft.VisualStudio.TestTools.UnitTesting;
using STM32_AllTimers_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM32_AllTimers_Test {
    [TestClass]
    public class BasicTimerTest {
        [TestMethod]
        public void ConvertSecondsToMsTest_WrongValueTest() {
            IBasicTimer bt = new BasicTimer();
        }
    }
}
