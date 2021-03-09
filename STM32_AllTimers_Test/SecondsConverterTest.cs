using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STM32_AllTimers_BL.Model;

namespace STM32_AllTimers_Test {
    [TestClass]
    public class SecondsConverterTest {
        [TestMethod]
        public void ConvertSecondsToMsTest_WrongValueTest() {
            Assert.ThrowsException<ArgumentException>(() => SecondsConverter.ConvertSecondsToMs(-1));
        }

        [TestMethod]
        public void ConvertSecondsToMsTest_RightResultTest() {
            Assert.AreEqual(1 * 1000f, SecondsConverter.ConvertSecondsToMs(1));
            Assert.AreEqual(100 * 1000f, SecondsConverter.ConvertSecondsToMs(100));
        }

        [TestMethod]
        public void ConvertMsToSecondsTest_WrongValueTest() {
            Assert.ThrowsException<ArgumentException>(() => SecondsConverter.ConvertMsToSeconds(-1));
        }

        [TestMethod]
        public void ConvertMscToSecondsTest_RightResultTest() {
            Assert.AreEqual(1 / 1000f, SecondsConverter.ConvertMsToSeconds(1));
            Assert.AreEqual(100 / 1000f, SecondsConverter.ConvertMsToSeconds(100));
        }
    }
}
