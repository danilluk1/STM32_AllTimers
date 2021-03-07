using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM32_AllTimers_BL.Model {
    public static class SecondsConverter {

        /// <summary>
        /// Переводит заданное количество секунд в мс
        /// </summary>
        /// <param name="seconds">Время в секундах</param>
        /// <returns>секунды, переведённые в мс</returns>
        public static float ConvertSecondsToMs(float seconds) {
            if (seconds < 0) throw new ArgumentException("Количество секунд должно быть больше нуля.");
            return seconds * 1000f;
        }
        /// <summary>
        /// Переводит заданное количество мс в секунды
        /// </summary>
        /// <param name="ms">Время в мс</param>
        /// <returns>мс, переведённые в секунды</returns>
        public static float ConvertMsToSeconds(float ms) {
            if (ms < 0) throw new ArgumentException("Количество мс должно быть больше нуля.");
            return ms / 1000f;
        }
    }
}
