using HomeApi.Data.Models.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Models.Home
{
    [Table("Rooms")]
    public class Room
    {
        /// <summary>
        /// Id комнаты
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Дата добавления комнаты
        /// </summary>
        public DateTime AddDate { get; set; } = DateTime.Now;

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

        /// <summary>
        /// Список устройств 
        /// </summary>
        public List<Device> Devices { get; set; }

    }
}
