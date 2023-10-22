﻿using Application.DTO.Request;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<EmployeeRequest>
    {
        private readonly IDepartmentQuery _departmentQuery;
        private readonly IPositionQuery _positionQuery;
        private readonly IEmployeeQuery _employeeQuery;

        public CreateEmployeeValidator(IDepartmentQuery _departmentQuery, IPositionQuery positionQuery, IEmployeeQuery employeeQuery)
        {
            RuleFor(x => x.FirsName)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .NotNull().MaximumLength(50).WithMessage("El nombre debe ser menor a than 50 caracteres.");

            RuleFor(x => x.LastName)
              .NotEmpty().WithMessage("El apellido es requerido.")
              .NotNull().MaximumLength(50).WithMessage("El apellido debe ser menor a than 50 caracteres.");

            this._departmentQuery = _departmentQuery;
            this._positionQuery = positionQuery;
            this._employeeQuery = employeeQuery;

            RuleFor(x => x)
                .MustAsync(ExistDepartment)
                .WithMessage("El departamento no existe.").WithName("Departamento"); 

            RuleFor(x => x)
               .MustAsync(ExistPosition)
               .WithMessage("La posicion no existe.").WithName("Posicion");

            RuleFor(x => x)
               .MustAsync(ExistEmployee)
               .WithMessage("El superior debe existir y pertenecer al mismo departamento.").WithName("Superior");
        }

        private async Task<bool> ExistEmployee(EmployeeRequest request, CancellationToken token)
        {
            if(request.SuperiorId == null)
                return true;

            Employee superior = await _employeeQuery.GetEmployee(request.SuperiorId);

            if (superior == null)
                return false;
            
            return superior.DepartamentId == request.DepartmentId;
        }

        private async Task<bool> ExistPosition(EmployeeRequest request, CancellationToken token)
        {
            return await _positionQuery.ExistPosition(request.PositionId);
        }

        private async Task<bool> ExistDepartment(EmployeeRequest request, CancellationToken token)
        {
            return await _departmentQuery.ExistDepartment(request.DepartmentId);
        }
    }
}
