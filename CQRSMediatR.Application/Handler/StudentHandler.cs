using System;
using CQRSMediatR.Application.Command;
using CQRSMediatR.Application.Interfaces;
using CQRSMediatR.Application.Query;
using CQRSMediatR.Domain;
using MediatR;

namespace CQRSMediatR.Application.Handler;

public class StudentHandler :
    IRequestHandler<StudentGetByIdQuery, Student?>,
    IRequestHandler<StudentCreateCommand>
{
	private IStudentRepository _studentRepository;

	public StudentHandler(IStudentRepository studentRepository)
	{
		_studentRepository = studentRepository;
	}

    public async Task<Student?> Handle(StudentGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetById(request.Id);
    }

    public async Task<Unit> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
    {
        await _studentRepository.Create(request.Name, request.Age);

        return Unit.Value;
    }
}

