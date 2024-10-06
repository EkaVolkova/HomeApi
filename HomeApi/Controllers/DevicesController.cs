using AutoMapper;
using HomeApi.Contracts.Models.Devices;
using HomeApi.Data.Models.Devices;
using HomeApi.Data.Repos;
using HomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
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

    }
}
