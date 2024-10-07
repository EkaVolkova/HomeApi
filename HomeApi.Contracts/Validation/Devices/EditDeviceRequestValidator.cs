using FluentValidation;
using HomeApi.Contracts.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Validation.Devices
{
    public class EditDeviceRequestValidator : AbstractValidator<EditDeviceRequest>
    {


        public EditDeviceRequestValidator()
        {
            // Сохраним список допустимых вариантов размещения устройств
            RuleFor(x => x.NewLocation).NotEmpty();
        }

    }
}
