using System;
using CQRSMediatR.Domain;

namespace CQRSMediatR.Application.Interfaces;

public interface IStudentRepository
{
    public Task<Student?> GetById(Int32 id);

    public Task Create(String name, Int32 age);
}

