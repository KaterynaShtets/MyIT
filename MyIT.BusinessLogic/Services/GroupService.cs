using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class GroupService : IGroupService
{
    private readonly IRepository<Group> _groupRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _groupRepository = unitOfWork.GetRepository<Group>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GroupDto>> GetAllGroupsAsync(Guid educationalProgramId)
    {
        var groups =  await _groupRepository.GetAsync(x=>x.EducationalProgramId == educationalProgramId);
        return _mapper.Map<IEnumerable<GroupDto>>(groups);
    }
    
    public async Task<GroupDto> GetGroupByIdAsync(Guid groupId)
    {
        var group = await _groupRepository.GetAsync(groupId);
        return _mapper.Map<GroupDto>(group);
    }
    
    public async Task AddGroupAsync(Guid educationalProgramId, GroupDto groupDto)
    {
        var group = _mapper.Map<Group>(groupDto);
        group.EducationalProgramId = educationalProgramId;
        _groupRepository.Create(group);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdateGroupAsync(Guid id, GroupDto groupDto)
    {
        var group = await _groupRepository.GetAsync(id);
        var groupMapped = _mapper.Map(groupDto, group);
        groupMapped.Id = id;
        groupMapped.EducationalProgramId = group.EducationalProgramId;
        _groupRepository.Update(groupMapped);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteGroupAsync(Guid groupId)
    {
        _groupRepository.Delete(groupId);
        await _unitOfWork.SaveChangesAsync();
    }
}