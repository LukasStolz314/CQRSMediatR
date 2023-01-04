using System;
using CQRSMediatR.Application.Interfaces;
using CQRSMediatR.Domain;

namespace CQRSMediatR.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
	private List<Student> students = new();

	public async Task<Student?> GetById(Int32 id)
	{
		return students.FirstOrDefault(s => s.Id == id);
	}

	public async Task Create(String name, Int32 age)
	{
		Int32 id = 1;
		if(students.Count > 0)
			id = students.Max(s => s.Id) + 1;

		var newStudent = new Student(id, name, age);

		students.Add(newStudent);
	}
}

