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

        public AddDeviceRequestValidator()
        {
            // Сохраним список допустимых вариантов размещения устройств
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.SerialNumber).NotEmpty();
            RuleFor(x => x.CurrentVolts)
                .NotEmpty()
                .InclusiveBetween(120,220)
                .WithMessage("Поддерживается напряжение питания от 120 до 220 В");
            RuleFor(x => x.Location).NotEmpty();
        }


    }
}
