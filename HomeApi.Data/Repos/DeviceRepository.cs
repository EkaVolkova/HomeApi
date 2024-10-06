using HomeApi.Contracts.Models.Devices;
using HomeApi.Data.Models;
using HomeApi.Data.Models.Devices;
using HomeApi.Data.Models.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Data.Repos
{
    public class DeviceRepository : IDeviceRepository
    {
        HomeApiContext _context;
        public DeviceRepository(HomeApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавить устройство в БД асинхронно
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <param name="room">Комната</param>
        public async Task AddDevice(Device device, Room room)
        {
            //Добавляем идентификатор комнаты и комнату к устройству
            device.RoomId = room.Id;
            device.Room = room;

            //Добавляем устройство в асинхронном режиме
            var entry = _context.Entry(device);
            if (entry.State == EntityState.Detached)
                await _context.Devices.AddAsync(device);

            // Сохраняем изменения в базе 
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получить список всех устройств в БД
        /// </summary>
        /// <returns>Список устройств</returns>
        public async Task<List<Device>> GetDevices()
        {
            //Получаем устройства вместе с объектам комнат, в которых они расположены
            return await _context.Devices
                .Include(d => d.Room)
                .ToListAsync();
        }
    }
}
