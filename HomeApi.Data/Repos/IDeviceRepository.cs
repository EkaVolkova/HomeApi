using HomeApi.Contracts.Models.Devices;
using HomeApi.Data.Models.Devices;
using HomeApi.Data.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Repos
{
    public interface IDeviceRepository
    {
        /// <summary>
        /// Добавить устройство в БД асинхронно
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <param name="room">Комната</param>
        Task AddDevice(Device device, Room room);

        /// <summary>
        /// Получить список всех устройств в БД
        /// </summary>
        /// <returns>Список устройств</returns>
        Task<List<Device>> GetDevices();
    }
}
