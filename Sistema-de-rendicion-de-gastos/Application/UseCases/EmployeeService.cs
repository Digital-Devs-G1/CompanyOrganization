﻿using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeQuery _repository;
        private EmployeeCreator _creator;
        private IEmployeeCommand _command;

        public EmployeeService(IEmployeeQuery repository, IEmployeeCommand command)
        {
            _repository = repository;
            _creator = new EmployeeCreator();
            _command = command;
        }

        public async Task<IList<EmployeeResponse>> GetEmployees()
        {
            IList<EmployeeResponse> list = new List<EmployeeResponse>();
            IList<Employee> entities = await _repository.GetEmployees();
            foreach (Employee entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }
        public async Task<EmployeeResponse>? GetEmployee(int employeeId)
        {
            Employee? entity = await _repository.GetEmployee(employeeId);
            if (entity != null)
                return _creator.Create(entity);
            return null;
        }
        public async Task<Employee> CreateEmployee(EmployeeRequest request)
        {
            var employee = new Employee
            {
                JobId = request.JobId,
                UserId = request.UserId,
                FirsName = request.FirsName,
                LastName = request.LastName,
                Phone = request.Phone,
                Sex = request.Sex,
                CivilStatus = request.CivilStatus,
                Dni = request.Dni
            };
            await _command.InsertEmployee(employee);
            return employee;
        }
    }
}