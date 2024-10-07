using AutoMapper;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models.Home;
using HomeApi.Data.Queries;
using HomeApi.Data.Repos;
using HomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
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

        /// <summary>
        /// Обновить устройство
        /// </summary>
        /// <param name="id">Идентификатор устройства</param>
        /// <param name="request">Модель запроса обновления</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit{id}")]
        public async Task<IActionResult> EditAsyc(
            [FromRoute] Guid id,
            [FromBody]
            EditRoomRequest request
            )
        {

            //Проверяем, есть ли комната с данным id в БД
            var room = await _repository.GetRoomById(id);
            if (room == null)
                return StatusCode(400, $"Комната c Id = {id} отсутствует!");

            //Проверяем, что комнаты с таким названием еще нет в БД
            var roomByName = await _repository.GetRoomByName(request.NewName);
            if (roomByName != null && roomByName.Id != id)
                return StatusCode(400, $"Комната с названием {request.NewName} уже существует");

            //Преобразуем EditRoomRequest в UpdateRoomQuery при помощи AutoMapper
            var query = _mapper.Map<EditRoomRequest, UpdateRoomQuery>(request);

            //Обновляем данные в БД
            await _repository.UpdateRoom(room, query);

            //Возвращаем код успешного завершения операции
            return StatusCode(200, $"Комната c id = {id} изменено!");

        }
    }
}
