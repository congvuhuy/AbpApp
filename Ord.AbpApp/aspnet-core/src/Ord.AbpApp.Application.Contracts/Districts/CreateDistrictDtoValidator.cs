﻿using FluentValidation;
using Ord.AbpApp.Districts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ord.AbpApp.Districts
{
    public class CreateDistrictDtoValidator:AbstractValidator<CreateDistrictDto>
    {
        public CreateDistrictDtoValidator()
        {
            RuleFor(x => x.DistrictCode).NotEmpty().WithMessage("Mã huyện không được để trống")
                                        .GreaterThan(0).WithMessage("Mã tỉnh không hợp lệ");
            RuleFor(x => x.DistrictName).NotNull().WithMessage("Tên huyện không được để trống")
                                         .NotEmpty().WithMessage("Tên huyện không được để trống")
                                        .MaximumLength(50).WithMessage("Tên huyện không quá 50 ký tự");
            RuleFor(x => x.DistrictType).IsInEnum().WithMessage("Cấp không hợp lệ");
            RuleFor(x => x.ProvinceCode).NotEmpty().WithMessage("Mã tỉnh không được để trống")
                                      .GreaterThan(0).WithMessage("Mã tỉnh không hợp lệ");
        }
    }
}