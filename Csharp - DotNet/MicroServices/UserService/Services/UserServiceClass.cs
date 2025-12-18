using UserService.DTO;
using UserService.Models;
using UserService.Rest;
using UserService.Service;

namespace UserService.Service;

public class UserServiceClass : IService<UserDtoReceive, UserDtoSend>
{
    private readonly IRepository<User> _repository;
    //private RestClient<IngredientDtoSend> _restClient;

    public UserServiceClass(IRepository<User> repository)
    {
        _repository = repository;
        //_restClient = new RestClient<IngredientDtoSend>("http://localhost:5280/api/ingredient/");
    }

    public async Task<UserDtoSend> Create(UserDtoReceive receive)
    {
        return await EntityToDto(_repository.Create(DtoToEntity(receive, null)));
    }

    public async Task<UserDtoSend> Update(UserDtoReceive receive, int id)
    {
        return await EntityToDto(_repository.Update(DtoToEntity(receive, id)));
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }

    public async Task<UserDtoSend> GetById(int id)
    {
        return await EntityToDto(_repository.GetById(id));
    }

    public async Task<List<UserDtoSend>> GetAll()
    {
        List<User> users = _repository.GetAll();
        List<UserDtoSend> usersDtoSend = new List<UserDtoSend>();
        foreach (var user in users)
        {
            usersDtoSend.Add(await EntityToDto(user));
        }

        return usersDtoSend;
    }

    private User DtoToEntity(UserDtoReceive receive, int? id)
    {
        User user = new User()
        {
            Name = receive.Name,
            Email = receive.Email,
        };

        if (id != null)
        {
            user.Id = (int)id;
        }


        return user;
    }
    private async Task<UserDtoSend> EntityToDto(User user)
    {
        UserDtoSend userDtoSend = new UserDtoSend()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };

        return userDtoSend;

    }
}