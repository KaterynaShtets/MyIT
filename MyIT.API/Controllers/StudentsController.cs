using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : Controller
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid groupId)
    {
        var students = await _studentService.GetAllStudentsAsync(groupId);

        return Ok(students);
    }
    
    [HttpGet("{id:Guid}", Name = nameof(StudentsController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);

        return Ok(student);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadDocumentToS3([FromQuery] Guid studentId, IFormFile file)
    {
        await _studentService.UploadStudentPhotoStudentAsync(studentId, file);

        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid groupId, [FromBody, Required] StudentDto studentDto)
    {
        await _studentService.AddStudentAsync(groupId, studentDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] StudentDto studentDto)
    {
        await _studentService.UpdateStudentAsync(id, studentDto);

        return Ok();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _studentService.DeleteStudentAsync(id);

        return NoContent();
    }
}