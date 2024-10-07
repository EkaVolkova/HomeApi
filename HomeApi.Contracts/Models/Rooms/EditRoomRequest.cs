using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Rooms
{
    public class EditRoomRequest
    {
        /// <summary>
        /// Название комнаты
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// Плозадь комнаты
        /// </summary>
        public int? NewArea { get; set; }

        /// <summary>
        /// Подключение газа к комнате
        /// </summary>
        public bool? NewGasConnected { get; set; }

        /// <summary>
        /// Напряжение питания в комнате
        /// </summary>
        public int? NewVoltage { get; set; }
    }
}
