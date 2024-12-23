using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ord.AbpApp.Provinces.Dtos;

namespace Ord.AbpApp.Provinces
{
    public class CreateProvinceDtoValidator : AbstractValidator<CreateProvinceDto>
    {
        public CreateProvinceDtoValidator()
        {
            RuleFor(x => x.ProvinceCode).NotEmpty().WithMessage("Mã tỉnh không được để trống")
                                        .GreaterThan(0).WithMessage("Mã tỉnh không hợp lệ");
            RuleFor(x => x.ProvinceName).NotEmpty().WithMessage("Tên tỉnh không được để trống")
                                        .MaximumLength(50).WithMessage("Tên tỉnh không quá 50 ký tự");
            RuleFor(x => x.ProvinceType).IsInEnum().WithMessage("Cấp không hợp lệ");
        }
    }

}
