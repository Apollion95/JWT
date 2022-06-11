﻿using FluentValidation;

namespace JWT.DTO.Validator
{
    public class TestUserDtoValidator : AbstractValidator<TestUserDTO>
    {
        public TestUserDtoValidator()
        {
            RuleFor(x => x.Phone).MinimumLength(9).MaximumLength(12);
            RuleFor(x => x.Email).EmailAddress();

        }
    }
}
