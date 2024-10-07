using AutoMapper;
using HomeApi.Contracts.Models.Devices;
using HomeApi.Data.Models.Devices;
using HomeApi.Data.Queries;
using HomeApi.Data.Repos;
using HomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер статусов устройств
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;
        private IDeviceRepository _deviceReposirory;
        private IRoomRepository _roomReposirory;

        public DevicesController(IOptions<HomeOptions> options, IMapper mapper, IDeviceRepository deviceReposirory, IRoomRepository roomReposirory)
        {
            _options = options;
            _mapper = mapper;
            _deviceReposirory = deviceReposirory;
            _roomReposirory = roomReposirory;
        }

        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            //Получаем список устройств из БД
            var devises = await _deviceReposirory.GetDevices();

            //Проверяем, есть ли устройства
            if(devises == null || devises.Count == 0)
                return StatusCode(200, "Устройства отсутствуют");

            //Преобразуем данные в представление
            var resp = new GetDevicesResponse
            {
                DeviceAmount = devises.Count,
                Devices = _mapper.Map<List<Device>, List<DeviceView>>(devises)
            };

            //Возвращаем код успешного завершения и представление
            return StatusCode(200, resp);
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(
            [FromBody] // Атрибут, указывающий, откуда брать значение объекта
            AddDeviceRequest request // Объект запроса
                                     )
        {
            
            //Получаем объект класса Room по названию из запроса
            var room = await _roomReposirory.GetRoomByName(request.Location);

            //Выясняем, есть ли комната с указанным названием в репозитории
            if (room == null)
                return StatusCode(400, $"Комната {request.Location} отсутствует!");

            //Преобразуем класс AddDeviceRequest в Device при помози автомаппера
            var device = _mapper.Map<AddDeviceRequest, Device>(request);

            //Записываем устройство в БД
            await _deviceReposirory.AddDevice(device, room);

            //Возвращаем статусное сообщение об успешно сохраненном устройстве
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }

        /// <summary>
        /// Обновить устройство
        /// </summary>
        /// <param name="id">Идентификатор устройства</param>
        /// <param name="request">Модель запроса обновления</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Edit{id}")]
        public async Task<IActionResult> EditAsyc(
            [FromRoute] Guid id,
            [FromBody]
            EditDeviceRequest request
            )
        {
            //Проверяем, есть ли устройство с данным id в БД
            var device = await _deviceReposirory.GetDeviceById(id);
            if (device == null)
                return StatusCode(400, $"Устройство c id = {id} отсутствует!");

            //Проверяем, есть ли комната с данным названием в БД
            var room = await _roomReposirory.GetRoomByName(request.NewLocation);
            if (room == null)
                return StatusCode(400, $"Комната {request.NewLocation} отсутствует!");

            //Преобразуем EditDeviceRequest в UpdateDeviceQuery при помощи AutoMapper
            var query = _mapper.Map<EditDeviceRequest, UpdateDeviceQuery>(request);

            //Обновляем данные в БД
            await _deviceReposirory.UpdateDevice(device, room, query);

            //Возвращаем код успешного завершения операции
            return StatusCode(200, $"Устройство c id = {id} изменено!");

        }
        /// <summary>
        /// Удалить устройство
        /// </summary>
        /// <param name="id">Идентификатор устройства</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete{id}")]
        public async Task<IActionResult> DeleteAsyc(
            [FromRoute] Guid id
            )
        {
            //Проверяем, есть ли устройство с данным id в БД
            var device = await _deviceReposirory.GetDeviceById(id);
            if (device == null)
                return StatusCode(400, $"Устройство c id = {id} отсутствует!");

            //Удаляем данные из БД
            await _deviceReposirory.DeleteDevice(device);

            //Возвращаем код успешного завершения операции
            return StatusCode(200, $"Устройство c id = {id} удалено!");

        }
    }
}
