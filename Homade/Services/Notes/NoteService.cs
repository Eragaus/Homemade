using Homade.Models.Notes;

namespace Homade.Services.Notes;

public class NoteService : AbstractRestService<Note>
{
    private static NoteService? _instance;
    
    public static NoteService Instance => _instance ??= new NoteService();
    
    private NoteService()
    {
    }
    
    
}