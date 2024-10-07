using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Devices
{
    /// <summary>
    /// Модель запроса всех устройств в БД
    /// </summary>
    public class GetDevicesResponse
    {
        /// <summary>
        /// Количество устройств
        /// </summary>
        public int DeviceAmount { get; set; }

        /// <summary>
        /// Список устройств
        /// </summary>
        public List<DeviceView> Devices { get; set; }
    }

    /// <summary>
    /// Модель представления одного устройства в запросе
    /// </summary>
    public class DeviceView
    {
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Серийный номер
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Напряжение питания
        /// </summary>
        public int CurrentVolts { get; set; }

        /// <summary>
        /// Подключение газа
        /// </summary>
        public bool GasUsage { get; set; }

        /// <summary>
        /// Комната, в которой расположено
        /// </summary>
        public string Location { get; set; }
    }
}
