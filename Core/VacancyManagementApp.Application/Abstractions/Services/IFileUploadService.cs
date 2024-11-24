using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.File;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IFileUploadService
    {
        string GetValidFileExtension(IFormFile file);
        bool IsFileSizeValid(IFormFile file, long maxSize);
        Task<string> SaveFileAsync(IFormFile file, string fileName, string candidateEmail);
        Task<GetFileByOwnerDto> GetByOwnerId(Guid ownerId);
    }
}
