using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Queries
{
    public class UpdateRoomQuery
    {

        /// <summary>
        /// Название комнаты
        /// </summary>
        public string NewName { get; }

        /// <summary>
        /// Плозадь комнаты
        /// </summary>
        public int? NewArea { get; }

        /// <summary>
        /// Подключение газа к комнате
        /// </summary>
        public bool? NewGasConnected { get; }

        /// <summary>
        /// Напряжение питания в комнате
        /// </summary>
        public int? NewVoltage { get; }

        public UpdateRoomQuery(string newName = null,
                               int? newArea = null,
                               bool? newGasConnected = null,
                               int? newVoltage = null)
        {
            NewName = newName;
            NewArea = newArea;
            NewGasConnected = newGasConnected;
            NewVoltage = newVoltage;
        }
    }
}
