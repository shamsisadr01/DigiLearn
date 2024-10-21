using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using CoreModule.Application._Utilities;
using CoreModule.Domain.Teacher.DomainServices;
using CoreModule.Domain.Teacher.Repositories;

namespace CoreModule.Application.Teacher.Register;

public class RegisterTeacherCommandHandler : IBaseCommandHandler<RegisterTeacherCommand>
{
    private readonly ITeacherRepository _repository;
    private readonly ITeacherDomainService _domainService;
    private readonly IFileService _fileService;
    public RegisterTeacherCommandHandler(ITeacherRepository repository, ITeacherDomainService domainService, IFileService fileService)
    {
        _repository = repository;
        _domainService = domainService;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
    {
        var cvFileName = await _fileService.SaveFileAndGenerateName(request.CvFile, CoreModuleDirectories.CvFileNames);

        var teacher = new Domain.Teacher.Models.Teacher(cvFileName, request.UserName, request.UserId, _domainService);
        _repository.Add(teacher);
        await _repository.Save();
        return OperationResult.Success();
    }
}