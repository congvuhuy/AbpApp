using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ord.AbpApp.Communes.Dtos;

namespace Ord.AbpApp.Communes
{
    public class CreateCommuneDtoValidator:AbstractValidator<CreateCommuneDto>
    {
        public  CreateCommuneDtoValidator()
        {
            RuleFor(x => x.CommuneCode).NotEmpty().WithMessage("Mã xã không được để trống")
                                        .GreaterThan(0).WithMessage("Mã xã không hợp lệ");
            RuleFor(x => x.CommuneName).NotEmpty().WithMessage("Tên xã không được để trống")
                                        .MaximumLength(50).WithMessage("Tên xã không quá 50 ký tự");
            RuleFor(x => x.CommuneType).IsInEnum().WithMessage("Cấp không hợp lệ");
            RuleFor(x => x.ProvinceCode).NotEmpty().WithMessage("Mã tỉnh không được để trống")
                                      .GreaterThan(0).WithMessage("Mã tỉnh không hợp lệ");
            RuleFor(x => x.DistrictCode).NotEmpty().WithMessage("Mã huyện không được để trống")
                                       .GreaterThan(0).WithMessage("Mã tỉnh không hợp lệ");
        }
       
    }
}
