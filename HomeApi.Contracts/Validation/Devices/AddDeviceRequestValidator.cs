using FluentValidation;
using HomeApi.Contracts.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Validation.Devices
{
    public class AddDeviceRequestValidator : AbstractValidator<AddDeviceRequest>
    {
        string[] _validLocations;

        public AddDeviceRequestValidator()
        {
            // Сохраним список допустимых вариантов размещения устройств
            _validLocations = new[]
            {
               "Kitchen",
               "Bathroom",
               "Livingroom",
               "Toilet"
            };
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.SerialNumber).NotEmpty();
            RuleFor(x => x.CurrentVolts)
                .NotEmpty()
                .InclusiveBetween(120,200)
                .WithMessage("Поддерживается напряжение питания от 120 до 220 В");
            RuleFor(x => x.GasUsage).NotEmpty();
            RuleFor(x => x.Location).NotEmpty().Must(BeSupported);
        }

        /// <summary>
        ///  Метод кастомной валидации для свойства location
        /// </summary>
        private bool BeSupported(string location)
        {
            // Проверим, содержится ли значение в списке допустимых
            return _validLocations.Any(e => e == location);
        }

    }
}
