using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Rooms
{
    public class AddRoomRequest
    {

        /// <summary>
        /// Название комнаты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Плозадь комнаты
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// Подключение газа к комнате
        /// </summary>
        public bool GasConnected { get; set; }

        /// <summary>
        /// Напряжение питания в комнате
        /// </summary>
        public int Voltage { get; set; }
    }
}
