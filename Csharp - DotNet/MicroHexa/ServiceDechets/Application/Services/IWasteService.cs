using ServiceDechets.Application.DTOs;

namespace ServiceDechets.Application.Services
{
    public interface IWasteService
    {
        List<WasteDtoSend> GetAll();
        WasteDtoSend GetById(int id);
        WasteDtoSend Create(WasteDtoReceive dto);
        WasteDtoSend Update(int id, WasteDtoReceive dto);
    }
}
