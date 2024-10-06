using AutoMapper;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models.Home;
using HomeApi.Data.Repos;
using HomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        // Ссылка на объект конфигурации
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;
        IRoomRepository _repository;

        // Инициализация конфигурации при вызове конструктора
        public RoomsController(IOptions<HomeOptions> options, IMapper mapper, IRoomRepository repository)
        {
            _options = options;
            _mapper = mapper;
            _repository = repository;
        }
        /// <summary>
        /// Добавление новой комнаты
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(
            [FromBody] // Атрибут, указывающий, откуда брать значение объекта
            AddRoomRequest request // Объект запроса
                                     )
        {
            //Получаем комнату с таким же именем из БД
            var savedRoom = await _repository.GetRoomByName(request.Name);

            //Если комната существует, возвращаем ошибку
            if (savedRoom != null)
                return StatusCode(400, $"Комната {request.Name} уже есть в БД");

            //
            var room = _mapper.Map<AddRoomRequest, Room>(request);

            await _repository.AddRoom(room);

            return StatusCode(200, $"Комната {request.Name} добавлено!");
        }
    }
}
